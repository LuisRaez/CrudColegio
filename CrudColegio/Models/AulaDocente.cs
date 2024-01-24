using System;
using System.Collections.Generic;

namespace CrudColegio.Models;

public partial class AulaDocente
{
    public int AulaDocenteId { get; set; }

    public int? AulaId { get; set; }

    public int? DocenteId { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual Aula? Aula { get; set; }

    public virtual Docente? Docente { get; set; }
}
