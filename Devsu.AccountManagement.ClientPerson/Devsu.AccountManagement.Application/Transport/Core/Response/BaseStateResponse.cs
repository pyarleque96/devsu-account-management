namespace Devsu.AccountManagement.Application.Transport;

public class BaseStateResponse
{
    public bool HasError { get; set; }
    public int? CodigoError { get; set; }
    public string? TipoError { get; set; }
    public string? MesageError { get; set; }
    public string? MessageDetail { get; set; }
}
