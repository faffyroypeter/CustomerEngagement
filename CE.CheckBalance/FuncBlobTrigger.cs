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
        public void Run([BlobTrigger("customer-pictures/{name}", Connection = "DefaultEndpointsProtocol=https;AccountName=stroageaccountnafinterns;AccountKey=5K3zoBHF2ySHBW+sF1HBei/zBxriV2Q8vlrErLjDOXlRVfdY9vjXKKQLPSQ4Ix82HLqzzMQ8fnE4+AStqDJDSA==;EndpointSuffix=core.windows.net")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
