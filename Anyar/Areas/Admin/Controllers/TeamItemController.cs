using Core.Entities;
using DataAcces;
using Microsoft.AspNetCore.Mvc;

namespace Anyar.Areas.Admin.Controllers;
[Area("Admin")]
public class TeamItemController : Controller
{
    private readonly AppDbContext _context;

    public TeamItemController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TeamItems item)
    {
        if(!ModelState.IsValid)return View(item);
        await _context.teamItems.AddAsync(item);
        await _context.SaveChangesAsync();
        return View(RedirectToAction(nameof(Index)));
    }


    public async Task<IActionResult> Details(int? id)
    {
        var member=await _context.teamItems.FindAsync(id);
        if (member == null)
        {
            return BadRequest();
        }
        return View(member);
    }

    public async Task<IActionResult> Update(int? id)
    {
        var member = await _context.teamItems.FindAsync(id);
        if(member==null)return BadRequest();
        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id,TeamItems member)
    {
        if (id != member.Id) return BadRequest();
        if (ModelState.IsValid)
        {
            return View(member);
        }

        return View(RedirectToAction(nameof(Index)));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var member = await _context.teamItems.FindAsync(id);
        if (member == null) return BadRequest();
        _context.teamItems.Remove(member);
        return RedirectToAction(nameof(member));
    }
    
}
