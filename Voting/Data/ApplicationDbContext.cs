using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Voting.Models;

namespace Voting.Data
{
    public class ApplicationDbContext : IdentityDbContext<applicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Vote>().ToTable("vote");
        }

        public DbSet<Voting.Models.Vote> Vote { get; set; }

        public DbSet<Voting.Models.Party> Party { get; set; }

        public DbSet<Voting.Models.Comment> Comment { get; set; }

        public DbSet<Voting.Models.Election> Election { get; set; }
    }
}
