using PO.Infrastructure.InterFaces;
using PO.Shared.DTOs;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace PO.Shared.AnotherAPIClass
{
    public class ItemMasterService: IItemServices
    {
        private readonly HttpClient _httpClient;
        public ItemMasterService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ItemMaster");
        }

        public async Task<ItemDto>GetItem(string ItemNo,string? Token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var response = await _httpClient.GetAsync($"api/Item/GetItem?ItemName={Uri.EscapeDataString(ItemNo)}");

            if (!response.IsSuccessStatusCode) 
            {

                return null;
            }
            else
            {
                return await response.Content.ReadFromJsonAsync<ItemDto>();
            }
        }
    }
}
