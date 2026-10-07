<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaCaja))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTotalCanje = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCant20000 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtTotalCheque = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotalTarjetaDeb = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTotalTarjetaCred = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotalCredito = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotalGasto = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotalReal = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotalDolar = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPesoArg = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCant100000 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCant50000 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCant10000 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCant5000 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCant2000 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCant1000 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCant500 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCant100 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCant50 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalCaja = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalSistema = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvDetalleCaja = New System.Windows.Forms.ListView()
        Me.nro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nroCajaCorr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nroCaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sucursal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalCaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalIngreso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.diferencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtTotalIngreso = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTotalEuro = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotalEuro)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtTotalCanje)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.txtCant20000)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtTotalCheque)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtTotalTarjetaDeb)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtTotalTarjetaCred)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtTotalCredito)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtTotalGasto)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtTotalReal)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtTotalDolar)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtPesoArg)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtCant100000)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtCant50000)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtCant10000)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtCant5000)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCant2000)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtCant1000)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCant500)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtCant100)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCant50)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtTotalCaja)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtTotalSistema)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtIdCaja)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(948, 199)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de la Caja"
        '
        'txtTotalCanje
        '
        Me.txtTotalCanje.BackColor = System.Drawing.Color.Pink
        Me.txtTotalCanje.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCanje.Location = New System.Drawing.Point(837, 152)
        Me.txtTotalCanje.Name = "txtTotalCanje"
        Me.txtTotalCanje.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalCanje.TabIndex = 57
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(747, 153)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(87, 18)
        Me.Label26.TabIndex = 56
        Me.Label26.Text = "Total Canje:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Pink
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(20, 175)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(328, 16)
        Me.Label25.TabIndex = 55
        Me.Label25.Text = "DIFERENCIA ENTRE NRO DE CAJA CORRELATIVO"
        '
        'txtCant20000
        '
        Me.txtCant20000.BackColor = System.Drawing.Color.Pink
        Me.txtCant20000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant20000.Location = New System.Drawing.Point(602, 12)
        Me.txtCant20000.Name = "txtCant20000"
        Me.txtCant20000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant20000.TabIndex = 54
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(517, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 18)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "20.000 Gs:"
        '
        'btnCargar
        '
        Me.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(879, 207)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(69, 37)
        Me.btnCargar.TabIndex = 4
        Me.btnCargar.Text = "&Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtTotalCheque
        '
        Me.txtTotalCheque.BackColor = System.Drawing.Color.Pink
        Me.txtTotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheque.Location = New System.Drawing.Point(835, 124)
        Me.txtTotalCheque.Name = "txtTotalCheque"
        Me.txtTotalCheque.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalCheque.TabIndex = 52
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(738, 125)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 18)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "Total Cheque:"
        '
        'txtTotalTarjetaDeb
        '
        Me.txtTotalTarjetaDeb.BackColor = System.Drawing.Color.Pink
        Me.txtTotalTarjetaDeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjetaDeb.Location = New System.Drawing.Point(834, 98)
        Me.txtTotalTarjetaDeb.Name = "txtTotalTarjetaDeb"
        Me.txtTotalTarjetaDeb.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalTarjetaDeb.TabIndex = 50
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(737, 99)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(92, 18)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Tarjeta Deb.:"
        '
        'txtTotalTarjetaCred
        '
        Me.txtTotalTarjetaCred.BackColor = System.Drawing.Color.Pink
        Me.txtTotalTarjetaCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTarjetaCred.Location = New System.Drawing.Point(835, 70)
        Me.txtTotalTarjetaCred.Name = "txtTotalTarjetaCred"
        Me.txtTotalTarjetaCred.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalTarjetaCred.TabIndex = 48
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(715, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 18)
        Me.Label22.TabIndex = 47
        Me.Label22.Text = "Tarjeta de Cred.:"
        '
        'txtTotalCredito
        '
        Me.txtTotalCredito.BackColor = System.Drawing.Color.Pink
        Me.txtTotalCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredito.Location = New System.Drawing.Point(834, 44)
        Me.txtTotalCredito.Name = "txtTotalCredito"
        Me.txtTotalCredito.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalCredito.TabIndex = 46
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(737, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 18)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Total Crédito:"
        '
        'txtTotalGasto
        '
        Me.txtTotalGasto.BackColor = System.Drawing.Color.Pink
        Me.txtTotalGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGasto.Location = New System.Drawing.Point(834, 16)
        Me.txtTotalGasto.Name = "txtTotalGasto"
        Me.txtTotalGasto.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalGasto.TabIndex = 44
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(737, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 18)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Total Gastos:"
        '
        'txtTotalReal
        '
        Me.txtTotalReal.BackColor = System.Drawing.Color.Pink
        Me.txtTotalReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReal.Location = New System.Drawing.Point(634, 144)
        Me.txtTotalReal.Name = "txtTotalReal"
        Me.txtTotalReal.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalReal.TabIndex = 42
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(555, 145)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 18)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Total Real:"
        '
        'txtTotalDolar
        '
        Me.txtTotalDolar.BackColor = System.Drawing.Color.Pink
        Me.txtTotalDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDolar.Location = New System.Drawing.Point(633, 118)
        Me.txtTotalDolar.Name = "txtTotalDolar"
        Me.txtTotalDolar.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalDolar.TabIndex = 40
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(516, 119)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 18)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Total Dolar US$:"
        '
        'txtPesoArg
        '
        Me.txtPesoArg.BackColor = System.Drawing.Color.Pink
        Me.txtPesoArg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoArg.Location = New System.Drawing.Point(633, 91)
        Me.txtPesoArg.Name = "txtPesoArg"
        Me.txtPesoArg.Size = New System.Drawing.Size(104, 24)
        Me.txtPesoArg.TabIndex = 38
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(516, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 18)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Total Peso Arg.:"
        '
        'txtCant100000
        '
        Me.txtCant100000.BackColor = System.Drawing.Color.Pink
        Me.txtCant100000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant100000.Location = New System.Drawing.Point(601, 65)
        Me.txtCant100000.Name = "txtCant100000"
        Me.txtCant100000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant100000.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(512, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 18)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "100.000 Gs:"
        '
        'txtCant50000
        '
        Me.txtCant50000.BackColor = System.Drawing.Color.Pink
        Me.txtCant50000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant50000.Location = New System.Drawing.Point(601, 39)
        Me.txtCant50000.Name = "txtCant50000"
        Me.txtCant50000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant50000.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(516, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 18)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "50.000 Gs:"
        '
        'txtCant10000
        '
        Me.txtCant10000.BackColor = System.Drawing.Color.Pink
        Me.txtCant10000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant10000.Location = New System.Drawing.Point(457, 171)
        Me.txtCant10000.Name = "txtCant10000"
        Me.txtCant10000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant10000.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(373, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 18)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "10.000 Gs:"
        '
        'txtCant5000
        '
        Me.txtCant5000.BackColor = System.Drawing.Color.Pink
        Me.txtCant5000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant5000.Location = New System.Drawing.Point(457, 145)
        Me.txtCant5000.Name = "txtCant5000"
        Me.txtCant5000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant5000.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(380, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 18)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "5.000 Gs:"
        '
        'txtCant2000
        '
        Me.txtCant2000.BackColor = System.Drawing.Color.Pink
        Me.txtCant2000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant2000.Location = New System.Drawing.Point(455, 119)
        Me.txtCant2000.Name = "txtCant2000"
        Me.txtCant2000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant2000.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(379, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 18)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "2.000 Gs:"
        '
        'txtCant1000
        '
        Me.txtCant1000.BackColor = System.Drawing.Color.Pink
        Me.txtCant1000.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant1000.Location = New System.Drawing.Point(454, 93)
        Me.txtCant1000.Name = "txtCant1000"
        Me.txtCant1000.Size = New System.Drawing.Size(56, 24)
        Me.txtCant1000.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(378, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 18)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "1.000 Gs:"
        '
        'txtCant500
        '
        Me.txtCant500.BackColor = System.Drawing.Color.Pink
        Me.txtCant500.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant500.Location = New System.Drawing.Point(454, 67)
        Me.txtCant500.Name = "txtCant500"
        Me.txtCant500.Size = New System.Drawing.Size(56, 24)
        Me.txtCant500.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(388, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 18)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "500 Gs:"
        '
        'txtCant100
        '
        Me.txtCant100.BackColor = System.Drawing.Color.Pink
        Me.txtCant100.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant100.Location = New System.Drawing.Point(452, 41)
        Me.txtCant100.Name = "txtCant100"
        Me.txtCant100.Size = New System.Drawing.Size(56, 24)
        Me.txtCant100.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(388, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 18)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "100 Gs:"
        '
        'txtCant50
        '
        Me.txtCant50.BackColor = System.Drawing.Color.Pink
        Me.txtCant50.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant50.Location = New System.Drawing.Point(452, 15)
        Me.txtCant50.Name = "txtCant50"
        Me.txtCant50.Size = New System.Drawing.Size(56, 24)
        Me.txtCant50.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(394, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 18)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "50 Gs:"
        '
        'txtSucursal
        '
        Me.txtSucursal.BackColor = System.Drawing.Color.Yellow
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.Location = New System.Drawing.Point(77, 87)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(299, 24)
        Me.txtSucursal.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 18)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Sucursal:"
        '
        'txtTotalCaja
        '
        Me.txtTotalCaja.BackColor = System.Drawing.Color.PeachPuff
        Me.txtTotalCaja.Enabled = False
        Me.txtTotalCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCaja.Location = New System.Drawing.Point(110, 117)
        Me.txtTotalCaja.Name = "txtTotalCaja"
        Me.txtTotalCaja.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalCaja.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(30, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Total Caja:"
        '
        'txtTotalSistema
        '
        Me.txtTotalSistema.BackColor = System.Drawing.Color.SpringGreen
        Me.txtTotalSistema.Enabled = False
        Me.txtTotalSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSistema.Location = New System.Drawing.Point(110, 144)
        Me.txtTotalSistema.Name = "txtTotalSistema"
        Me.txtTotalSistema.Size = New System.Drawing.Size(148, 24)
        Me.txtTotalSistema.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 18)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Total Sistema:"
        '
        'txtIdCaja
        '
        Me.txtIdCaja.BackColor = System.Drawing.Color.Yellow
        Me.txtIdCaja.Enabled = False
        Me.txtIdCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCaja.Location = New System.Drawing.Point(110, 27)
        Me.txtIdCaja.Name = "txtIdCaja"
        Me.txtIdCaja.Size = New System.Drawing.Size(94, 24)
        Me.txtIdCaja.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ID Caja:"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Yellow
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(750, 254)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(112, 24)
        Me.txtTotal.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(668, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 18)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "TOTALES:"
        '
        'lvDetalleCaja
        '
        Me.lvDetalleCaja.AllowColumnReorder = True
        Me.lvDetalleCaja.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nro, Me.nroCajaCorr, Me.nroCaja, Me.sucursal, Me.totalCaja, Me.totalIngreso, Me.diferencia})
        Me.lvDetalleCaja.FullRowSelect = True
        Me.lvDetalleCaja.GridLines = True
        Me.lvDetalleCaja.HideSelection = False
        Me.lvDetalleCaja.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.lvDetalleCaja.LabelWrap = False
        Me.lvDetalleCaja.Location = New System.Drawing.Point(13, 213)
        Me.lvDetalleCaja.MultiSelect = False
        Me.lvDetalleCaja.Name = "lvDetalleCaja"
        Me.lvDetalleCaja.Size = New System.Drawing.Size(636, 311)
        Me.lvDetalleCaja.TabIndex = 123
        Me.lvDetalleCaja.UseCompatibleStateImageBehavior = False
        Me.lvDetalleCaja.View = System.Windows.Forms.View.Details
        '
        'nro
        '
        Me.nro.Text = "Nro."
        Me.nro.Width = 40
        '
        'nroCajaCorr
        '
        Me.nroCajaCorr.Text = "Nro Caja Corr."
        Me.nroCajaCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nroCajaCorr.Width = 80
        '
        'nroCaja
        '
        Me.nroCaja.Text = "Nro Caja"
        Me.nroCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nroCaja.Width = 70
        '
        'sucursal
        '
        Me.sucursal.Text = "Sucursal"
        Me.sucursal.Width = 180
        '
        'totalCaja
        '
        Me.totalCaja.Text = "Total Caja"
        Me.totalCaja.Width = 90
        '
        'totalIngreso
        '
        Me.totalIngreso.Text = "Total Ingreso"
        Me.totalIngreso.Width = 80
        '
        'diferencia
        '
        Me.diferencia.Text = "Diferencia"
        Me.diferencia.Width = 90
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnEliminar)
        Me.GroupBox7.Controls.Add(Me.btnGuardar)
        Me.GroupBox7.Controls.Add(Me.btnBuscar)
        Me.GroupBox7.Location = New System.Drawing.Point(671, 275)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(92, 150)
        Me.GroupBox7.TabIndex = 124
        Me.GroupBox7.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(13, 99)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 37)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(13, 56)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 37)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(13, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 37)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtTotalIngreso
        '
        Me.txtTotalIngreso.BackColor = System.Drawing.Color.Lime
        Me.txtTotalIngreso.Enabled = False
        Me.txtTotalIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIngreso.Location = New System.Drawing.Point(787, 498)
        Me.txtTotalIngreso.Name = "txtTotalIngreso"
        Me.txtTotalIngreso.Size = New System.Drawing.Size(112, 24)
        Me.txtTotalIngreso.TabIndex = 56
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(654, 500)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(132, 18)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "TOTAL INGRESO:"
        '
        'txtTotalEuro
        '
        Me.txtTotalEuro.BackColor = System.Drawing.Color.Pink
        Me.txtTotalEuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEuro.Location = New System.Drawing.Point(633, 170)
        Me.txtTotalEuro.Name = "txtTotalEuro"
        Me.txtTotalEuro.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalEuro.TabIndex = 59
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(554, 171)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(81, 18)
        Me.Label27.TabIndex = 58
        Me.Label27.Text = "Total Euro:"
        '
        'frmPlanillaCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 536)
        Me.Controls.Add(Me.txtTotalIngreso)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.lvDetalleCaja)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla de Cajas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSistema As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvDetalleCaja As System.Windows.Forms.ListView
    Friend WithEvents nro As System.Windows.Forms.ColumnHeader
    Friend WithEvents nroCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents sucursal As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalIngreso As System.Windows.Forms.ColumnHeader
    Friend WithEvents diferencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtTotalCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTarjetaDeb As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTarjetaCred As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGasto As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTotalReal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDolar As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPesoArg As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCant100000 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCant50000 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCant10000 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCant5000 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCant2000 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCant1000 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCant500 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCant100 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCant50 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nroCajaCorr As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCant20000 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIngreso As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCanje As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtTotalEuro As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
