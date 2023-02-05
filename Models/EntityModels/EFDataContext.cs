using Microsoft.EntityFrameworkCore;

namespace HelioGaming.Models.EntityModels
{
	public class EFDataContext: DbContext
	{
		public EFDataContext(DbContextOptions<EFDataContext> options): base(options) { }

		public DbSet<Person> Persons { get; set; }

		public DbSet<Company> Companies { get; set; }

		public DbSet<Address> Addresses { get; set; }
	}
}
