using CrudServicios.Datos;
using CrudServicios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudServicios.Controllers
{
    public class ServiciosController : Controller
    {


        private readonly ApplicationDbContext _context;

        public ServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Servicio> listServicios = _context.Servicio;
            return View(listServicios);
        }
        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _context.Servicio.Add(servicio);
                _context.SaveChanges();

                TempData["mensaje"] = "El servicio se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();

        }
        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if ( id == null || id ==0)
            {
                return NotFound();
            }
            //obtener servicio
            var servicio = _context.Servicio.Find(id);

            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }
        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _context.Servicio.Update(servicio);
                _context.SaveChanges();

                TempData["mensaje"] = "El servicio se ha editado correctamente";
                return RedirectToAction("Index");
            }

            return View();

        }
        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //obtener servicio
            var servicio = _context.Servicio.Find(id);

            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }
        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteServicio(int? id)
        {
            //obtener servicio por id
            var servicio = _context.Servicio.Find(id);
            if (servicio == null)
            {
                return NotFound();
                
            }
            _context.Servicio.Remove(servicio);
            _context.SaveChanges();


            TempData["mensaje"] = "El servicio se ha eliminado correctamente";
           return RedirectToAction("Index");
            

        }
    }
}
