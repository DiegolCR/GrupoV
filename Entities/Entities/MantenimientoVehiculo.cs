using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class MantenimientoVehiculo
{
    public int IdMantenimientoVehiculo { get; set; }

    public int? IdCliente { get; set; }

    public int? IdVehiculo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaMantenimiento { get; set; }

    public bool? Activo { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
