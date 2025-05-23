using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    private readonly Services.UserService _userService = new Services.UserService();

    public UserController()
    {
        // Datos de ejemplo para pruebas de búsqueda
        if (_userService.GetAll().Count == 0)
        {
            _userService.Add(new User { Name = "Juan Pérez", Email = "juan.perez@email.com" });
            _userService.Add(new User { Name = "Ana Gómez", Email = "ana.gomez@email.com" });
            _userService.Add(new User { Name = "Carlos Ruiz", Email = "carlos.ruiz@email.com" });
            _userService.Add(new User { Name = "Maria Lopez", Email = "maria.lopez@email.com" });
            _userService.Add(new User { Name = "Pedro Sanchez", Email = "pedro.sanchez@email.com" });
            _userService.Add(new User { Name = "Laura Torres", Email = "laura.torres@email.com" });
            _userService.Add(new User { Name = "Miguel Castro", Email = "miguel.castro@email.com" });
            _userService.Add(new User { Name = "Sofia Herrera", Email = "sofia.herrera@email.com" });
            _userService.Add(new User { Name = "Diego Fernández", Email = "diego.fernandez@email.com" });
            _userService.Add(new User { Name = "Lucia Martínez", Email = "lucia.martinez@email.com" });
        }
    }

    // GET: User
    public ActionResult Index(string search)
    {
        var users = string.IsNullOrWhiteSpace(search)
            ? _userService.GetAll()
            : _userService.Search(search);
        ViewBag.Search = search;
        return View(users);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
            return NotFound();
        return View(user);
    }

    // GET: User/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: User/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.Add(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
            return NotFound();
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, User user)
    {
        if (ModelState.IsValid)
        {
            var updated = _userService.Update(id, user);
            if (!updated)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
            return NotFound();
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var deleted = _userService.Delete(id);
        if (!deleted)
            return NotFound();
        return RedirectToAction(nameof(Index));
    }
}
