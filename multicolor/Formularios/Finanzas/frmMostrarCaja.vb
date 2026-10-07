Public Class frmMostrarCaja
    '***************************'
    '-- VARIABLES TIPO OBJETO --'
    '***************************'
    Dim systemClass As New SystemClass
    Dim sp_datosTabla As New sp_datosTabla


    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listarDetalleCaja(intGl_idCaja)
        actualizarDatosCaja(intGl_idCaja)
    End Sub
    '********************'
    '-- PROCEDIMIENTOS --'
    '********************'
    Public Sub listarDetalleCaja(ByVal v_idCaja As Integer)
        '-- el detalle de los responsables de la caja
        systemClass.SqlToLv_detalleCompra(lvPersonal, "sp_consultaPersonalArqueo", v_idCaja)

    End Sub

    '-- actualizar los datos de la caja
    Public Sub actualizarDatosCaja(ByVal v_idCaja As Integer)
        ' MsgBox("Valor de idCaja en la consulta  " & v_idCaja)
        '-- el idCaja
        txtIdCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 0)
        '-- la sucursal
        Dim intTmpIdSucursal As Integer
        intTmpIdSucursal = sp_datosTabla.consulta_valor("select idSucursal from cabCaja where idcaja=" & v_idCaja)
        txtSucursal.Text = sp_datosTabla.consulta_valorString("select nombreFantasia from v_sucursalT where idSucursal=" & intTmpIdSucursal)
        '-- fecha y hora de carga
        txtFechaHora.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 3)
        '-- movimiento imp inicial
        txtIdMovIni1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 4)
        '- movimiento imp final
        txtIdMovFin1.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 5)
        '-- movimiento noimp inicial
        txtIdMovIni2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 6)
        '-- movimiento noimp final
        txtIdMovFin2.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 7)
        '-- fecha inicial y final imp
        If IsNumeric(txtIdMovIni1.Text) Then
            txtFechaIni1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & txtIdMovIni1.Text)
            txtFechaFin1.Text = sp_datosTabla.consulta_valorString("select fecha from cabVenta where idVenta=" & txtIdMovFin1.Text)
        End If
        '-- fecha inicial y final noimp
        If IsNumeric(txtIdMovIni2.Text) Then
            txtFechaIni2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & txtIdMovIni2.Text)
            txtFechaFin2.Text = sp_datosTabla.consulta_valorString("select fecha from cve where idVenta=" & txtIdMovFin2.Text)
        End If
        '-- total guaranies
        'MsgBox("Valor de total guarani  " & sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 12))
        txtTotalGuarani.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 12)
        txtTotalGuarani.Text = Format(CDec(txtTotalGuarani.Text), "###,###,##0")
        '-- total monedas
        txtTotalMoneda.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 13)
        txtTotalMoneda.Text = Format(CDec(txtTotalMoneda.Text), "###,###,##0")
        '-- total de gastos
        txtTotalGasto.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 14)
        txtTotalGasto.Text = Format(CDec(txtTotalGasto.Text), "###,###,##0")
        '-- total credito
        txtTotalCredito.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 15)
        txtTotalCredito.Text = Format(CDec(txtTotalCredito.Text), "###,###,##0")
        '-- total de tarjeta de debito
        txtTotalTarjetaDeb.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 16)
        txtTotalTarjetaDeb.Text = Format(CDec(txtTotalTarjetaDeb.Text), "###,###,##0")
        '-- total de tareta de credito
        txtTotalTarjetaCr.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 17)
        txtTotalTarjetaCr.Text = Format(CDec(txtTotalTarjetaCr.Text), "###,###,##0")
        '-- total cheque
        txtTotalCheque.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 18)
        txtTotalCheque.Text = Format(CDec(txtTotalCheque.Text), "###,###,##0")



        '---------------------
        ' totales generales
        '---------------------
        txtTotalCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 9)
        txtTotalCaja.Text = Format(CDec(txtTotalCaja.Text), "###,###,##0")
        txtTotalSistema.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 11)
        txtTotalSistema.Text = Format(CDec(txtTotalSistema.Text), "###,###,##0")
        txtTotalDevolucion.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 10)
        txtTotalDevolucion.Text = Format(CDec(txtTotalDevolucion.Text), "###,###,##0")
        '-- la diferencia
        txtTotalDiferencia.Text = sp_datosTabla.sp_traerValor("sp_consultaArqueo", v_idCaja, 27)
        txtTotalDiferencia.Text = Format(CDec(txtTotalDiferencia.Text), "###,###,##0")
        '---------------------------------------------------
    End Sub
    '------------------------------------------------------------------------------
    '*******************'
    '-- EL FORMULARIO --'
    '*******************'
    Private Sub frmConsultaArqueo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmArqueoCaja.btnGuardar.Enabled = True
        frmArqueoCaja.btnParar.Enabled = True
        frmArqueoCaja.Enabled = True
        frmArqueoCaja.Show()
        frmArqueoCaja.BringToFront()
        frmArqueoCaja.Refresh()
        e.Cancel = False

    End Sub
    '------------------------------------------------------------------------------

End Class