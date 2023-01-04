using AutoMapper;
using BackgroundJobsHangfire.Jobs;
using Data.DataModel;
using Data.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundJobsHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger<Book> _logger;

        private readonly IMapper mapper;


        public HangfireController(ILogger<Book> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        //Controller seviyesinde joblar tetiklenir.

        //update için
        [HttpGet]
        public IActionResult Get()
        {

            RecurringJobs recurringJob = new(unitOfWork);
            return Ok(unitOfWork.Book.GetAll());
        }

        //insert için
        //[HttpGet]
        //public IActionResult GetBooks()
        //{

        //    RecurringJobs recurringJob = new(unitOfWork);
        //    return Ok(unitOfWork.Book.GetAll());
        //}

    }
}
