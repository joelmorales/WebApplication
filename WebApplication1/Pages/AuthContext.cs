using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication1.Pages
{
    internal class AuthContext: DbContext
    {
        public DbSet<User> Users { get; internal set; }
    }
}