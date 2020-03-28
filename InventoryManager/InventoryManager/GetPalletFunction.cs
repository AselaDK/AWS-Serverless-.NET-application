using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using InventoryManager.Database;
using InventoryManager.BLL.Services;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace InventoryManager
{
    public class GetPalletFunction
    {
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request)
        {
            if (request.PathParameters != null && request.PathParameters.ContainsKey("palletId") &&
                int.TryParse(request.PathParameters["palletId"], out var palletId))
            {
                // get Pallet through service
                var inventoryManagerContext = new InventoryManagerContext();
                var palletService = new PalletService(inventoryManagerContext);
                var getPalletResponce = palletService.GetPallet(palletId);

                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonConvert.SerializeObject(getPalletResponce)
                };
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
    }
}
