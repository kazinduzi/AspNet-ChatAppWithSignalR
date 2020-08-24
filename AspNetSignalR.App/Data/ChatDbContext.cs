using AspNetSignalR.App.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetSignalR.App.Data
{
	
    public class ChatDbContext : IdentityDbContext<ApplicationUser>
    {
        public ChatDbContext() : base("ChatContext", false)
        {
        }

        //Public DBSets
        public DbSet<ChatHistory> ChatHistories { get; set; }
        
        public static ChatDbContext Create()
        {
            return new ChatDbContext();
        }
    }
}