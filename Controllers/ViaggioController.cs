using Microsoft.AspNetCore.Mvc;
using WebApp_TravelAgency.Data;
using WebApp_TravelAgency.Models;

namespace WebApp_TravelAgency.Controllers
{
    public class ViaggioController : Controller
    {
        [HttpGet]
        public IActionResult Index(string SearchString)
        {

            List<Viaggio> viaggi = new List<Viaggio>();

            using (ViaggioContext db = new ViaggioContext())
            {
                if (SearchString != null)
                {
                    viaggi = db.Viaggi.Where(viaggio => viaggio.Titolo.Contains(SearchString) || viaggio.Descrizione.Contains(SearchString)).ToList<Viaggio>();
                }
                else
                {
                    viaggi = db.Viaggi.ToList<Viaggio>();
                }

            }

            return View("HomePage", viaggi);
        }

        public IActionResult Details(int id)
        {


            using (ViaggioContext db = new ViaggioContext())
            {
                try
                {
                    Viaggio viaggioTrovato = db.Viaggi
                        .Where(viaggio => viaggio.Id == id)
                        .FirstOrDefault();

                    return View("Details", viaggioTrovato);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Mi dispiace, il viaggio non è stato trovato");

                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("FormViaggio");
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
                Viaggio viaggioDaCreare = new Viaggio(nuovoViaggio.Titolo, nuovoViaggio.Descrizione, nuovoViaggio.Immagine);
                db.Viaggi.Add(viaggioDaCreare);
                db.SaveChanges();
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
                    .FirstOrDefault();
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

            Viaggio viaggioOriginale = null;

            using (ViaggioContext db = new ViaggioContext())
            {
                viaggioOriginale = db.Viaggi.Where(viaggio => viaggio.Id == id)
                    .FirstOrDefault();

                if (viaggioOriginale != null)
                {
                   
                    viaggioOriginale.Titolo = model.Titolo;
                    viaggioOriginale.Immagine= model.Immagine
                    viaggioOriginale.Descrizione = model.Descrizione;
                
                    db.SaveChanges();

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
            using (ViaggioContext db = new ViaggioContext())
            {
                Viaggio viaggioDaEliminare = db.Viaggi.Where(viaggio => viaggio.Id == id).FirstOrDefault();

                if (viaggioDaEliminare != null)
                {
                    db.Viaggi.Remove(viaggioDaEliminare);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound();
                }

            }

        }


    }
}