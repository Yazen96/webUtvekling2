using System;
using System.Collections.Generic;

namespace webUtvekling2.Models;

public partial class Ordrar
{
    public int Id { get; set; }

    public int KundId { get; set; }

    public DateOnly OrderDatum { get; set; }

    public decimal TotalBelopp { get; set; }

    public virtual Kunder Kund { get; set; } = null!;

    public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; } = new List<Orderdetaljer>();
}
