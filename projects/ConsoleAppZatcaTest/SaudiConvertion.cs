using System.Text;

public class SaudiConvertion
{

    public string getTest()
    {
        // var sellername = "Salah Hospital";
        var sellername = " الجواهري العربي";
        var vatregistration = "310122393500003";
        var timestamp = "2021-12-10 01:26:44";
        var invoiceamount = "200.00";
        var vatamoun = "125.00";

        return getBase64(sellername, vatregistration, timestamp, invoiceamount, vatamoun);
    }

    public string getBase64(string sellername, string vatregistration, string timestamp, string invoiceamount,
        string vatamoun)
    {
        string ltr = ((char)0x200E).ToString();
        var seller = getTlvVAlue("1", sellername);
        var vatno = getTlvVAlue("2", vatregistration);
        var time = getTlvVAlue("3", timestamp);
        var invamt = getTlvVAlue("4", invoiceamount);
        var vatamt = getTlvVAlue("5", vatamoun);
        var result = seller.Concat(vatno).Concat(time).Concat(invamt).Concat(vatamt).ToArray();
        Console.WriteLine(result);
        ;
        Console.WriteLine(result.ToString());
        ;
        var output = Convert.ToBase64String(result);
        Console.WriteLine(output);
        return output;
    }



    public byte[] getTlvVAlue(string tagnums, string tagvalue)
    {
        string[] tagnums_array = { tagnums };
        var tagvalue1 = tagvalue;

        var tagnum = tagnums_array.Select(s => Byte.Parse(s)).ToArray();



        var tagvalueb = Encoding.UTF8.GetBytes(tagvalue1);
        string[] taglengths = { tagvalueb.Length.ToString() };
        var tagvaluelengths = taglengths.Select(s => Byte.Parse(s)).ToArray();
        var tlvVAlue = tagnum.Concat(tagvaluelengths).Concat(tagvalueb).ToArray();


        return tlvVAlue;
    }
}