using System;
using System.Collections.Generic;

namespace CrudColegio.Models;

public partial class Aula
{
    public int AulaId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<AulaDocente> AulaDocentes { get; set; } = new List<AulaDocente>();
}
