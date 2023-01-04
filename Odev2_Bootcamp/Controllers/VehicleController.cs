using AutoMapper;
using Data;
using Data.DataModel;
using Data.Uow;
using Entity.Entities;
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
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger<VehicleController> _logger;

        private readonly IMapper mapper;

        public VehicleController(ILogger<VehicleController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            //use mapping

            var listofvehicles = unitOfWork.Vehicle.GetAll().ToList();
            var vehicleList = mapper.Map<List<VehicleEntity>>(listofvehicles);
            //var vehicles = mapper.Map<List<Vehicle>>(vehicleList);

            return Ok(vehicleList);

            
        }


        [HttpGet("GetById")]
        public  IActionResult GetById([FromQuery] int id)
        {
            var vehicle = unitOfWork.Vehicle.GetById(id);

            if (vehicle is null)
            {
                return NotFound();
            }

            //use mapper
            var entity = mapper.Map<VehicleEntity>(vehicle);

            return Ok(entity);
        }


        [HttpPost]
        public IActionResult Create([FromBody] VehicleEntity entity)
        {
            var vehicle = mapper.Map<Vehicle>(entity);

            unitOfWork.Vehicle.Add(vehicle);
            unitOfWork.Complete();

            var vehicles = unitOfWork.Vehicle.GetAll().ToList();

            var vehicleList = mapper.Map<List<VehicleEntity>>(vehicles); //use mapper

            return Ok(vehicleList);
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody] VehicleEntity vehicle, int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var vehicleNew = mapper.Map<Vehicle>(vehicle);

            unitOfWork.Vehicle.Update(vehicleNew);
            unitOfWork.Complete();

            var model = mapper.Map<VehicleEntity>(vehicleNew);

            return Ok(model);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            unitOfWork.Vehicle.Delete(id);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
