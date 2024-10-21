$('#btnBuscar').on('click', function () {
    const fechaInicio = $('#fechaInicio').val() || null;
    const fechaFin = $('#fechaFin').val() || null;
    const tipoMovimiento = $('#tipoMovimiento').val() || null;
    const numeroDocumento = $('#numeroDocumento').val() || null;

    $.ajax({
        url: '/GetInventario',
        type: 'GET',
        data: {
            FechaInicio: fechaInicio,
            FechaFin: fechaFin,
            TipoMovimiento: tipoMovimiento,
            NumeroDocumento: numeroDocumento
        },
        success: function (data) {
            $('#resultados').html(''); 
            if (data.length > 0) {
                let html = '<ul>';
                for (let i = 0; i < data.length; i++) {
                    html += `<li>${data[i].tipO_DOCUMENTO} - ${data[i].nrO_DOCUMENTO} (${data[i].fechA_TRANSACCION})</li>`;
                }
                html += '</ul>';
                $('#resultados').html(html);
            } else {
                $('#resultados').html('<p>No se encontraron resultados.</p>');
            }
        },
        error: function (xhr, status, error) {
            $('#resultados').html('<p>Error al consultar el inventario.</p>');
            console.error('Error:', error);
        }
    });
});

$('#btnInsertar').on('click', function () {
    const tipoMovimiento = $('#tipoMovimiento').val() || '2';
    const nroDocumento = $('#nroDocumento').val() || '2938383';
    const codCia = "0"; 
    const companiaVenta = "1"; 
    const almacenVenta = "HU"; 
    const tipoDocumento = "1"; 
    const codItem = "1111"; 
    const proveedor = "DEMO"; 
    const almacenDestino = "DEMO"; 
    const cantidad = "1"; 

    $.ajax({
        url: '/InsertInventario',
        type: 'POST',
        data: {
            tipoMovimiento,
            nroDocumento,
            COD_CIA: codCia,
            COMPANIA_VENTA_3: companiaVenta,
            ALMACEN_VENTA: almacenVenta,
            TIPO_DOCUMENTO: tipoDocumento,
            COD_ITEM_2: codItem,
            PROVEEDOR: proveedor,
            ALMACEN_DESTINO: almacenDestino,
            CANTIDAD: cantidad

        }
    });

});