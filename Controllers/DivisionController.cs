using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        MyContext myContext;

        public DivisionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Index()
        {
            var data = myContext.Divisions.ToList();
            if (data != null)
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = data });
            }
            else
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = "null" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var data = myContext.Divisions.Find(id);

            if (data != null)
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = data });
            }
            else
            {
                return Ok(new { message = "Sukses", statusCode = 200, data = "null" });
            }

        }


        //CREATE
        [HttpPost]
        public IActionResult Post(Division division)
        {

            myContext.Divisions.Add(division);
            if (myContext.SaveChanges() > 0)
            {
                return Ok(new { message = "Sukses tambah data", statusCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Gagal tambah data", statusCode = 200 });
            }



        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Division division)
        {
            var data = myContext.Divisions.Find(id);
            data.Name = division.Name;
            myContext.Divisions.Update(data);

            if (myContext.SaveChanges() > 0)
            {
                return Ok(new { message = "Sukses ubah data", statusCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Gagal ubah data", statusCode = 200 });
            }

        }


        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Divisions.Find(id);
            myContext.Divisions.Remove(data);

            if (myContext.SaveChanges() > 0)
            {
                return Ok(new { message = "Sukses hapus data", statusCode = 200 });
            }
            else
            {
                return BadRequest(new { message = "Gagal hapus data", statusCode = 200 });
            }

        }

    }
}
