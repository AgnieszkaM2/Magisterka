using System;
using System.Collections.Generic;

namespace DiagnosticApp_API.Models;

public partial class Questionnaire
{
    public int IdQuestion { get; set; }

    public string Question { get; set; } = null!;

    public string? QuestionValue { get; set; }
}
