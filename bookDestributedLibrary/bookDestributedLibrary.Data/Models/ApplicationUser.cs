//Create ApplicationUser class with IdentityUser as base class with Login, Email and Password
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bookDestributedLibrary.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
    }
}