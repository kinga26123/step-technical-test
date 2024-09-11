namespace InvoiceGenerator
{
    public class InvoiceItem
    {
        public int Id { get; set; }

        public int Invoice_Id { get; set; }

        public string Product_Name { get; set; }

        public string Purchase_Order { get; set; }

        public string Item { get; set; }

        public string Month_Name { get; set; }

        public int Year { get; set; }

        public double? Gross_Price { get; set; }

        public double? Net_Price { get; set; }
    }
}
