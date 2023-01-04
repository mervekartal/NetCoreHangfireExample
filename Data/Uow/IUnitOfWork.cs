using Data.BookRepo;
using Data.ContainerRepo;
using Data.VehicleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Uow
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        IContainerRepository Container { get; }
        IBookRepository Book { get; }


        int Complete();
    }
}
