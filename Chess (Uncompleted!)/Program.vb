'
' Created by SharpDevelop.
' User: miche
' Date: 5/26/2021
' Time: 4:11 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Module Program
	
	Dim board(8,8) As Char
	Dim occupied(8,8) As Boolean
	
	Sub Main()
		
		initializeBoard()
		display()
		
		Console.Write("Press any key to continue . . . ")
		Console.ReadKey(True)
	End Sub
	
	Sub initializeBoard()
		For i = 1 To 8
			For j = 1 To 8
				If (i Mod 2 = 0 And j Mod 2 = 1) Or (i Mod 2 = 1 And j Mod 2 = 0) Then
					board(i,j) = CChar("☺")
				Else
					board(i,j) = CChar("☻")
				End If
				occupied(i,j) = False
			Next
		Next
	End Sub
	
	Sub display()
		For i = 1 To 8
			For j = 1 To 8
				Console.Write(board(i,j) & " ")
			Next
			Console.WriteLine()
		Next
	End Sub
	
	Sub move(piece As Item,row As Integer,column As Integer)
		
	End Sub
End Module
