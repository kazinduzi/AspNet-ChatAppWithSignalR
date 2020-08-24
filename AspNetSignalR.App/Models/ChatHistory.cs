using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetSignalR.App.Models
{
	public class ChatHistory
	{
		public int Id { get; set; }
		public string ConnectionId { get; set; }
		public string  Username { get; set; }
		public string Message { get; set; }
		public string ChatRoom { get; set; }
	}
}