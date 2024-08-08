using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoFinal.Models;

public partial class Recetum
{
    public int Id { get; set; }

    public string NombrePaciente { get; set; } = null!;

    public string ApellidoPaciente { get; set; } = null!;

    public string? TelefonoPaciente { get; set; }

    public string? DireccionPaciente { get; set; }

    public DateTime Fecha { get; set; }

    public string NombreDoctor { get; set; } = null!;

    [DataType(DataType.MultilineText)]
    public string Medicamentos { get; set; } = null!;
}
