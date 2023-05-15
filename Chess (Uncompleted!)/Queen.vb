'
' Created by SharpDevelop.
' User: miche
' Date: 5/26/2021
' Time: 4:25 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class Queen
	Inherits Item
	
	Public Sub New(row As Integer, column As Integer)
		MyBase.New(row,column)
	End Sub
	
	Public Function move(row As Integer, column As Integer) As Boolean
		If row < 1 Or row > 8 Or column < 1 Or column > 8 Or (MyBase.row = row And MyBase.column = column) Then
			Return False
		Else
			Dim flag As Boolean = False
			For i = 1 To 8
				If (row = MyBase.row + i And column = MyBase.column + i) Or (row = MyBase.row - i And column = MyBase.column - i) Or (row = MyBase.row - i And column = MyBase.column + i) Or (row = MyBase.row + i And column = MyBase.column - i) Then
					flag = True
				End If
			Next
			If flag = True Or (flag = False And ((MyBase.row = row And column >= 1 And column <= 8) Or (MyBase.column = column And row >= 1 And row <= 8))) Then
				MyBase.row = row
				MyBase.column = column
				Return True
			Else
				Return False
			End If
		End If
	End Function
End Class
