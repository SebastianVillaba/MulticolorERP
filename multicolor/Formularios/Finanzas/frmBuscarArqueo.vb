Public Class frmBuscarArqueo
    Private sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Private Sub listar(ByVal where As String)
        systemClass.SqlToLvConsultaCaja(lvCaja, "Select cc.idCaja,cc.totalCaja,cc.totalSistema,ltrim(_vs.nombreFantasia) as Sucursal,cc.fechaAlta,cc.controlado from cabCaja cc inner join v_sucursal _vs on cc.idSucursal=_vs.idSucursal  " & where)


        lvCaja.Columns(0).Width = 60
        lvCaja.Columns(1).Width = 100
        lvCaja.Columns(2).Width = 100
        lvCaja.Columns(3).Width = 250
        lvCaja.Columns(4).Width = 100
        lvCaja.Columns(5).Width = 35

        lvCaja.Columns(0).Text = "Id Caja"
        lvCaja.Columns(1).Text = "Total Caja"
        lvCaja.Columns(2).Text = "Total Sistema"
        lvCaja.Columns(3).Text = "Sucursal"
        lvCaja.Columns(4).Text = "Fecha"
        lvCaja.Columns(5).Text = "Cer"

        lvCaja.Scrollable = True
        ' txtSql.Text = "Select cc.idCaja,cc.totalCaja,cc.totalSistema,ltrim(_vs.nombreFantasia) as Sucursal,cc.fechaAlta from cabCaja cc inner join v_sucursal _vs on cc.idSucursal=_vs.idSucursal  " & where
    End Sub

    Private Sub verificarModulo()
        If banGl_consultaArqueo = True Then
            '-- consulta arqueo
            consultaArqueoCaja()
        End If
        If banGl_cajaMas = True Then
            '-- ajuste de caja positivo
            cajaMas(CInt(txtIdCaja.Text))
        End If
        If banGl_cajaMenos = True Then
            '-- ajuste de caja negativo
            cajaMenos(CInt(txtIdCaja.Text))
        End If
        If banGl_planillaCaja = True Then
            '-- planilla de cajas
            planillaCaja(CInt(txtIdCaja.Text))
        End If

    End Sub

    '-- para la consulta de arqueo
    Private Sub consultaArqueoCaja()
        '-- listar los responsables
        frmConsultaArqueo.listarDetalleCaja(CInt(txtIdCaja.Text))
        '-- los datos
        frmConsultaArqueo.actualizarDatosCaja(CInt(txtIdCaja.Text))
        'MsgBox("Valor de idCompra  " & (CInt(txtIdCompra.Text)))
        '------------------------------------------------------------
        Me.Close()
        frmConsultaArqueo.Enabled = True
        frmConsultaArqueo.Show()
        frmConsultaArqueo.BringToFront()
    End Sub

    '-- para el ajuste positivo de la caja
    Private Sub cajaMas(ByVal v_idCaja As Integer)
        '-- la sucursal
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabCaja where idCaja=" & v_idCaja)
        frmCajaMas.txtIdSucursal.Text = intTmpIdSucursal
        frmCajaMas.txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursal where idSucursal=" & intTmpIdSucursal)
        '-- datos de la caja
        frmCajaMas.txtIdCaja.Text = v_idCaja
        frmCajaMas.txtTotalCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 9)
        frmCajaMas.txtTotalCaja.Text = Format(CDec(frmCajaMas.txtTotalCaja.Text), "###,###,###.00")
        frmCajaMas.txtTotalSistema.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 30)
        frmCajaMas.txtTotalSistema.Text = Format(CDec(frmCajaMas.txtTotalSistema.Text), "###,###,##0")
        '-- la diferencia
        frmCajaMas.txtTotalDiferencia.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 27)
        frmCajaMas.txtTotalDiferencia.Text = Format(CDec(frmCajaMas.txtTotalDiferencia.Text), "###,###,##0")
        '---------------------------------------------------
        '-- movimiento imp inicial
        frmCajaMas.txtIdMovIni1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 4)
        '- movimiento imp final
        frmCajaMas.txtIdMovFin1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 5)
        '-- movimiento noimp inicial
        frmCajaMas.txtIdMovIni2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 6)
        '-- movimiento noimp final
        frmCajaMas.txtIdMovFin2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 7)
        '-- fecha inicial y final imp
        If IsNumeric(frmCajaMas.txtIdMovIni1.Text) Then
            frmCajaMas.txtFechaIni1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & frmCajaMas.txtIdMovIni1.Text)
            frmCajaMas.txtFechaFin1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & frmCajaMas.txtIdMovFin1.Text)
        End If
        '-- fecha inicial y final noimp
        If IsNumeric(frmCajaMas.txtIdMovIni2.Text) Then
            frmCajaMas.txtFechaIni2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & frmCajaMas.txtIdMovIni2.Text)
            frmCajaMas.txtFechaFin2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & frmCajaMas.txtIdMovFin2.Text)
        End If

        '-- habilitar los componentes
        '-- botones
        frmCajaMas.btnNuevo.Enabled = False
        frmCajaMas.btnGuardar.Enabled = True
        frmCajaMas.btnCancelar.Enabled = True
        '-- txt
        frmCajaMas.txtMotivo.Enabled = True
        frmCajaMas.txtMotivo.BackColor = Color.White
        frmCajaMas.txtMonto.Enabled = True
        frmCajaMas.txtMonto.BackColor = Color.White

        frmCajaMas.txtMonto.Focus()

        Me.Close()

    End Sub

    '-- para el ajuste negativo de la caja
    Private Sub cajaMenos(ByVal v_idCaja As Integer)
        '-- la sucursal
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabCaja where idCaja=" & v_idCaja)
        frmCajaMenos.txtIdSucursal.Text = intTmpIdSucursal
        frmCajaMenos.txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursal where idSucursal=" & intTmpIdSucursal)
        '-- datos de la caja
        frmCajaMenos.txtIdCaja.Text = v_idCaja
        frmCajaMenos.txtTotalCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 9)
        frmCajaMenos.txtTotalCaja.Text = Format(CDec(frmCajaMenos.txtTotalCaja.Text), "###,###,###.00")
        frmCajaMenos.txtTotalSistema.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 11)
        frmCajaMenos.txtTotalSistema.Text = Format(CDec(frmCajaMenos.txtTotalSistema.Text), "###,###,###.00")
        '-- la diferencia
        frmCajaMenos.txtTotalDiferencia.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 27)
        frmCajaMenos.txtTotalDiferencia.Text = Format(CDec(frmCajaMenos.txtTotalDiferencia.Text), "###,###,###.00")
        '---------------------------------------------------
        '-- movimiento imp inicial
        frmCajaMenos.txtIdMovIni1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 4)
        '- movimiento imp final
        frmCajaMenos.txtIdMovFin1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 5)
        '-- movimiento noimp inicial
        frmCajaMenos.txtIdMovIni2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 6)
        '-- movimiento noimp final
        frmCajaMenos.txtIdMovFin2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 7)
        '-- fecha inicial y final imp
        If IsNumeric(frmCajaMenos.txtIdMovIni1.Text) Then
            frmCajaMenos.txtFechaIni1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & frmCajaMenos.txtIdMovIni1.Text)
            frmCajaMenos.txtFechaFin1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & frmCajaMenos.txtIdMovFin1.Text)
        End If
        '-- fecha inicial y final noimp
        If IsNumeric(frmCajaMenos.txtIdMovIni2.Text) Then
            frmCajaMenos.txtFechaIni2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & frmCajaMenos.txtIdMovIni2.Text)
            frmCajaMenos.txtFechaFin2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & frmCajaMenos.txtIdMovFin2.Text)
        End If

        '-- habilitar los componentes
        '-- botones
        frmCajaMenos.btnNuevo.Enabled = False
        frmCajaMenos.btnGuardar.Enabled = True
        frmCajaMenos.btnCancelar.Enabled = True
        '-- txt
        frmCajaMenos.txtMotivo.Enabled = True
        frmCajaMenos.txtMotivo.BackColor = Color.White
        frmCajaMenos.txtMonto.Enabled = True
        frmCajaMenos.txtMonto.BackColor = Color.White

        frmCajaMenos.txtMonto.Focus()

        Me.Close()

    End Sub

    '-- planilla de cajas
    Private Sub planillaCaja(ByVal v_idCaja As Integer)
        '-- controlar que la caja no esté ya controlada
        If sp_datosTabla.consulta_valor("select idCaja from cabCaja where controlado=1 and idCaja=" & txtIdCaja.Text) > 0 Then
            MessageBox.Show("Esta caja ya está controlada...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        '-- la sucursal
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabCaja where idCaja=" & v_idCaja)
        frmPlanillaCaja.txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursal where idSucursal=" & intTmpIdSucursal)
        '-- datos de la caja
        frmPlanillaCaja.txtIdCaja.Text = v_idCaja
        'frmPlanillaCaja.txtTotalCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 9)
        'frmPlanillaCaja.txtTotalCaja.Text = Format(CDec(frmPlanillaCaja.txtTotalCaja.Text), "###,###,##0")
        frmPlanillaCaja.txtTotalSistema.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 11)
        frmPlanillaCaja.txtTotalSistema.Text = Format(CDec(frmPlanillaCaja.txtTotalSistema.Text), "###,###,##0")

        frmPlanillaCaja.mostrarValores(v_idCaja)

        frmPlanillaCaja.txtCant50.Focus()
        Me.Close()

    End Sub
    '------------------------------------------------------------------------------------
    '**********'
    '-- TXT --*
    '**********'
    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Not IsNumeric(txtBuscar.Text) Then
                '-- buscar por nombre
                'listar(" Where nombre Like '" & txtBuscar.Text & "%' Or nombre Like '" & txtBuscar.Text & "%' " & "order by nombre")
            Else
                '-- buscar por idCaja
                listar(" Where idCaja=" & txtBuscar.Text & " order by idCaja")
            End If
            lvCaja.Focus()
        End If
    End Sub
    '------------------------------------------------------------------------------------
    '*****************'
    '-- EL LISTVIEW --'
    '*****************'
    Private Sub lvCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCaja.KeyPress
        If IsNumeric(txtIdCaja.Text) Then
            '-- si ya ha sido controlado en el caso de las planillas


            If txtIdCaja.Text > 0 Then
                If e.KeyChar = ChrW(Keys.Enter) Then
                    verificarModulo()
                End If
            Else
                MessageBox.Show("Debe ingresar alguna Caja..!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub lvCaja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCaja.SelectedIndexChanged
        For Each item As ListViewItem In lvCaja.SelectedItems
            txtIdCaja.Text = CInt(item.SubItems(0).Text)
        Next
    End Sub
    '------------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'   
    Private Sub frmBuscarArqueo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        If banGl_consultaArqueo = True Then
            '-- consulta de arqueo de caja
            banGl_consultaArqueo = False

            frmConsultaArqueo.Enabled = True
            frmConsultaArqueo.Show()
            frmConsultaArqueo.BringToFront()
        End If
        If banGl_cajaMas = True Then
            '-- ajuste positivo de caja
            banGl_cajaMas = False

            frmCajaMas.Enabled = True
            frmCajaMas.Show()
            frmCajaMas.BringToFront()
        End If
        If banGl_cajaMenos = True Then
            '-- ajuste negativo de caja
            banGl_cajaMenos = False

            frmCajaMenos.Enabled = True
            frmCajaMenos.Show()
            frmCajaMenos.BringToFront()
        End If
        If banGl_planillaCaja = True Then
            '-- planilla de cajas
            banGl_planillaCaja = False

            frmPlanillaCaja.Enabled = True
            frmPlanillaCaja.Show()
            frmPlanillaCaja.BringToFront()
            frmPlanillaCaja.btnCargar.Focus()
        End If
    End Sub
End Class