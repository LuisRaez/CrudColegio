using System;
using System.Collections.Generic;
using CrudColegio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CrudColegio.Models;

public partial class Docente
{
    public int DocenteId { get; set; }

    public string? Nombre { get; set; }

    public string? Materia { get; set; }

    public virtual ICollection<AulaDocente> AulaDocentes { get; set; } = new List<AulaDocente>();
}