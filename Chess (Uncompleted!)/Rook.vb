'
' Created by SharpDevelop.
' User: miche
' Date: 5/26/2021
' Time: 4:26 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class Rook
	Inherits Item
	
	Public Sub New(row As Integer, column As Integer)
		MyBase.New(row,column)
	End Sub
	
	Public Function move(row As Integer, column As Integer) As Boolean
		If row < 1 Or row > 8 Or column < 1 Or column > 8 Or (MyBase.row = row And MyBase.column = column) Then
			Return False
		Else
			If MyBase.column = column Or MyBase.row = row Then
				MyBase.row = row
				MyBase.column = column
				Return True
			Else
				Return False
			End If
		End If
	End Function
End Class
