using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class CarritoVehiculo
{
    public int IdCarritoVehiculo { get; set; }

    public int? IdCliente { get; set; }

    public int? IdVehiculo { get; set; }

    public int? Cantidad { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
