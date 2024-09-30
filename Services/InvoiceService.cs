using Microsoft.EntityFrameworkCore;
using InvoiceGenerator.Data;

namespace InvoiceGenerator.Services;

public static class InvoiceService
{

    public static async Task<Invoice> GetInvoiceAsync(InvoiceStoreContext db)
    {
        var invoice = await db.Invoices.FirstOrDefaultAsync();
        
        if (invoice != null)
        {
            var invoiceItems = await db.InvoiceItems.Where(x => x.Invoice_Id == invoice.Id).ToListAsync();
            if (invoiceItems.Any(x => x != null))
            {
                invoice.Items = invoiceItems;
            }
        }
        return invoice;
    }
}