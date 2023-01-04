using Data.Context;
using Data.DataModel;
using Data.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BookRepo
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ProjectContext context, ILogger logger) : base(context, logger)
        {

        }
    }
}
