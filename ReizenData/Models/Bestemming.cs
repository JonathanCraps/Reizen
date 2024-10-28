using System;
using System.Collections.Generic;

namespace ReizenData.Models;

public partial class Bestemming
{
    public string Code { get; set; } = null!;

    public int Landid { get; set; }

    public string Plaats { get; set; } = null!;

    public virtual Land Land { get; set; } = null!;

    public virtual ICollection<Reiz> Reizen { get; set; } = new List<Reiz>();
}
