using Microsoft.EntityFrameworkCore;

namespace lesson15_11._02._21
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) :
            base(options) { }
        public TestContext() { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NushkoPC\\SQLEXPRESS; Database=TestDB; Trusted_Connection=True;");
        }
    }
}
