Imports System.Management
'Imports Scripting
Public Class info
    ' Dim fso As New FileSystemObject
    ' obtener el serial del disco duro
    Public Function obtenerSerialDisco1() As String
        Dim strTmpSerialNumero As String = ""
        Dim intContador As Integer
        Dim searcher As ManagementObjectSearcher = _
                New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
        'For Each wmi_HD As ManagementObject In searcher.Get()
        '   frmIngresoNick.ListBox1.Items.Add("Model:" & vbTab & wmi_HD("Model").ToString())
        '  frmIngresoNick.ListBox1.Items.Add("Type:" & vbTab & wmi_HD("InterfaceType").ToString())
        ' Next wmi_HD

        ' Get the hardware SerialNumber info
        searcher = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
        For Each wmi_HD As ManagementObject In searcher.Get()
            intContador = intContador + 1
            If intContador = 1 Then
                If wmi_HD("SerialNumber") Is Nothing Then
                    ' frmIngresoNick.ListBox1.Items.Add("Serial No:" & vbTab & "None")
                    strTmpSerialNumero = ""
                Else
                    'frmIngresoNick.ListBox1.Items.Add("Serial No:" & vbTab & wmi_HD("SerialNumber").ToString())
                    strTmpSerialNumero = wmi_HD("SerialNumber").ToString()
                End If
                'MsgBox("Valor " & strTmpSerialNumero)
            End If

        Next wmi_HD

        Return strTmpSerialNumero
    End Function


    Public Function obtenerSerialDisco() As String
        'MsgBox("Paso 1")
        Dim strValor As String = ""
        Dim BuscardorWMI As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
        'MsgBox("Paso 2")
        BuscardorWMI = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
        'MsgBox("Paso 3")
        Try
            'Deifinimos a i como un contador para manejar el ArrayList
            Dim i As Integer = 0

            For Each wmi_HD As ManagementObject In BuscardorWMI.Get
                MsgBox("Entro al contador!")
                i += 1
                'creamos  un nuevo objeto del Tipo DiscoDuro para ir almacenando alli 
                'cada uno de los discos duros encontrados
                Dim hd As New DiscoDuro
                'asignamos el valor acutalde la lista en el objeto HD
                ' hd = hdLista(i)
                'debemos verificar que el valor del campo "SerialNumber" obtenido en la busqueda 
                'no sea un valor nulo de lo contrario 
                'la aplicacion arrojará una excepcion
                MsgBox("Valor de i  " & i)
                If i = 1 Then
                    MsgBox("Valor del serial   " & wmi_HD("SerialNumber").ToString)
                    If wmi_HD("SerialNumber").ToString = Nothing Then
                        'en el caso de  que se halla encontrado el serial la propiedad "Serial" del
                        ' objeto hd se guardará los siguiente:
                        hd.Serial = "No se Pudo Obtener El Serial"
                        MsgBox("No se Pudo Obtener El Serial")
                    Else
                        'en el caso contrario almacenaremos el numero de serial interno 
                        'del disco duro en la propiedad "Serial" del objeto hd
                        hd.Serial = wmi_HD("SerialNumber").ToString
                        strValor = wmi_HD("SerialNumber").ToString
                        MsgBox("Valor  " & strValor)
                    End If
                End If

                'incrementando i
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & strGl_nombreSistema, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strGl_mensajeError = "Error: " & ex.Message & Me.ToString
            errorSistema(strGl_mensajeError, "consulta_valorString", intGl_idConfigPc, intGl_idUsuario, intGl_idSucursal)
        End Try

        Return strValor
        'aqui coloco una manera de mostrarlo ustedes pueden escoger la que mejor les paresca
        'For Each hd As DiscoDuro In hdLista
        'por cuestiones de tiempo yo escogí usar un MessageBox
        'Next



    End Function
    ''obtener el nombre de la pc o host
    Public Function obtenerNombreHost() As String
        'Dim i_cont As Integer
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        'asignar a la variabla global el valor del nombre de la pc o host
        strNombreHost = nombreHost
        Return nombreHost
    End Function
    ''OBTENER EL CPU ID
    Public Function ObtenerIdPc() As String
        Dim cpuInfo As String = String.Empty
        Dim temp As String = String.Empty
        Dim mc As ManagementClass = _
            New ManagementClass("Win32_Processor")
        Dim moc As ManagementObjectCollection = mc.GetInstances()
        For Each mo As ManagementObject In moc
            If cpuInfo = String.Empty Then
                strIDHost = _
                 mo.Properties("ProcessorId").Value.ToString()
            End If
        Next
        Return strIDHost
    End Function
End Class
