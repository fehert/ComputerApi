namespace ComputerApi.Models
{
    public record CreateOsDto(string name);
    public record UpdateOsDto(string name);
    public record CreateCompDto(string Brand, string Type, double Display, int Memory, DateTime CreatedTime, Guid OsId);
    public record UpdateCompDto(string Brand, string Type, double Display, int Memory);
}
