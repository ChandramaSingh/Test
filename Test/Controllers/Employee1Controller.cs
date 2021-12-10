using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee1Controller : ControllerBase
    {
        private readonly FKDBContext _context;

        public Employee1Controller(FKDBContext context)
        {
            _context = context;
        }


        public IEnumerable<EmployeeInfo> GetEmpInfo1()
        {
            var result = (from a in _context.Employees
                          join c in _context.Departments on a.DeptId equals c.DeptId
                          select new EmployeeInfo()
                          {
                              empid = a.EmployeeId,
                              empname = a.EmployeeName,
                              empdept = c.Name

                          }).ToList();

            return result;
        }

        [HttpGet("GetEmpInfo")]
        public IEnumerable<EmployeeInfo> GetEmpInfo()
        {
            var result = (from a in _context.Employees
                          join c in _context.Departments on a.DeptId equals c.DeptId
                          select new EmployeeInfo()
                          {
                                empid = a.EmployeeId,
                                empname = a.EmployeeName,
                                empdept = c.Name

                          }).ToList();

            return result;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
