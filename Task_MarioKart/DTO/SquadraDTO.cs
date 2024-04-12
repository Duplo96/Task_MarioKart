using Task_MarioKart.Models;

namespace Task_MarioKart.DTO
{
    public class SquadraDTO
    {

        public string NomeUt { get; set; } = null!;

        public string NomeSq{ get; set; } = null!;

        public int? Crediti{ get; set; }

        public string? Codice { get; set; }

        public virtual ICollection<Personaggi> ListaPersonaggi { get; set; } = new List<Personaggi>();
    }
}
