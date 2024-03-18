/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 03 
*  Date     :  	11th October 2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*  Version  :   0.0.1
************************************************************************************************************/
using Microsoft.EntityFrameworkCore;
using ZR.Demo.Domains;
using static ZR.Demo.Repositories.EmployeeRepository;

namespace ZR.Demo.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {        
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

       



    }
}