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
using Microsoft.EntityFrameworkCore;
using ZR.Demo.Domains;
using ZR.Demo.Repositories;
using ZR.Demo.Services.Interfaces;

namespace ZR.Demo.Services
{
    public class EmployeeService:IEmployeeService
    {
        private IRepositoryWrapper _repository;
        public EmployeeService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public  IQueryable<Employee>  GetAll(string searchFilter)
        {
            var  data = new List<Employee>();
            switch (searchFilter.ToLower())
            {
                case "firstname":
                    data = _repository.Employee.FindAll().OrderByDescending(x => x.FirstName).ToList();
                    break;
                case "lastname" :
                    data = _repository.Employee.FindAll().OrderByDescending(x => x.LastName).ToList();
                     break;
                case "gender male":
                    data = _repository.Employee.FindAll().OrderByDescending(x => x.Gender).Where(x => x.Gender == Domains.Enums.GenderType.Male).ToList();
                    break;
               case "gender female":
                    data = _repository.Employee.FindAll().OrderByDescending(x => x.Gender).Where(x => x.Gender == Domains.Enums.GenderType.Female).ToList();
                    break;
                default: data=_repository.Employee.FindAll().OrderByDescending(x => x.Id).ToList()  ;
                    break;
            }
            return data.AsQueryable();
            
        }

        public Employee Save(Employee model)
        {
            var data =  GetAll("FirstName").ToList();
            if(data.Any(x=>x.Id==model.Id))
            {
                 _repository.Employee.Update(model);
                _repository.Save();

            }
            else
            {
                _repository.Employee.Create(model);
                _repository.Save();

            }

            return model;
        }
    }
}