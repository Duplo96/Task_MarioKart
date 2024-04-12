using Task_MarioKart.Models;

namespace Task_MarioKart.DTO
{
    public class PersonaggiDTO
    {


        public string? Nom { get; set; }

        public int Cos { get; set; }

        public string? Cod { get; set; }

        public string Cat { get; set; } = null!;

        public string? Img { get; set; }

        public int? SquadraRif { get; set; }
        public Squadra? Squad { get; set; }
    }
}
