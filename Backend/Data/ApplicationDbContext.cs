using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }
    }
}
