﻿using System;
using System.Collections.Generic;

namespace webUtvekling2.Models;

public partial class Författare
{
    public int Id { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public DateOnly Födelsedatum { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
