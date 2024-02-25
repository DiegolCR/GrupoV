using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class DetalleVentaVehiculo
{
    public int IdDetalleVentaVehiculo { get; set; }

    public int? IdVentaVehiculo { get; set; }

    public int? IdVehiculo { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }

    public virtual VentaVehiculo? IdVentaVehiculoNavigation { get; set; }
}
