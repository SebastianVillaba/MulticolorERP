Imports System.Data.SqlClient
Module VariablesGlobales
    '-- nombre de la varbale con el nombre del sistema
    Public strGl_nombreSistema As String = "NetJoin"
    Public conexion As String
    Public conn As New SqlConnection
    Public strNombreHost As String
    Public strSerialHd As String
    Public strIDHost As String
    Public strGlNombreServer As String
    Public strGlClaveServer As String

    Public banGl_prueba As Boolean = False

    Public intGl_idEmpresaContable As Integer = 0
    Public intGl_idTipoAsiento As Integer = 0
    '-- variable para saber la forma de conexion al sistema
    Public intGl_tipoConexion As Integer
    '-- variable para saber el nombre del tipo de conexion configurado
    Public strGl_nombreConexion As String
    '-- variable para saber el nombre de la ruta de ingreso de los archivos de imagen
    Public strGl_rutaImagen As String
    ' id del usuario para el seguimiento y auditoria
    Public intGl_idUsuario As Integer
    ' nombgre del usuario
    Public strGl_nombreUsuario As String
    'grupo de usuario
    Public strGl_nombreGrupoUsuario As String
    'foto del usuario
    Public strGl_RutaFoto As String
    ' id de la entidad
    Public intGl_idEntidad As Integer
    Public strGl_nombreEntidad As String
    ' id de la configuracion de la pc
    Public intGl_idConfigPc As Integer
    ' nombre de la sucursal en que está configurado la pc
    Public intGl_idSucursal As Integer
    Public strGl_nombreSucursal As String
    'fecha y hora del servidor
    Public strGl_fechaHoraServer As String
    Public strGl_nombreDiaServer As String
    Public strGl_nombreMesServer As String
    Public strGl_anhoServer As String
    Public strGl_diaAserver As String
    ' datos de la empresa contable
    Public intGl_idPersonaJur As Integer
    Public strGl_empresaContable As String
    '-- nombre del reporte a utilizar
    Public strGl_nombreReporte As String
    '-- variable para el mensaje del error
    Public strGl_mensajeError As String
    '-- variable para el nombre de la base de datos
    Public strGl_nombreBaseDatos As String
    '-- variable para saber si la sucursal opera como hoteleria
    Public bolGl_hoteleria As Boolean
    '-- variable para la direccion del QR
    Public strGl_direccionQR As String

    '-- variable que cuenta las veces que se abre cada formulario
    Public intGl_contadorFormularios As Integer = 0
    '***********************************************
    ' VARIABLES PARA EL MODULO DE VENTAS DE FARMACIA
    '***********************************************
    '- variables enteras
    Public intGl_vtaIdCliente As Integer = 0
    Public intGl_vtaIdTipoVenta As Integer = 0
    Public intGl_vtaIdStock As Integer = 0
    Public intGl_vtaIdProducto As Integer = 0
    Public intGl_vtaTotalVenta As Integer = 0
    Public intGl_vtaTotalDescuento As Integer = 0
    Public intGl_vtaIdTarjetaDebito As Integer = 0
    Public intGl_vtaIdTarjetaCredito As Integer = 0
    Public intGl_nroVenta As Integer = 0
    Public intGl_vtaCantidadCuota As Integer = 0
    Public intGl_vtaIdVendedor As Integer
    Public intGl_vtaIdLote As Integer = 0
    Public intGl_vtaNroOrden As Integer = 0
    Public intGl_vtaTimbrado As Integer = 0
    Public intGl_vtaIdConvenio As Integer = 0
    Public intGl_vtaNroAutoriza As Integer = 0
    Public intGl_vtaNroCheque As Integer = 0

    '- variables caracteres
    Public strGl_vtaRucCliente As String = ""
    Public strGl_vtaCliente As String = ""
    Public strGl_vtaNombreFraccion As String = ""
    Public strGl_vtaFacturaManual As String = "0"
    Public strGl_vtaDsuc As String = ""
    Public strGl_vtaDcaja As String = ""
    Public strGl_vtaNombreBanco As String = ""
    '- variables doubles
    Public douGl_vtaPrecioProducto As Double = 0

    '-- variables booleanas
    Public bolGl_vtaFraccionado As Boolean = False
    Public bolGl_vtaDescuento As Boolean = False
    Public bolGl_vtaFarmaciaVuelto As Boolean = False
    Public bolGl_vtaVendedorFarmacia As Boolean = False
    Public bolGl_vtaFiscal As Boolean = False
    Public bolGl_vtaImprimir As Boolean = False
    Public bolGl_vtaFarmaciaLoteStock As Boolean = False
    Public bolGl_vtaDeliveryExterno As Boolean = False


    '*************************************************'
    ' VARIABLES PARA EL MODULO DE VENTAS DE HOTELERIA '
    '*************************************************'
    Public banGl_ventaHoteleria As Boolean = False
    Public bolGl_vtaHoteleriaFraccionado As Boolean = False
    Public banGl_ventaHoteleriaLoteStock As Boolean = False
    Public intGl_vtaHoteleriaIdLote As Integer = 0
    Public intGl_vtaHoteleriaIdCliente As Integer = 0
    Public intGl_vtaHoteleriaIdVendedor As Integer = 0

    '***********************************************
    ' VARIABLES PARA EL MODULO DE VENTAS DE HELADERIA
    '***********************************************
    '- variables enteras
    Public intGl_vtaHeladeriaIdCliente As Integer = 0
    Public intGl_vtaHeladeriaIdTipoVenta As Integer = 0
    Public intGl_vtaHeladeriaIdStock As Integer = 0
    Public intGl_vtaHeladeriaIdProducto As Integer = 0
    Public intGl_vtaHeladeriaTotalVenta As Integer = 0
    Public intGl_vtaHeladeriaTotalDescuento As Integer = 0
    Public intGl_vtaHeladeriaIdTarjetaDebito As Integer = 0
    Public intGl_vtaHeladeriaIdTarjetaCredito As Integer = 0
    Public intGl_nroVentaHeladeria As Integer = 0
    Public intGl_vtaHeladeriaCantidadCuota As Integer = 0
    Public intGl_vtaHeladeriaIdVendedor As Integer
    Public intGl_vtaHeladeriaIdVenta As Integer = 0

    '- variables caracteres
    Public strGl_vtaHeladeriaRucCliente As String = ""
    Public strGl_vtaHeladeriaCliente As String = ""
    Public strGl_vtaHeladeriaNombreFraccion As String = ""
    Public strGl_vtaHeladeriaFacturaManual As String = "0"
    Public strGl_vtaHeladeriaDsuc As String = ""
    Public strGl_vtaHeladeriaDcaja As String = ""
    '- variables doubles
    Public douGl_vtaHeladeriaPrecioProducto As Double = 0

    '-- variables booleanas
    Public bolGl_vtaHeladeriaPromoSamsung As Boolean = False
    Public bolGl_comboEstudiante As Boolean = False

    Public bolGl_vtaHeladeriaFraccionado As Boolean = False
    Public bolGl_vtaHeladeriaDescuento As Boolean = False
    Public bolGl_vtaHeladeriaFarmaciaVuelto As Boolean = False
    Public bolGl_vtaHeladeriaVendedorFarmacia As Boolean = False
    Public bolGl_vtaHeladeriaFiscal As Boolean = False
    Public bolGl_vtaHeladeriaImprimir As Boolean = False

    '************************************'
    ' VARIABLES PARA EL GRUPO DE USUARIO '
    '************************************'
    Public intGl_idGrupoUsuario As Integer
    '*************************************
    ' VARIABLES PARA EL MODULO DE COMPRAS 
    '*************************************
    '- varibles enteras
    Public intGl_comIdProveedor As Integer = 0
    Public intGl_nroCompra As Integer = 0
    '-- variables booleanas
    Public bolGl_comFraccionado As Boolean = False
    '**********************************************
    ' VARIABLES PARA EL MODULO DE NOTA DE CREDITO '
    '*********************************************
    '- varibles enteras
    Public intGl_nroNotaCredito As Integer = 0

    '****************************
    ' BANDERAS PARA LOS MODULOS ' 
    '****************************
    Public banGl_ventaFarmacia As Boolean = False
    Public banGl_compra As Boolean = False
    Public banGl_consultaCompra As Boolean = False
    Public banGl_buscarProveedor As Boolean = False
    Public banGl_buscarFacturaCompra As Boolean = False
    Public banGl_notacreditoCompra As Boolean = False
    Public banGl_buscarNotaCredito As Boolean = False
    Public banGl_consultaNotaCredito As Boolean = False
    Public banGl_notaCreditoVenta As Boolean = False
    Public banGl_buscarNotaDebito As Boolean = False
    Public banGl_descuentoGrupoCliente As Boolean = False
    Public banGl_ventaHeladeria As Boolean = False


    '**************************************
    ' VARIABLES DE MODULOS DE ANULACIONES '
    '**************************************
    Public banGl_anularCompra As Boolean = False
    Public banGl_anularVenta As Boolean = False
    Public banGl_anularNotaCredito As Boolean = False
    Public banGl_anularNotaDebito As Boolean = False

    '*****************************************
    ' VARIABLES DE MODULOS DE NOTA DE DEBITO '
    '*****************************************
    Public intGl_nroNotaDebito As Integer = 0
    Public banGl_notaDebito As Boolean = False

    '*********************************'
    ' VARIABLES DE LOS MODULOS DE ABM '
    '*********************************'
    Public banGl_abmPersona As Boolean = False
    Public banGl_abmProducto As Boolean = False

    '******************************************'
    ' VARIABLES PARA LA VENTANA DE LABORATORIO '
    '******************************************'
    Public banGl_labAbmProducto As Boolean = False

    '***********************************************'
    ' VARIABLES PARA LA VENTANA DE TIPO DE PRODUCTO '
    '***********************************************'
    Public banGl_tipoProdAbmProducto As Boolean = False

    '***************************************'
    ' VARIABLES PARA LA VENTANA DE DIVISION '
    '***************************************'
    Public banGl_divAbmProducto As Boolean = False

    '******************************************************'
    ' VARIABLES PARA LA VENTANA DE REFERENCIAR MERCADERIAS '
    '******************************************************'
    Public intGl_nroReferenciarMercaderia As Integer = 0

    '******************************************'
    ' VARIABLES PARA LA SABER EL IDLABORATORIO '
    '******************************************'
    Public intGl_idLaboratorio As Integer = 0

    '*************************************************************'
    ' VARIABLES PARA EL VENTATA DE DESCUENTO POR GRUPO DE CLIENTE '
    '*************************************************************'
    Public intGl_nroDescuentoGrupoCliente As Integer = 0

    '********************************************************'
    ' VARIABLES PARA LA LLAMAR LA VENTANA DE BUSCAR PRODUCTO '
    '********************************************************'
    '-- referenciar mercaderias
    Public bolGl_refMercaderias As Boolean = False
    Public bolGl_refMercaderiasDetalle As Boolean = False

    '********************************************'
    ' VARIABLES PARA EL MODULO DE ARQUEO DE CAJA '
    '********************************************'
    Public intGl_nroArqueoGuaranies As Integer = 0
    Public intGl_nroArqueoMoneda As Integer = 0
    Public intGl_nroArqueoGasto As Integer = 0
    Public intGl_nroArqueoCheque As Integer = 0
    Public intGl_nroArqueoCredito As Integer = 0
    Public intGl_nroArqueoTarjetaCredito As Integer = 0
    Public intGl_nroArqueoTarjetaDebito As Integer = 0
    Public intGl_nroArqueoWeb As Integer = 0
    Public intGl_idCaja As Integer = 0

    '**************************************************************'
    ' VARIABLES PARA EL MODULO DE PEDIDO DE MERCADERIAS A SUCURSAL '
    '**************************************************************'
    Public intGl_nroPedidoSucursal As Integer = 0
    Public banGl_pedidoMercaderiaSucursal As Boolean = False
    Public intGl_pedidoMercaderiaSucursalIdProducto As Integer = 0

    '******************************************************************'
    ' VARIABLES PARA EL MODULO DE REMISION DE MERCADERIAS A SUCURSALES '
    '******************************************************************'
    Public banGl_remisionSucursal As Boolean = False
    Public intGl_nroRemisionSucursal As Integer = 0

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE LA CONSULTA DE REMISION '
    '*****************************************************'
    Public banGl_buscarRemision As Boolean = False
    Public banGl_anularRemision As Boolean = False

    '***************************************************'
    ' VARIABLES PARA EL MODULO DEL SEGUIMIENTO DE STOCK '
    '***************************************************'
    Public banGl_seguimientoStock As Boolean = False
    Public intGl_idProductoSeguimientoStock As Integer = 0
    Public intGl_idDepositoSeguimientoStock As Integer = 0
    Public intGl_idStockSeguimientoStock As Integer = 0
    Public bolGl_busquedaVenceSeguimientoStock As Boolean = False

    '**********************************************'
    ' VARIABLES PARA EL MODULO DEL AJUSTE POSITIVO '
    '**********************************************'
    Public intGl_ajustePositivoIdSucursal As Integer = 0
    Public intGl_ajustePositivoIdDeposito As Integer = 0
    Public banGl_ajustePositivoMercaderia As Boolean = False
    Public intGl_nroAjustePositivoMercaderia As Integer = 0
    Public intGl_ajustePositivoIdProducto As Integer = 0

    '**********************************************'
    ' VARIABLES PARA EL MODULO DEL AJUSTE NEGATIVO '
    '**********************************************'
    Public intGl_ajusteNegativoIdSucursal As Integer = 0
    Public intGl_ajusteNegativoIdDeposito As Integer = 0
    Public banGl_ajusteNegativoMercaderia As Boolean = False
    Public intGl_nroAjusteNegativoMercaderia As Integer = 0
    Public intGl_ajusteNegativoIdProducto As Integer = 0

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE TABLA DE COTIZACION '
    '*************************************************'
    Public intGl_nroTablaCotizacion As Integer = 0
    Public banGl_tablaCotizacion As Boolean = False

    '*******************************************'
    ' VARIABLES PARA EL MODULO DE STOCK INICIAL '
    '*******************************************'
    Public banGl_stockInicial As Boolean = False
    Public intGl_nroStockInicial As Integer = 0
    Public intGl_stockInicialIdProducto As Integer = 0

    '********************************************'
    ' VARIABLES PARA EL MODULO DE CARGAR CHEQUES '
    '********************************************'
    Public banGl_cargarCheque As Boolean = False
    Public intGl_nroCargarCheque As Integer = 0

    '************************************************'
    ' VARIABLES PARA EL MODULO DE PAGO A PROVEEDORES '
    '************************************************'
    Public banGl_pagoProveedor As Boolean = False
    Public intGl_nroPagoProveedor As Integer = 0

    '******************************************************'
    ' VARIABLES PARA EL MODULO DE CARGAR DEPOSITO BANCARIO '
    '******************************************************'
    Public banGl_depositoBanco As Boolean = False
    Public intGl_nroDepositoBanco As Integer = 0

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DEPOSITO BANCARIO '
    '********************************************************'
    Public banGl_consultaDepositoBanco As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE PEDIDO DE SUCURSAL '
    '************************************************************'
    Public banGl_consultaPedidoSucursal As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE CONTROL DE REMISION '
    '*************************************************'
    Public banGl_controlRemision As Boolean = False

    '***************************************************'
    ' VARIABLES PARA EL MODULO DE CONTROL PRECIO ENTERO '
    '***************************************************'
    Public banGl_precioEntero As Boolean = False
    Public intGl_nroPrecioEntero As Integer = 0

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE CONTROL PRECIO FRACCIONADO '
    '********************************************************'
    Public banGl_precioFraccion As Boolean = False
    Public intGl_nroPrecioFraccion As Integer = 0

    '***************************************************************'
    ' VARIABLES PARA EL MODULO DE COLOCAR REPARTIDOR EN LA REMISION '
    '***************************************************************'
    Public banGl_remisionConRepartidor As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA RECEPCION '
    '************************************************'
    Public banGl_buscarRecepcion As Boolean = False
    Public banGl_consultaRecepcion As Boolean = False

    '***********************************'
    ' VARIABLES PARA EL MODULO DE CANJE '
    '***********************************'
    Public banGl_canje As Boolean = False
    Public intGl_nroCanje As Integer
    Public intGl_canjeIdDeposito As Integer

    '******************************************'
    ' VARIABLES PARA EL MODULO DE CONFIG EMAIL '
    '******************************************'
    Public banGl_configEmail As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE VENTAS '
    '************************************************'
    Public banGl_consultaVenta As Boolean = False
    Public intGl_consultaVentaTipo As Integer

    '**********************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE CAJA '
    '**********************************************'
    Public banGl_consultaArqueo As Boolean = False

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE AJUSTE POSITIVO DE CAJA '
    '*****************************************************'
    Public banGl_cajaMas As Boolean = False

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE AJUSTE NEGATIVO DE CAJA '
    '*****************************************************'
    Public banGl_cajaMenos As Boolean = False


    '********************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA CANJE '
    '********************************************'
    Public banGl_consultaCanje As Boolean = False
    Public banGl_buscarCanje As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE GENERACION DE CODIGO DE BARRAS '
    '************************************************************'
    Public banGl_generarCodigoBarraMercaderia As Boolean = False
    Public intGl_nroGenerarCodigoBarraMercaderia As Integer

    '**************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE REMISCION '
    '**************************************************'
    Public banGl_reporteRemision As Boolean = False

    '************************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE AJUSTE POSITIVO DE MERCADERIAS '
    '************************************************************************'
    Public banGl_consultaAjustePositivoMercaderia As Boolean = False
    Public banGl_buscarAjustePositivoMercaderia As Boolean = False

    '************************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE AJUSTE POSITIVO DE MERCADERIAS '
    '************************************************************************'
    Public banGl_consultaAjusteNegativoMercaderia As Boolean = False
    Public banGl_buscarAjusteNegativoMercaderia As Boolean = False

    '*******************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE STOCK INICIAL '
    '*******************************************************'
    Public banGl_buscarStockInicial As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE PEDIDO A PROVEEDOR '
    '************************************************'
    Public banGl_pedidoProveedor As Boolean = False
    Public banGl_pedidoProveedorDeASucursal As Boolean = False
    Public intGl_nroPedidoProveedor As Integer = 0
    Public intGl_cantidadPedidoProveedor As Integer = 0
    '-- para la parte de procesamiento
    Public banGl_procesandoPedidoProveedor As Boolean = False
    Public intGl_procesandoIdDepositoPedidoProveedor As Integer
    Public bolGl_procesandoAgruparSucursalPedidoProveedor As Boolean
    Public strGl_procesandoFechaDesdePedidoProveedor As String
    Public strGl_procesandoFechaHastaPedidoProveedor As String


    '************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE PEDIDO A PROVEEDOR '
    '************************************************************'
    Public banGl_consultaPedidoProveedor As Boolean = False
    Public banGl_buscarPedidoProveedor As Boolean = False

    '******************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE VENCIMIENTO DE MERCADERIA '
    '******************************************************************'
    Public banGl_reporteVencimientoMercaderia As Boolean = False

    '***********************************************'
    ' VARIABLES PARA EL MODULO DE DELIVERY DE VENTA '
    '***********************************************'
    Public banGl_deliveryVenta As Boolean = False
    Public banGl_deliveryVentaRecepcion As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE SALDO DE BANCOS '
    '********************************************************'
    Public banGl_reporteSaldoBanco As Boolean = False

    '********************************************'
    ' VARIABLES PARA EL MODULO DE CANCELAR CANJE '
    '********************************************'
    Public banGl_cancelarCanje As Boolean = False
    Public intGl_nroCancelarCanje As Integer = 0

    '***************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA NOTA DE CREDITO DE CANJE '
    '***************************************************************'
    Public banGl_consultaNotaCreditoCanje As Boolean = False
    Public banGl_buscarNotaCreditoCanje As Boolean = False

    '***************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE LIBRO IVA  '
    '***************************************************'
    Public banGl_reporteLibroIva As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA PAGO A PROVEEDORES '
    '*********************************************************'
    Public banGl_consultaPagoProveedor As Boolean = False
    Public banGl_buscarPagoProveedor As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE CHEQUES PENDIENTES  '
    '************************************************************'
    Public banGl_reporteChequePendiente As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE GASTOS DE PROVEEDOR '
    '*************************************************'
    Public intGl_nroGastoProveedor As Integer
    Public banGl_gastoProveedor As Boolean = False

    '***********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA GASTO DE PROVEEDORES '
    '***********************************************************'
    Public banGl_consultaGastoProveedor As Boolean = False
    Public banGl_buscarGastoProveedor As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE CHEQUES '
    '*************************************************'
    Public banGl_consultaCheque As Boolean = False
    Public intGl_idChequeConsultaCheque As Integer
    Public intGl_idChequeraConsultaCheque As Integer
    Public intGl_nroChequeConsultaCheque As Integer

    '***************************************************'
    ' VARIABLES PARA EL MODULO DE HISTORICO DE CLIENTES '
    '***************************************************'
    Public banGl_historicoCliente As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE HISTORICO DE COBRO DE CLIENTES '
    '************************************************************'
    Public banGl_cobroCliente As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE DELIVERY '
    '*************************************************'
    Public banGl_reporteDelivery As Boolean = False

    '*******************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA COBRO A CLIENTES '
    '*******************************************************'
    Public banGl_buscarCobroCliente As Boolean = False
    Public banGl_consultaCobroCliente As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE CARGA DE CREDITO DE SUCURSALES '
    '************************************************************'
    Public banGl_cargarVentaSucursal As Boolean = False
    Public intGl_nroCargarVentaSucursal As Integer = 0

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA VENTA DE SUCURSAL '
    '********************************************************'
    Public banGl_buscarVentaSucursal As Boolean = False
    Public banGl_consultaVentaSucursal As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE CARGA DE DESCUENTOS A CLIENTES '
    '************************************************************'
    Public banGl_cargarDescuentoCliente As Boolean = False

    '**************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE DESCUENTO DE CLIENTE '
    '**************************************************************'
    Public banGl_buscarDescuentoCliente As Boolean = False
    Public banGl_consultaDescuentoCliente As Boolean = False

    '****************************************'
    ' VARIABLES PARA EL MODULO DE INVENTARIO '
    '****************************************'
    Public banGl_inventario As Boolean = False

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE INVENTARIO '
    '****************************************************'
    Public banGl_buscarInventario As Boolean = False
    Public banGl_consultaInventario As Boolean = False

    '**********************************************'
    ' VARIABLES PARA EL MODULO DE NO INVENTARIADOS '
    '**********************************************'
    Public banGl_noinventariado As Boolean = False

    '*******************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE ARQUEO DE CAJA '
    '*******************************************************'
    Public banGl_reporteArqueoCaja As Boolean = False

    '****************************************************************'
    ' VARIABLES PARA EL MODULO DE CORRECCION DE CIERRE DE INVENTARIO '
    '****************************************************************'
    Public banGl_correccionInventario As Boolean = False

    '******************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE CORRECCION DE INVENTARIO '
    '******************************************************************'
    Public banGl_buscarCorreccionInventario As Boolean = False
    Public banGl_consultaCorreccionInventario As Boolean = False

    '*********************************************'
    ' VARIABLES PARA LA REUTILIZACION DE LA VENTA '
    '*********************************************'
    Public banGl_reutilizarVenta As Boolean = False

    '******************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE RECEPCION DE MERACEDERIAS '
    '******************************************************************'
    Public banGl_reporteRecepcionMercaderia As Boolean = False

    '*****************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE PRODUCTOS INVENTARIADOS '
    '*****************************************************************'
    Public banGl_consultaProductoInventariado As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE MERCADERIA EN GRAL. '
    '************************************************************'
    Public banGl_reporteMercaderiaGral As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE SALDO DE CLIENTE '
    '*********************************************************'
    Public banGl_reporteSaldoCliente As Boolean = False

    '*************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE HORARIO DEL PERSONAL '
    '*************************************************************'
    Public banGl_reporteHorarioPersonal As Boolean = False

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE MODIFICACION DE COSTOS '
    '****************************************************'
    Public intGl_nroModificaCosto As Integer = 0

    '*************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE PRODUCTO POR CLIENTE '
    '*************************************************************'
    Public banGl_reporteProductoCliente As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE MODIFICACION DE VENCIMIENTO '
    '*********************************************************'
    Public banGl_modificaVence As Boolean = False
    Public intGl_nroModiVence As Integer = 0

    '******************************************************'
    ' VARIABLES PARA EL MODULO DE ORDEN DE PAGO DEL CHEQUE '
    '******************************************************'
    Public banGl_OrdenPagoCheque As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE ORDEN DE CHEQUES'
    '*********************************************************'
    Public banGl_buscarOrdenCheque As Boolean = False
    Public banGl_consultaOrdenCheque As Boolean = False

    '**********************************************'
    ' VARIABLES PARA EL MODULO DE REMISION EXPRESS '
    '**********************************************'
    Public banGl_remisionExpress As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE REMISION PENDIENTE '
    '************************************************'
    Public banGl_remisionPendiente As Boolean = False

    '***************************************************************'
    ' VARIABLES PARA EL MODULO DE LA CONSULTA DE REMISION PENDIENTE '
    '***************************************************************'
    Public banGl_consultaRemisionPendiente As Boolean = False
    Public banGl_buscarRemisionPendiente As Boolean = False

    '*************************************************************************'
    ' VARIABLES PARA EL MODULO DE COLOCAR REPARTIDOR EN LA REMISION PENDIENTE '
    '*************************************************************************'
    Public banGl_remisionPendienteConRepartidor As Boolean = False

    '**************************************************************************'
    ' VARIABLES PARA EL MODULO DE COLOCAR REPARTIDOR EN LA RECEPCION PENDIENTE '
    '**************************************************************************'
    Public banGl_recepcionPendienteConRepartidor As Boolean = False

    '****************************************************************'
    ' VARIABLES PARA EL MODULO DE COLOCAR REPARTIDOR EN LA RECEPCION '
    '****************************************************************'
    Public banGl_recepcionConRepartidor As Boolean = False

    '*************************************************************'
    ' VARIABLES PARA EL MODULO DE COLOCAR ACTIVIDAD AL REPARTIDOR '
    '*************************************************************'
    Public banGl_actividadRepartidor As Boolean = False

    '***********************************************************************'
    ' VARIABLES PARA EL MODULO DE LA CONSULTA DE ACTIVIDADES DEL REPARTIDOR '
    '***********************************************************************'
    Public banGl_consultaActividadRepartidor As Boolean = False
    Public banGl_buscarActividadRepartidor As Boolean = False

    '***************************************************'
    ' VARIABLES PARA EL MODULO DE FACTURACION FARMACIA1 '
    '***************************************************'
    Public banGl_ventaFarmacia1 As Boolean = False
    Public banGl_ventaFarmacia1LoteStock As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO DEL BLACK FRIDAY '
    '********************************************************'
    Public banGl_descuentoBlackFriday As Boolean = False

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE CONFIGURACION DE CUOTAS '
    '*****************************************************'
    Public intGl_nroconfiguracionCuota As Integer = 0

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE PROVEEDORES '
    '****************************************************'
    Public banGl_reporteProveedor As Boolean = False

    '*********************************************'
    ' VARIABLES PARA EL MODULO DE GASTO DE VENTAS '
    '*********************************************'
    Public banGl_gastoVenta As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE GASTO DE VENTAS '
    '*********************************************************'
    Public banGl_consultaGastoVenta As Boolean = False
    Public banGl_buscarGastoVenta As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE ESTADISTICA DE PROVEEDORES '
    '********************************************************'
    Public banGl_estadisticaProveedor As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE PUNTAJE DE CLIENTES '
    '*************************************************'
    Public intGl_nroPuntajeCliente As Integer = 0
    Public intGl_nroPuntajeClienteProducto As Integer = 0
    Public banGl_puntajeCliente As Boolean = False

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE ESTADISTICA DE CLIENTES '
    '*****************************************************'
    Public banGl_estadisticaCliente As Boolean = False

    '*******************************************'
    ' VARIABLES PARA EL MODULO DE TELEMARKETING '
    '*******************************************'
    Public banGl_telemarketing As Boolean = False
    Public intGl_telemarketingProceso As Integer = 0


    '*********************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE PEDIDO A SUCURSAL A REMITIR '
    '*********************************************************************'
    Public banGl_consultaPedidoASucursal As Boolean = False

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO EN CONVENIOS '
    '****************************************************'
    Public banGl_descuentoConvenio As Boolean = False
    Public intGl_nroDescuentoConvenio As Integer = 0

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE PRECIO POR SUCURSAL '
    '*************************************************'
    Public banGl_precioSucursal As Boolean = False

    '***********************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO BLACKFRIDAY EXPRESS '
    '***********************************************************'
    Public banGl_descuentoBlackfrideyExpress As Boolean = False

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE MERCADERIAS CONTROLADAS '
    '*****************************************************'
    Public banGl_mercaderiaControlada As Boolean = False

    '*****************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE MERCADERIAS CONTROLADAS '
    '*****************************************************************'
    Public banGl_consultaMercaderiaControlada As Boolean = False
    Public banGl_buscarMercaderiaControlada As Boolean = False

    '***************************************************'
    ' VARIABLES PARA EL MODULO DE FRACCIONAR MERCADERIAS'
    '***************************************************'
    Public banGl_fraccionarMercaderia As Boolean = False

    '****************************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO DE LABORATORIO Y DIVISION'
    '****************************************************************'
    Public banGl_descuentoLaboratorioDivision As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE MODIFICACION DE FRACCIONADO'
    '********************************************************'
    Public banGl_modificarFracionado As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE CONFIGURACION DE PC'
    '************************************************'
    Public banGl_abmConfigPc As Boolean = False
    Public banGl_abmConfigPcNcr As Boolean = False
    Public intGl_abmIdSucursalConfig As Integer = 0

    '**********************************************************************'
    ' VARIABLES PARA EL MODULO DE MAS DE UN LOTE EN EL DETALLE REFERENCIADO'
    '**********************************************************************'
    Public banGl_masLoteReferencia As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE CHECKIN EN EL HOTEL'
    '************************************************'
    Public banGl_hotelCheckIn As Boolean = False

    '*******************************************'
    ' VARIABLES PARA EL MODULO DE ITEM CONTABLE '
    '*******************************************'
    Public banGl_itemContable As Boolean = False
    Public intGl_itemContableIdEmpresaContable As Integer = 0

    '********************************************'
    ' VARIABLES PARA EL MODULO DE VENTA CONTABLE '
    '********************************************'
    Public banGl_ventaContablePlanCuenta1 As Boolean = False
    Public banGl_ventaContablePlanCuenta2 As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE VENTA CONTABLE '
    '********************************************************'
    Public banGl_consultaVentaContable As Boolean = False

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE NUEVO ASIENTO CONTABLE '
    '****************************************************'
    Public banGl_nuevoAsientoContable As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE GENERAR ASIENTOS CONTABLES '
    '********************************************************'
    Public banGl_generarAsientoContable As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTES CONTABLES '
    '************************************************'
    Public banGl_reporteContable As Boolean = False

    '**********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA PRESTAMOS BANCARIOS '
    '**********************************************************'
    Public banGl_consultaPrestamoBancario As Boolean = False
    Public banGl_buscarPrestamoBancario As Boolean = False

    '**************************************************************'
    ' VARIABLES PARA EL MODULO DE CARGAR PAGO DE PRESTAMO BANCARIO '
    '**************************************************************'
    Public banGl_pagoPrestamoBancario As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE METAS DE VENDEDORES '
    '*************************************************'
    Public banGl_metaVendedor As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE ABM PLAN DE CUENTAS'
    '************************************************************'
    Public banGl_abmPlanCuenta As Boolean = False
    Public bolGl_abmPlanCuentaPadre As Boolean = False

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE CONSUMICION EN EL HOTEL'
    '****************************************************'
    Public banGl_consumicionHotel As Boolean = False

    '*************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA CONSUMICION EN EL HOTEL'
    '*************************************************************'
    Public banGl_consultaConsumicionHotel As Boolean = False
    Public banGl_buscarConsumicionHotel As Boolean = False

    '*************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA FACTURACION EN EL HOTEL'
    '*************************************************************'
    Public banGl_consultaFacturacionHotel As Boolean = False
    Public banGl_buscarFacturacionHotel As Boolean = False
    Public intGl_consultaFacturaHotelTipo As Integer = 1

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE RETENCION DE PROVEEDOR '
    '****************************************************'
    Public banGl_retencionProveedor As Boolean = False

    '****************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE RETENCION DE PROVEEDOR '
    '****************************************************************'
    Public banGl_consultaRetencionProveedor As Boolean = False
    Public banGl_buscarRetencionProveedor As Boolean = False

    '*********************************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE ENTREGA DE PREMIO A CLIENTES '
    '*********************************************************************'
    Public banGl_reporteClientePremio As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE ESTADISTICAS DE TELE MARKETING '
    '************************************************************'
    Public banGl_estadisticaTelemark As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE CARGAR MENU DEL RESTAURANTE '
    '*********************************************************'
    Public banGl_cargarMenuResto As Boolean = False

    '**********************************************************'
    ' VARIABLES PARA EL MODULO DE CARGAR STOCK DEL RESTAURANTE '
    '**********************************************************'
    Public banGl_cargarStockMercaderiaResto As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE FACTURACION DEL RESTAURANTE '
    '*********************************************************'
    Public banGl_facturacionResto As Boolean = False

    '***********************************************'
    ' VARIABLES PARA EL MODULO DE ENTREGA DE EVENTO '
    '***********************************************'
    Public banGl_entregaEvento As Boolean = False

    '********************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA FACTURACION EN EL RESTAURANTE '
    '********************************************************************'
    Public banGl_consultaFacturacionResto As Boolean = False
    Public banGl_buscarFacturacionResto As Boolean = False
    Public intGl_consultaFacturaRestoTipo As Integer = 1

    '***************************************'
    ' VARIABLES PARA EL MODULO DE CHECK OUT '
    '***************************************'
    Public banGl_checkOut As Boolean = False
    Public banGl_checkOutOtraFactura As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE HISTORIAL DE LA CONSUMISION '
    '*********************************************************'
    Public banGl_historialConsume As Boolean = False

    '**********************************************'
    ' VARIABLES PARA EL MODULO DE FACTURAR EVENTOS '
    '**********************************************'
    Public banGl_facturarEvento As Boolean = False

    '*************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA FACTURACION DE EVENTOS '
    '*************************************************************'
    Public banGl_consultaFacturacionEvento As Boolean = False
    Public banGl_buscarFacturacionEvento As Boolean = False
    Public intGl_consultaFacturaEventoTipo As Integer = 1

    '************************************************'
    ' VARIABLES PARA EL MODULO DE HABILITAR FACTURAS '
    '************************************************'
    Public banGl_habilitarFactura As Boolean = False

    '*****************************************************'
    ' VARIABLES PARA EL MODULO DE LA CONSULTA DE DESAYUNO '
    '*****************************************************'
    Public banGl_consultaDesayunoResto As Boolean = False

    '*******************************************************************'
    ' VARIABLES PARA EL MODULO DE PEDIDO DEL RESTAURANTE PARA LA TABLET '
    '*******************************************************************'
    Public intGl_idTipoRestoTablet As Integer = 0
    Public intGl_tipoRestoTablet As Integer = 0

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTES DE COMPRA Y GASTO '
    '********************************************************'
    Public banGl_reporteCompraGasto As Boolean = False

    '***********************************************'
    ' VARIABLES PARA EL MODULO DE PRECIO DE BELLINI '
    '***********************************************'
    Public banGl_precioBellini As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE CHECKIN '
    '*************************************************'
    Public banGl_buscarCheckIn As Boolean = False
    Public banGl_consultaCheckIn As Boolean = False

    '**********************************************'
    ' VARIABLES PARA EL MODULO DE AGREGADO BELLINI '
    '**********************************************'
    Public banGl_agregadoBellini As Boolean = False

    '**************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA USO INTERNO '
    '**************************************************'
    Public banGl_buscarUsoInterno As Boolean = False
    Public banGl_consultaUsoInterno As Boolean = False

    '***************************************************'
    ' VARIABLES PARA EL MODULO DE SEGUIMIENTO DE PLATOS '
    '***************************************************'
    Public banGl_seguimientoPlato As Boolean = False

    '**********************************************************'
    ' VARIABLES PARA EL MODULO DE QUITAR MAXIPUNTO AL PERSONAL '
    '**********************************************************'
    Public banGl_quitarMaxipuntoPersonal As Boolean = False

    '******************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA CARGA DE PASTAS '
    '******************************************************'
    Public banGl_buscarCargaPasta As Boolean = False
    Public banGl_consultaCargaPasta As Boolean = False

    '*********************************************************************************'
    ' VARIABLES PARA EL MODULO DE PRECIO DE MERCADERIAS POR PORCENTAJE DE LABORATORIO '
    '*********************************************************************************'
    Public banGl_porcentajePrecioLabo As Boolean = False

    '**************************************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE MODIFICACION DE PRECIOS DE PRODUCTOS ENTEROS '
    '**************************************************************************************'
    Public banGl_buscarModificaPrecioEntero As Boolean = False
    Public banGl_consultaModificaPrecioEntero As Boolean = False

    '******************************************************'
    ' VARIABLES PARA EL MODULO DE MODDIFICACION DE CHEQUES '
    '******************************************************'
    Public banGl_modificacionCheque As Boolean = False

    '***********************************************'
    ' VARIABLES PARA EL MODULO DE PLANILLA DE CAJAS '
    '***********************************************'
    Public banGl_planillaCaja As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA PLANILLA DE CAJAS '
    '********************************************************'
    Public banGl_buscarPlanillaCaja As Boolean = False
    Public banGl_consultaPlanillaCaja As Boolean = False

    '***********************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE CANJES '
    '***********************************************'
    Public banGl_reporteCanje As Boolean = False

    '*************************************************************************'
    ' VARIABLES PARA EL MODULO DE RECEPCION DESDE CANJE DE CUALQUIER DEPOSITO '
    '*************************************************************************'
    Public banGl_recepcionCanje As Boolean = False

    '*******************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO POR FECHA CORTA '
    '*******************************************************'
    Public banGl_descuentoFechaCorta As Boolean = False

    '******************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA DE LA PROMO DE SAMSUNG CLUB '
    '******************************************************************'
    Public banGl_consultaPromoSamsung As Boolean = False

    '***************************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO POR LABORATORIO - NUEVO '
    '***************************************************************'
    Public banGl_descLaboratorioNuevo As Boolean = False

    '**********************************************************'
    ' VARIABLES PARA EL MODULO DE REPORTE DE VENTAS DE CLIENTES'
    '**********************************************************'
    Public banGl_reporteClienteVenta As Boolean = False
    Public intGl_idClienteReporteVenta As Integer = 0

    '*******************************************************'
    ' VARIABLES PARA EL MODULO DE CANCELAR CANJES PENDINTES '
    '*******************************************************'
    Public banGl_cancelaCanjePendiente As Boolean = False
    Public intGl_idProveedorCanje As Integer = 0

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA CANCELA CANJE '
    '****************************************************'
    Public banGl_consultaCanjecalCanje As Boolean = False
    Public banGl_buscaCancelaCanje As Boolean = False

    '*******************************************************'
    ' VARIABLES PARA EL MODULO DE NOTA DE CERDITO POR CANJE '
    '*******************************************************'
    Public banGl_notaCreditoCanje As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE ACCION TERAPEUTICA '
    '************************************************'
    Public banGl_accionTerapeutica As Boolean = False

    '***********************************************************'
    ' VARIABLES PARA EL MODULO DE BUSCAR LAS DROGAS Y SIMILARES '
    '***********************************************************'
    Public banGl_vtaSimilares As Boolean = False
    Public banGl_vtaDroga1 As Boolean = False
    Public banGl_vtaDroga2 As Boolean = False

    '***************************************************************'
    ' VARIABLES PARA EL MODULO DE GENERACION DE FACTURA ELECTRONICA '
    '***************************************************************'
    Public banGl_errorDTE As Boolean = False

    '***********************************************'
    ' VARIABLES PARA EL MODULO DE ABM FIRMA DIGITAL '
    '***********************************************'
    Public banGl_abmFirmaDigital As Boolean = False

    '******************************************************'
    ' VARIABLES PARA EL MODULO DE ABM TIMBRADO ELECTRONICO '
    '******************************************************'
    Public banGl_abmTimbradoDE As Boolean = False

    '*********************************************************'
    ' VARIABLES PARA EL MODULO DE GENERAR FACTURA ELECTRONICA '
    '*********************************************************'
    Public banGl_generaFE As Boolean = False

    '******************************************************'
    ' VARIABLES PARA EL MODULO DE ORDEN DE PREPARADO CORAL '
    '******************************************************'
    Public banGl_ordenCoral As Boolean = False

    '********************************************************'
    ' VARIABLES PARA EL MODULO DE ORDEN DE PREPARADO SUVINIL '
    '********************************************************'
    Public banGl_ordenSuvinil As Boolean = False

    '***********************************************************'
    ' VARIABLES PARA EL MODULO DE ORDEN DE PREPARADO AUTOMOTIVE '
    '***********************************************************'
    Public banGl_ordenAutomotive As Boolean = False

    '************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA ORDEN PREPARADO CORAL '
    '************************************************************'
    Public banGl_consultaOrdenCoral As Boolean = False
    Public banGl_buscarOrdenCoral As Boolean = False

    '**************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA ORDEN PREPARADO SUVINIL '
    '**************************************************************'
    Public banGl_consultaOrdenSuvinil As Boolean = False
    Public banGl_buscarOrdenSuvinil As Boolean = False

    '*****************************************************************'
    ' VARIABLES PARA EL MODULO DE CONSULTA ORDEN PREPARADO AUTOMOTIVE '
    '*****************************************************************'
    Public banGl_consultaOrdenAutomotive As Boolean = False
    Public banGl_buscarOrdenAutomotive As Boolean = False

    '************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO ESPECIAL '
    '************************************************'
    Public banGl_descuentoEspecial As Boolean = False

    '*********************************************************************'
    ' VARIABLES PARA EL MODULO DE DESCUENTO ESPECIAL POR GRUPO DE CLIENTE '
    '*********************************************************************'
    Public banGl_descuentoEspecialGrupoCliente As Boolean = False

    '****************************************************'
    ' VARIABLES PARA EL MODULO DE COBRO DE CLIENTE NUEVO '
    '****************************************************'
    Public banGl_cobroClienteNuevo As Boolean = False

    '**************************************************'
    ' VARIABLES PARA EL MODULO DE DEVOLUCION DE COMPRA '
    '**************************************************'
    Public banGl_devolucionCompra As Boolean = False

    '*************************************************'
    ' VARIABLES PARA EL MODULO DE RECEPCION DE COMPRA '
    '*************************************************'
    Public banGl_recepcionCompra As Boolean = False

    '******************************************************************'
    ' VARIABLES PARA EL MODULO NOTA DE CREDITO POR MONTO DEL PROVEEDOR '
    '******************************************************************'
    Public banGl_notacreditoMonto As Boolean = False
    Public intGl_nroNotaCreditoMonto As Integer = 0

End Module
