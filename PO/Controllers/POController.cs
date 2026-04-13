using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PO.Infrastructure.InterFaces;
using PO.Models;
using PO.Shared.DTOs;
using System.Net.Http.Headers;

namespace PO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {
        private readonly IPODbClass _purchaseOrderDB;
       
        private readonly IItemServices _itemServices;

       
        public POController(IPODbClass purchaseOrderDB, IItemServices itemServices)
        {
            _purchaseOrderDB = purchaseOrderDB;
            _itemServices = itemServices;
        }
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> AddPO([FromBody] PurchaseHeaderDTO purchaseHeaderDto)
        {

            var poHeader = await _purchaseOrderDB.purchaseHeaders.Where(x => x.No == purchaseHeaderDto.No).FirstOrDefaultAsync();
            if (poHeader == null)
            {
                var PoID = await _purchaseOrderDB.purchaseHeaders.MaxAsync(x => x.purchaseID)+1;
                var poDetail = new PurchaseHeader();
                poDetail.No = purchaseHeaderDto.No;
                poDetail.purchaseID = PoID;
                poDetail.CreatedOn = DateTime.Now;
                poDetail.CreatedBy = 1;

                await _purchaseOrderDB.purchaseHeaders.AddAsync(poDetail);
                await _purchaseOrderDB.SaveChangesAsync();

                if (purchaseHeaderDto.purchaseline != null)
                {
                    foreach (var line in purchaseHeaderDto.purchaseline)
                    {
                        var token = HttpContext.Request.Headers["Authorization"]
                          .ToString().Replace("Bearer ", "");

                        var itemData = await _itemServices.GetItem(line.ItemNo, token);

                       // var itemData = await response.Content.ReadFromJsonAsync<ItemDto>();

                        if (itemData != null)
                        {

                            var Purchaselines = new Purchaseline();
                            Purchaselines.purchaseID = poDetail.purchaseID;
                            Purchaselines.Qty = line.Qty;
                            Purchaselines.ItemNo = line.ItemNo;
                            Purchaselines.CreatedBy = 1;
                            Purchaselines.CreatedOn = DateTime.Now;

                            await _purchaseOrderDB.purchaselines.AddAsync(Purchaselines);
                            await _purchaseOrderDB.SaveChangesAsync();
                        }


                    }
                }
                return Ok(poHeader);
            }
            else
            {
                return BadRequest("Order already Exits");
            }
        }
    }
}
