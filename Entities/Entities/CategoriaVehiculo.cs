using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class CategoriaVehiculo
{
    public int IdCategoriaVehiculo { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
