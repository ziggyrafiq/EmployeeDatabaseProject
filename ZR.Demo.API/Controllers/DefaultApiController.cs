/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 03 
*  Date     :  	12th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*  Version  :   0.0.1
************************************************************************************************************/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
 
using ZR.Demo.API.DataContract;
using ZR.Demo.Domains;
using ZR.Demo.Repositories;
using ZR.Demo.Services;
using ZR.Demo.Services.Interfaces;

namespace ZR.Demo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefaultApiController : ControllerBase
    {
               
        private IEmployeeService _employeeService;
        public DefaultApiController(IEmployeeService employeeService )
        {
            _employeeService = employeeService;
            
        }

        /// <summary>
        /// GetAll the Employees in the Database
        /// </summary>
        /// <returns>A List of Employees</returns>
        [HttpGet("GetAll")]
        [SwaggerOperation("GetAll")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Employee>), description: "Internal Error")]
        public async Task<IActionResult> GetAll()
        {

            var data =  _employeeService.GetAll("firstname");

            if (data == null)
            {
                SeedDatabase();
            }

            return StatusCode(200, data);

        }

        [HttpGet("Get")]
        [SwaggerOperation("Get")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Employee>), description: "Internal Error")]
        public IActionResult Get(Guid id)
        {

            var data =   _employeeService.GetAll("");
            if (data != null)
            {
               
                return StatusCode(200, data);

            }
            else
            {
                return StatusCode(404, $"Employee Id {id} Data {data.ToString()} is not found or empty!");
            }

        }


        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="Id">Guid</param>
        /// <param name="FirstName">string</param>
        /// <param name="LastName">string</param>
        /// <param name="Age">int</param>
        /// <param name="Gender">1 is Male and 2 is Female</param>
        /// <returns>Employee</returns>
        [HttpPost]
        [SwaggerOperation("CreateEmployee")]
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Created")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public  IActionResult CreateEmployee([FromRoute][Required][FromBody] Employee body)
        {
            if(body != null)
            {
                _employeeService.Save(body);
                return StatusCode(200, body);
                
            }
            else
            {
                return StatusCode(404, $"Employee  Data {body.ToString()} is not found or missing!");
            }



        }

        /// <summary>
        /// Update Employee Recoard
        /// </summary>
        /// <param name="Id">Guid</param>
        /// <param name="FirstName">string</param>
        /// <param name="LastName">string</param>
        /// <param name="Age">int</param>
        /// <param name="Gender">1 is Male and 2 is Female</param>
        /// <returns>Employee Data</returns>
        [HttpPut]
        [SwaggerOperation("UpdateEmployee")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        public  IActionResult UpdateEmployee([FromRoute][Required][FromBody] Employee body)
        {
                        
            if (body != null)
            {
                _employeeService.Save(body);
                return StatusCode(200, body);

            }
            else
            {
                return StatusCode(404, $"Employee  Data {body.ToString()} is not found or missing!");
            }



        }

        /// <summary>
        /// Delete Employee by GUID ID
        /// </summary>
        /// <param name="id">GUID</param>
        /// <returns>StatusCode 200 if found and deleted</returns>
        [HttpDelete]
        [SwaggerOperation("DeleteEmployeeById")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Employee>), description: "Success")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse400), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(List<Employee>), description: "Internal Error")]
        public IActionResult  DeleteById([FromRoute][Required] Guid? id)
        {
            Employee data =  _employeeService.GetAll("").SingleOrDefault(x => x.Id == id);
                
            if(data !=null)
            {
                //need to delete here
                return StatusCode(200);
            }
            else
            {
                return StatusCode(404,$"Employee ID {id} is not found");
            }    
            
        }

        private void SeedDatabase()
        {
           _employeeService.Save(
                           new Employee
                            {
                                Id = Guid.NewGuid(),
                                FirstName = "Qudsiyah",
                                LastName = "Siddiqah",
                                Age = 23,
                                Gender = Domains.Enums.GenderType.Female
                            });

             _employeeService.Save(
                 new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dhakwan",
                    LastName = "Abdul-Barr",
                    Age = 25,
                    Gender = Domains.Enums.GenderType.Male
                }
            );
            _employeeService.Save(
              new Employee
              {
                  Id = Guid.NewGuid(),
                  FirstName = "Hilmi",
                  LastName = "Qureshi",
                  Age = 41,
                  Gender = Domains.Enums.GenderType.Male
              }
          );

             _employeeService.Save(
             new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = " Thùy",
                LastName = "Quỳnh",
                Age = 31,
                Gender = Domains.Enums.GenderType.Female
            }
        );

          _employeeService.Save(
          new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Thu",
                LastName = "Hồng",
                Age = 45,
                Gender = Domains.Enums.GenderType.Female
             }
        );
            
        }
    }
}
