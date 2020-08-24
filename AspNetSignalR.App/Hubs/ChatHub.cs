using AspNetSignalR.App.Data;
using AspNetSignalR.App.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspNetSignalR.App.Hubs
{
	public class ChatHub : Hub
	{
		
		public void SendMessageToRoom(string userName, string chatRoomName, string message)
		{
			using(var context = ChatDbContext.Create())
			{
				var chatHistory = new ChatHistory
				{
					Username = userName,
					Message = message,
					ConnectionId = Context.ConnectionId,
					ChatRoom = chatRoomName
				};
				context.ChatHistories.Add(chatHistory);
				context.SaveChanges();

				Clients.Group(chatRoomName).broadcastMessage(chatHistory.Username, message);
				
			}
			
		}

		public async Task JoinChatRoom(string chatRoomName)
		{
			using(var context = ChatDbContext.Create())
			{
				var room = context.ChatHistories.FirstOrDefault(c => c.ChatRoom == chatRoomName);
				if (room != null)
				{
					await Groups.Add(Context.ConnectionId, chatRoomName);
				}				

				var messages = context.ChatHistories.AsNoTracking().Where(c => c.ChatRoom == chatRoomName).ToList();

				Clients.Group(chatRoomName).broadcastMessages(messages);
			}
			
		}

		public async Task LeaveChatRoom(string chatRoomName)
		{
			using (var context = ChatDbContext.Create())
			{
				var ch = context.ChatHistories.FirstOrDefault(c => c.ConnectionId == Context.ConnectionId && c.ChatRoom == chatRoomName);
				if (ch != null)
				{
					context.ChatHistories.Remove(ch);
					context.SaveChanges();
				}				

				await Groups.Remove(Context.ConnectionId, chatRoomName);
			}				
		}
	}
}