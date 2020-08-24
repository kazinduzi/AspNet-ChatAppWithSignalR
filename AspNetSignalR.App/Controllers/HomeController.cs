using AspNetSignalR.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetSignalR.App.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[Authorize]
		public ActionResult Chat()
		{
			var vm = new ChatViewModel
			{
				UserName = User.Identity.Name,
				ChatRoom = $"Chat-room-{DateTime.Today}"
			};

			return View(vm);

		}
	}

}