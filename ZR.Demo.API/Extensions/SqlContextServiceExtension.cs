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
using ZR.Demo.Repositories;

namespace ZR.Demo.API.Extensions
{
    public static class SqlContextServiceExtension
    {
        public static void ConfigureSqlDbEntitiesContext(this IServiceCollection services, IConfiguration configuration)
        {
           configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            services.AddDbContext<RepositoryContext>(
               options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("DevDbConnection")));
        }

    }
}
