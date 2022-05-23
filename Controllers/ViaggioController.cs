 /*using Microsoft.AspNetCore.Mvc;
using ViaggioAgencyWebApp.Controllers;
using WebApp_TravelAgency.Models;

namespace WebApp_TravelAgency.Controllers
{
    public class ViaggioController : Controller
    {
        [HttpGet]
        public IActionResult Index
        {
            get
            {

                List<Viaggio> viaggi = new List<Viaggio>();

                using (ViaggioContext database = new())
                {
                    viaggi = database.Viaggi.ToList<Viaggio>();
                }

                return View("HomePage", viaggi);
            }
        }

        public IActionResult Details(int id)
        {

            Viaggio viaggioFound = null;

            using (ViaggioContext database = new ViaggioContext())
            {
                viaggioFound = database.Trips
                    .Where(trip => trip.Id == id).FirstOrDefault();
            }

            if (viaggioFound != null)
            {
                return View("Details", viaggioFound);
            }
            else
            {
                return NotFound($"Il viaggio con l'Id {id} non è stato trovato");
            }


        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("FormTrip");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaggio newViaggio)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPost", newViaggio);
            }

            using (ViaggioContext database = new ViaggioContext())
            {
                Viaggio newViaggioToCreate = new Viaggio(newViaggio.Image, newViaggio.Title, newViaggio.Description, newViaggio.Length, newViaggio.Price);
                database.Trips.Add(newViaggioToCreate);
                database.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Viaggio viaggioToEdit = null;

            using (ViaggioContext database = new ViaggioContext())
            {
                viaggioToEdit = database.Trips
                    .Where(trip => trip.Id == id).FirstOrDefault();
            }

            if (viaggioToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update", viaggioToEdit);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id, Viaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            Viaggio viaggioOriginal = null;

            using (ViaggioContext database = new ViaggioContext())
            {
                viaggioOriginal = database.Viaggi.Where(viaggio => viaggio.Id == id).FirstOrDefault();

                if (viaggioOriginal != null)
                {
                    viaggioOriginal.Image = model.Image;
                    viaggioOriginal.Title = model.Titolo;
                    viaggioOriginal.Description = model.Description;
                    viaggioOriginal.Length = model.Length;
                    viaggioOriginal.Price = model.Price;

                    database.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound();
                }
            }

        }


        [HttpPost]

        public IActionResult Delete(int id)
        {
            using (ViaggioContext database = new ViaggioContext())
            {
                Viaggio viaggioToDelete = database.Viaggi.Where(viaggio => viaggio.Id == id).FirstOrDefault();

                if (viaggioToDelete != null)
                {
                    database.Viaggi.Remove(viaggioToDelete);
                    database.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound();
                }

            }

        }


    }
}*/