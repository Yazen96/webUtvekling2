using System;
using System.Collections.Generic;

namespace webUtvekling2.Models;

public partial class LagerSaldo
{
    public int ButikId { get; set; }

    public string Isbn { get; set; } = null!;

    public int Antal { get; set; }

    public virtual Böcker IsbnNavigation { get; set; } = null!;
}
