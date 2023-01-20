using ApiVersioningExample.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiVersioningExample.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet("~/api/v1/[controller]")]
    public IActionResult GetV1()
    {
        List<OrderDtoV1> orders = new List<OrderDtoV1> {
            new() { Amount = 10M, ClientFirstname = "Bertrand", ClientLastname = "Dupuis", Number = 100000 },
            new() { Amount = 100M, ClientFirstname = "Justine", ClientLastname = "Renard", Number = 100001 },
            new() { Amount = 50M, ClientFirstname = "Alice", ClientLastname = "Wonderland", Number = 100002 }
        };
        return Ok(orders);
    }

    [HttpGet("~/api/v2/[controller]")]
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
