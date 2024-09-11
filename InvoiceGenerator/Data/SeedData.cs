namespace InvoiceGenerator.Data;

public static class SeedData
{
    public static void Initialize(InvoiceStoreContext db)
    {
        var invoice = new Invoice
            {
                Id = 62654,
                Sales_Person = "Jed Blackthorn",
                Order_Confirmed_Date = new DateTime(2022,12,16,16,51,00),
                Currency_Name = "GBP",
                Invoice_Advertiser = "Alpha Inc",
                Invoice_Company_Name = "Alpha Inc",
                Invoice_Address1 = "40 Septon Drive",
                Invoice_City = "Portsmouth",
                Invoice_State_County = "Hampshire",
                Invoice_Post_Code = "SO23 4KL",
                Invoice_Country_Name = "United Kingdom",
                Invoice_Contact_Name = "Daenarys Baseley",
                Invoice_Contact_Email_Address = "dbaseley@alphainc.com",
        };

        var items = new List<InvoiceItem> 
                {
                    new InvoiceItem 
                    {
                        Id = 52849,
                        Invoice_Id = invoice.Id,
                        Product_Name = "Clinical Services Journal",
                        Purchase_Order = "PO 566/21",
                        Item = "Quarter Page",
                        Month_Name = "May",
                        Year = 2023,
                        Gross_Price = 375.0,
                        Net_Price = 375.0
                    },
                    new InvoiceItem 
                    {
                        Id = 52850,
                        Invoice_Id = invoice.Id,
                        Product_Name = "Clinical Services Journal",
                        Purchase_Order = "PO 566/21",
                        Item = "Quarter Page",
                        Month_Name = "June",
                        Year = 2023,
                        Gross_Price = 375.0,
                        Net_Price = 375.0
                    }
                };

        db.Invoices.Add(invoice);
        db.InvoiceItems.AddRange(items);
        db.SaveChanges();
    }
}