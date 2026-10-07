Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Deployment.Application
Imports System.Net
Imports System.IO

'Imports Neurotec
Public Class frmMenuPrincipal
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim strTecla As String

    Sub New()
        'lvPersona.
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    '-- crea la marquesina de las noticias del sistema
    Private Sub Marquee(ByVal aCtrl As Control, ByVal Direction As Byte, Optional ByVal Speed As Integer = 3)
        Select Case Direction
            Case 0 'Leftwards
                If aCtrl.Left <= 0 - aCtrl.Width Then
                    aCtrl.Left = Me.Width
                Else
                    aCtrl.Left = aCtrl.Left - Speed
                End If
            Case 1 'Rightwards
                If aCtrl.Left >= Me.Width Then
                    aCtrl.Left = 0 - aCtrl.Width
                Else
                    aCtrl.Left = aCtrl.Left + Speed
                End If
            Case 2 'Upwards
                If aCtrl.Top <= 0 - aCtrl.Height Then
                    aCtrl.Top = Me.Height
                Else
                    aCtrl.Top = aCtrl.Top - Speed
                End If
            Case 3 'Downwards
                If aCtrl.Top >= Me.Height Then
                    aCtrl.Top = 0 - aCtrl.Height
                Else
                    aCtrl.Top = aCtrl.Top + Speed
                End If
        End Select
    End Sub
    '----------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmMenuPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- el valor a la etiqueta de mensaje
        lblMensaje.Text = sp_datosTabla.un_datoString("mensajeMenuPrincipal", "configEmpresa", "idEntidad", intGl_idEntidad)
        '-- activar el timer del mensaje
        Timer2.Start()
        '-- el reloj de la computadora
        'MsgBox("Paso 1")
        relojPrincipal()
        'MsgBox("Paso 2")
        '-- para el detalle de los menus
        establecerMenuPrincipal(MenuStrip1)
        'MsgBox("Paso 3")
        '-- el menu para el horario
        If (sp_datosTabla.un_dato_boleano("habilitarHorario", "configPc", "idConfig", intGl_idConfigPc)) = True Then
            horario.Enabled = True
        Else
            horario.Enabled = False
        End If
        'MsgBox("Paso 4")
        '-- el menu de facturacion de hoteleria si la sucursal es un hotel
        'If bolGl_hoteleria = True Then
        '    clienteFacturacionHoteleria.Enabled = True
        'Else
        '    clienteFacturacionHoteleria.Enabled = False
        'End If

    End Sub

    '--- para no salir con Alt+f4
    Private Sub frmMenuPrincipal_unload(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub relojPrincipal() Handles Timer1.Tick
        lblHora.Text = TimeOfDay
    End Sub

    Private Sub frmMenuPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    '**************'
    '-- EL TIMER --'
    '**************'
    '-- para realizar la marquesina del mensaje del menu principal
    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Marquee(lblMensaje, 0, 3)
    End Sub

    '--------------------------------------------------------------------------------
    '***********************'
    '-- ITEM DE LOS MENUS --'
    '***********************'

    '*********'
    '-- ABM --'
    '*********'
    '-- persona
    Private Sub PersonaEntidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abmPersonaEntidad.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmPersonaEntidad.Enabled = False

        frmAbmPeronaNuevo.WindowState = FormWindowState.Normal
        frmAbmPeronaNuevo.Show()
        frmAbmPeronaNuevo.BringToFront()
    End Sub
    '-- impuesto
    Private Sub ImpuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abmMercaderiaImpuesto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------

        frmAbmImpuesto.WindowState = FormWindowState.Normal
        frmAbmImpuesto.Show()
        frmAbmImpuesto.BringToFront()
    End Sub
    '-- tipo
    Private Sub TipoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abmTipo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------

        abmTipo.Enabled = False
        frmAbmTipo.WindowState = FormWindowState.Normal
        frmAbmTipo.Show()
        frmAbmTipo.BringToFront()

    End Sub
    '-- producto
    Private Sub ProductoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abmMercaderiaProducto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmMercaderiaProducto.Enabled = False

        frmAbmProducto.WindowState = FormWindowState.Normal
        frmAbmProducto.Show()
        frmAbmProducto.BringToFront()
        frmAbmProducto.txtBuscar.Focus()

    End Sub
    '-- abm tipo de producto
    Private Sub abmTipoProducto_Click(sender As System.Object, e As System.EventArgs) Handles abmTipoProducto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmTipoProducto.Enabled = False

        frmAbmTipoProducto.WindowState = FormWindowState.Normal
        frmAbmTipoProducto.Show()
        frmAbmTipoProducto.BringToFront()
    End Sub

    '-- abm deposito
    Private Sub abmDeposito_Click(sender As System.Object, e As System.EventArgs) Handles abmDeposito.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        'abmDeposito.Enabled = False
        abmDeposito.Enabled = False

        frmAbmDeposito.WindowState = FormWindowState.Normal
        frmAbmDeposito.Show()
        frmAbmDeposito.BringToFront()
    End Sub
    '-- abm cargo
    Private Sub abmCargoEmpleado_Click(sender As System.Object, e As System.EventArgs)
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        ' abmCargoEmpleado.Enabled = False

        frmCargo.WindowState = FormWindowState.Normal
        frmCargo.Show()
        frmCargo.BringToFront()
    End Sub
    '-- abm motivo de ajuste
    Private Sub abmMotivoAjuste_Click(sender As System.Object, e As System.EventArgs) Handles abmMotivoAjuste.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmMotivoAjuste.Enabled = False

        frmAbmMotivoAjuste.WindowState = FormWindowState.Normal
        frmAbmMotivoAjuste.Show()
        frmAbmMotivoAjuste.BringToFront()
    End Sub
    '-- abm pais
    Private Sub abmPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abmPais.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmPais.Enabled = False

        frmAbmPais.WindowState = FormWindowState.Normal
        frmAbmPais.Show()
        frmAbmPais.BringToFront()
    End Sub
    '-- abm grupo de cliente
    Private Sub abmGrupoCliente_Click(sender As System.Object, e As System.EventArgs) Handles abmGrupoCliente.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmGrupoCliente.Enabled = False

        frmAbmGrupoCliente.WindowState = FormWindowState.Normal
        frmAbmGrupoCliente.Show()
        frmAbmGrupoCliente.BringToFront()
    End Sub
    '-- abm color
    Private Sub abmColor_Click(sender As System.Object, e As System.EventArgs) Handles abmColor.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        abmColor.Enabled = False

        frmAbmColor.WindowState = FormWindowState.Normal
        frmAbmColor.Show()
        frmAbmColor.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- CLIENTE --'
    '*************'
    '-- devolucion de venta
    Private Sub DevoluciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clienteDevolucion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteDevolucion.Enabled = False

        frmDevolucionVenta.WindowState = FormWindowState.Normal
        frmDevolucionVenta.Show()
        frmDevolucionVenta.BringToFront()
        frmDevolucionVenta.btnNuevo.Focus()
    End Sub
    '-- consulta devolucion de venta
    Private Sub NotaDeCréditoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clienteConsultaNotaCredito.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        'clientecon
        clienteConsultaNotaCredito.Enabled = False

        frmConsultaDevolucionVenta.WindowState = FormWindowState.Normal
        frmConsultaDevolucionVenta.Show()
        frmConsultaDevolucionVenta.BringToFront()
    End Sub
    '-- consulta de ventas
    Private Sub clienteConsultaVentas_Click(sender As System.Object, e As System.EventArgs) Handles clienteConsultaVentas.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteConsultaVentas.Enabled = False

        frmConsultaVenta.WindowState = FormWindowState.Normal
        frmConsultaVenta.Show()
        frmConsultaVenta.BringToFront()
    End Sub
    '-- reporte control sobre ventas
    Private Sub clienteReportesControlVenta_Click(sender As System.Object, e As System.EventArgs) Handles clienteReportesControlVenta.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteReportesControlVenta.Enabled = False

        frmReporteControlVenta.WindowState = FormWindowState.Normal
        frmReporteControlVenta.Show()
        frmReporteControlVenta.BringToFront()
    End Sub
    '-- reporte venta
    Private Sub clienteReportesVenta_Click(sender As System.Object, e As System.EventArgs) Handles clienteReportesVenta.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteReportesVenta.Enabled = False

        frmReporteVenta.WindowState = FormWindowState.Normal
        frmReporteVenta.Show()
        frmReporteVenta.BringToFront()
    End Sub
    '-- historico de clientes
    Private Sub clienteConsultaHistorico_Click(sender As System.Object, e As System.EventArgs) Handles clienteConsultaHistorico.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteConsultaHistorico.Enabled = False

        frmHistoricoCliente.WindowState = FormWindowState.Normal
        frmHistoricoCliente.Show()
        frmHistoricoCliente.BringToFront()
    End Sub
    '-- cobro a clientes
    Private Sub clienteCobro_Click(sender As System.Object, e As System.EventArgs) Handles clienteCobro.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteCobro.Enabled = False
        frmCobroClienteNuevo.WindowState = FormWindowState.Normal
        frmCobroClienteNuevo.Show()
        frmCobroClienteNuevo.BringToFront()
    End Sub
    '-- reporte de delivery
    Private Sub clienteReportesDelivery_Click(sender As System.Object, e As System.EventArgs) Handles clienteReportesDelivery.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteReportesDelivery.Enabled = False
        frmReporteDelivery.WindowState = FormWindowState.Normal
        frmReporteDelivery.Show()
        frmReporteDelivery.BringToFront()
    End Sub
    '-- consulta de la cobranza
    Private Sub clienteConsultaCobranza_Click(sender As System.Object, e As System.EventArgs) Handles clienteConsultaCobranza.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteConsultaCobranza.Enabled = False
        frmConsultaCobro.WindowState = FormWindowState.Normal
        frmConsultaCobro.Show()
        frmConsultaCobro.BringToFront()
    End Sub
    '-- reporte de saldo de cliente
    Private Sub clienteReportesSaldoCliente_Click(sender As System.Object, e As System.EventArgs) Handles clienteReportesSaldoCliente.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteReportesSaldoCliente.Enabled = False
        frmReporteSaldoCliente.WindowState = FormWindowState.Normal
        frmReporteSaldoCliente.Show()
        frmReporteSaldoCliente.BringToFront()
    End Sub
    '-- reporte de cliente por producto
    Private Sub clienteReportesClienteMercaderia_Click(sender As System.Object, e As System.EventArgs) Handles clienteReportesClienteMercaderia.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteReportesClienteMercaderia.Enabled = False
        frmReporteClienteProducto.WindowState = FormWindowState.Normal
        frmReporteClienteProducto.Show()
        frmReporteClienteProducto.BringToFront()
    End Sub
    '-- estadisticas de clientes
    Private Sub ClienteEstadisticas_Click(sender As System.Object, e As System.EventArgs) Handles ClienteEstadisticas.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        ClienteEstadisticas.Enabled = False
        frmEstadisticaClientes.WindowState = FormWindowState.Normal
        frmEstadisticaClientes.Show()
        frmEstadisticaClientes.BringToFront()
    End Sub
    '-- facturacion farmacia 1
    Private Sub clienteFacturacionFarmacia1_Click(sender As System.Object, e As System.EventArgs) Handles clienteFacturacionFarmacia1.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteFacturacionFarmacia1.Enabled = False
        frmVentaFarmacia1.WindowState = FormWindowState.Normal
        frmVentaFarmacia1.Show()
        frmVentaFarmacia1.BringToFront()
    End Sub
    '-- orden de preparado automotive
    Private Sub clienteOrdenPreparadoAutomotive_Click(sender As System.Object, e As System.EventArgs) Handles clienteOrdenPreparadoAutomotive.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteOrdenPreparadoAutomotive.Enabled = False
        frmOrdenPreparadoAutomotive.WindowState = FormWindowState.Normal
        frmOrdenPreparadoAutomotive.Show()
        frmOrdenPreparadoAutomotive.BringToFront()
    End Sub
    '-- orden de preparado coral
    Private Sub clienteOrdenPreparadoCoral_Click(sender As System.Object, e As System.EventArgs) Handles clienteOrdenPreparadoCoral.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteOrdenPreparadoCoral.Enabled = False
        frmOrdenPreparadoCoral.WindowState = FormWindowState.Normal
        frmOrdenPreparadoCoral.Show()
        frmOrdenPreparadoCoral.BringToFront()
    End Sub
    '-- orden de preparado suvinil
    Private Sub clienteOrdenPreparadoSuvinil_Click(sender As System.Object, e As System.EventArgs) Handles clienteOrdenPreparadoSuvinil.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteOrdenPreparadoSuvinil.Enabled = False
        frmOrdenPreparadoSuvinil.WindowState = FormWindowState.Normal
        frmOrdenPreparadoSuvinil.Show()
        frmOrdenPreparadoSuvinil.BringToFront()
    End Sub
    '-- consulta orden coral
    Private Sub clienteConsultaOrdenCoral_Click(sender As System.Object, e As System.EventArgs) Handles clienteConsultaOrdenCoral.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteConsultaOrdenCoral.Enabled = False
        frmConsultaPreparadoCoral.WindowState = FormWindowState.Normal
        frmConsultaPreparadoCoral.Show()
        frmConsultaPreparadoCoral.BringToFront()
    End Sub
    '-- consulta orden suvinil
    Private Sub clienteConsultaOrdenSuvinil_Click(sender As System.Object, e As System.EventArgs) Handles clienteConsultaOrdenSuvinil.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteConsultaOrdenSuvinil.Enabled = False
        frmConsultaPreparadoSuvinil.WindowState = FormWindowState.Normal
        frmConsultaPreparadoSuvinil.Show()
        frmConsultaPreparadoSuvinil.BringToFront()
    End Sub
    '-- consulta automotive
    Private Sub clienteConsultaOrdenAutomotive_Click(sender As System.Object, e As System.EventArgs) Handles clienteConsultaOrdenAutomotive.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteConsultaOrdenAutomotive.Enabled = False
        frmConsultaPreparadoAutomotive.WindowState = FormWindowState.Normal
        frmConsultaPreparadoAutomotive.Show()
        frmConsultaPreparadoAutomotive.BringToFront()
    End Sub
    '-- reporte de cobranza
    Private Sub clienteReportesClienteCobro_Click(sender As System.Object, e As System.EventArgs) Handles clienteReportesClienteCobro.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        clienteReportesClienteCobro.Enabled = False
        frmReporteCobros.WindowState = FormWindowState.Normal
        frmReporteCobros.Show()
        frmReporteCobros.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '***************'
    '-- PROVEEDOR --'
    '***************'
    '-- compras
    Private Sub FacturaDeCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorFacturaCompra.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorFacturaCompra.Enabled = False

        frmCompras.WindowState = FormWindowState.Normal
        frmCompras.Show()
        frmCompras.BringToFront()
    End Sub
    '-- consulta de compras
    Private Sub FacturaDeCompraToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorConsultaFacturaCompra.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorConsultaFacturaCompra.Enabled = False

        frmConsultaCompra.WindowState = FormWindowState.Normal
        frmConsultaCompra.Show()
        frmConsultaCompra.BringToFront()
    End Sub
    '-- nota de credito
    Private Sub NotaDeCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorNotaCredito.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorNotaCredito.Enabled = False

        frmNotaCreditoProveedor.WindowState = FormWindowState.Normal
        frmNotaCreditoProveedor.Show()
        frmNotaCreditoProveedor.BringToFront()
    End Sub
    '-- consulta nota de credito
    Private Sub ConsultaNotaDeCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorConsultaNotaCredito.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorConsultaNotaCredito.Enabled = False

        frmConsultaNotaCredito.WindowState = FormWindowState.Normal
        frmConsultaNotaCredito.Show()
        frmConsultaNotaCredito.BringToFront()
    End Sub
    '-- pago a proveedor
    Private Sub proveedorPagoProveedor_Click(sender As System.Object, e As System.EventArgs) Handles proveedorPagoProveedor.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorPagoProveedor.Enabled = False

        frmPagoProveedor.WindowState = FormWindowState.Normal
        frmPagoProveedor.Show()
        frmPagoProveedor.BringToFront()
    End Sub
    '-- consulta de pago a proveedor
    Private Sub proveedorConsultaPagoProveedor_Click(sender As System.Object, e As System.EventArgs) Handles proveedorConsultaPagoProveedor.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorConsultaPagoProveedor.Enabled = False

        frmConsultaPagoProveedor.WindowState = FormWindowState.Normal
        frmConsultaPagoProveedor.Show()
        frmConsultaPagoProveedor.BringToFront()
    End Sub
    '-- gatos a proveedor
    Private Sub proveedorGasto_Click(sender As System.Object, e As System.EventArgs) Handles proveedorGasto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorGasto.Enabled = False

        frmGastoProveedor.WindowState = FormWindowState.Normal
        frmGastoProveedor.Show()
        frmGastoProveedor.BringToFront()
    End Sub
    '-- consulta de gasto del proveedor
    Private Sub proveedorConsultaGasto_Click(sender As System.Object, e As System.EventArgs) Handles proveedorConsultaGasto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorConsultaGasto.Enabled = False

        frmConsultaGasto.WindowState = FormWindowState.Normal
        frmConsultaGasto.Show()
        frmConsultaGasto.BringToFront()
    End Sub
    '-- reporte de datos del proveedor
    Private Sub proveedorReporteDatos_Click(sender As System.Object, e As System.EventArgs) Handles proveedorReporteDatos.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorReporteDatos.Enabled = False
        frmReporteDatosProveedor.WindowState = FormWindowState.Normal
        frmReporteDatosProveedor.Show()
        frmReporteDatosProveedor.BringToFront()
    End Sub
    '-- reporte de saldo de proveedores
    Private Sub proveedorReporteSaldoProveedor_Click(sender As System.Object, e As System.EventArgs) Handles proveedorReporteSaldoProveedor.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorReporteSaldoProveedor.Enabled = False
        frmReporteSaldoProveedor.WindowState = FormWindowState.Normal
        frmReporteSaldoProveedor.Show()
        frmReporteSaldoProveedor.BringToFront()
    End Sub
    '-- estadistica de proveedores
    Private Sub proveedorEstadistica_Click(sender As System.Object, e As System.EventArgs) Handles proveedorEstadistica.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorEstadistica.Enabled = False
        frmEstadisticaProveedor.WindowState = FormWindowState.Normal
        frmEstadisticaProveedor.Show()
        frmEstadisticaProveedor.BringToFront()
    End Sub
    '-- nota de credito de gastos
    Private Sub proveedorNotaCreditoGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorNotaCreditoGasto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorNotaCreditoGasto.Enabled = False
        frmNotaCreditoGasto.WindowState = FormWindowState.Normal
        frmNotaCreditoGasto.Show()
        frmNotaCreditoGasto.BringToFront()
    End Sub

    '-- reporte de compras y gastos
    Private Sub proveedorReporteCompraGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorReporteCompraGasto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorReporteCompraGasto.Enabled = False
        frmReporteCompraGasto.WindowState = FormWindowState.Normal
        frmReporteCompraGasto.Show()
        frmReporteCompraGasto.BringToFront()
    End Sub
    '-- retenciones del proveedor
    Private Sub proveedorRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorRetencion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorRetencion.Enabled = False
        frmRetencionProveedor.WindowState = FormWindowState.Normal
        frmRetencionProveedor.Show()
        frmRetencionProveedor.BringToFront()
    End Sub
    '-- consulta las retenciones del proveedor
    Private Sub proveedorConsultaRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proveedorConsultaRetencion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorConsultaRetencion.Enabled = False
        frmConsultaRetencionProveedor.WindowState = FormWindowState.Normal
        frmConsultaRetencionProveedor.Show()
        frmConsultaRetencionProveedor.BringToFront()
    End Sub
    '-- devolucion comprometido en compras
    Private Sub proveedorDevolucion_Click(sender As System.Object, e As System.EventArgs) Handles proveedorDevolucion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorDevolucion.Enabled = False
        frmDevolucionCompra.WindowState = FormWindowState.Normal
        frmDevolucionCompra.Show()
        frmDevolucionCompra.BringToFront()
    End Sub
    '-- recepcion de mercaderias comprometidas
    Private Sub proveedorRecepcion_Click(sender As System.Object, e As System.EventArgs) Handles proveedorRecepcion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorRecepcion.Enabled = False
        frmRecepcionCompra.WindowState = FormWindowState.Normal
        frmRecepcionCompra.Show()
        frmRecepcionCompra.BringToFront()
    End Sub
    '-- nota de credito por monto
    Private Sub proveedorNotaCreditoMonto_Click(sender As System.Object, e As System.EventArgs) Handles proveedorNotaCreditoMonto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        proveedorNotaCreditoMonto.Enabled = False
        frmNotaCreditoMontoProveedor.WindowState = FormWindowState.Normal
        frmNotaCreditoMontoProveedor.Show()
        frmNotaCreditoMontoProveedor.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------
    '****************'
    '-- MERCADERIA --'
    '****************'
    '-- referenciar mercaderia
    Private Sub ReferenciarMercaderíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mercaderiaReferenciarMercaderia.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaReferenciarMercaderia.Enabled = False

        frmReferenciarMercaderias.WindowState = FormWindowState.Normal
        frmReferenciarMercaderias.Show()
        frmReferenciarMercaderias.BringToFront()
        frmReferenciarMercaderias.btnNuevo.Focus()
    End Sub
    '-- imprimir codigo de barra de mercaderia
    Private Sub mercaderiaMercaderiasImprimirCodigoBarra_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasImprimirCodigoBarra.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasImprimirCodigoBarra.Enabled = False

        frmImpCodigoBarraMercaderia.WindowState = FormWindowState.Normal
        frmImpCodigoBarraMercaderia.Show()
        frmImpCodigoBarraMercaderia.BringToFront()
    End Sub
    '-- seguimiento de stock
    Private Sub mercaderiaMercaderiasSeguimientoStock_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasSeguimientoStock.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasSeguimientoStock.Enabled = False

        frmSeguimientoStock.WindowState = FormWindowState.Normal
        frmSeguimientoStock.Show()
        frmSeguimientoStock.BringToFront()

    End Sub
    '-- ajuste positivo de mercaderia
    Private Sub mercaderiaMercaderiasAjustesPositivo_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasAjustesPositivo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasAjustesPositivo.Enabled = False

        frmAjustePositivoMercaderia.WindowState = FormWindowState.Normal
        frmAjustePositivoMercaderia.Show()
        frmAjustePositivoMercaderia.BringToFront()
    End Sub
    '-- ajuste negativo de mercaderia
    Private Sub mercaderiaMercaderiasAjustesNegativo_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasAjustesNegativo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasAjustesNegativo.Enabled = False

        frmAjusteNegativoMercaderia.WindowState = FormWindowState.Normal
        frmAjusteNegativoMercaderia.Show()
        frmAjusteNegativoMercaderia.BringToFront()
    End Sub
    '-- stock inicial
    Private Sub menuMercaderiaStockInicial_Click(sender As System.Object, e As System.EventArgs) Handles menuMercaderiaStockInicial.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        menuMercaderiaStockInicial.Enabled = False

        frmStockInicial.WindowState = FormWindowState.Normal
        frmStockInicial.Show()
        frmStockInicial.BringToFront()
    End Sub
    '-- modificar precio de mercaderias enteras
    Private Sub mercaderiaMercaderiasModificarPRecioEntero_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasModificarPRecioEntero.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasModificarPRecioEntero.Enabled = False

        frmPrecioEntero.WindowState = FormWindowState.Normal
        frmPrecioEntero.Show()
        frmPrecioEntero.BringToFront()
    End Sub
    '-- modificar precio de mecaderias fraccionadas
    Private Sub mercaderiaMercaderiasModificarPrecioFraccion_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasModificarPrecioFraccion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasModificarPrecioFraccion.Enabled = False

        frmPrecioFraccion.WindowState = FormWindowState.Normal
        frmPrecioFraccion.Show()
        frmPrecioFraccion.BringToFront()
    End Sub
    '-- consulta stock
    Private Sub mercaderiaConsultasStock_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaConsultasStock.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaConsultasStock.Enabled = False

        frmConsultaStock.WindowState = FormWindowState.Normal
        frmConsultaStock.Show()
        frmConsultaStock.BringToFront()
    End Sub
    '-- generar codigo de barras
    Private Sub mercaderiaMercaderiasGenerarCodigoBarra_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasGenerarCodigoBarra.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasGenerarCodigoBarra.Enabled = False

        frmGenerarCodigoBarraMercaderia.WindowState = FormWindowState.Normal
        frmGenerarCodigoBarraMercaderia.Show()
        frmGenerarCodigoBarraMercaderia.BringToFront()
    End Sub
    '-- consulta ajuste positivo de mercaderias
    Private Sub mercaderiaConsultasAjustePositivo_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaConsultasAjustePositivo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaConsultasAjustePositivo.Enabled = False

        frmConsultaAjustePositivo.WindowState = FormWindowState.Normal
        frmConsultaAjustePositivo.Show()
        frmConsultaAjustePositivo.BringToFront()
    End Sub
    '-- consulta ajuste negativo de mercaderias
    Private Sub mercaderiaConsultasAjusteNegativo_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaConsultasAjusteNegativo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaConsultasAjusteNegativo.Enabled = False

        frmConsultaAjusteNegativo.WindowState = FormWindowState.Normal
        frmConsultaAjusteNegativo.Show()
        frmConsultaAjusteNegativo.BringToFront()
    End Sub
    '-- consulta stock inicial
    Private Sub mercaderiaConsultasStockInicial_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaConsultasStockInicial.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaConsultasStockInicial.Enabled = False

        frmConsultaStockInicial.WindowState = FormWindowState.Normal
        frmConsultaStockInicial.Show()
        frmConsultaStockInicial.BringToFront()
    End Sub
    '-- reporte de vencimientos de mercaderias
    Private Sub mercaderiasReportesVencimientos_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiasReportesVencimientos.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiasReportesVencimientos.Enabled = False

        frmReporteVencimiento.WindowState = FormWindowState.Normal
        frmReporteVencimiento.Show()
        frmReporteVencimiento.BringToFront()
    End Sub
    '-- reporte de mercaderias en gral
    Private Sub mercaderiasReportesMercaderiaGral_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiasReportesMercaderiaGral.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiasReportesMercaderiaGral.Enabled = False

        frmReporteMercaderiaGral.WindowState = FormWindowState.Normal
        frmReporteMercaderiaGral.Show()
        frmReporteMercaderiaGral.BringToFront()
    End Sub
    '-- estadisticas
    Private Sub menuMercaderiaEstadisticas_Click(sender As System.Object, e As System.EventArgs) Handles menuMercaderiaEstadisticas.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        menuMercaderiaEstadisticas.Enabled = False

        frmEstadisticaMercaderia.WindowState = FormWindowState.Normal
        frmEstadisticaMercaderia.Show()
        frmEstadisticaMercaderia.BringToFront()
    End Sub
    '-- modificacion de costos 
    Private Sub MercaderiaModificarCosto_Click(sender As System.Object, e As System.EventArgs) Handles MercaderiaModificarCosto.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        MercaderiaModificarCosto.Enabled = False

        frmModificarCosto.WindowState = FormWindowState.Normal
        frmModificarCosto.Show()
        frmModificarCosto.BringToFront()
    End Sub
    '-- modificacion de vencimiento
    Private Sub mercaderiaMercaderiasModificarVencimiento_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaMercaderiasModificarVencimiento.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasModificarVencimiento.Enabled = False

        frmModificarVence.WindowState = FormWindowState.Normal
        frmModificarVence.Show()
        frmModificarVence.BringToFront()
    End Sub
    '-- fraccionar mercaderias
    Private Sub mercaderiaMercaderiasFraccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mercaderiaMercaderiasFraccionar.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasFraccionar.Enabled = False

        frmFraccionarMercaderia.WindowState = FormWindowState.Normal
        frmFraccionarMercaderia.Show()
        frmFraccionarMercaderia.BringToFront()
    End Sub
    '-- modificar cantidad de fraccionamiento
    Private Sub mercaderiaMercaderiasModificarCantidadFraccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mercaderiaMercaderiasModificarCantidadFraccion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaMercaderiasModificarCantidadFraccion.Enabled = False

        frmModificarFraccionado.WindowState = FormWindowState.Normal
        frmModificarFraccionado.Show()
        frmModificarFraccionado.BringToFront()
    End Sub
    '-- consulta modificacion de precios de mercadeias enteras
    Private Sub mercaderiaConsultasModificaPrecioEntero_Click(sender As System.Object, e As System.EventArgs) Handles mercaderiaConsultasModificaPrecioEntero.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        mercaderiaConsultasModificaPrecioEntero.Enabled = False

        frmConsultaPrecioEntero.WindowState = FormWindowState.Normal
        frmConsultaPrecioEntero.Show()
        frmConsultaPrecioEntero.BringToFront()
    End Sub
    '-- descuento por grupo de clientes
    Private Sub MercaderiaDescuentoGrupoCliente_Click(sender As System.Object, e As System.EventArgs) Handles MercaderiaDescuentoGrupoCliente.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        MercaderiaDescuentoGrupoCliente.Enabled = False

        frmDescuentoGrupoCliente.WindowState = FormWindowState.Normal
        frmDescuentoGrupoCliente.Show()
        frmDescuentoGrupoCliente.BringToFront()
    End Sub
    '-- descuentos especiales
    Private Sub MercaderiaDescuentoEspecial_Click(sender As System.Object, e As System.EventArgs) Handles MercaderiaDescuentoEspecial.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        MercaderiaDescuentoEspecial.Enabled = False

        frmDescuentoEspecial.WindowState = FormWindowState.Normal
        frmDescuentoEspecial.Show()
        frmDescuentoEspecial.BringToFront()
    End Sub
    '-- descuento por producto en mayorista
    Private Sub MercaderiaDescuentoProductoMayo_Click(sender As System.Object, e As System.EventArgs) Handles MercaderiaDescuentoProductoMayo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        MercaderiaDescuentoProductoMayo.Enabled = False

        frmDescuentoEspecialGrupoCliente.WindowState = FormWindowState.Normal
        frmDescuentoEspecialGrupoCliente.Show()
        frmDescuentoEspecialGrupoCliente.BringToFront()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*******************'
    '-- CONFIGURACION --'
    '*******************'
    '-- abm pc
    Private Sub PCToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles configuracionAbmPc.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionAbmPc.Enabled = False

        frmAbmPc.WindowState = FormWindowState.Normal
        frmAbmPc.Show()
        frmAbmPc.BringToFront()
    End Sub
    '-- abm usuario
    Private Sub UsuarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles configuracionAbmUsuario.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionAbmUsuario.Enabled = False

        frmAbmUsuario.WindowState = FormWindowState.Normal
        frmAbmUsuario.Show()
        frmAbmUsuario.BringToFront()
    End Sub
    '-- abm formulario
    Private Sub FormulariosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles configuracionAbmFormularios.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionAbmFormularios.Enabled = False

        frmAbmFormulario.WindowState = FormWindowState.Normal
        frmAbmFormulario.Show()
        frmAbmFormulario.BringToFront()
    End Sub
    '-- permisos de usuarios
    Private Sub PermisosDeUsuariosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles configuracionPermisoUsuario.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionPermisoUsuario.Enabled = False

        frmPermisoUsuario.WindowState = FormWindowState.Normal
        frmPermisoUsuario.Show()
        frmPermisoUsuario.BringToFront()
    End Sub
    '-- mantenimietno de contraseña
    Private Sub configuracionMantenimientoPass_Click(sender As System.Object, e As System.EventArgs) Handles configuracionMantenimientoPass.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionMantenimientoPass.Enabled = False

        frmPassUsuario.WindowState = FormWindowState.Normal
        frmPassUsuario.Show()
        frmPassUsuario.BringToFront()
    End Sub
    '-- regisrar las facturas
    Private Sub RegistrarFacturasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles configuracionRegistrarFacturas.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionRegistrarFacturas.Enabled = False

        frmAbmFactura.WindowState = FormWindowState.Normal
        frmAbmFactura.Show()
        frmAbmFactura.BringToFront()
    End Sub
    '-- enviar email
    Private Sub configuracionEnviarEmail_Click(sender As System.Object, e As System.EventArgs)
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        'configuracionEnviarEmail.Enabled = False

        frmConfigEmail.WindowState = FormWindowState.Normal
        frmConfigEmail.Show()
        frmConfigEmail.BringToFront()
    End Sub
    '-- abm de tipo de procesos
    Private Sub configuracionTipoProceso_Click(sender As System.Object, e As System.EventArgs) Handles configuracionTipoProceso.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionTipoProceso.Enabled = False

        frmAbmTipoProcesoEmail.WindowState = FormWindowState.Normal
        frmAbmTipoProcesoEmail.Show()
        frmAbmTipoProcesoEmail.BringToFront()
    End Sub
    '-- configuracion de email
    Private Sub configuracionEmail_Click(sender As System.Object, e As System.EventArgs) Handles configuracionEmail.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionEmail.Enabled = False

        frmConfigEmail.WindowState = FormWindowState.Normal
        frmConfigEmail.Show()
        frmConfigEmail.BringToFront()
    End Sub
    '-- configuracion de cantidad de cuotas
    Private Sub configuracionCuotaCredito_Click(sender As System.Object, e As System.EventArgs) Handles configuracionCuotaCredito.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionCuotaCredito.Enabled = False

        frmCuotaVenta.WindowState = FormWindowState.Normal
        frmCuotaVenta.Show()
        frmCuotaVenta.BringToFront()
    End Sub
    '-- genarar codigo de barra de usuario
    Private Sub configuracionGenerarCodigoBarraUsuario_Click(sender As System.Object, e As System.EventArgs) Handles configuracionGenerarCodigoBarraUsuario.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionGenerarCodigoBarraUsuario.Enabled = False

        frmGenerarCodigoBarraUsuario.WindowState = FormWindowState.Normal
        frmGenerarCodigoBarraUsuario.Show()
        frmGenerarCodigoBarraUsuario.BringToFront()
    End Sub
    '-- abm grupo de usuario
    Private Sub configuracionAbmGrupoUsuario_Click(sender As System.Object, e As System.EventArgs) Handles configuracionAbmGrupoUsuario.Click
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        configuracionAbmGrupoUsuario.Enabled = False

        frmAbmGrupoUsuario.WindowState = FormWindowState.Normal
        frmAbmGrupoUsuario.Show()
        frmAbmGrupoUsuario.BringToFront()
    End Sub
    '---------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- FINANZA --'
    '*************'
    '-- arqueo de caja
    Private Sub ArqueoDeCajaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles finanzaArqueCaja.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaArqueCaja.Enabled = False

        frmArqueoCaja.WindowState = FormWindowState.Normal
        frmArqueoCaja.Show()
        frmArqueoCaja.BringToFront()
    End Sub
    '-- tabla de cozacion
    Private Sub finanzaTablaCotizacion_Click(sender As System.Object, e As System.EventArgs) Handles finanzaTablaCotizacion.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaTablaCotizacion.Enabled = False

        frmTablaCotizacion.WindowState = FormWindowState.Normal
        frmTablaCotizacion.Show()
        frmTablaCotizacion.BringToFront()
    End Sub
    '-- consulta de arqueo
    Private Sub finanzaConsultaArqueo_Click(sender As System.Object, e As System.EventArgs) Handles finanzaConsultaArqueo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaConsultaArqueo.Enabled = False

        frmConsultaArqueo.WindowState = FormWindowState.Normal
        frmConsultaArqueo.Show()
        frmConsultaArqueo.BringToFront()
    End Sub
    '-- aumentar caja
    Private Sub finanzaAjustarCajaMas_Click(sender As System.Object, e As System.EventArgs) Handles finanzaAjustarCajaMas.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaAjustarCajaMas.Enabled = False

        frmCajaMas.WindowState = FormWindowState.Normal
        frmCajaMas.Show()
        frmCajaMas.BringToFront()
    End Sub
    '-- disminuir caja
    Private Sub finanzaAjustarCajaMenos_Click(sender As System.Object, e As System.EventArgs) Handles finanzaAjustarCajaMenos.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaAjustarCajaMenos.Enabled = False

        frmCajaMenos.WindowState = FormWindowState.Normal
        frmCajaMenos.Show()
        frmCajaMenos.BringToFront()
    End Sub
    '-- reporte del arqueo de caja
    Private Sub finanzaReportesArqueo_Click(sender As System.Object, e As System.EventArgs) Handles finanzaReportesArqueo.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaReportesArqueo.Enabled = False

        frmReporteArqueo.WindowState = FormWindowState.Normal
        frmReporteArqueo.Show()
        frmReporteArqueo.BringToFront()
    End Sub
    '-- carga de planillas de caja
    Private Sub finanzaCargaPlanilla_Click(sender As System.Object, e As System.EventArgs) Handles finanzaCargaPlanilla.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaCargaPlanilla.Enabled = False

        frmPlanillaCaja.WindowState = FormWindowState.Normal
        frmPlanillaCaja.Show()
        frmPlanillaCaja.BringToFront()
    End Sub
    '-- consulta de planillas de cajas
    Private Sub finanzaConsultaPlanillaCaja_Click(sender As System.Object, e As System.EventArgs) Handles finanzaConsultaPlanillaCaja.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        finanzaConsultaPlanillaCaja.Enabled = False

        frmConsultaPlanillaCaja.WindowState = FormWindowState.Normal
        frmConsultaPlanillaCaja.Show()
        frmConsultaPlanillaCaja.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '************'
    '-- BANCOS --'
    '************'
    '-- abm de cuenta corriente
    Private Sub bancoAbmCuentaCorriente_Click(sender As System.Object, e As System.EventArgs) Handles bancoAbmCuentaCorriente.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoAbmCuentaCorriente.Enabled = False

        frmAbmCuentaCorriente.WindowState = FormWindowState.Normal
        frmAbmCuentaCorriente.Show()
        frmAbmCuentaCorriente.BringToFront()
    End Sub
    '-- abm de chequera
    Private Sub bancoAbmChequera_Click(sender As System.Object, e As System.EventArgs) Handles bancoAbmChequera.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoAbmChequera.Enabled = False

        frmAbmChequera.WindowState = FormWindowState.Normal
        frmAbmChequera.Show()
        frmAbmChequera.BringToFront()
    End Sub
    '-- cargar cheques
    Private Sub bancoCargarCheque_Click(sender As System.Object, e As System.EventArgs) Handles bancoCargarCheque.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoCargarCheque.Enabled = False

        frmCargarCheques.WindowState = FormWindowState.Normal
        frmCargarCheques.Show()
        frmCargarCheques.BringToFront()
    End Sub

    '-- cargar el deposito bancario
    Private Sub bancoCargarDeposito_Click(sender As System.Object, e As System.EventArgs) Handles bancoCargarDeposito.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoCargarDeposito.Enabled = False

        frmCargarDepositoBanco.WindowState = FormWindowState.Normal
        frmCargarDepositoBanco.Show()
        frmCargarDepositoBanco.BringToFront()
    End Sub

    '-- consulta de deposito bancario
    Private Sub bancoConsultasDepositoBancario_Click(sender As System.Object, e As System.EventArgs) Handles bancoConsultasDepositoBancario.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoConsultasDepositoBancario.Enabled = False

        frmConsultaDepositoBanco.WindowState = FormWindowState.Normal
        frmConsultaDepositoBanco.Show()
        frmConsultaDepositoBanco.BringToFront()
    End Sub
    '-- aumentar cuenta corriente
    Private Sub bancoAumentarCuenta_Click(sender As System.Object, e As System.EventArgs) Handles bancoAumentarCuenta.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoAumentarCuenta.Enabled = False

        frmAjusteBancoMas.WindowState = FormWindowState.Normal
        frmAjusteBancoMas.Show()
        frmAjusteBancoMas.BringToFront()
    End Sub
    '-- disminuir cuenta corriente
    Private Sub bancoDisminuirCuenta_Click(sender As System.Object, e As System.EventArgs) Handles bancoDisminuirCuenta.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoDisminuirCuenta.Enabled = False

        frmAjusteBancoMenos.WindowState = FormWindowState.Normal
        frmAjusteBancoMenos.Show()
        frmAjusteBancoMenos.BringToFront()
    End Sub
    '-- reporte de saldo de banco
    Private Sub bancoReportesSaldoBanco_Click(sender As System.Object, e As System.EventArgs) Handles bancoReportesSaldoBanco.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoReportesSaldoBanco.Enabled = False

        frmReporteSaldoBanco.WindowState = FormWindowState.Normal
        frmReporteSaldoBanco.Show()
        frmReporteSaldoBanco.BringToFront()
    End Sub
    '-- reporte de cheque pendiente
    Private Sub bancoReportesChequePendiente_Click(sender As System.Object, e As System.EventArgs) Handles bancoReportesChequePendiente.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoReportesChequePendiente.Enabled = False

        frmReporteChequePendientes.WindowState = FormWindowState.Normal
        frmReporteChequePendientes.Show()
        frmReporteChequePendientes.BringToFront()
    End Sub
    '-- consulta de cheques
    Private Sub bancoConsultasCheques_Click(sender As System.Object, e As System.EventArgs) Handles bancoConsultasCheques.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoOrdenCheque.Enabled = False

        frmConsultaCheque.WindowState = FormWindowState.Normal
        frmConsultaCheque.Show()
        frmConsultaCheque.BringToFront()
    End Sub
    '-- cargar ondedn de cheque para pagos
    Private Sub bancoOrdenCheque_Click(sender As System.Object, e As System.EventArgs) Handles bancoOrdenCheque.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoConsultasCheques.Enabled = False

        frmCargarOrdenPagoCheque.WindowState = FormWindowState.Normal
        frmCargarOrdenPagoCheque.Show()
        frmCargarOrdenPagoCheque.BringToFront()
    End Sub
    '-- consulta de orden de cheques
    Private Sub bancoConsultasOrdenCheque_Click(sender As System.Object, e As System.EventArgs) Handles bancoConsultasOrdenCheque.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoConsultasOrdenCheque.Enabled = False

        frmConsultaOrdenCheque.WindowState = FormWindowState.Normal
        frmConsultaOrdenCheque.Show()
        frmConsultaOrdenCheque.BringToFront()
    End Sub
    '-- imprimir orden de cheques
    Private Sub bancoImprimirOrdenCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bancoImprimirOrdenCheque.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoImprimirOrdenCheque.Enabled = False

        frmImprimirOrdenCheque.WindowState = FormWindowState.Normal
        frmImprimirOrdenCheque.Show()
        frmImprimirOrdenCheque.BringToFront()
    End Sub
    '--- control de cheques
    Private Sub bancoControlarCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bancoControlarCheque.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        bancoControlarCheque.Enabled = False

        frmControlarCheques.WindowState = FormWindowState.Normal
        frmControlarCheques.Show()
        frmControlarCheques.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '******************'
    '-- CONTABILIDAD --'
    '******************'
    Private Sub contabilidadReportesLibroIva_Click(sender As System.Object, e As System.EventArgs) Handles contabilidadReportesLibroIva.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        contabilidadReportesLibroIva.Enabled = False

        frmReporteLibroIVA.WindowState = FormWindowState.Normal
        frmReporteLibroIVA.Show()
        frmReporteLibroIVA.BringToFront()
    End Sub
    '-- actualizar RUC  
    Private Sub contabilidadActualizarRuc_Click(sender As System.Object, e As System.EventArgs) Handles contabilidadActualizarRuc.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        contabilidadActualizarRuc.Enabled = False

        frmActualizarRuc.WindowState = FormWindowState.Normal
        frmActualizarRuc.Show()
        frmActualizarRuc.BringToFront()
    End Sub
    '-- generar factura electronica
    Private Sub contabilidadGenerarFacturaDTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contabilidadGenerarFacturaDTE.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        contabilidadGenerarFacturaDTE.Enabled = False

        frmFacturaElectronica.WindowState = FormWindowState.Normal
        frmFacturaElectronica.Show()
        frmFacturaElectronica.BringToFront()
    End Sub
    '-- generar nota de credito electronica
    Private Sub contabilidadGenerarNotaCrDTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contabilidadGenerarNotaCrDTE.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        contabilidadGenerarNotaCrDTE.Enabled = False

        frmNotaDebitoElectronico.WindowState = FormWindowState.Normal
        frmNotaDebitoElectronico.Show()
        frmNotaDebitoElectronico.BringToFront()
    End Sub
    '-- abm timbrado factura electronica
    Private Sub contabilidadAbmTimbradoDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contabilidadAbmTimbradoDE.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        contabilidadAbmTimbradoDE.Enabled = False

        frmAbmTimbradoDE.WindowState = FormWindowState.Normal
        frmAbmTimbradoDE.Show()
        frmAbmTimbradoDE.BringToFront()
    End Sub
    '-- abm facturas electronicas
    Private Sub contabilidadAbmFacturaElectronica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contabilidadAbmFacturaElectronica.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        contabilidadAbmFacturaElectronica.Enabled = False

        frmAbmFacturaDE.WindowState = FormWindowState.Normal
        frmAbmFacturaDE.Show()
        frmAbmFacturaDE.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '**********'
    '-- RRHH --'
    '**********'
    '-- reporte de horario del personal
    Private Sub rrhhReportesHorario_Click(sender As System.Object, e As System.EventArgs) Handles rrhhReportesHorario.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        rrhhReportesHorario.Enabled = False

        frmReporteHorario.WindowState = FormWindowState.Normal
        frmReporteHorario.Show()
        frmReporteHorario.BringToFront()
    End Sub
    '-- actualizar noticias
    Private Sub rrhhActualizarNoticia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rrhhActualizarNoticia.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        rrhhActualizarNoticia.Enabled = False

        frmNoticias.WindowState = FormWindowState.Normal
        frmNoticias.Show()
        frmNoticias.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '*************'
    '-- HORARIO --'
    '*************'
    '-- marcar el horario de entrada y salida
    Private Sub horario_Click(sender As System.Object, e As System.EventArgs) Handles horario.Click
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios + 1
        '----------------------------------------------------
        frmHorarioEmpleado.WindowState = FormWindowState.Normal
        frmHorarioEmpleado.Show()
        frmHorarioEmpleado.BringToFront()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '***********************'
    '-- SALIR DEL SISTEMA --'
    '***********************'
    '----------------------------------------------------------------------------------------------------------------------

    '----------------------------------------------------------------------------------------------------------------------
    Private Sub lvCumple_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCumple.KeyDown
        Try
            If e.KeyData = Keys.Alt + Keys.S Then
                If MessageBox.Show("Desea Salir de Multicolor..?", strGl_nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    End
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class