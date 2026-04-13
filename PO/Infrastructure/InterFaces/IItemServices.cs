using PO.Shared.DTOs;

namespace PO.Infrastructure.InterFaces
{
    public interface IItemServices
    {
        Task<ItemDto> GetItem(string ItemNo, string Token);
    }
}
