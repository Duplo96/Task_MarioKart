using System;
using System.Collections.Generic;

namespace Task_MarioKart.Models;

public partial class Personaggi
{
    public string? Nome { get; set; } = null!;
    public int PersonaggioId { get; set; }

    public int Costo { get; set; }

    public string? Codice { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Img { get; set; }

    public int? SquadraRif { get; set; }

    public virtual Squadra? SquadraRifNavigation { get; set; }
}
