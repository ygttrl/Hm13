using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstruct;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name ="Image")] FormFile file ,[FromForm(Name =("Id"))] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id) 
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() 
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesById(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

    }
}
