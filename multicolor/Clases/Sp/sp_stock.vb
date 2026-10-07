Imports System.Data.SqlClient
Public Class sp_stock
    Private info As New info
    Dim v_resultado As String
    Public Function traer_stock()
        v_resultado = "select p.idProducto,p.codigo,p.nombreProducto,p.precio,s.cantidad as stock from producto p inner join stock s on p.idProducto=s.idProducto  where(p.activo = 1)    union  select p.idProducto,p.codigo,p.nombreProducto,p.precio,0 from producto p where p.activo=1 and p.idProducto not in(select idProducto from stock)"
        Return v_resultado
    End Function
End Class

