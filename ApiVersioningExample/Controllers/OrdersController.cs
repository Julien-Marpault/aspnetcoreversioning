using ApiVersioningExample.Dto;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiVersioningExample.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(1.0)]
[ApiVersion(2.0)]
public class OrdersController : ControllerBase
{
    [HttpGet(""), MapToApiVersion(1.0)]
    public IActionResult GetV1()
    {
        List<OrderDtoV1> orders = new List<OrderDtoV1> {
            new() { Amount = 10M, ClientFirstname = "Bertrand", ClientLastname = "Dupuis", Number = 100000 },
            new() { Amount = 100M, ClientFirstname = "Justine", ClientLastname = "Renard", Number = 100001 },
            new() { Amount = 50M, ClientFirstname = "Alice", ClientLastname = "Wonderland", Number = 100002 }
        };
        return Ok(orders);
    }

    [HttpGet(""), MapToApiVersion(2.0)]
    public IActionResult GetV2()
    {
        List<OrderDtoV2> orders = new List<OrderDtoV2> {
            new() { Amount = 10M, ClientName = "Bertrand Dupuis", Number = 100000 },
            new() { Amount = 100M, ClientName = "Justine Renard", Number = 100001 },
            new() { Amount = 50M, ClientName = "Alice Wonderland", Number = 100002 }
        };
        return Ok(orders);
    }
}

//namespace ApiVersioningExample.Controllers.V1
//{


//    [ApiController]
//    [Produces(MediaTypeNames.Application.Json)]
//    [Route("api/orders")]
//    [ApiVersion("1.0")]
//    public class OrdersV1Controller : ControllerBase
//    {
//        [HttpGet, MapToApiVersion("1.0")]
//        public IActionResult Get()
//        {
//            List<OrderDtoV1> orders = new List<OrderDtoV1> {
//            new() { Amount = 10M, ClientFirstname = "Bertrand", ClientLastname = "Dupuis", Number = 100000 },
//            new() { Amount = 100M, ClientFirstname = "Justine", ClientLastname = "Renard", Number = 100001 },
//            new() { Amount = 50M, ClientFirstname = "Alice", ClientLastname = "Wonderland", Number = 100002 }
//        };
//            return Ok(orders);
//        }
//    }
//}

//namespace ApiVersioningExample.Controllers.V2
//{

//    [ApiController]
//    [Produces(MediaTypeNames.Application.Json)]
//    [Route("api/orders")]
//    [ApiVersion("2.0")]
//    public class OrdersV2Controller : ControllerBase
//    {

//        [HttpGet, MapToApiVersion("2.0")]
//        public IActionResult Get()
//        {
//            List<OrderDtoV2> orders = new List<OrderDtoV2> {
//            new() { Amount = 10M, ClientName = "Bertrand Dupuis", Number = 100000 },
//            new() { Amount = 100M, ClientName = "Justine Renard", Number = 100001 },
//            new() { Amount = 50M, ClientName = "Alice Wonderland", Number = 100002 }
//        };
//            return Ok(orders);
//        }
//    }
//}