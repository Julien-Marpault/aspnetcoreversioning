namespace ApiVersioningExample.Dto;

public abstract class OrderDtoBase
{
    public int Number { get; set; }
    public decimal Amount { get; set; }
}

public class OrderDtoV1 : OrderDtoBase
{
    public string ClientLastname { get; set; }
    public string ClientFirstname { get; set; }
}

public class OrderDtoV2 : OrderDtoBase
{
    public string ClientName { get; set; }
}