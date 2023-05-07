
using BlazorAppSales.Data;
using ClassLibraryModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MyApp.Services;
using System.Linq;

namespace BlazorAppSales.Pages.General
{
    public partial class POS : ComponentBase
    {


        private bool ShiftIsOpen { get { return !ShiftClosed; } set { ShiftClosed = !value; } } //= false;

        private string searchQuery_item = string.Empty;
        Order CurrentOrder = new Order();
        bool ShowReceipt = true;
        private List<Product>? ProductsAll { get; set; }
        private List<Product>? Products { get; set; }
        private List<Order>? Orders { get; set; }
        private List<CartItem>? Cart { get; set; }
        private List<Customer>? customers { get; set; } = new List<Customer>();

        List<string> productTags = new List<string>();

        private decimal Total { get; set; }
        private bool ShiftClosed { get; set; } = true;
        private decimal ShiftTotalSales { get; set; }
        private int ShiftTotalOrders { get; set; }
        private decimal ShiftAverageSale { get; set; }
        DbContextMainData DbContext = new DbContextMainData();
        DbContextMainData db = new DbContextMainData();



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


        ApplicationDbContext applicationDbContext = new();

        /// <summary>
        /// temppppp
        /// </summary>
        /// <param name="product"></param>
       /* */ WebApp1User currentUser;
        string currentUserEmail="";
        bool isAdmin = false;
        private async Task ReadCurrent()
        {
            currentUser = await Util .ClassCurrentSessionUtil.GetUser(authenticationStateProvider, applicationDbContext);
            currentUserEmail = currentUser.Email;//  await ClassCurrentSessionUtil.GetUserEmail(authenticationStateProvider);
            currentCompanyName = currentUser.CompanyName; 
            //isAdmin = await Util.ClassCurrentSessionUtil.CheckIfUserHasRole(authenticationStateProvider, applicationDbContext, "Admin");
        }

        private ProductService productService;
  

        protected override async Task OnInitializedAsync()
        {
            ProductsAll = DbContext.Pos_Products.ToList();
            Products = DbContext.Pos_Products.Include(p=>p.ProductTags).ToList();
            Orders = DbContext.Pos_Orders.ToList();
            customers = DbContext.Pos_Customers.ToList();
            Cart = new List<CartItem>();


            productService = new ProductService();

           // productTags = await productService.GetProductsTagsAsync();
           // productTags = await productService.GetProductsTagsLinkedWithProductsAsync();
           var productTags_objects = await productService.GetProductTagsWithProducts();
            productTags = productTags_objects.Select(t => t.Name).ToList();
            await ReadCurrent();
        }
        private void AddToCart(Product product)
        {
            var cartItem = Cart.FirstOrDefault(item => item.Product.Id == product.Id);
            if (cartItem == null)
            {
                cartItem = new CartItem { Product = product, Quantity = 1  , Price= product.Price};
                Cart.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            cartItem.Total = cartItem.Price * cartItem.Quantity;

            Total += product.Price;
        }
        private void Search()
        {
            // if (!string.IsNullOrEmpty(searchQuery))
            {
                // Filter items based on search query
                Products = ProductsAll.Where(i => i.Name.Contains(searchQuery_item, StringComparison.OrdinalIgnoreCase) || i.Number.Contains(searchQuery_item, StringComparison.OrdinalIgnoreCase)).ToList();
            }
           if (selectedTagFilter != "")
                // Assuming you have a list of products named 'products' and a string variable named 'tagName' for the tag you want to filter by
                Products = Products.Where(p => p.ProductTags.Any(t => t.Name.Contains(selectedTagFilter))).ToList();

        }
        private void ClearSearch()
        {
            searchQuery_item = string.Empty;
            Search(); // Reload all items
        }
        private async Task OpenShift()
        {
            // Check if there is an open shift already
            var openShift = await db.Pos_Shifts.FirstOrDefaultAsync(s => s.IsOpen);

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

        private async Task PlaceOrder(OrderPage orderPage1)
        {
            if (ShiftClosed)
                return;
            if (selectedCustomer == null)
                return;


            var order = new Order { };// Items = Cart



            //var company = await DbContext.Companies.FindAsync(currentCompanyId);
            var company = await DbContext.Pos_Companies.Where(c => c.Name == currentCompanyName)
                .FirstOrDefaultAsync();
            if(company==null )
                company = await DbContext.Pos_Companies.FindAsync(defaultCompanyId);

            // Get the last invoice number used for the company and increment it
            var companyInvoiceNumber = await DbContext.CompanyInvoiceNumbers
                .Where(c => c.CompanyId == company.Id)
                .FirstOrDefaultAsync();

            if (companyInvoiceNumber == null)
                companyInvoiceNumber.LastInvoiceNumber=1;
            else
                companyInvoiceNumber.LastInvoiceNumber++;

            // Assign the invoice number to the order
            order.InvoiceNumber = companyInvoiceNumber.LastInvoiceNumber;


            order.Items = Cart;
            order.CustomerId = selectedCustomer.Id;
            order.customer_name = selectedCustomer.Name;
            order.CompanyId = currentCompanyId;
            order.company_name = currentCompanyName;
            order.OrderDate = DateTime.UtcNow;

            order.Total = order.Items.Sum(o => (o.Quantity * o.Product.Price));

            Shift currentShift = await DbContext.Pos_Shifts.FirstOrDefaultAsync(s => s.IsOpen);
            order.shift_Id = currentShift.Id;
            order.shift = currentShift;

            DbContext.Pos_Orders.Add(order);
            //AddOrderToShift(order);
            await DbContext.SaveChangesAsync();
            Orders.Add(order);
            Cart = new List<CartItem>();
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
    }

}






















/*
    private async Task SaveNewCustomer()
    {
        // Save the new customer to the database
        DbContext.Customers.Add(newCustomer);
        await DbContext.SaveChangesAsync();

        // Add the new customer to the list of customers
        customers.Add(newCustomer);

        // Reset the new customer form and hide it
        newCustomer = new Customer();
        showNewCustomerForm = false;
    }

    private void CancelNewCustomer()
    {
        // Reset the new customer form and hide it
        newCustomer = new Customer();
        showNewCustomerForm = false;
    } 


 private bool showNewCustomerForm { get; set; }

    private void CreateNewCustomer()
    {
        // Show the new customer form
        showNewCustomerForm = true;
    }

    private void CreateNewCustomerx()
    {
        // Add the new customer to the database
        db.Customers.Add(newCustomer);
        db.SaveChanges();

        // Select the new customer
        selectedCustomer = newCustomer;

        // Hide the new customer form
        showNewCustomerForm = false;

        // Reset the new customer information
        newCustomer = new Customer();
    }
 
   @*         @if (showNewCustomerForm)
                    {
                        <div class="create-customer-form">
                            <h3>Create New Customer</h3>
                            <div class="form-group">
                                <label for="customer-name">Name:</label>
                                <input type="text" class="form-control" id="customer-name" @bind-value="newCustomer.Name" />
                            </div>
                            <div class="form-group">
                                <label for="customer-email">Email:</label>
                                <input type="email" class="form-control" id="customer-email" @bind-value="newCustomer.Email" />
                            </div>
                            <div class="form-group">
                                <label for="customer-phone">Phone:</label>
                                <input type="tel" class="form-control" id="customer-phone" @bind-value="newCustomer.Phone" />
                            </div>
                            <div class="form-group">
                                <button type="button" class="btn btn-primary" @onclick="SaveNewCustomer">Save</button>
                                <button type="button" class="btn btn-secondary" @onclick="CancelNewCustomer">Cancel</button>
                            </div>
                        </div>
                    }*@
 */













//                         <button class="btn btn-primary" @onclick="AddLine">Add Line</button>
//
//private void AddLine()
//{
//    var product = new Product();
//    var cartItem = new CartItem { Product = product, Quantity = 1 };
//    Cart.Add(cartItem);
//}

