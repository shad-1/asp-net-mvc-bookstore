using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace bookstore.Models
{
	public class IdentitySeedData
	{
		public IdentitySeedData()
		{
		}

		private const string adminUser = "Admin";
		private const string adminPassword = "413ExtraYeetPeriod(t)!";

		public static async void EnsurePopulated (IApplicationBuilder app)
        {
			UserManager<IdentityUser> userManager = app.ApplicationServices
				.CreateScope().ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();

			IdentityUser user = await userManager.FindByIdAsync(adminUser);

			if (user == null)
            {
				user = new IdentityUser(adminUser);

				user.Email = "shad@shadrach.dev";
				user.PhoneNumber = "567-8309";

				await userManager.CreateAsync(user, adminPassword);
            }
        }
	}
}

