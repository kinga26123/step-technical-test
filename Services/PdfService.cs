using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InvoiceGenerator.Services;

public static class PdfService
{

    public static void GeneratePdf(Invoice invoice)
    {
        double? total_gross;
        double? total_net;
        total_gross = invoice.Items.Select(x => x.Gross_Price).Sum();
        total_net = invoice.Items.Select(x => x.Net_Price).Sum();

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);

                page.Header().Text("Step Communications").FontSize(30);

                page.Content()
                .PaddingVertical(1, Unit.Centimetre)
                .Column(column => 
                {
                    column.Spacing(10);
                    column.Item().Row(row => 
                    {
                        row.RelativeItem().Column(innerColumn => 
                        {
                            innerColumn.Item().Text("BILLED TO:").SemiBold();
                            innerColumn.Item().Text(invoice.Invoice_Contact_Name);
                            innerColumn.Item().Text(invoice.Invoice_Advertiser);
                            innerColumn.Item().Text(invoice.Invoice_Company_Name);
                            innerColumn.Item().Text(text => 
                            {
                                text.Span(invoice.Invoice_Address1);
                                if (invoice.Invoice_Address2 != null && invoice.Invoice_Address2.Any())
                                    text.Span(", " + invoice.Invoice_Address2);
                                if (invoice.Invoice_Address3 != null && invoice.Invoice_Address3.Any())
                                    text.Span(", " + invoice.Invoice_Address3);
                                if (invoice.Invoice_State_County != null && invoice.Invoice_State_County.Any())
                                    text.Span(", " + invoice.Invoice_State_County);
                                text.Span(", " + invoice.Invoice_Post_Code);
                            });
                            innerColumn.Item().Text(invoice.Invoice_Country_Name);
                            innerColumn.Item().Text(invoice.Invoice_Contact_Email_Address);
                        });

                        row.RelativeItem().Column(innerColumn =>
                        {
                            innerColumn.Item().AlignRight().Text("Invoice No. " + invoice.Id);
                            innerColumn.Item().AlignRight().Text(invoice.Order_Confirmed_Date.ToShortTimeString());
                            innerColumn.Item().AlignRight().Text(invoice.Order_Confirmed_Date.ToLongDateString());
                            innerColumn.Item().AlignRight().Text(invoice.Special_Instructions);
                        });
                    });

                    column.Item().Table(table => 
                    {
                        table.ColumnsDefinition(columns => 
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        
                        table.Cell().Padding(1,Unit.Millimetre).Text("Order Item Id");
                        table.Cell().Padding(1,Unit.Millimetre).Text("Product Name");
                        table.Cell().Padding(1,Unit.Millimetre).Text("Purchase Order");
                        table.Cell().Padding(1,Unit.Millimetre).Text("Item");
                        table.Cell().Padding(1,Unit.Millimetre).Text("Month");
                        table.Cell().Padding(1,Unit.Millimetre).Text("Year");
                        table.Cell().Padding(1,Unit.Millimetre).Text($"Gross Price ({invoice.Currency_Name})");
                        table.Cell().Padding(1,Unit.Millimetre).Text($"Net Price ({invoice.Currency_Name})");
                        table.Cell().ColumnSpan(8).Background(Colors.BlueGrey.Medium).Height(1);

                        foreach (var item in invoice.Items)
                        {
                            table.Cell().Text(item.Id.ToString());
                            table.Cell().Text(item.Product_Name);
                            table.Cell().Text(item.Purchase_Order);
                            table.Cell().Text(item.Item);
                            table.Cell().Text(item.Month_Name);
                            table.Cell().Text(item.Year.ToString());
                            table.Cell().Text(item.Gross_Price.ToString());
                            table.Cell().Text(item.Net_Price.ToString());
                            table.Cell().ColumnSpan(8).Background(Colors.BlueGrey.Medium).Height(1);
                        }
                        table.Cell().ColumnSpan(5);
                        table.Cell().Text("Total:").SemiBold();
                        table.Cell().Text(total_gross.ToString());
                        table.Cell().Text(total_net.ToString());
                    });
                    
                });
                page.Footer().Text(invoice.Sales_Person);
            });
        })
        .GeneratePdf("./PdfLibrary/CreatedPdf.pdf");
    }
}