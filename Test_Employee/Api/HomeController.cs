using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_Employee.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_Employee.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<object> Get()
        {
            using (var AppContext= new TestEmployeeContext())
            {
                return AppContext.Employee.ToList();
            }
        }

      

        // POST api/values
        [HttpPost]
        public bool Save([FromBody]Employee value)
        {
            using (var AppContext = new TestEmployeeContext())
            {

                AppContext.Employee.Add(value);
                AppContext.SaveChanges();
                return true;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}", Name = "EditEmp")]
        public bool Put([FromBody]Employee value)
        {
            using (var AppContext = new TestEmployeeContext())
            {
                Employee save = AppContext.Employee.FirstOrDefault(obj => obj.Id == value.Id);
                save.FirstName = value.FirstName;
                save.LastName = value.LastName;
                save.Email = value.Email;
                AppContext.Employee.Update(save);
                AppContext.SaveChanges();
                return true;
            }
        }

        // DELETE api/values/5
       [HttpPost("{id}",Name ="DeleteEmp")]
        //[HttpPost("{id}")]
        public bool Delete([FromBody] Employee data)
        {
            using (var AppContext = new TestEmployeeContext())
            {
                Employee save = AppContext.Employee.FirstOrDefault(obj => obj.Id == data.Id);
                AppContext.Employee.Remove(save);
                AppContext.SaveChanges();
                return true;
            }
        }
    }
}
