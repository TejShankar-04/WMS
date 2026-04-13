using ItemMaster.Infrastructure.Interfaces;
using ItemMaster.Models;
using ItemMaster.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemDbClass _itemDbClass;

        public ItemController(IItemDbClass itemDbClass)
        {
            _itemDbClass = itemDbClass;
        }
        [Authorize]
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            var ItemDetails = await _itemDbClass.Items.Where(x => x.Name == itemDto.Name).FirstOrDefaultAsync();
            if (ItemDetails == null)
            {

                var Items = new Item();

                Items.Name = itemDto.Name;
                Items.Description = itemDto.Description;
                Items.Type = itemDto.Type;
                Items.CreatedDate = DateTime.Now;
                Items.CreatedBy = 1;

                await _itemDbClass.Items.AddAsync(Items);
                await _itemDbClass.SaveChangesAsync();

                return Ok(Items);
            }
            else { return BadRequest("Item Already Exits"); }
        }
        [Authorize]
        [HttpGet("GetItem")]
        public async Task<IActionResult> GetItem(string ItemName)
        {
            var ItemDetails = await _itemDbClass.Items.Where(x => x.Name == ItemName).FirstOrDefaultAsync();
            if (ItemDetails != null)
            {
                ItemDto objitemDto = new ItemDto();
                objitemDto.Name = ItemDetails.Name;
                objitemDto.Type = ItemDetails.Type;
                objitemDto.Description = ItemDetails.Description;
                return Ok(ItemDetails);
            }
            else
            {
                ItemDto objitemDto = new ItemDto();
                return Ok(objitemDto);
            }
        }
    }
}
