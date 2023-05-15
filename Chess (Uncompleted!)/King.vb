'
' Created by SharpDevelop.
' User: miche
' Date: 5/26/2021
' Time: 4:23 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class King
	Inherits Item
	
	Public Sub New(row As Integer, column As Integer)
		MyBase.New(row,column)
	End Sub
	
	Public Function move(row As Integer, column As Integer) As Boolean
		If row > MyBase.row + 1 Or column > MyBase.column + 1 Or row < MyBase.row - 1 Or column < MyBase.column - 1 Then
			Return False
		Else
			If row < 1 Or row > 8 Or column < 1 Or column > 8 Or (MyBase.row = row And MyBase.column = column) Then
				Return False
			Else
				MyBase.row = row
				MyBase.column = column
				Return True
			End If
		End If
	End Function
End Class
