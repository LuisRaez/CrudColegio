using System;
using System.Collections.Generic;

namespace CrudColegio.Models;

public partial class Alumno
{
    public int AlumnoId { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public int? AulaId { get; set; }

    public int? AulaDocenteId { get; set; }

    public virtual Aula? Aula { get; set; }

    public virtual AulaDocente? AulaDocente { get; set; }
}
