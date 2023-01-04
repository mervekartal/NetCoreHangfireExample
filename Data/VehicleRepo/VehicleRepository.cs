using Data.ContainerRepo;
using Data.Context;
using Data.DataModel;
using Data.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.VehicleRepo
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {

        private ProjectContext _context;
        private ILogger _logger;
        public VehicleRepository(ProjectContext context, ILogger logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
        public override void Delete(int id)
        {
            //delete method override for VehicleID relationship 

            ContainerRepository containerRepo = new ContainerRepository(_context, _logger);
            var containers = containerRepo.GetAll(x => x.VehicleID == id);

            foreach (var item in containers)
            {
                containerRepo.Delete(item.Id);
            }

            base.Delete(id);
        }

    }
}
