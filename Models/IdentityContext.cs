using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Models
{
	public class IdentityContext : IdentityDbContext<IdentityUser> 
	{
		public IdentityContext()
		{
		}

        public IdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}

