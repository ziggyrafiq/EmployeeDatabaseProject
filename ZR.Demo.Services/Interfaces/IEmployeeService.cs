using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.Demo.Domains;

namespace ZR.Demo.Services.Interfaces
{
    public interface IEmployeeService
    {
        IQueryable<Employee>  GetAll(string searchFilter);
        Employee Save(Employee model);
        
    }
}
