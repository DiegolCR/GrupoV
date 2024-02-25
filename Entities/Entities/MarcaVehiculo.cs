using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class MarcaVehiculo
{
    public int IdMarcaVehiculo { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
