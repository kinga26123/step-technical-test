namespace InvoiceGenerator
{
    public class Invoice
    {

        public int Id { get; set; }

        public string Sales_Person { get; set; }

        public DateTime Order_Confirmed_Date { get; set; }

        public string Currency_Name { get; set; }

        public string Special_Instructions { get; set; }

        public string Invoice_Advertiser { get; set; }

        public string Invoice_Company_Name { get; set; }

        public string Invoice_Address1 { get; set; }

        public string Invoice_Address2 { get; set; }

        public string Invoice_Address3 { get; set; }

        public string Invoice_City { get; set; }

        public string Invoice_State_County { get; set; }

        public string Invoice_Post_Code { get; set; }

        public string Invoice_Country_Name { get; set; }

        public string Invoice_Contact_Name { get; set; }

        public string Invoice_Contact_Email_Address { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }
}
