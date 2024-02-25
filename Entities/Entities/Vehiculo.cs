using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdMarcaVehiculo { get; set; }

    public int? IdCategoriaVehiculo { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? RutaImagen { get; set; }

    public string? NombreImagen { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CarritoVehiculo> CarritoVehiculos { get; set; } = new List<CarritoVehiculo>();

    public virtual ICollection<DetalleVentaVehiculo> DetalleVentaVehiculos { get; set; } = new List<DetalleVentaVehiculo>();

    public virtual CategoriaVehiculo? IdCategoriaVehiculoNavigation { get; set; }

    public virtual MarcaVehiculo? IdMarcaVehiculoNavigation { get; set; }

    public virtual ICollection<MantenimientoVehiculo> MantenimientoVehiculos { get; set; } = new List<MantenimientoVehiculo>();
}
