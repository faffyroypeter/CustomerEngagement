namespace CE.CheckBalance
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using CE.DataAccess;
    using System.Data;

    public static class Function1
    {
        [FunctionName("FetchCustomers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)

        {

            clsSqlServerDBContext objReftoDAL = new clsSqlServerDBContext();

            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var result= objReftoDAL.FetchCustomers();


            //var customerNames = string.Empty;

            // Iterate the values in a collction
            foreach(DataRow row in result.Rows) 
            {

                if (row["FirstName"].ToString().Equals(name))
                {
                    return new OkObjectResult("I have found a customer named: " + row["FirstName"].ToString());
                }

                // obtain the currentrow
               // customerNames += row["FirstName"];
            }

           

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
              //  : $"Hello, {name}. This HTTP triggered function executed successfully.";

            string customerNotFound = "I am Sorry I could not find a customer by the given Name :" + name;

            return new OkObjectResult(customerNotFound);
        }
    }
}
