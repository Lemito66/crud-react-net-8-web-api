using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Employeer
{
    public int IdEmployeer { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Salary { get; set; }
}
