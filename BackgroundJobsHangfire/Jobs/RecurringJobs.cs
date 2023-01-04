using Data.DataModel;
using Data.Uow;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundJobsHangfire.Jobs
{
    public class RecurringJobs
    {
        private readonly IUnitOfWork unitOfWork;

        public RecurringJobs(IUnitOfWork unitOfWork)
        {
           
            this.unitOfWork = unitOfWork;

            RecurringJob.AddOrUpdate(() => UpdateStatus(), "0 18 * * *"); //her gün saat 18.00'da update
            RecurringJob.AddOrUpdate(() => InsertData(), "*/15 * * * *"); //her 15 dk'da insert
        }

        //status field update
        public void UpdateStatus()
        {
            var bookList = unitOfWork.Book.GetAll();
            foreach (var item in bookList)
            {
                if (item.Status == 1)
                {
                    item.Status = 0;
                }
                else
                {
                    item.Status = 1;
                }
                unitOfWork.Book.Update(item);
            }
        }

        //insert data for Book table
        public void InsertData()
        {
            Book book = new Book
            {
                Name = "Vadideki Zambak",
                NumberOfPage = 200,
                Status = 1
            };
            unitOfWork.Book.Add(book);
            
        }

    }
}
