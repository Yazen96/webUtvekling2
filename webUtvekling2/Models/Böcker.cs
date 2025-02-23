using System;
using System.Collections.Generic;

namespace webUtvekling2.Models;

public partial class Böcker
{
    public string Isbn13 { get; set; } = null!;

    public string Titel { get; set; } = null!;

    public string Språk { get; set; } = null!;

    public decimal Pris { get; set; }

    public DateOnly Utgivningsdatum { get; set; }

    public int FörfattareId { get; set; }

    public string? Genre { get; set; }

    public int? Sidor { get; set; }

    public virtual Författare Författare { get; set; } = null!;

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();

    public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; } = new List<Orderdetaljer>();
}
