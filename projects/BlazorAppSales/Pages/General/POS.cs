﻿
using BlazorAppSales.Data;
using BlazorAppSales.Pages.Components;
using ClassLibraryModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;


namespace BlazorAppSales.Pages.General
{
    public partial class POS : ComponentBase
    {
        PaymentButtonsComponent PaymentButtonsComponent1;

        private bool ShiftIsOpen { get { return !ShiftClosed; } set { ShiftClosed = !value; } } //= false;

        private string searchQuery_item = string.Empty;
        Order CurrentOrder = new Order();
        bool ShowReceipt = true;
        private List<Product>? ProductsAll { get; set; }
        private List<Product>? Products { get; set; }
        private List<Order>? Orders { get; set; }
        private List<OrderLine>? orderLines { get; set; }
        private List<Customer>? customers { get; set; } = new List<Customer>();
        private List<Pos_MethodOfPayment>? pos_MethodOfPayments { get; set; } = new List<Pos_MethodOfPayment>();
        private List<Pos_OrderPayment>? pos_OrderPayments { get; set; } = new List<Pos_OrderPayment>();

        List<string> productTags = new List<string>();
        private decimal Total { get; set; }
        private bool ShiftClosed { get; set; } = true;
        private decimal ShiftTotalSales { get; set; }
        private int ShiftTotalOrders { get; set; }
        private decimal ShiftAverageSale { get; set; }
        DbContextMainData DbContext = new DbContextMainData();
        DbContextMainData db = new DbContextMainData();
        ApplicationDbContext applicationDbContext = new();
        private Customer selectedCustomer { get; set; }
        /*      private Customer newCustomer { get; set; } = new Customer();*/
        private async Task CreateCustomer(Customer customer)
        {
            customers = DbContext.Pos_Customers.ToList();
            selectedCustomer = customer;
        }

        private async Task CustomerSelected(Customer customer)
        {
            selectedCustomer = customer;
        }


        void calc_total() {
            Total=orderLines.Sum(x => x.Total);
            PaymentButtonsComponent1.order_total = Total;
            PaymentButtonsComponent1.calc();
        }
        /// <summary>
        /// temppppp
        /// </summary>
        /// <param name="product"></param>
        /* */
        WebApp1User currentUser;
        // bool isAdmin = false;
        private async Task ReadCurrent()
        {
            currentUser = await Util.ClassCurrentSessionUtil.GetUser(authenticationStateProvider, applicationDbContext);
            //isAdmin = await Util.ClassCurrentSessionUtil.CheckIfUserHasRole(authenticationStateProvider, applicationDbContext, "Admin");
        
        currentCompanyName = currentUser.CompanyName;
        }

        private ProductService productService;

        private void AddToCart(Product product)
        {
            var cartItem = orderLines.FirstOrDefault(item => item.Product.Id == product.Id);
            if (cartItem == null)
            {
                cartItem = new OrderLine { Product = product, Quantity = 1, Price = product.Price };
                orderLines.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            cartItem.Total = cartItem.Price * cartItem.Quantity;

            //Total += product.Price;
            calc_total();

        }
    
        private async Task OpenShift()
        {
            // Check if there is an open shift already
            var openShift = await db.Pos_Shifts.FirstOrDefaultAsync(s => s.IsOpen 
            &&              s.EmployeeNumber==currentUser.EmployeeNumber
            &&              s.CompanyName==currentUser.CompanyName
            );

            if (openShift != null)
            {
                // If there is an open shift, show an error message
                // or redirect to the POS screen
                ShiftIsOpen = true;
            }
            else
            {
                // Create a new shift object and set its properties
                var newShift = new Shift
                {
                    OpenedAt = DateTime.Now,
                    IsOpen = true,
                    TotalSales = 0,
                    TotalPayments = 0,
                    Orders = new List<Order>(),
                    EmployeeNumber = currentUser.EmployeeNumber,// "12345",
                    Branch = currentUser.branch,// "Main Branch",
                    CompanyName = currentUser.CompanyName //"ACME Inc."

                };

                // Add the new shift to the database and save the changes
                await db.Pos_Shifts.AddAsync(newShift);
                await db.SaveChangesAsync();

                ShiftIsOpen = true;
            }
        }
        public async Task CloseShift()
        {
            // Get the current shift from the database
            var shift = await db.Pos_Shifts
                 .Include(s => s.Orders)
                .FirstOrDefaultAsync(s => s.IsOpen);

            if (shift == null)
            {
                // No open shift found, so do nothing
                return;
            }

            // Calculate the total sales for the shift
            var totalSales = shift.Orders.Sum(o => o.Total);
            shift.TotalSales = totalSales;
            shift.ClosedAt = DateTime.UtcNow;

            // Close the current shift
            shift.IsOpen = false;

            // Add the ShiftSummary to the database
            db.Pos_Shifts.Attach(shift);

            // Save changes to the database
            await db.SaveChangesAsync();

            ShiftClosed = true;
            StateHasChanged();//TEMPPP

        }
        int currentCompanyId = 1;
        int defaultCompanyId = 1;
        string currentCompanyName = "";

        private OrderPage GetOrderPage1()
        {
            return orderPage1;
        }

        private List<Order>? GetOrders()
        {
            return Orders;
        }

        //private readonly ILoyaltyProgramService _loyaltyProgramService;

        private async Task PlaceOrder(OrderPage orderPage1, List<Order>? orders)
        {
            if (ShiftClosed)
                return;
            if (selectedCustomer == null)
                return;


            var order = new Order { };// Items = Cart

            //var company = await DbContext.Companies.FindAsync(currentCompanyId);
            var company = await DbContext.Pos_Companies.Where(c => c.Name == currentCompanyName)
.FirstOrDefaultAsync();
                if (company == null)
            {
                company = new Company { Name =currentCompanyName };

                db.Pos_Companies.Add(company);
                db.SaveChanges();
            }

                
            if (company == null)
                company = await DbContext.Pos_Companies.FindAsync(defaultCompanyId);

            // Get the last invoice number used for the company and increment it
            var companyInvoiceNumber = await DbContext.Pos_CompanyInvoiceNumbers
                .Where(c => c.CompanyId == company.Id)
                .FirstOrDefaultAsync();

            if (companyInvoiceNumber == null)
            {
                companyInvoiceNumber = new CompanyInvoiceNumber { LastInvoiceNumber = 1, CompanyId = company.Id };
                companyInvoiceNumber.LastInvoiceNumber = 1;

            }
            else
                companyInvoiceNumber.LastInvoiceNumber++;

            // Assign the invoice number to the order
            order.InvoiceNumber = companyInvoiceNumber.LastInvoiceNumber;

            order.Pos_OrderPayments = pos_OrderPayments;
            order.OrderLines = orderLines;
            order.CustomerId = selectedCustomer.Id;
            order.customer_name = selectedCustomer.Name;
            order.CompanyId = currentCompanyId;
            order.company_name = currentCompanyName;
            order.OrderDate = DateTime.UtcNow;


            order.userId = currentUser.Id;
            order.EmployeeName = currentUser.Name;
            order.EmployeeNumber = currentUser.EmployeeNumber;

            order.Total = order.OrderLines.Sum(o => (o.Quantity * o.Product.Price));

            Shift currentShift = await DbContext.Pos_Shifts.FirstOrDefaultAsync(s => s.IsOpen);
            order.shift_Id = currentShift.Id;
            order.shift = currentShift;

            LoyaltyProgramService _loyaltyProgramService = new LoyaltyProgramService();
            int loyaltyPointsEarned = _loyaltyProgramService.CalculateLoyaltyPointsEarned(order.Total);
            order.LoyaltyPointsEarned = loyaltyPointsEarned;
            selectedCustomer.LoyaltyPoints += order.LoyaltyPointsEarned;

            ///saveing LoyaltyPoints
            DbContext.Pos_Customers.Where(_ => _.Id == selectedCustomer.Id).FirstOrDefault().LoyaltyPoints = selectedCustomer.LoyaltyPoints; 


            DbContext.Pos_Orders.Add(order);
            //AddOrderToShift(order);
            await DbContext.SaveChangesAsync();
            orders.Add(order);
            orderLines = new List<OrderLine>();
            pos_OrderPayments = new List<Pos_OrderPayment>();

            Total = 0;
            //await jsRuntime.InvokeVoidAsync("printQRCode", order.Id);
            ShiftTotalSales += order.Total;
            ShiftTotalOrders++;
            ShiftAverageSale = ShiftTotalOrders == 0 ? 0 : ShiftTotalSales / ShiftTotalOrders;

            // set the created order to the property
            CurrentOrder = order;
            // show the order receipt
            ShowReceipt = true;
            orderPage1.doRerender(order);

            //if (ShiftTotalOrders >= 10)
            //{
            //    await CloseShift();
            //}
        }

        public OrderPage orderPage1 { get; set; }

        public async Task AddOrderToShift(Order order)
        {
            // Get the current open shift from the database
            var shift = await db.Pos_Shifts
                 .Include(s => s.Orders)
                .FirstOrDefaultAsync(s => s.IsOpen);

            if (shift == null)
            {
                // No open shift found, so create a new one
                shift = new Shift { IsOpen = true, OpenedAt = DateTime.UtcNow };
                db.Pos_Shifts.Add(shift);
            }

            // Link the order to the shift
            shift.Orders.Add(order);

            // Save changes to the database
            //await db.SaveChangesAsync();
        }

        private void Search()
        {
            // if (!string.IsNullOrEmpty(searchQuery))
            //{
            // Filter items based on search query
            Products = ProductsAll.Where(i => 
            
            i.Name.Contains(searchQuery_item, StringComparison.OrdinalIgnoreCase)
            || i.Number.Contains(searchQuery_item, StringComparison.OrdinalIgnoreCase)
            || i.Barcode.Contains(searchQuery_item, StringComparison.OrdinalIgnoreCase)
            
            ).ToList();
            //}
            if (selectedTagFilter != "")
                // Assuming you have a list of products named 'products' and a string variable named 'tagName' for the tag you want to filter by
                Products = Products.Where(p => p.ProductTags.Any(t => t.Name.Contains(selectedTagFilter))).ToList();

            if(Products.Count()==1)
                if (

                    Products[0].Name==searchQuery_item ||
                    Products[0].Number==searchQuery_item ||
                    Products[0].Barcode==searchQuery_item 
                    
                    )
                AddToCart(Products[0]);
               
        }
        protected override async Task OnInitializedAsync()
        {
            await ReadCurrent();
             

            ProductsAll = DbContext.Pos_Products.Where(p => p.CompanyName==currentCompanyName) .Include(p => p.RelatedProducts).Include(p => p.ProductTags).ToList();
            Products = ProductsAll;// DbContext.Pos_Products.Include(p => p.RelatedProducts).Include(p => p.ProductTags).ToList();
            Orders = DbContext.Pos_Orders.ToList();
            customers = DbContext.Pos_Customers.ToList();
            orderLines = new List<OrderLine>();


            productService = new ProductService();

            // productTags = await productService.GetProductsTagsAsync();
            // productTags = await productService.GetProductsTagsLinkedWithProductsAsync();
            var productTags_objects = await productService.GetProductTagsWithProducts();
            productTags = productTags_objects.Select(t => t.Name).ToList();


            if (currentUser != null)
            {
                CustomerService cs = new CustomerService();
                pos_MethodOfPayments = await cs.GetPos_MethodOfPayment_list(currentUser.CompanyName);
            }
        }
        private void ClearSearch()
        {
            searchQuery_item = string.Empty;
            Search(); // Reload all items
        }

        string selectedTagFilter = "";
        private void OnChange_selectedTagFilter(string selected)
        {
            if (selectedTagFilter == selected)
                selectedTagFilter = "";
            else
                selectedTagFilter = selected;
            Search();
        }
    }
}



















 









