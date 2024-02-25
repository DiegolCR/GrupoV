using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public bool? Reestablecer { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CarritoVehiculo> CarritoVehiculos { get; set; } = new List<CarritoVehiculo>();

    public virtual ICollection<MantenimientoVehiculo> MantenimientoVehiculos { get; set; } = new List<MantenimientoVehiculo>();

    public virtual ICollection<VentaVehiculo> VentaVehiculos { get; set; } = new List<VentaVehiculo>();
}
