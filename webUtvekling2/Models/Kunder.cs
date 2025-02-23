using System;
using System.Collections.Generic;

namespace webUtvekling2.Models;

public partial class Kunder
{
    public int Id { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public string Epost { get; set; } = null!;

    public string? Telefonnummer { get; set; }

    public virtual ICollection<Ordrar> Ordrars { get; set; } = new List<Ordrar>();
}
