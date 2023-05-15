'
' Created by SharpDevelop.
' User: miche
' Date: 5/26/2021
' Time: 4:42 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class Item
	Public row As Integer
	Public column As Integer
	
	Public Sub New(row As Integer, column As Integer)
		Me.row = row
		Me.column = column
	End Sub
	
	Public Function getLocation() As Integer
		Return CInt(CStr(row) & CStr(column))
	End Function
End Class
