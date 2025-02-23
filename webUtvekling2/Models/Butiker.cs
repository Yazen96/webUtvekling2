using System;
using System.Collections.Generic;

namespace webUtvekling2.Models;

public partial class Butiker
{
    public int Id { get; set; }

    public string Butiksnamn { get; set; } = null!;

    public string Adress { get; set; } = null!;
}
