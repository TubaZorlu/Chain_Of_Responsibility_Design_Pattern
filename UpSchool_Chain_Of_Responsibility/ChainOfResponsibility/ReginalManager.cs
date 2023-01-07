using UpSchool_Chain_Of_Responsibility.DAL.Context;
using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.ChainOfResponsibility
{
	public class ReginalManager : Employee
	{
		public override void ProcessRequest(WithdrawVierModel reg)
		{
			if (reg.Amount <= 250000)
			{
				using (var context = new BankContext())
				{
					BankProcess bank = new BankProcess();
					bank.EmployeeName = "Bölge Müdürü-Nazlı Siyah";
					bank.Description = "Talep edilen tutarın ödemesi bölge müdürü sorumlusu tarafından gerçekleitirldi";
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

					bank.EmployeeName = "Bölge Müdürü-Nazlı Siyah";
					bank.Description = "Müşterinin talep ettiği tutar günlük limit dışındadır";
					bank.Amount = reg.Amount;
					bank.CustomerName = reg.CustomerName;

					context.BankProcesses.Add(bank);
					context.SaveChanges();
				

				}


			}
		}
	}
}
