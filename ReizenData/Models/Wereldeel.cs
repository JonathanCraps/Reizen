﻿using System;
using System.Collections.Generic;

namespace ReizenData.Models;

public partial class Wereldeel
{
    public int Id { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Land> Landen { get; set; } = new List<Land>();
}
