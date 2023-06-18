using System;
using System.Collections.Generic;

namespace DiagnosticApp_API.Models;

public partial class Disease
{
    public int IdDisease { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Specialist { get; set; }

    public int SumWeight { get; set; }

    public int SymptomsCount { get; set; }
}
