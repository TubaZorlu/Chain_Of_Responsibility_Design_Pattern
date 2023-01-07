using Microsoft.AspNetCore.Mvc;
using UpSchool_Chain_Of_Responsibility.ChainOfResponsibility;
using UpSchool_Chain_Of_Responsibility.DAL.Entities;

namespace UpSchool_Chain_Of_Responsibility.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(WithdrawVierModel p)
		{	//her hangi bir adım çıkarsa yönledirmeyi bir üst seviyeden devam edilerek yapılır
			
			Employee veznedar = new Treasurer();
			Employee mudurYar = new Manager_Helper();
			Employee mudur = new Manager();
			Employee bolgeMudur = new ReginalManager();

			veznedar.SetNextApprover(mudurYar);
			mudurYar.SetNextApprover(mudur);
			mudur.SetNextApprover(bolgeMudur);

			veznedar.ProcessRequest(p);
			return View();
		}
	}
}
