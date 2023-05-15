'
' Created by SharpDevelop.
' User: miche
' Date: 5/26/2021
' Time: 4:26 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class Pawn
	Inherits Item
	
	Public Sub New(row As Integer, column As Integer)
		MyBase.New(row,column)
	End Sub
	
	Function move(row As Integer, column As Integer) As Boolean
		If row < 1 Or row > 8 Or column < 1 Or column > 8 Then
			Return False
		Else
			If MyBase.row = 2 Then
				If row <> 3 And row <> 4 Then
					Return False
				Else
					If MyBase.column <> column Then ''Or if object that could be killed stands at row And column And (myBase.column = column + 1 Or myBase.column = column - 1)
						Return False
					Else
						MyBase.row = row
						MyBase.column = column
						Return True
					End If
				End If
			Else
				If MyBase.column <> column Or MyBase.row <> row - 1 Then
					Return False
				Else
					MyBase.row = row
					MyBase.column = column
					Return True
				End If
			End If
		End If
	End Function
End Class
