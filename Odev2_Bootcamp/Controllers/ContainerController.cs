using AutoMapper;
using Data.DataModel;
using Data.Uow;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2_Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger<ContainerController> _logger;

        private readonly IMapper mapper;


        public ContainerController(ILogger<ContainerController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
         //use mapping
            var listofcontainers = unitOfWork.Container.GetAll().ToList();
            var containerList = mapper.Map<List<ContainerEntity>>(listofcontainers);
          //  var containers = mapper.Map<List<Container>>(containerList);

            return Ok(containerList);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var container = unitOfWork.Container.GetById(id);

            if (container is null)
            {
                return NotFound();
            }

            //use mapper
            var entity = mapper.Map<ContainerEntity>(container);  

            return Ok(entity);
        }


        [HttpPost]
        public IActionResult Create([FromBody] ContainerEntity entity)
        {
            
            var container = mapper.Map<Container>(entity);

            unitOfWork.Container.Add(container);
            unitOfWork.Complete();

            var containers = unitOfWork.Container.GetAll().ToList();

            var containerList = mapper.Map<List<ContainerEntity>>(containers); //use mapper

            return Ok(containerList);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ContainerEntity container, int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

           // var data = unitOfWork.Container.GetById(id);

            var containerNew = mapper.Map<Container>(container);


            unitOfWork.Container.Update(containerNew);
            unitOfWork.Complete();

            var model = mapper.Map<ContainerEntity>(containerNew);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            unitOfWork.Container.Delete(id);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("GetContainersByVehicleId")]
        public IActionResult GetContainersByVehicleId([FromQuery] int id)
        {
            //List containers by VehicleId

            if (id == 0)
            {
                return BadRequest();
            }

            var containers = unitOfWork.Container.GetAll(x => x.VehicleID == id);
            if (containers is null)
            {
                return NotFound();
            }

            var containerList = mapper.Map<List<ContainerEntity>>(containers); //use mapper
            return Ok(containerList);
        }
    }
}

