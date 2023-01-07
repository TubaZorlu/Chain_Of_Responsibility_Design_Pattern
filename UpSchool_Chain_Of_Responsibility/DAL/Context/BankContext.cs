using Microsoft.EntityFrameworkCore;
using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.DAL.Context
{
	public class BankContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-CJELTSN\\MSSQLSERVER2019; Database=DbChainOfResponse;integrated security=True;");
		}
		public DbSet<BankProcess> BankProcesses { get; set; }
	}
}
