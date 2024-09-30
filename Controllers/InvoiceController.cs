using Microsoft.AspNetCore.Mvc;
using InvoiceGenerator.Data;
using InvoiceGenerator.Services;

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
        var invoice = await InvoiceService.GetInvoiceAsync(_db);
        return invoice;
    }
}