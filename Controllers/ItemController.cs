using DataBaseCorrelations.Data;
using DataBaseCorrelations.DTO;
using DataBaseCorrelations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Controllers;

public class ItemController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ItemController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("/createItem")]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemDTO reqBody)
    {
        ItemClass newItem = new ItemClass
        {
            Name = reqBody.Name,
        };
        _context.Item.Add(newItem);
        await _context.SaveChangesAsync();
        var item = await _context.Item.FirstAsync(x => x.Name == newItem.Name);
        foreach (var userId in reqBody.UserIds)
        {
            var user = await _context.User.FirstAsync(x => x.Id == userId);

            UserToItem newConn = new UserToItem
            {
                Id = Guid.NewGuid(),
                Item = item,
                User = user
            };
            _context.UserToItems.Add(newConn);
            await _context.SaveChangesAsync();
            user.Items.Add(newConn);
            _context.User.Update(user);
            item.UserToItems.Add(newConn);
        }

        _context.Item.Update(item);
        await _context.SaveChangesAsync();
        return Ok("Item Created");
    }

    [HttpGet("/getItems")]
    public async Task<IActionResult> GetItems()
    {
        var items = await _context.Item
            .Include(x => x.UserToItems)
            .ThenInclude(x => x.User)
            .ToListAsync();
        return Ok(items);
    }
}