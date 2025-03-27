using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

<<<<<<< HEAD
    // GET: User
    public ActionResult Index()
    {
        // Muestra la lista de usuarios
        return View(userlist);
    }
=======
        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
<<<<<<< HEAD
            return NotFound();
=======
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
        }
        return View(user);
    }

<<<<<<< HEAD
    // GET: User/Create
    public ActionResult Create()
    {
        // Muestra el formulario para crear un nuevo usuario
        return View();
    }
=======
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
<<<<<<< HEAD
            // Agrega el nuevo usuario a la lista
            userlist.Add(user);
            return RedirectToAction(nameof(Index));
=======
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
        }
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
<<<<<<< HEAD
            return NotFound();
=======
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
        }
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        if (ModelState.IsValid)
        {
<<<<<<< HEAD
            // Busca el usuario existente y actualiza sus datos
=======
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            return RedirectToAction(nameof(Index));
=======

            if (ModelState.IsValid)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // Update other fields as necessary
                return RedirectToAction(nameof(Index));
            }
            return View(user);
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
        }
        return View(user);
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        // Busca el usuario por ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
<<<<<<< HEAD
            return NotFound();
=======
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
        }
        return View(user);
    }

<<<<<<< HEAD
    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        // Elimina el usuario de la lista
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        userlist.Remove(user);
        return RedirectToAction(nameof(Index));
=======
        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            userlist.Remove(user);
            return RedirectToAction(nameof(Index));
        }
>>>>>>> c037b9f271d1c9ee4117173d4742e2e63627bb41
    }
}
