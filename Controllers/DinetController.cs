using Dinet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Dinet.Controllers
{

    public class DinetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DinetController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetInventario")]
        public async Task<IActionResult> GetInventario(string FechaInicio, string FechaFin, string TipoMovimiento, string NumeroDocumento)
        {
            
            try
            {
                var prod = new List<MOV_INVENTARIO>();
                var fechaInicioParam = new SqlParameter("@FechaInicio", string.IsNullOrEmpty(FechaInicio) ? (object)DBNull.Value : FechaInicio);
                var fechaFinParam = new SqlParameter("@FechaFin", string.IsNullOrEmpty(FechaFin) ? (object)DBNull.Value : FechaFin);
                var tipoMovimientoParam = new SqlParameter("@TipoMovimiento", string.IsNullOrEmpty(TipoMovimiento) ? (object)DBNull.Value : TipoMovimiento);
                var numeroDocumentoParam = new SqlParameter("@NumeroDocumento", string.IsNullOrEmpty(NumeroDocumento) ? (object)DBNull.Value : NumeroDocumento);

                prod = await _context.MOV_INVENTARIO
                    .FromSqlRaw("EXEC FiltrarInventario @FechaInicio, @FechaFin, @TipoMovimiento, @NumeroDocumento",
                                 fechaInicioParam, fechaFinParam, tipoMovimientoParam, numeroDocumentoParam)
                    .ToListAsync();


                return Ok(prod);
            }
            catch (Exception ex) { 
                return BadRequest(ex);
            }

        }

        [HttpPost("InsertInventario")]
        public async Task<IActionResult> InsertarInventario(
            string tipoMovimiento,
            string nroDocumento,
            string? COD_CIA,
            string? COMPANIA_VENTA_3 ,
            string? ALMACEN_VENTA,
            string? TIPO_DOCUMENTO ,
            string? COD_ITEM_2,
            string? PROVEEDOR,
            string? ALMACEN_DESTINO,
            string? CANTIDAD
            )

        {

            try
            {
                var codCiaParam = new SqlParameter("@COD_CIA", string.IsNullOrEmpty(COD_CIA) ? (object)DBNull.Value : 1);
                var companiaVentaParam = new SqlParameter("@COMPANIA_VENTA_3", string.IsNullOrEmpty(COMPANIA_VENTA_3) ? (object)DBNull.Value : COMPANIA_VENTA_3);
                var almacenVentaParam = new SqlParameter("@ALMACEN_VENTA", string.IsNullOrEmpty(ALMACEN_VENTA) ? (object)DBNull.Value : ALMACEN_VENTA);
                var tipoMovimientoParam = new SqlParameter("@TIPO_MOVIMIENTO", string.IsNullOrEmpty(tipoMovimiento) ? (object)DBNull.Value : tipoMovimiento);
                var tipoDocumentoParam = new SqlParameter("@TIPO_DOCUMENTO", string.IsNullOrEmpty(TIPO_DOCUMENTO) ? (object)DBNull.Value : TIPO_DOCUMENTO);
                var numeroDocumentoParam = new SqlParameter("@NRO_DOCUMENTO", string.IsNullOrEmpty(nroDocumento) ? (object)DBNull.Value : nroDocumento);
                var codItemParam = new SqlParameter("@COD_ITEM_2", string.IsNullOrEmpty(COD_ITEM_2) ? (object)DBNull.Value : COD_ITEM_2);
                var proveedorParam = new SqlParameter("@PROVEEDOR", string.IsNullOrEmpty(PROVEEDOR) ? (object)DBNull.Value : PROVEEDOR);
                var almacenDestinoParam = new SqlParameter("@ALMACEN_DESTINO", string.IsNullOrEmpty(ALMACEN_DESTINO) ? (object)DBNull.Value : ALMACEN_DESTINO);
                var cantidadParam = new SqlParameter("@CANTIDAD", string.IsNullOrEmpty(CANTIDAD) ? (object)DBNull.Value : CANTIDAD);

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC InsertarInventario @COD_CIA, @COMPANIA_VENTA_3, @ALMACEN_VENTA, @TIPO_MOVIMIENTO, @TIPO_DOCUMENTO, @NRO_DOCUMENTO, @COD_ITEM_2, @PROVEEDOR, @ALMACEN_DESTINO, @CANTIDAD",
                    codCiaParam, companiaVentaParam, almacenVentaParam, tipoMovimientoParam, tipoDocumentoParam, numeroDocumentoParam, codItemParam, proveedorParam, almacenDestinoParam, cantidadParam
                );

                return Ok(new { message = "Inventario insertado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }










    }

}
