using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.ChainOfResponsibility
{
	public abstract class Employee
	{
		protected Employee NextApprover;

		public void SetNextApprover(Employee supervisor)
		{
			this.NextApprover = supervisor;
		}

		public abstract void ProcessRequest(WithdrawVierModel reg);
	}
}
