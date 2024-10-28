﻿using System;
using System.Collections.Generic;

namespace ReizenData.Models;

public partial class Land
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public int Werelddeelid { get; set; }

    public virtual ICollection<Bestemming> Bestemmingen { get; set; } = new List<Bestemming>();

    public virtual Wereldeel Werelddeel { get; set; } = null!;
}
