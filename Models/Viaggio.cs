using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_TravelAgency.Models
{
    public class Viaggio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mi dispiace, l'URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'Url inserito non è valido")]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Mi dispiace, il campo titolo è obbligatorio")]
        [StringLength(80, ErrorMessage = "Il titolo non può avere più di 80 caratteri")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "Mi dispiace,il campo descrizione è obbligatorio")]
        [Column(TypeName = "text")]
        public string Descrizione { get; set; }

        public Viaggio()
        {
           
        }
        public Viaggio(string immagine, string titolo, string descrizione)
        {
            this.Immagine = immagine;
            this.Titolo = titolo;
            this.Descrizione = descrizione;

        }
    }
}

