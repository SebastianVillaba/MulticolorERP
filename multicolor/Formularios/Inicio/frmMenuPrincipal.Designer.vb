<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ColumnHeader1 As System.Windows.Forms.ColumnHeader
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menuABM = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmDeposito = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAbmMercaderias = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmMercaderiaImpuesto = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmMercaderiaProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmMotivoAjuste = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmPais = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAbmPersonas = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmPersonaEntidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmGrupoCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmTipo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAbmTipos = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmTipoProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.abmColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCLIENTE = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteCobro = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuClienteConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaCobranza = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaHistorico = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaNotaCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaVentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaOrdenCoral = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaOrdenSuvinil = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteConsultaOrdenAutomotive = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteDevolucion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClienteEstadisticas = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteFacturacionFarmacia1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportesClienteMercaderia = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportesControlVenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportesDelivery = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportesSaldoCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportesVenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteReportesClienteCobro = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteOrdenPreparado = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteOrdenPreparadoAutomotive = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteOrdenPreparadoCoral = New System.Windows.Forms.ToolStripMenuItem()
        Me.clienteOrdenPreparadoSuvinil = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPROVEEDOR = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorFacturaCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProveedorConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorConsultaFacturaCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorConsultaGasto = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorConsultaNotaCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorConsultaPagoProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorConsultaRetencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorEstadistica = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorGasto = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorNotaCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorNotaCreditoGasto = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorPagoProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorReporteCompraGasto = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorReporteDatos = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorReporteSaldoProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorRetencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorDevolucion = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorRecepcion = New System.Windows.Forms.ToolStripMenuItem()
        Me.proveedorNotaCreditoMonto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMERCADERIA = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaReferenciarMercaderia = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasAjustePositivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasAjusteNegativo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasMercaderiaControlada = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasPedidoSucursal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasPedidoASucursal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasPedidoProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasRecepcion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasRecepcionPendiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasRemision = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasRemisionPendiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasStock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasStockInicial = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasModificaPrecioEntero = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaConsultasPromoSamsung = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMecaderiaDescuentos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MercaderiaDescuentoGrupoCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.MercaderiaDescuentoEspecial = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMercaderiaEstadisticas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMecaderiaMercaderias = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasAjustes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasAjustesNegativo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasAjustesPositivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasFraccionar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasGenerarCodigoBarra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasImprimirCodigoBarra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasSeguimientoStock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasModificarCantidadFraccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasModificarPRecioEntero = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasModificarPrecioFraccion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasModificarVencimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiaMercaderiasFoto = New System.Windows.Forms.ToolStripMenuItem()
        Me.MercaderiaModificarCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMercaderiaReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiasReportesMercaderiaGral = New System.Windows.Forms.ToolStripMenuItem()
        Me.mercaderiasReportesVencimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMercaderiaStockInicial = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFinanza = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaAjustarCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaAjustarCajaMas = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaAjustarCajaMenos = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaArqueCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaConsulta = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaConsultaArqueo = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaConsultaPlanillaCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaTablaCotizacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaReportesArqueo = New System.Windows.Forms.ToolStripMenuItem()
        Me.finanzaCargaPlanilla = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuBANCO = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoAbm = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoAbmCuentaCorriente = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoAbmChequera = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoAjustarCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoAumentarCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoDisminuirCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoCargarCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoCargarDeposito = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoConsultasCheques = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoConsultasDepositoBancario = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoConsultasOrdenCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoControlarCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoImprimirOrdenCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoOrdenCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoReportesChequePendiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.bancoReportesSaldoBanco = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCONTABILIDAD = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadAbmTimbradoDE = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadAbmFacturaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadReportesLibroIva = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadActualizarRuc = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadGenerarFacturaDTE = New System.Windows.Forms.ToolStripMenuItem()
        Me.contabilidadGenerarNotaCrDTE = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRRHH = New System.Windows.Forms.ToolStripMenuItem()
        Me.rrhhActualizarNoticia = New System.Windows.Forms.ToolStripMenuItem()
        Me.rrhhReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.rrhhReportesHorario = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCONFIGURACION = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuConfiguracionAbm = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionAbmPc = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionAbmFormularios = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionGenerarCodigoBarraUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionAbmUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionRegistrarFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionTipoProceso = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionAbmGrupoUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionCuotaCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionMantenimientoPass = New System.Windows.Forms.ToolStripMenuItem()
        Me.configuracionPermisoUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.horario = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblIdUsuario = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picFotoUsuario = New System.Windows.Forms.PictureBox()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEmpresaContable = New System.Windows.Forms.Label()
        Me.lblIdPersonaJur = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblIdGrupoUsuario = New System.Windows.Forms.Label()
        Me.lblFechaServidor = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEntidad = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaHoraServer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblGrupoUsuario = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblNombreUsuario = New System.Windows.Forms.Label()
        Me.lvCumple = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblNombrePc = New System.Windows.Forms.Label()
        Me.lblIdConfig = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.MercaderiaDescuentoProductoMayo = New System.Windows.Forms.ToolStripMenuItem()
        ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picFotoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        ColumnHeader1.Text = "Nombre de la Persona con Aniversario"
        ColumnHeader1.Width = 300
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuABM, Me.menuCLIENTE, Me.menuPROVEEDOR, Me.menuMERCADERIA, Me.menuFinanza, Me.menuBANCO, Me.menuCONTABILIDAD, Me.menuRRHH, Me.menuCONFIGURACION, Me.horario})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(974, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menuABM
        '
        Me.menuABM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.abmDeposito, Me.menuAbmMercaderias, Me.abmMotivoAjuste, Me.abmPais, Me.menuAbmPersonas, Me.abmTipo, Me.menuAbmTipos, Me.abmColor})
        Me.menuABM.Image = CType(resources.GetObject("menuABM.Image"), System.Drawing.Image)
        Me.menuABM.Name = "menuABM"
        Me.menuABM.Size = New System.Drawing.Size(61, 20)
        Me.menuABM.Text = "&ABM"
        '
        'abmDeposito
        '
        Me.abmDeposito.Image = CType(resources.GetObject("abmDeposito.Image"), System.Drawing.Image)
        Me.abmDeposito.Name = "abmDeposito"
        Me.abmDeposito.Size = New System.Drawing.Size(148, 22)
        Me.abmDeposito.Text = "&Deposito"
        '
        'menuAbmMercaderias
        '
        Me.menuAbmMercaderias.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.abmMercaderiaImpuesto, Me.abmMercaderiaProducto})
        Me.menuAbmMercaderias.Image = CType(resources.GetObject("menuAbmMercaderias.Image"), System.Drawing.Image)
        Me.menuAbmMercaderias.Name = "menuAbmMercaderias"
        Me.menuAbmMercaderias.Size = New System.Drawing.Size(148, 22)
        Me.menuAbmMercaderias.Text = "&Mercaderias"
        '
        'abmMercaderiaImpuesto
        '
        Me.abmMercaderiaImpuesto.Name = "abmMercaderiaImpuesto"
        Me.abmMercaderiaImpuesto.Size = New System.Drawing.Size(124, 22)
        Me.abmMercaderiaImpuesto.Text = "&Impuesto"
        '
        'abmMercaderiaProducto
        '
        Me.abmMercaderiaProducto.Name = "abmMercaderiaProducto"
        Me.abmMercaderiaProducto.Size = New System.Drawing.Size(124, 22)
        Me.abmMercaderiaProducto.Text = "&Producto"
        '
        'abmMotivoAjuste
        '
        Me.abmMotivoAjuste.Image = CType(resources.GetObject("abmMotivoAjuste.Image"), System.Drawing.Image)
        Me.abmMotivoAjuste.Name = "abmMotivoAjuste"
        Me.abmMotivoAjuste.Size = New System.Drawing.Size(148, 22)
        Me.abmMotivoAjuste.Text = "&Motivo Ajuste"
        '
        'abmPais
        '
        Me.abmPais.Image = CType(resources.GetObject("abmPais.Image"), System.Drawing.Image)
        Me.abmPais.Name = "abmPais"
        Me.abmPais.Size = New System.Drawing.Size(148, 22)
        Me.abmPais.Text = "P&ais"
        '
        'menuAbmPersonas
        '
        Me.menuAbmPersonas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.abmPersonaEntidad, Me.abmGrupoCliente})
        Me.menuAbmPersonas.Image = CType(resources.GetObject("menuAbmPersonas.Image"), System.Drawing.Image)
        Me.menuAbmPersonas.Name = "menuAbmPersonas"
        Me.menuAbmPersonas.Size = New System.Drawing.Size(148, 22)
        Me.menuAbmPersonas.Text = "&Personas"
        '
        'abmPersonaEntidad
        '
        Me.abmPersonaEntidad.Name = "abmPersonaEntidad"
        Me.abmPersonaEntidad.Size = New System.Drawing.Size(167, 22)
        Me.abmPersonaEntidad.Text = "&Persona - Entidad"
        '
        'abmGrupoCliente
        '
        Me.abmGrupoCliente.Name = "abmGrupoCliente"
        Me.abmGrupoCliente.Size = New System.Drawing.Size(167, 22)
        Me.abmGrupoCliente.Text = "Grupo de Cliente"
        '
        'abmTipo
        '
        Me.abmTipo.Image = CType(resources.GetObject("abmTipo.Image"), System.Drawing.Image)
        Me.abmTipo.Name = "abmTipo"
        Me.abmTipo.Size = New System.Drawing.Size(148, 22)
        Me.abmTipo.Text = "&Tipo"
        '
        'menuAbmTipos
        '
        Me.menuAbmTipos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.abmTipoProducto})
        Me.menuAbmTipos.Image = CType(resources.GetObject("menuAbmTipos.Image"), System.Drawing.Image)
        Me.menuAbmTipos.Name = "menuAbmTipos"
        Me.menuAbmTipos.Size = New System.Drawing.Size(148, 22)
        Me.menuAbmTipos.Text = "Ti&pos"
        '
        'abmTipoProducto
        '
        Me.abmTipoProducto.Name = "abmTipoProducto"
        Me.abmTipoProducto.Size = New System.Drawing.Size(123, 22)
        Me.abmTipoProducto.Text = "&Producto"
        '
        'abmColor
        '
        Me.abmColor.Image = CType(resources.GetObject("abmColor.Image"), System.Drawing.Image)
        Me.abmColor.Name = "abmColor"
        Me.abmColor.Size = New System.Drawing.Size(148, 22)
        Me.abmColor.Text = "Color"
        '
        'menuCLIENTE
        '
        Me.menuCLIENTE.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clienteCobro, Me.menuClienteConsultas, Me.clienteDevolucion, Me.ClienteEstadisticas, Me.clienteFacturacionFarmacia1, Me.clienteReportes, Me.clienteOrdenPreparado})
        Me.menuCLIENTE.Image = CType(resources.GetObject("menuCLIENTE.Image"), System.Drawing.Image)
        Me.menuCLIENTE.Name = "menuCLIENTE"
        Me.menuCLIENTE.Size = New System.Drawing.Size(72, 20)
        Me.menuCLIENTE.Text = "&Cliente"
        '
        'clienteCobro
        '
        Me.clienteCobro.Image = CType(resources.GetObject("clienteCobro.Image"), System.Drawing.Image)
        Me.clienteCobro.Name = "clienteCobro"
        Me.clienteCobro.Size = New System.Drawing.Size(185, 22)
        Me.clienteCobro.Text = "Co&bro "
        '
        'menuClienteConsultas
        '
        Me.menuClienteConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clienteConsultaCobranza, Me.clienteConsultaHistorico, Me.clienteConsultaNotaCredito, Me.clienteConsultaVentas, Me.clienteConsultaOrdenCoral, Me.clienteConsultaOrdenSuvinil, Me.clienteConsultaOrdenAutomotive})
        Me.menuClienteConsultas.Image = CType(resources.GetObject("menuClienteConsultas.Image"), System.Drawing.Image)
        Me.menuClienteConsultas.Name = "menuClienteConsultas"
        Me.menuClienteConsultas.Size = New System.Drawing.Size(185, 22)
        Me.menuClienteConsultas.Text = "&Consultas"
        '
        'clienteConsultaCobranza
        '
        Me.clienteConsultaCobranza.Name = "clienteConsultaCobranza"
        Me.clienteConsultaCobranza.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaCobranza.Text = "&Cobranza"
        '
        'clienteConsultaHistorico
        '
        Me.clienteConsultaHistorico.Name = "clienteConsultaHistorico"
        Me.clienteConsultaHistorico.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaHistorico.Text = "&Histórico"
        '
        'clienteConsultaNotaCredito
        '
        Me.clienteConsultaNotaCredito.Name = "clienteConsultaNotaCredito"
        Me.clienteConsultaNotaCredito.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaNotaCredito.Text = "Devolución"
        '
        'clienteConsultaVentas
        '
        Me.clienteConsultaVentas.Name = "clienteConsultaVentas"
        Me.clienteConsultaVentas.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaVentas.Text = "&Ventas"
        '
        'clienteConsultaOrdenCoral
        '
        Me.clienteConsultaOrdenCoral.Name = "clienteConsultaOrdenCoral"
        Me.clienteConsultaOrdenCoral.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaOrdenCoral.Text = "Orden Preparado Coral"
        '
        'clienteConsultaOrdenSuvinil
        '
        Me.clienteConsultaOrdenSuvinil.Name = "clienteConsultaOrdenSuvinil"
        Me.clienteConsultaOrdenSuvinil.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaOrdenSuvinil.Text = "Orden Preparado Suvinil"
        '
        'clienteConsultaOrdenAutomotive
        '
        Me.clienteConsultaOrdenAutomotive.Name = "clienteConsultaOrdenAutomotive"
        Me.clienteConsultaOrdenAutomotive.Size = New System.Drawing.Size(202, 22)
        Me.clienteConsultaOrdenAutomotive.Text = "Orden Automotive"
        '
        'clienteDevolucion
        '
        Me.clienteDevolucion.Image = CType(resources.GetObject("clienteDevolucion.Image"), System.Drawing.Image)
        Me.clienteDevolucion.Name = "clienteDevolucion"
        Me.clienteDevolucion.Size = New System.Drawing.Size(185, 22)
        Me.clienteDevolucion.Text = "&Devolución"
        '
        'ClienteEstadisticas
        '
        Me.ClienteEstadisticas.Image = CType(resources.GetObject("ClienteEstadisticas.Image"), System.Drawing.Image)
        Me.ClienteEstadisticas.Name = "ClienteEstadisticas"
        Me.ClienteEstadisticas.Size = New System.Drawing.Size(185, 22)
        Me.ClienteEstadisticas.Text = "Estadísticas"
        '
        'clienteFacturacionFarmacia1
        '
        Me.clienteFacturacionFarmacia1.Image = CType(resources.GetObject("clienteFacturacionFarmacia1.Image"), System.Drawing.Image)
        Me.clienteFacturacionFarmacia1.Name = "clienteFacturacionFarmacia1"
        Me.clienteFacturacionFarmacia1.Size = New System.Drawing.Size(185, 22)
        Me.clienteFacturacionFarmacia1.Text = "&Facturación"
        '
        'clienteReportes
        '
        Me.clienteReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clienteReportesClienteMercaderia, Me.clienteReportesControlVenta, Me.clienteReportesDelivery, Me.clienteReportesSaldoCliente, Me.clienteReportesVenta, Me.clienteReportesClienteCobro})
        Me.clienteReportes.Image = CType(resources.GetObject("clienteReportes.Image"), System.Drawing.Image)
        Me.clienteReportes.Name = "clienteReportes"
        Me.clienteReportes.Size = New System.Drawing.Size(185, 22)
        Me.clienteReportes.Text = "&Reportes"
        '
        'clienteReportesClienteMercaderia
        '
        Me.clienteReportesClienteMercaderia.Name = "clienteReportesClienteMercaderia"
        Me.clienteReportesClienteMercaderia.Size = New System.Drawing.Size(184, 22)
        Me.clienteReportesClienteMercaderia.Text = "C&liente - Mercadería"
        '
        'clienteReportesControlVenta
        '
        Me.clienteReportesControlVenta.Name = "clienteReportesControlVenta"
        Me.clienteReportesControlVenta.Size = New System.Drawing.Size(184, 22)
        Me.clienteReportesControlVenta.Text = "&Control Sobre Ventas"
        '
        'clienteReportesDelivery
        '
        Me.clienteReportesDelivery.Name = "clienteReportesDelivery"
        Me.clienteReportesDelivery.Size = New System.Drawing.Size(184, 22)
        Me.clienteReportesDelivery.Text = "&Delivery"
        '
        'clienteReportesSaldoCliente
        '
        Me.clienteReportesSaldoCliente.Name = "clienteReportesSaldoCliente"
        Me.clienteReportesSaldoCliente.Size = New System.Drawing.Size(184, 22)
        Me.clienteReportesSaldoCliente.Text = "&Saldo de Clientes"
        '
        'clienteReportesVenta
        '
        Me.clienteReportesVenta.Name = "clienteReportesVenta"
        Me.clienteReportesVenta.Size = New System.Drawing.Size(184, 22)
        Me.clienteReportesVenta.Text = "&Ventas"
        '
        'clienteReportesClienteCobro
        '
        Me.clienteReportesClienteCobro.Name = "clienteReportesClienteCobro"
        Me.clienteReportesClienteCobro.Size = New System.Drawing.Size(184, 22)
        Me.clienteReportesClienteCobro.Text = "Cobros"
        '
        'clienteOrdenPreparado
        '
        Me.clienteOrdenPreparado.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.clienteOrdenPreparadoAutomotive, Me.clienteOrdenPreparadoCoral, Me.clienteOrdenPreparadoSuvinil})
        Me.clienteOrdenPreparado.Image = CType(resources.GetObject("clienteOrdenPreparado.Image"), System.Drawing.Image)
        Me.clienteOrdenPreparado.Name = "clienteOrdenPreparado"
        Me.clienteOrdenPreparado.Size = New System.Drawing.Size(185, 22)
        Me.clienteOrdenPreparado.Text = "Orden de Preparados"
        '
        'clienteOrdenPreparadoAutomotive
        '
        Me.clienteOrdenPreparadoAutomotive.Name = "clienteOrdenPreparadoAutomotive"
        Me.clienteOrdenPreparadoAutomotive.Size = New System.Drawing.Size(137, 22)
        Me.clienteOrdenPreparadoAutomotive.Text = "Automotive"
        '
        'clienteOrdenPreparadoCoral
        '
        Me.clienteOrdenPreparadoCoral.Name = "clienteOrdenPreparadoCoral"
        Me.clienteOrdenPreparadoCoral.Size = New System.Drawing.Size(137, 22)
        Me.clienteOrdenPreparadoCoral.Text = "Coral"
        '
        'clienteOrdenPreparadoSuvinil
        '
        Me.clienteOrdenPreparadoSuvinil.Name = "clienteOrdenPreparadoSuvinil"
        Me.clienteOrdenPreparadoSuvinil.Size = New System.Drawing.Size(137, 22)
        Me.clienteOrdenPreparadoSuvinil.Text = "Suvinil"
        '
        'menuPROVEEDOR
        '
        Me.menuPROVEEDOR.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.proveedorFacturaCompra, Me.menuProveedorConsultas, Me.proveedorEstadistica, Me.proveedorGasto, Me.proveedorNotaCredito, Me.proveedorNotaCreditoGasto, Me.proveedorPagoProveedor, Me.proveedorReportes, Me.proveedorRetencion, Me.proveedorDevolucion, Me.proveedorRecepcion, Me.proveedorNotaCreditoMonto})
        Me.menuPROVEEDOR.Image = CType(resources.GetObject("menuPROVEEDOR.Image"), System.Drawing.Image)
        Me.menuPROVEEDOR.Name = "menuPROVEEDOR"
        Me.menuPROVEEDOR.Size = New System.Drawing.Size(89, 20)
        Me.menuPROVEEDOR.Text = "&Proveedor"
        '
        'proveedorFacturaCompra
        '
        Me.proveedorFacturaCompra.Image = CType(resources.GetObject("proveedorFacturaCompra.Image"), System.Drawing.Image)
        Me.proveedorFacturaCompra.Name = "proveedorFacturaCompra"
        Me.proveedorFacturaCompra.Size = New System.Drawing.Size(299, 22)
        Me.proveedorFacturaCompra.Text = "&Factura de Compra"
        '
        'menuProveedorConsultas
        '
        Me.menuProveedorConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.proveedorConsultaFacturaCompra, Me.proveedorConsultaGasto, Me.proveedorConsultaNotaCredito, Me.proveedorConsultaPagoProveedor, Me.proveedorConsultaRetencion})
        Me.menuProveedorConsultas.Image = CType(resources.GetObject("menuProveedorConsultas.Image"), System.Drawing.Image)
        Me.menuProveedorConsultas.Name = "menuProveedorConsultas"
        Me.menuProveedorConsultas.Size = New System.Drawing.Size(299, 22)
        Me.menuProveedorConsultas.Text = "&Consultas"
        '
        'proveedorConsultaFacturaCompra
        '
        Me.proveedorConsultaFacturaCompra.Name = "proveedorConsultaFacturaCompra"
        Me.proveedorConsultaFacturaCompra.Size = New System.Drawing.Size(178, 22)
        Me.proveedorConsultaFacturaCompra.Text = "&Factura de Compra"
        '
        'proveedorConsultaGasto
        '
        Me.proveedorConsultaGasto.Name = "proveedorConsultaGasto"
        Me.proveedorConsultaGasto.Size = New System.Drawing.Size(178, 22)
        Me.proveedorConsultaGasto.Text = "&Gastos"
        '
        'proveedorConsultaNotaCredito
        '
        Me.proveedorConsultaNotaCredito.Name = "proveedorConsultaNotaCredito"
        Me.proveedorConsultaNotaCredito.Size = New System.Drawing.Size(178, 22)
        Me.proveedorConsultaNotaCredito.Text = "&Nota de Crédito"
        '
        'proveedorConsultaPagoProveedor
        '
        Me.proveedorConsultaPagoProveedor.Name = "proveedorConsultaPagoProveedor"
        Me.proveedorConsultaPagoProveedor.Size = New System.Drawing.Size(178, 22)
        Me.proveedorConsultaPagoProveedor.Text = "&Pago a Proveedores"
        '
        'proveedorConsultaRetencion
        '
        Me.proveedorConsultaRetencion.Name = "proveedorConsultaRetencion"
        Me.proveedorConsultaRetencion.Size = New System.Drawing.Size(178, 22)
        Me.proveedorConsultaRetencion.Text = "&Retenciones"
        '
        'proveedorEstadistica
        '
        Me.proveedorEstadistica.Image = CType(resources.GetObject("proveedorEstadistica.Image"), System.Drawing.Image)
        Me.proveedorEstadistica.Name = "proveedorEstadistica"
        Me.proveedorEstadistica.Size = New System.Drawing.Size(299, 22)
        Me.proveedorEstadistica.Text = "&Estadísticas"
        '
        'proveedorGasto
        '
        Me.proveedorGasto.Image = CType(resources.GetObject("proveedorGasto.Image"), System.Drawing.Image)
        Me.proveedorGasto.Name = "proveedorGasto"
        Me.proveedorGasto.Size = New System.Drawing.Size(299, 22)
        Me.proveedorGasto.Text = "&Gastos"
        '
        'proveedorNotaCredito
        '
        Me.proveedorNotaCredito.Image = CType(resources.GetObject("proveedorNotaCredito.Image"), System.Drawing.Image)
        Me.proveedorNotaCredito.Name = "proveedorNotaCredito"
        Me.proveedorNotaCredito.Size = New System.Drawing.Size(299, 22)
        Me.proveedorNotaCredito.Text = "Nota de Crédito"
        '
        'proveedorNotaCreditoGasto
        '
        Me.proveedorNotaCreditoGasto.Image = CType(resources.GetObject("proveedorNotaCreditoGasto.Image"), System.Drawing.Image)
        Me.proveedorNotaCreditoGasto.Name = "proveedorNotaCreditoGasto"
        Me.proveedorNotaCreditoGasto.Size = New System.Drawing.Size(299, 22)
        Me.proveedorNotaCreditoGasto.Text = "Nota Crédito de Gastos"
        '
        'proveedorPagoProveedor
        '
        Me.proveedorPagoProveedor.Image = CType(resources.GetObject("proveedorPagoProveedor.Image"), System.Drawing.Image)
        Me.proveedorPagoProveedor.Name = "proveedorPagoProveedor"
        Me.proveedorPagoProveedor.Size = New System.Drawing.Size(299, 22)
        Me.proveedorPagoProveedor.Text = "&Pago a Proveedor"
        '
        'proveedorReportes
        '
        Me.proveedorReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.proveedorReporteCompraGasto, Me.proveedorReporteDatos, Me.proveedorReporteSaldoProveedor})
        Me.proveedorReportes.Image = CType(resources.GetObject("proveedorReportes.Image"), System.Drawing.Image)
        Me.proveedorReportes.Name = "proveedorReportes"
        Me.proveedorReportes.Size = New System.Drawing.Size(299, 22)
        Me.proveedorReportes.Text = "&Reportes"
        '
        'proveedorReporteCompraGasto
        '
        Me.proveedorReporteCompraGasto.Name = "proveedorReporteCompraGasto"
        Me.proveedorReporteCompraGasto.Size = New System.Drawing.Size(187, 22)
        Me.proveedorReporteCompraGasto.Text = "&Compras y Gastos"
        '
        'proveedorReporteDatos
        '
        Me.proveedorReporteDatos.Name = "proveedorReporteDatos"
        Me.proveedorReporteDatos.Size = New System.Drawing.Size(187, 22)
        Me.proveedorReporteDatos.Text = "&Datos "
        '
        'proveedorReporteSaldoProveedor
        '
        Me.proveedorReporteSaldoProveedor.Name = "proveedorReporteSaldoProveedor"
        Me.proveedorReporteSaldoProveedor.Size = New System.Drawing.Size(187, 22)
        Me.proveedorReporteSaldoProveedor.Text = "&Saldo de Proveedores"
        '
        'proveedorRetencion
        '
        Me.proveedorRetencion.Image = CType(resources.GetObject("proveedorRetencion.Image"), System.Drawing.Image)
        Me.proveedorRetencion.Name = "proveedorRetencion"
        Me.proveedorRetencion.Size = New System.Drawing.Size(299, 22)
        Me.proveedorRetencion.Text = "Retenciones"
        '
        'proveedorDevolucion
        '
        Me.proveedorDevolucion.Image = CType(resources.GetObject("proveedorDevolucion.Image"), System.Drawing.Image)
        Me.proveedorDevolucion.Name = "proveedorDevolucion"
        Me.proveedorDevolucion.Size = New System.Drawing.Size(299, 22)
        Me.proveedorDevolucion.Text = "Devoluciones comprometido en Compras"
        '
        'proveedorRecepcion
        '
        Me.proveedorRecepcion.Image = CType(resources.GetObject("proveedorRecepcion.Image"), System.Drawing.Image)
        Me.proveedorRecepcion.Name = "proveedorRecepcion"
        Me.proveedorRecepcion.Size = New System.Drawing.Size(299, 22)
        Me.proveedorRecepcion.Text = "Recepcion de Mercaderias comprometidas"
        '
        'proveedorNotaCreditoMonto
        '
        Me.proveedorNotaCreditoMonto.Image = CType(resources.GetObject("proveedorNotaCreditoMonto.Image"), System.Drawing.Image)
        Me.proveedorNotaCreditoMonto.Name = "proveedorNotaCreditoMonto"
        Me.proveedorNotaCreditoMonto.Size = New System.Drawing.Size(299, 22)
        Me.proveedorNotaCreditoMonto.Text = "Nota de Crédito por Monto"
        '
        'menuMERCADERIA
        '
        Me.menuMERCADERIA.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mercaderiaReferenciarMercaderia, Me.mercaderiaConsultas, Me.menuMecaderiaDescuentos, Me.menuMercaderiaEstadisticas, Me.menuMecaderiaMercaderias, Me.MercaderiaModificarCosto, Me.menuMercaderiaReportes, Me.menuMercaderiaStockInicial})
        Me.menuMERCADERIA.Image = CType(resources.GetObject("menuMERCADERIA.Image"), System.Drawing.Image)
        Me.menuMERCADERIA.Name = "menuMERCADERIA"
        Me.menuMERCADERIA.Size = New System.Drawing.Size(94, 20)
        Me.menuMERCADERIA.Text = "&Mercadería"
        '
        'mercaderiaReferenciarMercaderia
        '
        Me.mercaderiaReferenciarMercaderia.Image = CType(resources.GetObject("mercaderiaReferenciarMercaderia.Image"), System.Drawing.Image)
        Me.mercaderiaReferenciarMercaderia.Name = "mercaderiaReferenciarMercaderia"
        Me.mercaderiaReferenciarMercaderia.Size = New System.Drawing.Size(200, 22)
        Me.mercaderiaReferenciarMercaderia.Text = "&Referenciar Mercaderías"
        '
        'mercaderiaConsultas
        '
        Me.mercaderiaConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mercaderiaConsultasAjustePositivo, Me.mercaderiaConsultasAjusteNegativo, Me.mercaderiaConsultasMercaderiaControlada, Me.mercaderiaConsultasPedidoSucursal, Me.mercaderiaConsultasPedidoASucursal, Me.mercaderiaConsultasPedidoProveedor, Me.mercaderiaConsultasRecepcion, Me.mercaderiaConsultasRecepcionPendiente, Me.mercaderiaConsultasRemision, Me.mercaderiaConsultasRemisionPendiente, Me.mercaderiaConsultasStock, Me.mercaderiaConsultasStockInicial, Me.mercaderiaConsultasModificaPrecioEntero, Me.mercaderiaConsultasPromoSamsung})
        Me.mercaderiaConsultas.Image = CType(resources.GetObject("mercaderiaConsultas.Image"), System.Drawing.Image)
        Me.mercaderiaConsultas.Name = "mercaderiaConsultas"
        Me.mercaderiaConsultas.Size = New System.Drawing.Size(200, 22)
        Me.mercaderiaConsultas.Text = "&Consultas"
        '
        'mercaderiaConsultasAjustePositivo
        '
        Me.mercaderiaConsultasAjustePositivo.Name = "mercaderiaConsultasAjustePositivo"
        Me.mercaderiaConsultasAjustePositivo.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasAjustePositivo.Text = "&Ajuste Positivo"
        '
        'mercaderiaConsultasAjusteNegativo
        '
        Me.mercaderiaConsultasAjusteNegativo.Name = "mercaderiaConsultasAjusteNegativo"
        Me.mercaderiaConsultasAjusteNegativo.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasAjusteNegativo.Text = "Ajuste &Negativo"
        '
        'mercaderiaConsultasMercaderiaControlada
        '
        Me.mercaderiaConsultasMercaderiaControlada.Name = "mercaderiaConsultasMercaderiaControlada"
        Me.mercaderiaConsultasMercaderiaControlada.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasMercaderiaControlada.Text = "Mercaderias Controladas (DINAC)"
        '
        'mercaderiaConsultasPedidoSucursal
        '
        Me.mercaderiaConsultasPedidoSucursal.Name = "mercaderiaConsultasPedidoSucursal"
        Me.mercaderiaConsultasPedidoSucursal.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasPedidoSucursal.Text = "&Pedido a Sucursal"
        '
        'mercaderiaConsultasPedidoASucursal
        '
        Me.mercaderiaConsultasPedidoASucursal.Name = "mercaderiaConsultasPedidoASucursal"
        Me.mercaderiaConsultasPedidoASucursal.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasPedidoASucursal.Text = "Pedido a Sucursal a Remitir"
        '
        'mercaderiaConsultasPedidoProveedor
        '
        Me.mercaderiaConsultasPedidoProveedor.Name = "mercaderiaConsultasPedidoProveedor"
        Me.mercaderiaConsultasPedidoProveedor.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasPedidoProveedor.Text = "Pedido a Pr&oveedor"
        '
        'mercaderiaConsultasRecepcion
        '
        Me.mercaderiaConsultasRecepcion.Name = "mercaderiaConsultasRecepcion"
        Me.mercaderiaConsultasRecepcion.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasRecepcion.Text = "Re&cepciones"
        '
        'mercaderiaConsultasRecepcionPendiente
        '
        Me.mercaderiaConsultasRecepcionPendiente.Name = "mercaderiaConsultasRecepcionPendiente"
        Me.mercaderiaConsultasRecepcionPendiente.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasRecepcionPendiente.Text = "Recepciones &Pendientes"
        '
        'mercaderiaConsultasRemision
        '
        Me.mercaderiaConsultasRemision.Name = "mercaderiaConsultasRemision"
        Me.mercaderiaConsultasRemision.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasRemision.Text = "&Remision"
        '
        'mercaderiaConsultasRemisionPendiente
        '
        Me.mercaderiaConsultasRemisionPendiente.Name = "mercaderiaConsultasRemisionPendiente"
        Me.mercaderiaConsultasRemisionPendiente.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasRemisionPendiente.Text = "Remisi&ones Pendientes"
        '
        'mercaderiaConsultasStock
        '
        Me.mercaderiaConsultasStock.Name = "mercaderiaConsultasStock"
        Me.mercaderiaConsultasStock.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasStock.Text = "&Stock"
        '
        'mercaderiaConsultasStockInicial
        '
        Me.mercaderiaConsultasStockInicial.Name = "mercaderiaConsultasStockInicial"
        Me.mercaderiaConsultasStockInicial.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasStockInicial.Text = "Stock &Inicial"
        '
        'mercaderiaConsultasModificaPrecioEntero
        '
        Me.mercaderiaConsultasModificaPrecioEntero.Name = "mercaderiaConsultasModificaPrecioEntero"
        Me.mercaderiaConsultasModificaPrecioEntero.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasModificaPrecioEntero.Text = "Modifiación de precios enteros"
        '
        'mercaderiaConsultasPromoSamsung
        '
        Me.mercaderiaConsultasPromoSamsung.Name = "mercaderiaConsultasPromoSamsung"
        Me.mercaderiaConsultasPromoSamsung.Size = New System.Drawing.Size(252, 22)
        Me.mercaderiaConsultasPromoSamsung.Text = "Promo Samsung Club"
        '
        'menuMecaderiaDescuentos
        '
        Me.menuMecaderiaDescuentos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MercaderiaDescuentoGrupoCliente, Me.MercaderiaDescuentoEspecial, Me.MercaderiaDescuentoProductoMayo})
        Me.menuMecaderiaDescuentos.Image = CType(resources.GetObject("menuMecaderiaDescuentos.Image"), System.Drawing.Image)
        Me.menuMecaderiaDescuentos.Name = "menuMecaderiaDescuentos"
        Me.menuMecaderiaDescuentos.Size = New System.Drawing.Size(200, 22)
        Me.menuMecaderiaDescuentos.Text = "&Descuentos"
        '
        'MercaderiaDescuentoGrupoCliente
        '
        Me.MercaderiaDescuentoGrupoCliente.Name = "MercaderiaDescuentoGrupoCliente"
        Me.MercaderiaDescuentoGrupoCliente.Size = New System.Drawing.Size(266, 22)
        Me.MercaderiaDescuentoGrupoCliente.Text = "Por Grupo de Cliente"
        '
        'MercaderiaDescuentoEspecial
        '
        Me.MercaderiaDescuentoEspecial.Name = "MercaderiaDescuentoEspecial"
        Me.MercaderiaDescuentoEspecial.Size = New System.Drawing.Size(266, 22)
        Me.MercaderiaDescuentoEspecial.Text = "Descuentos Especiales"
        '
        'menuMercaderiaEstadisticas
        '
        Me.menuMercaderiaEstadisticas.Image = CType(resources.GetObject("menuMercaderiaEstadisticas.Image"), System.Drawing.Image)
        Me.menuMercaderiaEstadisticas.Name = "menuMercaderiaEstadisticas"
        Me.menuMercaderiaEstadisticas.Size = New System.Drawing.Size(200, 22)
        Me.menuMercaderiaEstadisticas.Text = "Estadísticas"
        '
        'menuMecaderiaMercaderias
        '
        Me.menuMecaderiaMercaderias.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mercaderiaMercaderiasAjustes, Me.mercaderiaMercaderiasFraccionar, Me.mercaderiaMercaderiasGenerarCodigoBarra, Me.mercaderiaMercaderiasImprimirCodigoBarra, Me.mercaderiaMercaderiasSeguimientoStock, Me.mercaderiaMercaderiasModificarCantidadFraccion, Me.mercaderiaMercaderiasModificarPRecioEntero, Me.mercaderiaMercaderiasModificarPrecioFraccion, Me.mercaderiaMercaderiasModificarVencimiento, Me.mercaderiaMercaderiasFoto})
        Me.menuMecaderiaMercaderias.Image = CType(resources.GetObject("menuMecaderiaMercaderias.Image"), System.Drawing.Image)
        Me.menuMecaderiaMercaderias.Name = "menuMecaderiaMercaderias"
        Me.menuMecaderiaMercaderias.Size = New System.Drawing.Size(200, 22)
        Me.menuMecaderiaMercaderias.Text = "&Mercaderías"
        '
        'mercaderiaMercaderiasAjustes
        '
        Me.mercaderiaMercaderiasAjustes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mercaderiaMercaderiasAjustesNegativo, Me.mercaderiaMercaderiasAjustesPositivo})
        Me.mercaderiaMercaderiasAjustes.Name = "mercaderiaMercaderiasAjustes"
        Me.mercaderiaMercaderiasAjustes.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasAjustes.Text = "&Ajustes"
        '
        'mercaderiaMercaderiasAjustesNegativo
        '
        Me.mercaderiaMercaderiasAjustesNegativo.Name = "mercaderiaMercaderiasAjustesNegativo"
        Me.mercaderiaMercaderiasAjustesNegativo.Size = New System.Drawing.Size(122, 22)
        Me.mercaderiaMercaderiasAjustesNegativo.Text = "&Negativo"
        '
        'mercaderiaMercaderiasAjustesPositivo
        '
        Me.mercaderiaMercaderiasAjustesPositivo.Name = "mercaderiaMercaderiasAjustesPositivo"
        Me.mercaderiaMercaderiasAjustesPositivo.Size = New System.Drawing.Size(122, 22)
        Me.mercaderiaMercaderiasAjustesPositivo.Text = "&Positivo"
        '
        'mercaderiaMercaderiasFraccionar
        '
        Me.mercaderiaMercaderiasFraccionar.Name = "mercaderiaMercaderiasFraccionar"
        Me.mercaderiaMercaderiasFraccionar.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasFraccionar.Text = "Fraccionar "
        '
        'mercaderiaMercaderiasGenerarCodigoBarra
        '
        Me.mercaderiaMercaderiasGenerarCodigoBarra.Name = "mercaderiaMercaderiasGenerarCodigoBarra"
        Me.mercaderiaMercaderiasGenerarCodigoBarra.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasGenerarCodigoBarra.Text = "&Generar Codigo de Barras"
        '
        'mercaderiaMercaderiasImprimirCodigoBarra
        '
        Me.mercaderiaMercaderiasImprimirCodigoBarra.Name = "mercaderiaMercaderiasImprimirCodigoBarra"
        Me.mercaderiaMercaderiasImprimirCodigoBarra.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasImprimirCodigoBarra.Text = "&Imprimir Codigos de Barras"
        '
        'mercaderiaMercaderiasSeguimientoStock
        '
        Me.mercaderiaMercaderiasSeguimientoStock.Name = "mercaderiaMercaderiasSeguimientoStock"
        Me.mercaderiaMercaderiasSeguimientoStock.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasSeguimientoStock.Text = "&Seguimineto de Stock"
        '
        'mercaderiaMercaderiasModificarCantidadFraccion
        '
        Me.mercaderiaMercaderiasModificarCantidadFraccion.Name = "mercaderiaMercaderiasModificarCantidadFraccion"
        Me.mercaderiaMercaderiasModificarCantidadFraccion.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasModificarCantidadFraccion.Text = "Modificar Cantidad de Fraccionamiento"
        '
        'mercaderiaMercaderiasModificarPRecioEntero
        '
        Me.mercaderiaMercaderiasModificarPRecioEntero.Name = "mercaderiaMercaderiasModificarPRecioEntero"
        Me.mercaderiaMercaderiasModificarPRecioEntero.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasModificarPRecioEntero.Text = "Modificar Precio &Entero"
        '
        'mercaderiaMercaderiasModificarPrecioFraccion
        '
        Me.mercaderiaMercaderiasModificarPrecioFraccion.Name = "mercaderiaMercaderiasModificarPrecioFraccion"
        Me.mercaderiaMercaderiasModificarPrecioFraccion.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasModificarPrecioFraccion.Text = "Modificar Precio &Fracción"
        '
        'mercaderiaMercaderiasModificarVencimiento
        '
        Me.mercaderiaMercaderiasModificarVencimiento.Name = "mercaderiaMercaderiasModificarVencimiento"
        Me.mercaderiaMercaderiasModificarVencimiento.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasModificarVencimiento.Text = "Modificar &Vencimiento"
        '
        'mercaderiaMercaderiasFoto
        '
        Me.mercaderiaMercaderiasFoto.Name = "mercaderiaMercaderiasFoto"
        Me.mercaderiaMercaderiasFoto.Size = New System.Drawing.Size(284, 22)
        Me.mercaderiaMercaderiasFoto.Text = "Fotos a Mercaderias"
        '
        'MercaderiaModificarCosto
        '
        Me.MercaderiaModificarCosto.Image = CType(resources.GetObject("MercaderiaModificarCosto.Image"), System.Drawing.Image)
        Me.MercaderiaModificarCosto.Name = "MercaderiaModificarCosto"
        Me.MercaderiaModificarCosto.Size = New System.Drawing.Size(200, 22)
        Me.MercaderiaModificarCosto.Text = "M&odificar Costos "
        '
        'menuMercaderiaReportes
        '
        Me.menuMercaderiaReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mercaderiasReportesMercaderiaGral, Me.mercaderiasReportesVencimientos})
        Me.menuMercaderiaReportes.Image = CType(resources.GetObject("menuMercaderiaReportes.Image"), System.Drawing.Image)
        Me.menuMercaderiaReportes.Name = "menuMercaderiaReportes"
        Me.menuMercaderiaReportes.Size = New System.Drawing.Size(200, 22)
        Me.menuMercaderiaReportes.Text = "Re&portes"
        '
        'mercaderiasReportesMercaderiaGral
        '
        Me.mercaderiasReportesMercaderiaGral.Name = "mercaderiasReportesMercaderiaGral"
        Me.mercaderiasReportesMercaderiaGral.Size = New System.Drawing.Size(176, 22)
        Me.mercaderiasReportesMercaderiaGral.Text = "&Mercadería en Gral."
        '
        'mercaderiasReportesVencimientos
        '
        Me.mercaderiasReportesVencimientos.Name = "mercaderiasReportesVencimientos"
        Me.mercaderiasReportesVencimientos.Size = New System.Drawing.Size(176, 22)
        Me.mercaderiasReportesVencimientos.Text = "&Vencimientos"
        '
        'menuMercaderiaStockInicial
        '
        Me.menuMercaderiaStockInicial.Image = CType(resources.GetObject("menuMercaderiaStockInicial.Image"), System.Drawing.Image)
        Me.menuMercaderiaStockInicial.Name = "menuMercaderiaStockInicial"
        Me.menuMercaderiaStockInicial.Size = New System.Drawing.Size(200, 22)
        Me.menuMercaderiaStockInicial.Text = "&Stock Inicial"
        '
        'menuFinanza
        '
        Me.menuFinanza.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.finanzaAjustarCaja, Me.finanzaArqueCaja, Me.finanzaConsulta, Me.finanzaTablaCotizacion, Me.finanzaReportes, Me.finanzaCargaPlanilla})
        Me.menuFinanza.Image = CType(resources.GetObject("menuFinanza.Image"), System.Drawing.Image)
        Me.menuFinanza.Name = "menuFinanza"
        Me.menuFinanza.Size = New System.Drawing.Size(75, 20)
        Me.menuFinanza.Text = "&Finanza"
        '
        'finanzaAjustarCaja
        '
        Me.finanzaAjustarCaja.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.finanzaAjustarCajaMas, Me.finanzaAjustarCajaMenos})
        Me.finanzaAjustarCaja.Image = CType(resources.GetObject("finanzaAjustarCaja.Image"), System.Drawing.Image)
        Me.finanzaAjustarCaja.Name = "finanzaAjustarCaja"
        Me.finanzaAjustarCaja.Size = New System.Drawing.Size(177, 22)
        Me.finanzaAjustarCaja.Text = "A&justar Caja"
        '
        'finanzaAjustarCajaMas
        '
        Me.finanzaAjustarCajaMas.Name = "finanzaAjustarCajaMas"
        Me.finanzaAjustarCajaMas.Size = New System.Drawing.Size(153, 22)
        Me.finanzaAjustarCajaMas.Text = "&Aumentar Caja"
        '
        'finanzaAjustarCajaMenos
        '
        Me.finanzaAjustarCajaMenos.Name = "finanzaAjustarCajaMenos"
        Me.finanzaAjustarCajaMenos.Size = New System.Drawing.Size(153, 22)
        Me.finanzaAjustarCajaMenos.Text = "&Disminuir Caja"
        '
        'finanzaArqueCaja
        '
        Me.finanzaArqueCaja.Image = CType(resources.GetObject("finanzaArqueCaja.Image"), System.Drawing.Image)
        Me.finanzaArqueCaja.Name = "finanzaArqueCaja"
        Me.finanzaArqueCaja.Size = New System.Drawing.Size(177, 22)
        Me.finanzaArqueCaja.Text = "&Arqueo de Caja"
        '
        'finanzaConsulta
        '
        Me.finanzaConsulta.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.finanzaConsultaArqueo, Me.finanzaConsultaPlanillaCaja})
        Me.finanzaConsulta.Image = CType(resources.GetObject("finanzaConsulta.Image"), System.Drawing.Image)
        Me.finanzaConsulta.Name = "finanzaConsulta"
        Me.finanzaConsulta.Size = New System.Drawing.Size(177, 22)
        Me.finanzaConsulta.Text = "&Consultas"
        '
        'finanzaConsultaArqueo
        '
        Me.finanzaConsultaArqueo.Name = "finanzaConsultaArqueo"
        Me.finanzaConsultaArqueo.Size = New System.Drawing.Size(159, 22)
        Me.finanzaConsultaArqueo.Text = "&Arqueo"
        '
        'finanzaConsultaPlanillaCaja
        '
        Me.finanzaConsultaPlanillaCaja.Name = "finanzaConsultaPlanillaCaja"
        Me.finanzaConsultaPlanillaCaja.Size = New System.Drawing.Size(159, 22)
        Me.finanzaConsultaPlanillaCaja.Text = "Planilla de Cajas"
        '
        'finanzaTablaCotizacion
        '
        Me.finanzaTablaCotizacion.Image = CType(resources.GetObject("finanzaTablaCotizacion.Image"), System.Drawing.Image)
        Me.finanzaTablaCotizacion.Name = "finanzaTablaCotizacion"
        Me.finanzaTablaCotizacion.Size = New System.Drawing.Size(177, 22)
        Me.finanzaTablaCotizacion.Text = "&Tabla de Cotización"
        '
        'finanzaReportes
        '
        Me.finanzaReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.finanzaReportesArqueo})
        Me.finanzaReportes.Image = CType(resources.GetObject("finanzaReportes.Image"), System.Drawing.Image)
        Me.finanzaReportes.Name = "finanzaReportes"
        Me.finanzaReportes.Size = New System.Drawing.Size(177, 22)
        Me.finanzaReportes.Text = "&Reportes"
        '
        'finanzaReportesArqueo
        '
        Me.finanzaReportesArqueo.Name = "finanzaReportesArqueo"
        Me.finanzaReportesArqueo.Size = New System.Drawing.Size(155, 22)
        Me.finanzaReportesArqueo.Text = "&Arqueo de Caja"
        '
        'finanzaCargaPlanilla
        '
        Me.finanzaCargaPlanilla.Image = CType(resources.GetObject("finanzaCargaPlanilla.Image"), System.Drawing.Image)
        Me.finanzaCargaPlanilla.Name = "finanzaCargaPlanilla"
        Me.finanzaCargaPlanilla.Size = New System.Drawing.Size(177, 22)
        Me.finanzaCargaPlanilla.Text = "Carga de Planillas"
        '
        'menuBANCO
        '
        Me.menuBANCO.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bancoAbm, Me.bancoAjustarCuenta, Me.bancoCargarCheque, Me.bancoCargarDeposito, Me.bancoConsultas, Me.bancoControlarCheque, Me.bancoImprimirOrdenCheque, Me.bancoOrdenCheque, Me.bancoReportes})
        Me.menuBANCO.Image = CType(resources.GetObject("menuBANCO.Image"), System.Drawing.Image)
        Me.menuBANCO.Name = "menuBANCO"
        Me.menuBANCO.Size = New System.Drawing.Size(73, 20)
        Me.menuBANCO.Text = "&Bancos"
        '
        'bancoAbm
        '
        Me.bancoAbm.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bancoAbmCuentaCorriente, Me.bancoAbmChequera})
        Me.bancoAbm.Image = CType(resources.GetObject("bancoAbm.Image"), System.Drawing.Image)
        Me.bancoAbm.Name = "bancoAbm"
        Me.bancoAbm.Size = New System.Drawing.Size(221, 22)
        Me.bancoAbm.Text = "&ABM"
        '
        'bancoAbmCuentaCorriente
        '
        Me.bancoAbmCuentaCorriente.Name = "bancoAbmCuentaCorriente"
        Me.bancoAbmCuentaCorriente.Size = New System.Drawing.Size(201, 22)
        Me.bancoAbmCuentaCorriente.Text = "Abm - &Cuenta Corriente"
        '
        'bancoAbmChequera
        '
        Me.bancoAbmChequera.Name = "bancoAbmChequera"
        Me.bancoAbmChequera.Size = New System.Drawing.Size(201, 22)
        Me.bancoAbmChequera.Text = "Abm - C&hequera"
        '
        'bancoAjustarCuenta
        '
        Me.bancoAjustarCuenta.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bancoAumentarCuenta, Me.bancoDisminuirCuenta})
        Me.bancoAjustarCuenta.Image = CType(resources.GetObject("bancoAjustarCuenta.Image"), System.Drawing.Image)
        Me.bancoAjustarCuenta.Name = "bancoAjustarCuenta"
        Me.bancoAjustarCuenta.Size = New System.Drawing.Size(221, 22)
        Me.bancoAjustarCuenta.Text = "A&justar Cuenta Corriente"
        '
        'bancoAumentarCuenta
        '
        Me.bancoAumentarCuenta.Name = "bancoAumentarCuenta"
        Me.bancoAumentarCuenta.Size = New System.Drawing.Size(168, 22)
        Me.bancoAumentarCuenta.Text = "&Aumentar Cuenta"
        '
        'bancoDisminuirCuenta
        '
        Me.bancoDisminuirCuenta.Name = "bancoDisminuirCuenta"
        Me.bancoDisminuirCuenta.Size = New System.Drawing.Size(168, 22)
        Me.bancoDisminuirCuenta.Text = "&Disminuir Cuenta"
        '
        'bancoCargarCheque
        '
        Me.bancoCargarCheque.Image = CType(resources.GetObject("bancoCargarCheque.Image"), System.Drawing.Image)
        Me.bancoCargarCheque.Name = "bancoCargarCheque"
        Me.bancoCargarCheque.Size = New System.Drawing.Size(221, 22)
        Me.bancoCargarCheque.Text = "Cargar &Cheques"
        '
        'bancoCargarDeposito
        '
        Me.bancoCargarDeposito.Image = CType(resources.GetObject("bancoCargarDeposito.Image"), System.Drawing.Image)
        Me.bancoCargarDeposito.Name = "bancoCargarDeposito"
        Me.bancoCargarDeposito.Size = New System.Drawing.Size(221, 22)
        Me.bancoCargarDeposito.Text = "Cargar &Depositos "
        '
        'bancoConsultas
        '
        Me.bancoConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bancoConsultasCheques, Me.bancoConsultasDepositoBancario, Me.bancoConsultasOrdenCheque})
        Me.bancoConsultas.Image = CType(resources.GetObject("bancoConsultas.Image"), System.Drawing.Image)
        Me.bancoConsultas.Name = "bancoConsultas"
        Me.bancoConsultas.Size = New System.Drawing.Size(221, 22)
        Me.bancoConsultas.Text = "C&onsultas"
        '
        'bancoConsultasCheques
        '
        Me.bancoConsultasCheques.Name = "bancoConsultasCheques"
        Me.bancoConsultasCheques.Size = New System.Drawing.Size(172, 22)
        Me.bancoConsultasCheques.Text = "&Cheques"
        '
        'bancoConsultasDepositoBancario
        '
        Me.bancoConsultasDepositoBancario.Name = "bancoConsultasDepositoBancario"
        Me.bancoConsultasDepositoBancario.Size = New System.Drawing.Size(172, 22)
        Me.bancoConsultasDepositoBancario.Text = "&Deposito Bancario"
        '
        'bancoConsultasOrdenCheque
        '
        Me.bancoConsultasOrdenCheque.Name = "bancoConsultasOrdenCheque"
        Me.bancoConsultasOrdenCheque.Size = New System.Drawing.Size(172, 22)
        Me.bancoConsultasOrdenCheque.Text = "&Orden de Cheques"
        '
        'bancoControlarCheque
        '
        Me.bancoControlarCheque.Image = CType(resources.GetObject("bancoControlarCheque.Image"), System.Drawing.Image)
        Me.bancoControlarCheque.Name = "bancoControlarCheque"
        Me.bancoControlarCheque.Size = New System.Drawing.Size(221, 22)
        Me.bancoControlarCheque.Text = "Controlar Cheques"
        '
        'bancoImprimirOrdenCheque
        '
        Me.bancoImprimirOrdenCheque.Image = CType(resources.GetObject("bancoImprimirOrdenCheque.Image"), System.Drawing.Image)
        Me.bancoImprimirOrdenCheque.Name = "bancoImprimirOrdenCheque"
        Me.bancoImprimirOrdenCheque.Size = New System.Drawing.Size(221, 22)
        Me.bancoImprimirOrdenCheque.Text = "&Imprimir Orden de Cheques"
        '
        'bancoOrdenCheque
        '
        Me.bancoOrdenCheque.Image = CType(resources.GetObject("bancoOrdenCheque.Image"), System.Drawing.Image)
        Me.bancoOrdenCheque.Name = "bancoOrdenCheque"
        Me.bancoOrdenCheque.Size = New System.Drawing.Size(221, 22)
        Me.bancoOrdenCheque.Text = "&Orden Cheque"
        '
        'bancoReportes
        '
        Me.bancoReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bancoReportesChequePendiente, Me.bancoReportesSaldoBanco})
        Me.bancoReportes.Image = CType(resources.GetObject("bancoReportes.Image"), System.Drawing.Image)
        Me.bancoReportes.Name = "bancoReportes"
        Me.bancoReportes.Size = New System.Drawing.Size(221, 22)
        Me.bancoReportes.Text = "&Reportes"
        '
        'bancoReportesChequePendiente
        '
        Me.bancoReportesChequePendiente.Name = "bancoReportesChequePendiente"
        Me.bancoReportesChequePendiente.Size = New System.Drawing.Size(169, 22)
        Me.bancoReportesChequePendiente.Text = "&Cheques Emitidos"
        '
        'bancoReportesSaldoBanco
        '
        Me.bancoReportesSaldoBanco.Name = "bancoReportesSaldoBanco"
        Me.bancoReportesSaldoBanco.Size = New System.Drawing.Size(169, 22)
        Me.bancoReportesSaldoBanco.Text = "&Saldo de Bancos"
        '
        'menuCONTABILIDAD
        '
        Me.menuCONTABILIDAD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contabilidadAbmTimbradoDE, Me.contabilidadAbmFacturaElectronica, Me.contabilidadReportes, Me.contabilidadActualizarRuc, Me.contabilidadGenerarFacturaDTE, Me.contabilidadGenerarNotaCrDTE})
        Me.menuCONTABILIDAD.Image = CType(resources.GetObject("menuCONTABILIDAD.Image"), System.Drawing.Image)
        Me.menuCONTABILIDAD.Name = "menuCONTABILIDAD"
        Me.menuCONTABILIDAD.Size = New System.Drawing.Size(103, 20)
        Me.menuCONTABILIDAD.Text = "C&ontabilidad"
        '
        'contabilidadAbmTimbradoDE
        '
        Me.contabilidadAbmTimbradoDE.Image = CType(resources.GetObject("contabilidadAbmTimbradoDE.Image"), System.Drawing.Image)
        Me.contabilidadAbmTimbradoDE.Name = "contabilidadAbmTimbradoDE"
        Me.contabilidadAbmTimbradoDE.Size = New System.Drawing.Size(273, 22)
        Me.contabilidadAbmTimbradoDE.Text = "Crear Timbrado FE"
        '
        'contabilidadAbmFacturaElectronica
        '
        Me.contabilidadAbmFacturaElectronica.Image = CType(resources.GetObject("contabilidadAbmFacturaElectronica.Image"), System.Drawing.Image)
        Me.contabilidadAbmFacturaElectronica.Name = "contabilidadAbmFacturaElectronica"
        Me.contabilidadAbmFacturaElectronica.Size = New System.Drawing.Size(273, 22)
        Me.contabilidadAbmFacturaElectronica.Text = "Crear Facturas Electrónicas"
        '
        'contabilidadReportes
        '
        Me.contabilidadReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contabilidadReportesLibroIva})
        Me.contabilidadReportes.Image = CType(resources.GetObject("contabilidadReportes.Image"), System.Drawing.Image)
        Me.contabilidadReportes.Name = "contabilidadReportes"
        Me.contabilidadReportes.Size = New System.Drawing.Size(273, 22)
        Me.contabilidadReportes.Text = "&Reportes"
        '
        'contabilidadReportesLibroIva
        '
        Me.contabilidadReportesLibroIva.Name = "contabilidadReportesLibroIva"
        Me.contabilidadReportesLibroIva.Size = New System.Drawing.Size(121, 22)
        Me.contabilidadReportesLibroIva.Text = "&Libro IVA"
        '
        'contabilidadActualizarRuc
        '
        Me.contabilidadActualizarRuc.Image = CType(resources.GetObject("contabilidadActualizarRuc.Image"), System.Drawing.Image)
        Me.contabilidadActualizarRuc.Name = "contabilidadActualizarRuc"
        Me.contabilidadActualizarRuc.Size = New System.Drawing.Size(273, 22)
        Me.contabilidadActualizarRuc.Text = "Actualizar RUC"
        '
        'contabilidadGenerarFacturaDTE
        '
        Me.contabilidadGenerarFacturaDTE.Image = CType(resources.GetObject("contabilidadGenerarFacturaDTE.Image"), System.Drawing.Image)
        Me.contabilidadGenerarFacturaDTE.Name = "contabilidadGenerarFacturaDTE"
        Me.contabilidadGenerarFacturaDTE.Size = New System.Drawing.Size(273, 22)
        Me.contabilidadGenerarFacturaDTE.Text = "Generar Facturas Electrónicas"
        '
        'contabilidadGenerarNotaCrDTE
        '
        Me.contabilidadGenerarNotaCrDTE.Image = CType(resources.GetObject("contabilidadGenerarNotaCrDTE.Image"), System.Drawing.Image)
        Me.contabilidadGenerarNotaCrDTE.Name = "contabilidadGenerarNotaCrDTE"
        Me.contabilidadGenerarNotaCrDTE.Size = New System.Drawing.Size(273, 22)
        Me.contabilidadGenerarNotaCrDTE.Text = "Generar Nota de Créditos Electrónicas"
        '
        'menuRRHH
        '
        Me.menuRRHH.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rrhhActualizarNoticia, Me.rrhhReportes})
        Me.menuRRHH.Image = CType(resources.GetObject("menuRRHH.Image"), System.Drawing.Image)
        Me.menuRRHH.Name = "menuRRHH"
        Me.menuRRHH.Size = New System.Drawing.Size(73, 20)
        Me.menuRRHH.Text = "&RR.HH."
        '
        'rrhhActualizarNoticia
        '
        Me.rrhhActualizarNoticia.Image = CType(resources.GetObject("rrhhActualizarNoticia.Image"), System.Drawing.Image)
        Me.rrhhActualizarNoticia.Name = "rrhhActualizarNoticia"
        Me.rrhhActualizarNoticia.Size = New System.Drawing.Size(230, 22)
        Me.rrhhActualizarNoticia.Text = "Actualizar Noticia del Sistema"
        '
        'rrhhReportes
        '
        Me.rrhhReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rrhhReportesHorario})
        Me.rrhhReportes.Image = CType(resources.GetObject("rrhhReportes.Image"), System.Drawing.Image)
        Me.rrhhReportes.Name = "rrhhReportes"
        Me.rrhhReportes.Size = New System.Drawing.Size(230, 22)
        Me.rrhhReportes.Text = "&Reportes"
        '
        'rrhhReportesHorario
        '
        Me.rrhhReportesHorario.Name = "rrhhReportesHorario"
        Me.rrhhReportesHorario.Size = New System.Drawing.Size(181, 22)
        Me.rrhhReportesHorario.Text = "&Horario del Personal"
        '
        'menuCONFIGURACION
        '
        Me.menuCONFIGURACION.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuConfiguracionAbm, Me.configuracionEmail, Me.configuracionCuotaCredito, Me.configuracionMantenimientoPass, Me.configuracionPermisoUsuario})
        Me.menuCONFIGURACION.Image = CType(resources.GetObject("menuCONFIGURACION.Image"), System.Drawing.Image)
        Me.menuCONFIGURACION.Name = "menuCONFIGURACION"
        Me.menuCONFIGURACION.Size = New System.Drawing.Size(111, 20)
        Me.menuCONFIGURACION.Text = "Con&figuración"
        '
        'menuConfiguracionAbm
        '
        Me.menuConfiguracionAbm.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.configuracionAbmPc, Me.configuracionAbmFormularios, Me.configuracionGenerarCodigoBarraUsuario, Me.configuracionAbmUsuario, Me.configuracionRegistrarFacturas, Me.configuracionTipoProceso, Me.configuracionAbmGrupoUsuario})
        Me.menuConfiguracionAbm.Image = CType(resources.GetObject("menuConfiguracionAbm.Image"), System.Drawing.Image)
        Me.menuConfiguracionAbm.Name = "menuConfiguracionAbm"
        Me.menuConfiguracionAbm.Size = New System.Drawing.Size(328, 22)
        Me.menuConfiguracionAbm.Text = "&ABM"
        '
        'configuracionAbmPc
        '
        Me.configuracionAbmPc.Name = "configuracionAbmPc"
        Me.configuracionAbmPc.Size = New System.Drawing.Size(238, 22)
        Me.configuracionAbmPc.Text = "&PC"
        '
        'configuracionAbmFormularios
        '
        Me.configuracionAbmFormularios.Name = "configuracionAbmFormularios"
        Me.configuracionAbmFormularios.Size = New System.Drawing.Size(238, 22)
        Me.configuracionAbmFormularios.Text = "&Formularios"
        '
        'configuracionGenerarCodigoBarraUsuario
        '
        Me.configuracionGenerarCodigoBarraUsuario.Name = "configuracionGenerarCodigoBarraUsuario"
        Me.configuracionGenerarCodigoBarraUsuario.Size = New System.Drawing.Size(238, 22)
        Me.configuracionGenerarCodigoBarraUsuario.Text = "Generar  Codigo Barras Usuario"
        '
        'configuracionAbmUsuario
        '
        Me.configuracionAbmUsuario.Name = "configuracionAbmUsuario"
        Me.configuracionAbmUsuario.Size = New System.Drawing.Size(238, 22)
        Me.configuracionAbmUsuario.Text = "&Usuario"
        '
        'configuracionRegistrarFacturas
        '
        Me.configuracionRegistrarFacturas.Name = "configuracionRegistrarFacturas"
        Me.configuracionRegistrarFacturas.Size = New System.Drawing.Size(238, 22)
        Me.configuracionRegistrarFacturas.Text = "Registrar &Facturas"
        '
        'configuracionTipoProceso
        '
        Me.configuracionTipoProceso.Name = "configuracionTipoProceso"
        Me.configuracionTipoProceso.Size = New System.Drawing.Size(238, 22)
        Me.configuracionTipoProceso.Text = "Tipo de Procedimiento"
        '
        'configuracionAbmGrupoUsuario
        '
        Me.configuracionAbmGrupoUsuario.Name = "configuracionAbmGrupoUsuario"
        Me.configuracionAbmGrupoUsuario.Size = New System.Drawing.Size(238, 22)
        Me.configuracionAbmGrupoUsuario.Text = "Grupo de Usuario"
        '
        'configuracionEmail
        '
        Me.configuracionEmail.Image = CType(resources.GetObject("configuracionEmail.Image"), System.Drawing.Image)
        Me.configuracionEmail.Name = "configuracionEmail"
        Me.configuracionEmail.Size = New System.Drawing.Size(328, 22)
        Me.configuracionEmail.Text = "&Configuracion Em@il"
        '
        'configuracionCuotaCredito
        '
        Me.configuracionCuotaCredito.Image = CType(resources.GetObject("configuracionCuotaCredito.Image"), System.Drawing.Image)
        Me.configuracionCuotaCredito.Name = "configuracionCuotaCredito"
        Me.configuracionCuotaCredito.Size = New System.Drawing.Size(328, 22)
        Me.configuracionCuotaCredito.Text = "Cantidad de Cuotas a Crédito"
        '
        'configuracionMantenimientoPass
        '
        Me.configuracionMantenimientoPass.Image = CType(resources.GetObject("configuracionMantenimientoPass.Image"), System.Drawing.Image)
        Me.configuracionMantenimientoPass.Name = "configuracionMantenimientoPass"
        Me.configuracionMantenimientoPass.Size = New System.Drawing.Size(328, 22)
        Me.configuracionMantenimientoPass.Text = "&Mantenimiento de Contraseñas y Cod. de Barras"
        '
        'configuracionPermisoUsuario
        '
        Me.configuracionPermisoUsuario.Image = CType(resources.GetObject("configuracionPermisoUsuario.Image"), System.Drawing.Image)
        Me.configuracionPermisoUsuario.Name = "configuracionPermisoUsuario"
        Me.configuracionPermisoUsuario.Size = New System.Drawing.Size(328, 22)
        Me.configuracionPermisoUsuario.Text = "&Permisos de Usuarios"
        '
        'horario
        '
        Me.horario.Image = CType(resources.GetObject("horario.Image"), System.Drawing.Image)
        Me.horario.Name = "horario"
        Me.horario.Size = New System.Drawing.Size(75, 20)
        Me.horario.Text = "H&orario"
        '
        'lblIdUsuario
        '
        Me.lblIdUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdUsuario.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblIdUsuario.Location = New System.Drawing.Point(44, 12)
        Me.lblIdUsuario.Name = "lblIdUsuario"
        Me.lblIdUsuario.Size = New System.Drawing.Size(36, 14)
        Me.lblIdUsuario.TabIndex = 3
        Me.lblIdUsuario.Text = "IDUsuario"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.picFotoUsuario)
        Me.GroupBox1.Controls.Add(Me.lblBaseDatos)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblEmpresaContable)
        Me.GroupBox1.Controls.Add(Me.lblIdPersonaJur)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblIdGrupoUsuario)
        Me.GroupBox1.Controls.Add(Me.lblFechaServidor)
        Me.GroupBox1.Controls.Add(Me.lblHora)
        Me.GroupBox1.Controls.Add(Me.lblSucursal)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblEntidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFechaHoraServer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblGrupoUsuario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.lblNombreUsuario)
        Me.GroupBox1.Controls.Add(Me.lblIdUsuario)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 415)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(974, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'picFotoUsuario
        '
        Me.picFotoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFotoUsuario.Location = New System.Drawing.Point(872, 8)
        Me.picFotoUsuario.Name = "picFotoUsuario"
        Me.picFotoUsuario.Size = New System.Drawing.Size(99, 89)
        Me.picFotoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFotoUsuario.TabIndex = 12
        Me.picFotoUsuario.TabStop = False
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.AutoSize = True
        Me.lblBaseDatos.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBaseDatos.Location = New System.Drawing.Point(560, 83)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(120, 18)
        Me.lblBaseDatos.TabIndex = 24
        Me.lblBaseDatos.Text = "BASE DE DATOS"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(479, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Base de Datos :"
        '
        'lblEmpresaContable
        '
        Me.lblEmpresaContable.AutoSize = True
        Me.lblEmpresaContable.BackColor = System.Drawing.Color.DarkBlue
        Me.lblEmpresaContable.ForeColor = System.Drawing.Color.White
        Me.lblEmpresaContable.Location = New System.Drawing.Point(508, 26)
        Me.lblEmpresaContable.Name = "lblEmpresaContable"
        Me.lblEmpresaContable.Size = New System.Drawing.Size(119, 13)
        Me.lblEmpresaContable.TabIndex = 21
        Me.lblEmpresaContable.Text = "EMPRESA CONTABLE"
        '
        'lblIdPersonaJur
        '
        Me.lblIdPersonaJur.AutoSize = True
        Me.lblIdPersonaJur.BackColor = System.Drawing.Color.DarkBlue
        Me.lblIdPersonaJur.ForeColor = System.Drawing.Color.White
        Me.lblIdPersonaJur.Location = New System.Drawing.Point(488, 26)
        Me.lblIdPersonaJur.Name = "lblIdPersonaJur"
        Me.lblIdPersonaJur.Size = New System.Drawing.Size(18, 13)
        Me.lblIdPersonaJur.TabIndex = 20
        Me.lblIdPersonaJur.Text = "ID"
        Me.lblIdPersonaJur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(580, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Empresa Contable"
        '
        'lblIdGrupoUsuario
        '
        Me.lblIdGrupoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdGrupoUsuario.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblIdGrupoUsuario.Location = New System.Drawing.Point(42, 27)
        Me.lblIdGrupoUsuario.Name = "lblIdGrupoUsuario"
        Me.lblIdGrupoUsuario.Size = New System.Drawing.Size(20, 12)
        Me.lblIdGrupoUsuario.TabIndex = 18
        Me.lblIdGrupoUsuario.Text = "ID"
        '
        'lblFechaServidor
        '
        Me.lblFechaServidor.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaServidor.ForeColor = System.Drawing.Color.Blue
        Me.lblFechaServidor.Location = New System.Drawing.Point(3, 79)
        Me.lblFechaServidor.Name = "lblFechaServidor"
        Me.lblFechaServidor.Size = New System.Drawing.Size(282, 20)
        Me.lblFechaServidor.TabIndex = 17
        Me.lblFechaServidor.Text = "Fecha del Servidor"
        Me.lblFechaServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHora.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.ForeColor = System.Drawing.Color.Blue
        Me.lblHora.Location = New System.Drawing.Point(6, 61)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(103, 17)
        Me.lblHora.TabIndex = 11
        Me.lblHora.Text = "Hora"
        Me.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSucursal.Location = New System.Drawing.Point(537, 65)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(65, 13)
        Me.lblSucursal.TabIndex = 16
        Me.lblSucursal.Text = "SUCURSAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(483, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Sucursal :"
        '
        'lblEntidad
        '
        Me.lblEntidad.AutoSize = True
        Me.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEntidad.Location = New System.Drawing.Point(530, 47)
        Me.lblEntidad.Name = "lblEntidad"
        Me.lblEntidad.Size = New System.Drawing.Size(55, 13)
        Me.lblEntidad.TabIndex = 14
        Me.lblEntidad.Text = "ENTIDAD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(482, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Entidad :"
        '
        'txtFechaHoraServer
        '
        Me.txtFechaHoraServer.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFechaHoraServer.Enabled = False
        Me.txtFechaHoraServer.Location = New System.Drawing.Point(129, 43)
        Me.txtFechaHoraServer.Name = "txtFechaHoraServer"
        Me.txtFechaHoraServer.Size = New System.Drawing.Size(157, 20)
        Me.txtFechaHoraServer.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fecha/Hora de Ingreso :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(3, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Grupo:"
        '
        'lblGrupoUsuario
        '
        Me.lblGrupoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupoUsuario.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblGrupoUsuario.Location = New System.Drawing.Point(73, 27)
        Me.lblGrupoUsuario.Name = "lblGrupoUsuario"
        Me.lblGrupoUsuario.Size = New System.Drawing.Size(143, 13)
        Me.lblGrupoUsuario.TabIndex = 6
        Me.lblGrupoUsuario.Text = "Grupo de Usuario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(1, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Usuario:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(485, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(319, 15)
        Me.Panel2.TabIndex = 22
        '
        'lblNombreUsuario
        '
        Me.lblNombreUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreUsuario.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblNombreUsuario.Location = New System.Drawing.Point(69, 13)
        Me.lblNombreUsuario.Name = "lblNombreUsuario"
        Me.lblNombreUsuario.Size = New System.Drawing.Size(246, 15)
        Me.lblNombreUsuario.TabIndex = 5
        Me.lblNombreUsuario.Text = "Usuario del Sistema"
        '
        'lvCumple
        '
        Me.lvCumple.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {ColumnHeader1, Me.ColumnHeader2})
        Me.lvCumple.FullRowSelect = True
        Me.lvCumple.GridLines = True
        Me.lvCumple.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvCumple.HideSelection = False
        Me.lvCumple.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvCumple.LabelWrap = False
        Me.lvCumple.Location = New System.Drawing.Point(704, 24)
        Me.lvCumple.MultiSelect = False
        Me.lvCumple.Name = "lvCumple"
        Me.lvCumple.Size = New System.Drawing.Size(268, 344)
        Me.lvCumple.TabIndex = 17
        Me.lvCumple.UseCompatibleStateImageBehavior = False
        Me.lvCumple.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Dia"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 70
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        Me.Timer1.Tag = "     lblFechaHoraServer.Text = Date.Now.ToString"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.White
        Me.lblMensaje.Location = New System.Drawing.Point(904, 5)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(67, 16)
        Me.lblMensaje.TabIndex = 0
        Me.lblMensaje.Text = "Mensaje"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.lblMensaje)
        Me.Panel1.Location = New System.Drawing.Point(2, 514)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(969, 27)
        Me.Panel1.TabIndex = 21
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.lblNombreSucursal)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(0, 370)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(655, 44)
        Me.Panel3.TabIndex = 25
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreSucursal.Location = New System.Drawing.Point(100, 10)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(134, 25)
        Me.lblNombreSucursal.TabIndex = 26
        Me.lblNombreSucursal.Text = "SUCURSAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 24)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Sucursal :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblNombrePc)
        Me.GroupBox2.Controls.Add(Me.lblIdConfig)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(660, 362)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 50)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        '
        'lblNombrePc
        '
        Me.lblNombrePc.AutoSize = True
        Me.lblNombrePc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePc.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblNombrePc.Location = New System.Drawing.Point(68, 32)
        Me.lblNombrePc.Name = "lblNombrePc"
        Me.lblNombrePc.Size = New System.Drawing.Size(85, 15)
        Me.lblNombrePc.TabIndex = 3
        Me.lblNombrePc.Text = "NOMBREPC"
        '
        'lblIdConfig
        '
        Me.lblIdConfig.AutoSize = True
        Me.lblIdConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdConfig.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblIdConfig.Location = New System.Drawing.Point(68, 15)
        Me.lblIdConfig.Name = "lblIdConfig"
        Me.lblIdConfig.Size = New System.Drawing.Size(72, 15)
        Me.lblIdConfig.TabIndex = 2
        Me.lblIdConfig.Text = "IDCONFIG"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Nombre PC:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "IdConfig:"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 26)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(695, 341)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 28
        Me.PictureBox3.TabStop = False
        '
        'MercaderiaDescuentoProductoMayo
        '
        Me.MercaderiaDescuentoProductoMayo.Name = "MercaderiaDescuentoProductoMayo"
        Me.MercaderiaDescuentoProductoMayo.Size = New System.Drawing.Size(266, 22)
        Me.MercaderiaDescuentoProductoMayo.Text = "Descuento por Producto - Mayorista"
        '
        'frmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(974, 543)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lvCumple)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picFotoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents menuABM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCLIENTE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPROVEEDOR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFinanza As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAbmPersonas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmPersonaEntidad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblIdUsuario As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblGrupoUsuario As System.Windows.Forms.Label
    Friend WithEvents lblNombreUsuario As System.Windows.Forms.Label
    Friend WithEvents txtFechaHoraServer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picFotoUsuario As System.Windows.Forms.PictureBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblEntidad As System.Windows.Forms.Label
    Friend WithEvents lvCumple As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents lblFechaServidor As System.Windows.Forms.Label
    Friend WithEvents menuAbmMercaderias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmMercaderiaImpuesto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmMercaderiaProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmTipo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorFacturaCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProveedorConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorConsultaFacturaCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorNotaCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorConsultaNotaCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMERCADERIA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaReferenciarMercaderia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteDevolucion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuClienteConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaNotaCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCONFIGURACION As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuConfiguracionAbm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionAbmPc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMecaderiaDescuentos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaArqueCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionAbmUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionAbmFormularios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionPermisoUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblIdGrupoUsuario As System.Windows.Forms.Label
    Friend WithEvents configuracionMantenimientoPass As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents horario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEmpresaContable As System.Windows.Forms.Label
    Friend WithEvents lblIdPersonaJur As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblNombreSucursal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents menuMecaderiaMercaderias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasImprimirCodigoBarra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasSeguimientoStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasAjustes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasAjustesNegativo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasAjustesPositivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionRegistrarFacturas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaTablaCotizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaConsulta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaConsultaArqueo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMercaderiaStockInicial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuBANCO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoAbm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoAbmCuentaCorriente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoAbmChequera As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoCargarCheque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorPagoProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoCargarDeposito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoConsultasDepositoBancario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasPedidoSucursal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasRemision As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasModificarPRecioEntero As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasModificarPrecioFraccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAbmTipos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmTipoProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasRecepcionPendiente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasRecepcion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmDeposito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents mercaderiaConsultasStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaVentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaAjustarCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaAjustarCajaMas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaAjustarCajaMenos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportesControlVenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportesVenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoAjustarCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoAumentarCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoDisminuirCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasGenerarCodigoBarra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMercaderiaReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombrePc As System.Windows.Forms.Label
    Friend WithEvents lblIdConfig As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mercaderiaConsultasAjustePositivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasAjusteNegativo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasStockInicial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasPedidoProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiasReportesVencimientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoReportesSaldoBanco As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCONTABILIDAD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contabilidadReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contabilidadReportesLibroIva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorConsultaPagoProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoReportesChequePendiente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorGasto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorConsultaGasto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoConsultasCheques As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaHistorico As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteCobro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportesDelivery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaCobranza As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRRHH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rrhhReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rrhhReportesHorario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorReporteDatos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiasReportesMercaderiaGral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaReportesArqueo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportesSaldoCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionTipoProceso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionEmail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMercaderiaEstadisticas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MercaderiaModificarCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportesClienteMercaderia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasModificarVencimiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoOrdenCheque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoConsultasOrdenCheque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoImprimirOrdenCheque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClienteEstadisticas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasRemisionPendiente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteFacturacionFarmacia1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionCuotaCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorReporteSaldoProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionGenerarCodigoBarraUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorEstadistica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmMotivoAjuste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorNotaCreditoGasto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasPedidoASucursal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rrhhActualizarNoticia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasMercaderiaControlada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasFraccionar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasModificarCantidadFraccion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bancoControlarCheque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmPais As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorReporteCompraGasto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorRetencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorConsultaRetencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmGrupoCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaMercaderiasFoto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasModificaPrecioEntero As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaCargaPlanilla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents finanzaConsultaPlanillaCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mercaderiaConsultasPromoSamsung As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents configuracionAbmGrupoUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents contabilidadActualizarRuc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contabilidadGenerarFacturaDTE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contabilidadGenerarNotaCrDTE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contabilidadAbmTimbradoDE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contabilidadAbmFacturaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteOrdenPreparado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteOrdenPreparadoAutomotive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteOrdenPreparadoCoral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteOrdenPreparadoSuvinil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaOrdenCoral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaOrdenSuvinil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteConsultaOrdenAutomotive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MercaderiaDescuentoGrupoCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents abmColor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MercaderiaDescuentoEspecial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorDevolucion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorRecepcion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents proveedorNotaCreditoMonto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clienteReportesClienteCobro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MercaderiaDescuentoProductoMayo As System.Windows.Forms.ToolStripMenuItem
End Class
