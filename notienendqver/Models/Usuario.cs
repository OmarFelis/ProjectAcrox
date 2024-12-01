using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class Usuario
{
    public int CodUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ClaveUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
