using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetSignalR.App.ViewModels
{
	public class ChatViewModel
	{
		public string UserName { get; set; }
		public string GroupId { get; set; }
		public string ChatRoom { get; set; }
		public string Message { get; set; }
	}
}