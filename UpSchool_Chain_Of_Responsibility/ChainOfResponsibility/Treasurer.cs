using System;
using UpSchool_Chain_Of_Responsibility.DAL.Context;
using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.ChainOfResponsibility
{
	public class Treasurer : Employee
	{
		public override void ProcessRequest(WithdrawVierModel reg)
		{
			if (reg.Amount <= 40000)
			{
				using (var context = new BankContext())
				{
					BankProcess bank = new BankProcess();
					bank.EmployeeName = "Veznedar-Ayşenur Yılduz";
					bank.Description = "Talep edilen tutarın ödemesi vezne sorumlusu tarafından gerçekleitirldi";
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

					bank.EmployeeName = "Veznedar-Ayşenur Yılduz";
					bank.Description = "yetkim dışı şunbe müdür yardımcısına yönlendirildi";
					bank.Amount=reg.Amount;
					bank.CustomerName = reg.CustomerName;

					context.BankProcesses.Add(bank);
					context.SaveChanges();
					NextApprover.ProcessRequest(reg);
				}


			}
		}


	}
}
