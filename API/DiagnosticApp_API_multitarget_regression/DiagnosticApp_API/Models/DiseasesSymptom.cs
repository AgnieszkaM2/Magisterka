using System;
using System.Collections.Generic;

namespace DiagnosticApp_API.Models;

public partial class DiseasesSymptom
{
    public int IdDisease { get; set; }

    public int IdSymptom { get; set; }

    public virtual Disease IdDiseaseNavigation { get; set; } = null!;

    public virtual Symptom IdSymptomNavigation { get; set; } = null!;
}
