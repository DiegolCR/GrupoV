using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class VentaVehiculo
{
    public int IdVentaVehiculo { get; set; }

    public int? IdCliente { get; set; }

    public int? TotalVehiculos { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? Contacto { get; set; }

    public string? IdDistrito { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? IdTransaccion { get; set; }

    public DateTime? FechaVenta { get; set; }

    public virtual ICollection<DetalleVentaVehiculo> DetalleVentaVehiculos { get; set; } = new List<DetalleVentaVehiculo>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
