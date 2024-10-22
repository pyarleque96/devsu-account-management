namespace Devsu.AccountManagement.Application.Transport;

public class BaseResult<T>
{
    public PaginationRawResult Pagination { get; set; } = new();
    public T Result { get; set; }
}