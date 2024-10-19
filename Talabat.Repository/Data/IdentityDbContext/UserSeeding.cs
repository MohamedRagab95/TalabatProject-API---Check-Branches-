using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.IdentityEntities;

namespace Talabat.Repository.Data.IdentityDbContext
{
    public class UserSeeding
    {

        public static async Task UserSeedAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
              
                await _userManager.CreateAsync(new AppUser()
                {
                    DisplayedName="Mohamed Ragab",
                    Email="Mohamed@gmail.com",
                    UserName="moragab787",
                    PhoneNumber="0111111555"
                });
            }



        }


    }
}
