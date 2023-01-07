using UpSchool_Chain_Of_Responsibility.DAL.Context;
using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.ChainOfResponsibility
{
	public class Manager_Helper:Employee
	{

		public override void ProcessRequest(WithdrawVierModel reg)
		{
			if (reg.Amount <= 70000)
			{
				using (var context = new BankContext())
				{
					


					BankProcess bank = new BankProcess();
					bank.EmployeeName = "Şube Müdür Yardımcısı-hilal Sarı";
					bank.Description = "Talep edilen tutarın ödemesi şubbe müdürü yardımcısı gerçekleitirildi";
					bank.Amount = reg.Amount;
					bank.CustomerName = reg.CustomerName;
					context.BankProcesses.Add(bank);
					context.SaveChanges();
				}
				
			}
			else if (NextApprover != null)
			{
				using (var context = new BankContext())
				{
					BankProcess bank = new BankProcess();

					bank.EmployeeName = "Şube Müdür Yardımcısı-Ayşenur Yılduz";
					bank.Description = "yetkim dışı şube müdürüne yönlendirildi";
					bank.Amount = reg.Amount;
					bank.CustomerName = reg.CustomerName;

					context.BankProcesses.Add(bank);
					context.SaveChanges();
					NextApprover.ProcessRequest(reg);

				}

				
			}
		}
	}
}
