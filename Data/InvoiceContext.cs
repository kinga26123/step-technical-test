using Microsoft.EntityFrameworkCore;

namespace InvoiceGenerator.Data;

public class InvoiceStoreContext : DbContext
{
    public InvoiceStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
}  