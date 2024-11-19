﻿using System;
using System.Collections.Generic;

namespace ComputerApi.Models;

public partial class Comp
{
    public Guid Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Type { get; set; } = null!;

    public double Display { get; set; }

    public int Memory { get; set; }

    public DateTime CreatedTime { get; set; }

    public Guid OdId { get; set; }

    public virtual Os Os { get; set; } = null!;
}