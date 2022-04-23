using Domain.Models;
using Domain.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<CriminalCode> CriminalCode { get; set; }
        public virtual DbSet<Status> Status { get; set; }
    }
}
