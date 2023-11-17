using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.Services;
using IdeaBunker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

[Area("Public")]
public class HomeController : Controller
{
    private readonly IPublicEventService _publicEventService;

    public HomeController(IPublicEventService publicEventService)
    {
        _publicEventService = publicEventService;
    }




    // GET: HomeController
    public ActionResult Index()
    {
        //ModelClass model = new()
        {
            //Name = _publicEventService.GetEvent(),
        };
        return View();
    }

    // GET: HomeController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: HomeController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: HomeController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: HomeController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: HomeController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: HomeController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: HomeController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
