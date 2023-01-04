using Data.BookRepo;
using Data.ContainerRepo;
using Data.Context;
using Data.VehicleRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration1;
        private readonly ProjectContext context;

        public IVehicleRepository Vehicle { get; private set; }

        public IContainerRepository Container { get; private set; }
        public IBookRepository Book { get; private set; }
  

        public UnitOfWork(ProjectContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("");


            Vehicle = new VehicleRepository(context, logger);
            Container = new ContainerRepository(context, logger);
            Book = new BookRepository(context, logger);

        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}