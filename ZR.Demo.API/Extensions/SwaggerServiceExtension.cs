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

using System.Reflection;

namespace ZR.Demo.API.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static void ConfigureSwagger(this IServiceCollection service)
        {



            service.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ZR Demo Project 03",
                    Description = "RESTful api that manages a collection of Employees using .Net 6",
                    Version = "v1"


                });


                string? xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string? xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}
