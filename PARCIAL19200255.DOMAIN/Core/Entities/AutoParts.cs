using System;
using System.Collections.Generic;

namespace PARCIAL19200255.DOMAIN.Core.Entities;

public partial class AutoParts
{
    public int Id { get; set; }

    public string? PartName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }
}
