using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceGenerator.Data;

namespace InvoiceGenerator.Controllers;

[Route("invoice")]
[ApiController]
public class InvoiceController : Controller
{
    private readonly InvoiceStoreContext _db;

    public InvoiceController(InvoiceStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<Invoice>> GetInvoice()
    {
        var invoice = await _db.Invoices.FirstOrDefaultAsync();
        
        if (invoice != null)
        {
            var invoiceItems = await _db.InvoiceItems.Where(x => x.Invoice_Id == invoice.Id).ToListAsync();
            if (invoiceItems.Any(x => x != null))
            {
                invoice.Items = invoiceItems;
            }
        }
        return invoice;
    }
}