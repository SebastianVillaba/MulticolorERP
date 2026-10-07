Public Class frmPlanillaCaja
    Dim sp_datosTabla As New sp_datosTabla
    Dim systemClass As New SystemClass

    Dim intIdCaja As Integer = 0
    Dim total50 As Double
    Dim total100 As Double
    Dim total500 As Double
    Dim total1000 As Double
    Dim total2000 As Double
    Dim total5000 As Double
    Dim total10000 As Double
    Dim total20000 As Double
    Dim total50000 As Double
    Dim total100000 As Double
    Dim credito As Double
    Dim gasto As Double
    Dim canje As Double
    Dim tarjetaCre As Double
    Dim tarjetaDeb As Double
    Dim cheque As Double
    Dim peso As Double
    Dim douReal As Double
    Dim euro As Double
    Dim dolar As Double
    Dim cotizaReal As Double
    Dim cotizaPeso As Double
    Dim cotizaDolar As Double
    Dim cotizaEuro As Double

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        inicializar()
        consultaDetalleCaja()
    End Sub

    Private Sub inicializar()
        limpiar()
        sumarTotales()
    End Sub

    Public Sub limpiar()
        Try
            '-- limpiar la tabla temporal de la venta
            'sp_datosTabla.consulta_valor("delete from detControlCajaTmp where idConfig=" & intGl_idConfigPc)
            '--- datos de la caja
            txtIdCaja.Text = 0
            txtSucursal.Text = ""
            txtTotalCaja.Text = 0
            txtTotalSistema.Text = 0
            txtTotalIngreso.Text = 0

            '-- los txt
            txtCant50.Text = 0
            txtCant100.Text = 0
            txtCant500.Text = 0
            txtCant1000.Text = 0
            txtCant2000.Text = 0
            txtCant5000.Text = 0
            txtCant10000.Text = 0
            txtCant20000.Text = 0
            txtCant50000.Text = 0
            txtCant100000.Text = 0
            txtPesoArg.Text = 0
            txtTotalDolar.Text = 0
            txtTotalReal.Text = 0
            txtTotalEuro.Text = 0
            txtTotalGasto.Text = 0
            txtTotalCredito.Text = 0
            txtTotalTarjetaCred.Text = 0
            txtTotalTarjetaDeb.Text = 0
            txtTotalCheque.Text = 0
            txtTotal.Text = 0
            txtTotalCanje.Text = 0


            consultaDetalleCaja()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.Name, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.Name
            errorSistema(strGl_mensajeError, Me.Name, intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try
    End Sub

    '-- listar los detalles cargados
    Private Sub consultaDetalleCaja()
        systemClass.SqlToLv_detalleCajaCargada(lvDetalleCaja, "sp_consultaDetallePlanillaCajaTmp", intGl_idConfigPc)
    End Sub

    Private Sub sumarTotales()
        total50 = txtCant50.Text * 50
        total100 = txtCant100.Text * 100
        total500 = txtCant500.Text * 500
        total2000 = txtCant2000.Text * 2000
        total1000 = txtCant1000.Text * 1000
        total5000 = txtCant5000.Text * 5000
        total10000 = txtCant10000.Text * 10000
        total20000 = txtCant20000.Text * 20000
        total50000 = txtCant50000.Text * 50000
        total100000 = txtCant100000.Text * 100000
        credito = CDbl(sacarComa(txtTotalCredito.Text))
        cheque = CDbl(sacarComa(txtTotalCheque.Text))
        gasto = CDbl(sacarComa(txtTotalGasto.Text))
        tarjetaCre = CDbl(sacarComa(txtTotalTarjetaCred.Text))
        canje = CDbl(sacarComa(txtTotalCanje.Text))
        tarjetaDeb = CDbl(sacarComa(txtTotalTarjetaDeb.Text))
        cotizaDolar = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idMoneda=3")
        cotizaPeso = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idMoneda=1")
        cotizaReal = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idMoneda=2")
        cotizaEuro = sp_datosTabla.consulta_valorDouble("select venta from detCotiza where idMoneda=6")
        dolar = CDbl(sacarComa(txtTotalDolar.Text)) * cotizaDolar
        peso = CDbl(sacarComa(txtPesoArg.Text)) * cotizaPeso
        douReal = (CDbl(sacarComa(txtTotalReal.Text)) * cotizaReal)
        euro = (CDbl(sacarComa(txtTotalEuro.Text)) * cotizaEuro)

        txtTotal.Text = total50 + total100 + total500 + total1000 + total2000 + total5000 + total10000 + total20000 + total50000 + total100000 + credito + cheque + gasto + tarjetaCre + tarjetaDeb + dolar + douReal + peso + canje + euro
        'txtTotal.Text = total50 + total100 + total500 + total1000 + total2000 + total5000 + total10000 + total20000 + total50000 + total100000 + credito + cheque + gasto + tarjetaCre + tarjetaDeb + dolar + douReal

        txtTotal.Text = Format(CDec(txtTotal.Text), "##,###,###,##0")

        If sp_datosTabla.consulta_valor("select idConfig from detControlCajaTmp where idConfig=" & intGl_idConfigPc) > 0 Then
            txtTotalIngreso.Text = sp_datosTabla.consulta_valorDouble("select sum(totalIngreso) from detControlCajaTmp where idConfig=" & intGl_idConfigPc)
        Else
            txtTotalIngreso.Text = 0
        End If

        txtTotalIngreso.Text = CDbl(sacarComa(txtTotalIngreso.Text)) + CDbl(sacarComa(txtTotal.Text))
        txtTotalIngreso.Text = Format(CDec(txtTotalIngreso.Text), "##,###,###,##0")
    End Sub

    Private Sub inicializaObjetos()
        '-- los txt
        txtCant50.Text = 0
        txtCant100.Text = 0
        txtCant500.Text = 0
        txtCant1000.Text = 0
        txtCant2000.Text = 0
        txtCant5000.Text = 0
        txtCant10000.Text = 0
        txtCant20000.Text = 0
        txtCant50000.Text = 0
        txtCant100000.Text = 0
        txtPesoArg.Text = 0
        txtTotalDolar.Text = 0
        txtTotalReal.Text = 0
        txtTotalGasto.Text = 0
        txtTotalCredito.Text = 0
        txtTotalTarjetaCred.Text = 0
        txtTotalTarjetaDeb.Text = 0
        txtTotalCheque.Text = 0
        txtTotal.Text = 0
        txtIdCaja.Text = 0
        txtTotalSistema.Text = 0
        txtTotalCaja.Text = 0
        txtSucursal.Text = ""
        txtTotalCanje.Text = 0
    End Sub

    Private Sub cargarPlanilla()
        If (fun_guardarSp("sp_agregarDetControlCajaTmp", intGl_idConfigPc & "," & txtIdCaja.Text & "," & txtCant50.Text & "," & txtCant100.Text & "," & txtCant500.Text & "," & txtCant1000.Text & _
                          "," & txtCant2000.Text & "," & txtCant5000.Text & "," & txtCant10000.Text & "," & txtCant20000.Text & "," & txtCant50000.Text & "," & txtCant100000.Text & _
                          "," & CDbl(sacarComa(txtPesoArg.Text)) & "," & CDbl(sacarComa(txtTotalDolar.Text)) & "," & CDbl(sacarComa(txtTotalReal.Text)) & "," & CDbl(sacarComa(txtTotalGasto.Text)) & _
                          "," & CDbl(sacarComa(txtTotalCredito.Text)) & "," & CDbl(sacarComa(txtTotalTarjetaCred.Text)) & "," & CDbl(sacarComa(txtTotalTarjetaDeb.Text)) & _
                          "," & CDbl(sacarComa(txtTotalCheque.Text)) & "," & CDbl(sacarComa(txtTotalCanje.Text)) & "," & CDbl(sacarComa(txtTotal.Text)) & "," & _
                          CDbl(sacarComa(txtTotalCaja.Text)) & "," & CDbl(sacarComa(txtTotalEuro.Text)), Me.Name)) = 0 Then
            '-- no se guardo los registros
            MessageBox.Show("No se pudo guardar los Registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            consultaDetalleCaja()
            inicializaObjetos()
            btnBuscar.Focus()
        End If
    End Sub

    Public Sub mostrarValores(ByVal v_idCaja As Integer)
        '--- 50
        txtCant50.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 0)
        txtCant50.Text = Format(CDec(txtCant50.Text), "#,##0")
        If CDbl(sacarComa(txtCant50.Text)) = 0 Then
            txtCant50.BackColor = Color.Pink
        Else
            txtCant50.BackColor = Color.GreenYellow
        End If
        '--- 100
        txtCant100.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 1)
        txtCant100.Text = Format(CDec(txtCant100.Text), "#,##0")
        If CDbl(sacarComa(txtCant100.Text)) = 0 Then
            txtCant100.BackColor = Color.Pink
        Else
            txtCant100.BackColor = Color.GreenYellow
        End If
        '--- 500
        txtCant500.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 2)
        txtCant500.Text = Format(CDec(txtCant500.Text), "#,##0")
        If CDbl(sacarComa(txtCant500.Text)) = 0 Then
            txtCant500.BackColor = Color.Pink
        Else
            txtCant500.BackColor = Color.GreenYellow
        End If
        '--1.000
        txtCant1000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 3)
        txtCant1000.Text = Format(CDec(txtCant1000.Text), "#,##0")
        If CDbl(sacarComa(txtCant1000.Text)) = 0 Then
            txtCant1000.BackColor = Color.Pink
        Else
            txtCant1000.BackColor = Color.GreenYellow
        End If
        '-- 2.000
        txtCant2000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 4)
        txtCant2000.Text = Format(CDec(txtCant2000.Text), "#,##0")
        If CDbl(sacarComa(txtCant2000.Text)) = 0 Then
            txtCant2000.BackColor = Color.Pink
        Else
            txtCant2000.BackColor = Color.GreenYellow
        End If
        '-- 5.000
        txtCant5000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 5)
        txtCant5000.Text = Format(CDec(txtCant5000.Text), "#,##0")
        If CDbl(sacarComa(txtCant5000.Text)) = 0 Then
            txtCant5000.BackColor = Color.Pink
        Else
            txtCant5000.BackColor = Color.GreenYellow
        End If
        '-- 10.000
        txtCant10000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 6)
        txtCant10000.Text = Format(CDec(txtCant10000.Text), "#,##0")
        If CDbl(sacarComa(txtCant10000.Text)) = 0 Then
            txtCant10000.BackColor = Color.Pink
        Else
            txtCant10000.BackColor = Color.GreenYellow
        End If
        '-- 20.000
        txtCant20000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 7)
        txtCant20000.Text = Format(CDec(txtCant20000.Text), "#,##0")
        If CDbl(sacarComa(txtCant20000.Text)) = 0 Then
            txtCant20000.BackColor = Color.Pink
        Else
            txtCant20000.BackColor = Color.GreenYellow
        End If
        '-- 50.000
        txtCant50000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 8)
        txtCant50000.Text = Format(CDec(txtCant50000.Text), "#,##0")
        If CDbl(sacarComa(txtCant50000.Text)) = 0 Then
            txtCant50000.BackColor = Color.Pink
        Else
            txtCant50000.BackColor = Color.GreenYellow
        End If
        '-- 100.000
        txtCant100000.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 9)
        txtCant100000.Text = Format(CDec(txtCant100000.Text), "#,##0")
        If CDbl(sacarComa(txtCant100000.Text)) = 0 Then
            txtCant100000.BackColor = Color.Pink
        Else
            txtCant100000.BackColor = Color.GreenYellow
        End If
        '-- peso
        txtPesoArg.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 10)
        txtPesoArg.Text = Format(CDec(txtPesoArg.Text), "###,##0.##")
        If CDbl(sacarComa(txtPesoArg.Text)) = 0 Then
            txtPesoArg.BackColor = Color.Pink
        Else
            txtPesoArg.BackColor = Color.GreenYellow
        End If
        '-- dolar
        txtTotalDolar.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 11)
        txtTotalDolar.Text = Format(CDec(txtTotalDolar.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalDolar.Text)) = 0 Then
            txtTotalDolar.BackColor = Color.Pink
        Else
            txtTotalDolar.BackColor = Color.GreenYellow
        End If
        '--real
        txtTotalReal.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 12)
        txtTotalReal.Text = Format(CDec(txtTotalReal.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalReal.Text)) = 0 Then
            txtTotalReal.BackColor = Color.Pink
        Else
            txtTotalReal.BackColor = Color.GreenYellow
        End If
        '-- gasto
        txtTotalGasto.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 13)
        txtTotalGasto.Text = Format(CDec(txtTotalGasto.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalGasto.Text)) = 0 Then
            txtTotalGasto.BackColor = Color.Pink
        Else
            txtTotalGasto.BackColor = Color.GreenYellow
        End If
        '-- credito
        txtTotalCredito.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 14)
        txtTotalCredito.Text = Format(CDec(txtTotalCredito.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalCredito.Text)) = 0 Then
            txtTotalCredito.BackColor = Color.Pink
        Else
            txtTotalCredito.BackColor = Color.GreenYellow
        End If
        '-- tarjeta de credito
        txtTotalTarjetaCred.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 16)
        txtTotalTarjetaCred.Text = Format(CDec(txtTotalTarjetaCred.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalTarjetaCred.Text)) = 0 Then
            txtTotalTarjetaCred.BackColor = Color.Pink
        Else
            txtTotalTarjetaCred.BackColor = Color.GreenYellow
        End If
        '-- tarjeta de debito
        txtTotalTarjetaDeb.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 15)
        txtTotalTarjetaDeb.Text = Format(CDec(txtTotalTarjetaDeb.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalTarjetaDeb.Text)) = 0 Then
            txtTotalTarjetaDeb.BackColor = Color.Pink
        Else
            txtTotalTarjetaDeb.BackColor = Color.GreenYellow
        End If
        '-- total cheque
        txtTotalCheque.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 17)
        txtTotalCheque.Text = Format(CDec(txtTotalCheque.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalCheque.Text)) = 0 Then
            txtTotalCheque.BackColor = Color.Pink
        Else
            txtTotalCheque.BackColor = Color.GreenYellow
        End If
        '-- total euro
        txtTotalEuro.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 19)
        txtTotalEuro.Text = Format(CDec(txtTotalEuro.Text), "###,##0.##")
        If CDbl(sacarComa(txtTotalEuro.Text)) = 0 Then
            txtTotalEuro.BackColor = Color.Pink
        Else
            txtTotalEuro.BackColor = Color.GreenYellow
        End If
        txtTotalCaja.Text = sp_datosTabla.sp_traerValor("sp_consultaCajaDetalle", v_idCaja, 18)
        txtTotalCaja.Text = Format(CDec(txtTotalCaja.Text), "##,###,###,##0")

        sumarTotales()
    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '*****************'
    '-- LOS BOTONES --'
    '*****************'
    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        cargarPlanilla()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        banGl_planillaCaja = True
        Me.Enabled = False
        frmBuscarArqueo.txtBuscar.Text = ""
        frmBuscarArqueo.txtIdCaja.Text = ""
        frmBuscarArqueo.Visible = True
        frmBuscarArqueo.Show()
        frmBuscarArqueo.BringToFront()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Me.Enabled = False

        frmGuardarControlPlanilla.listarDetalle()
        frmGuardarControlPlanilla.txtTotalIngreso.Text = txtTotalIngreso.Text
        frmGuardarControlPlanilla.Show()
        frmGuardarControlPlanilla.BringToFront()
        frmGuardarControlPlanilla.txtNroDoc.Focus()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        sp_datosTabla.consulta_valor("delete from detControlCajaTmp where idConfig=" & intGl_idConfigPc & " and idCaja=" & intIdCaja)
        sp_datosTabla.consulta_valor("delete from detControlCajaGuaraniesTmp where idConfig=" & intGl_idConfigPc & " and idCaja=" & intIdCaja)
        sp_datosTabla.consulta_valor("delete from detControlCajaMonedaTmp where idConfig=" & intGl_idConfigPc & " and idCaja=" & intIdCaja)

        sumarTotales()
        consultaDetalleCaja()

    End Sub
    '--------------------------------------------------------------------------------------------------------------------
    '****************'
    '-- LOS TEXTOS --'
    '****************'
    Private Sub txtCant50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant50.KeyPress
        e.Handled = txtNumerico(txtCant50, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant50.Text = Format(CDec(txtCant50.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant50.Text)) = 0 Then
                txtCant50.BackColor = Color.Pink
            Else
                txtCant50.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant100.Focus()
        End If
    End Sub

    Private Sub txtCant100_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant100.KeyPress
        e.Handled = txtNumerico(txtCant100, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant100.Text = Format(CDec(txtCant100.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant100.Text)) = 0 Then
                txtCant100.BackColor = Color.Pink
            Else
                txtCant100.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant500.Focus()
        End If
    End Sub

    Private Sub txtCant500_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant500.KeyPress
        e.Handled = txtNumerico(txtCant500, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant500.Text = Format(CDec(txtCant500.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant500.Text)) = 0 Then
                txtCant500.BackColor = Color.Pink
            Else
                txtCant500.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant1000.Focus()
        End If
    End Sub

    Private Sub txtCant1000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant1000.KeyPress
        e.Handled = txtNumerico(txtCant1000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant1000.Text = Format(CDec(txtCant1000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant1000.Text)) = 0 Then
                txtCant1000.BackColor = Color.Pink
            Else
                txtCant1000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant2000.Focus()
        End If
    End Sub

    Private Sub txtCant2000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant2000.KeyPress
        e.Handled = txtNumerico(txtCant2000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant2000.Text = Format(CDec(txtCant2000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant2000.Text)) = 0 Then
                txtCant2000.BackColor = Color.Pink
            Else
                txtCant2000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant5000.Focus()
        End If
    End Sub

    Private Sub txtCant5000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant5000.KeyPress
        e.Handled = txtNumerico(txtCant5000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant5000.Text = Format(CDec(txtCant5000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant5000.Text)) = 0 Then
                txtCant5000.BackColor = Color.Pink
            Else
                txtCant5000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant10000.Focus()
        End If
    End Sub

    Private Sub txtCant10000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant10000.KeyPress
        e.Handled = txtNumerico(txtCant10000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant10000.Text = Format(CDec(txtCant10000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant10000.Text)) = 0 Then
                txtCant10000.BackColor = Color.Pink
            Else
                txtCant10000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant20000.Focus()
        End If
    End Sub

    Private Sub txtCant20000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant20000.KeyPress
        e.Handled = txtNumerico(txtCant20000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant20000.Text = Format(CDec(txtCant20000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant20000.Text)) = 0 Then
                txtCant20000.BackColor = Color.Pink
            Else
                txtCant20000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant50000.Focus()
        End If
    End Sub

    Private Sub txtCant50000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant50000.KeyPress
        e.Handled = txtNumerico(txtCant50000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant50000.Text = Format(CDec(txtCant50000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant50000.Text)) = 0 Then
                txtCant50000.BackColor = Color.Pink
            Else
                txtCant50000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtCant100000.Focus()
        End If
    End Sub

    Private Sub txtCant100000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant100000.KeyPress
        e.Handled = txtNumerico(txtCant100000, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtCant100000.Text = Format(CDec(txtCant100000.Text), "##,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtCant100000.Text)) = 0 Then
                txtCant100000.BackColor = Color.Pink
            Else
                txtCant100000.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtPesoArg.Focus()
        End If
    End Sub

    Private Sub txtPesoArg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoArg.KeyPress
        e.Handled = txtNumerico(txtPesoArg, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtPesoArg.Text = Format(CDec(txtPesoArg.Text), "###,##0.##")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtPesoArg.Text)) = 0 Then
                txtPesoArg.BackColor = Color.Pink
            Else
                txtPesoArg.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalDolar.Focus()
        End If
    End Sub

    Private Sub txtTotalDolar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalDolar.KeyPress
        e.Handled = txtNumerico(txtTotalDolar, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalDolar.Text = Format(CDec(txtTotalDolar.Text), "###,##0.##")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalDolar.Text)) = 0 Then
                txtTotalDolar.BackColor = Color.Pink
            Else
                txtTotalDolar.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalReal.Focus()
        End If
    End Sub

    Private Sub txtTotalReal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalReal.KeyPress
        e.Handled = txtNumerico(txtTotalReal, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalReal.Text = Format(CDec(txtTotalReal.Text), "###,##0.##")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalReal.Text)) = 0 Then
                txtTotalReal.BackColor = Color.Pink
            Else
                txtTotalReal.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalEuro.Focus()
        End If
    End Sub

    Private Sub txtTotalEuro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalEuro.KeyPress
        e.Handled = txtNumerico(txtTotalReal, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalEuro.Text = Format(CDec(txtTotalEuro.Text), "###,##0.##")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalEuro.Text)) = 0 Then
                txtTotalEuro.BackColor = Color.Pink
            Else
                txtTotalEuro.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalGasto.Focus()
        End If
    End Sub

    Private Sub txtTotalGasto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalGasto.KeyPress
        e.Handled = txtNumerico(txtTotalGasto, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalGasto.Text = Format(CDec(txtTotalGasto.Text), "###,###,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalGasto.Text)) = 0 Then
                txtTotalGasto.BackColor = Color.Pink
            Else
                txtTotalGasto.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalCredito.Focus()
        End If
    End Sub

    Private Sub txtTotalCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalCredito.KeyPress
        e.Handled = txtNumerico(txtTotalCredito, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalCredito.Text = Format(CDec(txtTotalCredito.Text), "###,###,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalCredito.Text)) = 0 Then
                txtTotalCredito.BackColor = Color.Pink
            Else
                txtTotalCredito.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalTarjetaCred.Focus()
        End If
    End Sub

    Private Sub txtTotalTarjetaCred_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalTarjetaCred.KeyPress
        e.Handled = txtNumerico(txtTotalTarjetaCred, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalTarjetaCred.Text = Format(CDec(txtTotalTarjetaCred.Text), "###,###,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalTarjetaCred.Text)) = 0 Then
                txtTotalTarjetaCred.BackColor = Color.Pink
            Else
                txtTotalTarjetaCred.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalTarjetaDeb.Focus()
        End If
    End Sub

    Private Sub txtTotalTarjetaDeb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalTarjetaDeb.KeyPress
        e.Handled = txtNumerico(txtTotalTarjetaDeb, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalTarjetaDeb.Text = Format(CDec(txtTotalTarjetaDeb.Text), "###,###,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalTarjetaDeb.Text)) = 0 Then
                txtTotalTarjetaDeb.BackColor = Color.Pink
            Else
                txtTotalTarjetaDeb.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalCheque.Focus()
        End If
    End Sub

    Private Sub txtTotalCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalCheque.KeyPress
        e.Handled = txtNumerico(txtTotalCheque, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalCheque.Text = Format(CDec(txtTotalCheque.Text), "###,###,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalCheque.Text)) = 0 Then
                txtTotalCheque.BackColor = Color.Pink
            Else
                txtTotalCheque.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            txtTotalCanje.Focus()
        End If
    End Sub

    Private Sub txtTotalCanje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalCanje.KeyPress
        e.Handled = txtNumerico(txtTotalCanje, e.KeyChar, True)
        If e.KeyChar = ChrW(Keys.Enter) Then
            '-- el formato
            txtTotalCanje.Text = Format(CDec(txtTotalCanje.Text), "###,###,##0")
            '-- controlar la cantidad
            If CDbl(sacarComa(txtTotalCanje.Text)) = 0 Then
                txtTotalCanje.BackColor = Color.Pink
            Else
                txtTotalCanje.BackColor = Color.GreenYellow
            End If

            sumarTotales()

            btnCargar.Focus()
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------
    '**************'
    '-- LISTVIEW --'
    '**************'
    Private Sub lvDetalleCaja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalleCaja.SelectedIndexChanged
        For Each item As ListViewItem In lvDetalleCaja.SelectedItems
            intIdCaja = CInt(item.SubItems(2).Text)
        Next
    End Sub

    Private Sub lvDetalleCaja_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDetalleCaja.GotFocus
        For Each item As ListViewItem In lvDetalleCaja.SelectedItems
            intIdCaja = CInt(item.SubItems(2).Text)
        Next
    End Sub
    '-------------------------------------------------------------------------------------------------
    '****************'
    '-- FORMULARIO --'
    '****************'
    Private Sub frmPlanillaCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intTmpConta As Integer = 0
        '-- contador de formularios
        intGl_contadorFormularios = intGl_contadorFormularios - 1
        '----------------------------------------------------
        banGl_ventaFarmacia1 = 0
        frmMenuPrincipal.finanzaCargaPlanilla.Enabled = True
        e.Cancel = False
    End Sub
    '-------------------------------------------------------------------------------------------------
End Class