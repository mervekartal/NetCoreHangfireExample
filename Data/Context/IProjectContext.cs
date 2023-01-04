using Data.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
   public interface IProjectContext
    {
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<Container> Container { get; set; }

        DbSet<Book> Book { get; set; }

        int SaveChanges();
    }
}
