using UpSchool_Chain_Of_Responsibility.DAL.Context;
using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.ChainOfResponsibility
{
	public class Manager : Employee
	{
		public override void ProcessRequest(WithdrawVierModel reg)
		{
			if (reg.Amount <= 150000)
			{
				using (var context = new BankContext())
				{
					BankProcess bank = new BankProcess();
					bank.EmployeeName = "Şubne Müdürü-Hakan Kayalı";
					bank.Description = "Talep edilen tutarın ödemesi Şube Müdürü tarafından gerçekleitirldi";
					bank.Amount = reg.Amount;
					bank.CustomerName = reg.CustomerName;
					context.BankProcesses.Add(bank);
					context.SaveChanges();
				
				}
				//Console.WriteLine("{0} tarafından para çekme i��lemi onaylandı #{1}",
				//	this.GetType().Name, p.Amount);
			}
			else if (NextApprover != null)
			{

				using (var context = new BankContext())
				{

					BankProcess bank = new BankProcess();

					bank.EmployeeName = "Şube Müdürü-Hakan Kayalı";
					bank.Description = "yetkim dışı bölge müdürüne yönlendirildi";
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
