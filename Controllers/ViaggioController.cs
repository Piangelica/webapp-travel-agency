using Microsoft.AspNetCore.Mvc;
using WebApp_TravelAgency.Data;
using WebApp_TravelAgency.Models;

namespace WebApp_TravelAgency.Controllers
{
    public class ViaggioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            List<Viaggio> viaggi = new List<Viaggio>();
            using (ViaggioContext db = new ViaggioContext())
            {
                viaggi = db.Viaggi.ToList<Viaggio>();
            }

            return View("HomePage", viaggi);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (ViaggioContext db = new ViaggioContext())
            {
                try
                {
                    Viaggio viaggioTrovato = db.Viaggi
                         .Where(viaggio => viaggio.Id == id)
                         .FirstorDefault();

                    return View("Details", viaggioTrovato);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Mi dispiace, il viaggio con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }


            }

        [HttpGet]
            public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaggio nuovoViaggio)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPost", nuovoViaggio);
            }

                using (ViaggioContext db = new ViaggioContext())
                {
                    Viaggio nuovoViaggioDaCreare = new Viaggio( nuovoViaggio.Titolo, nuovoViaggio.Descrizione, nuovoViaggio.Immagine);
                    db.Viaggi.Add(nuovoViaggioDaCreare);
                    db.Viaggi.SaveChanges();
                }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Viaggio viaggioToEdit = null;
            using (ViaggioContext db = new ViaggioContext())
            {
              viaggioToEdit = db.Viaggi
              .Where(viaggio => viaggio.Id == id)
              .FirstorDefault();

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
        public IActionResult Update(int id, Viaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }
                Viaggio viaggioOriginal = null;
                using (ViaggioContext db = new ViaggioContext())
                {

                 viaggioOriginal = db.Viaggi
              .Where(viaggio => viaggio.Id == id)
              .FirstorDefault();

               if (viaggioOriginal != null)
            {
                viaggioOriginal.Titolo = model.Titolo;
                viaggioOriginal.Descrizione = model.Descrizione;
                viaggioOriginal.Immagine = model.Immagine;

                        db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
                    using (ViaggioContext db = new ViaggioContext())
        {
                      Viaggio  viaggioToDelete = db.Viaggi
             .Where(viaggio => viaggio.Id == id)
             .FirstorDefault();

                if (viaggioToDelete = null)
                {
                 db.Viaggi.Remove(viaggioToDelete);
                 db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
}