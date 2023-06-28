namespace CE.CheckBalance
{
    using System;
    using System.IO;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;

    using Microsoft.Extensions.Logging;
    public class FuncBlobTrigger
    {
        [FunctionName("FuncBlobTrigger")]
        public void Run([BlobTrigger("customer-pictures/{name}", Connection = "")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
