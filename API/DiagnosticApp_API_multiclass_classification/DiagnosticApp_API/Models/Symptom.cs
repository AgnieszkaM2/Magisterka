using System;
using System.Collections.Generic;

namespace DiagnosticApp_API.Models;

public partial class Symptom
{
    public int IdSymptom { get; set; }

    public string Name { get; set; } = null!;

    public int Weight { get; set; }
}
