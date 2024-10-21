using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Dinet.Models
{
    [Keyless]
    public class MOV_INVENTARIO
    {
        public string? COD_CIA { get; set; }
        public string? COMPANIA_VENTA_3 { get; set; }
        public string? ALMACEN_VENTA { get; set; }
        public string? TIPO_MOVIMIENTO { get; set; }
        public string? TIPO_DOCUMENTO { get; set; }
        public string? NRO_DOCUMENTO { get; set; }
        public string? COD_ITEM_2 { get; set; }
        public string? PROVEEDOR { get; set; }
        public string? ALMACEN_DESTINO { get; set; }
        public string? CANTIDAD { get; set; }
        public string? FECHA_TRANSACCION { get; set; }

    }
}
