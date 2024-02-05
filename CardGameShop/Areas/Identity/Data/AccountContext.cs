﻿using Microsoft.AspNetCore.Identity; // Import statements for namespaces
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardGameShop.Data // Namespace declaration
{
    // DbContext class representing the database context for user accounts
    public class AccountContext : IdentityDbContext<IdentityUser>
    {
        // Constructor to initialize the AccountContext with DbContextOptions
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        // Method to customize the ASP.NET Identity model
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Call the base method implementation

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
