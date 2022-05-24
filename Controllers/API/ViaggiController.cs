using Microsoft.AspNetCore.Mvc;
using WebApp_TravelAgency.Data;
using WebApp_TravelAgency.Models;

namespace WebApp_TravelAgency.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViaggiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Viaggio> viaggi = new List<Viaggio>();

            using (ViaggioContext db = new ViaggioContext())
            {

                if (search != null && search != "")
                {
                    viaggi = db.Viaggi.Where(viaggio => viaggio.Title.Contains(search) || viaggio.Descrizione.Contains(search)).ToList<Viaggio>();
                }
                else
                {
                    viaggi = db.Viaggi.ToList<Viaggio>();
                }

            }

            return Ok(viaggi);
        }


        [HttpGet("{id}")]

        public IActionResult Details(int id)
        {
            using (ViaggioContext db = new ViaggioContext())
            {
                try
                {
                    Viaggio vaggioTrovato = db.Viaggi
                        .Where(trip => trip.Id == id)
                        .FirstOrDefault();

                    return Ok(vaggioTrovato);

                }
                catch (InvalidOperationException)
                {
                    return NotFound("Mi dispiace, il viaggio non è stato trovato");

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }



    }
}
