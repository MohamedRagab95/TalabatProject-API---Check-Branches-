using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.IdentityEntities
{
    public class AppUser : IdentityUser
    {

        public string DisplayedName { get; set; }

        public Address  Addresss { get; set; }
    }
}
