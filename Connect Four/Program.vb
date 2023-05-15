'
' Created by SharpDevelop.
' User: miche
' Date: 12/30/2020
' Time: 5:33 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Module Program
	Sub Main()
		
		Dim grid(6,7) As Char
		Dim win As String = "NULL"
		Dim i As Integer = 1
		Dim mark As Char
		Dim p1, p2 As String
		Dim retry As Boolean = False
		Dim score1, score2, round As Integer
		score1 = 0
		score2 = 0
		round = 0
		
		Register (p1,p2)
		
		Do
			For i = 1 To 6
				For j = 1 To 7
					grid(i,j) = "-"
				Next
			Next
	
			i = 1
			While (i < 43 And win = "NULL")
				Turn(grid, (i+round), mark, p1, p2)
				If (i > 6) Then
					Check(grid, win, mark, p1, p2)
				End If	
				i = i + 1
			End While
			
			Console.Clear
			DisplayBoard(grid)
			
			If (win <> "NULL") Then
				Console.WriteLine(win & " has won!!")
			Else 
				Console.WriteLine("It's a tie game!")
			End If
			
			Score(win, score1, score2, p1, p2)
			
			retry = PlayAgain(p1, p2, score1, score2)
			round = round + 1
		Loop Until (retry = False)
		Console.Clear
		CallScore(p1, p2, score1, score2)
		Console.WriteLine("")
		
		If (score1 > score2) Then
			Console.WriteLine(p1 & " has won!")
		Else If (score1 < score2)
			Console.WriteLine(p2 & " has won!")
		Else
			Console.WriteLine(p1 & " and " & p2 & " tied scores!")
		End If
		Console.WriteLine(Environment.NewLine)
		
		Console.Write("Press any key to continue . . . ")
		Console.ReadKey(True)
	End Sub
	
	
	
	
	Sub DisplayBoard(ByVal grid(,) As Char)
		For i = 1 To 7
			Console.Write(i & "  ")
		Next
		Console.WriteLine("")
		For i = 1 To 6
			For j = 1 To 7
				Console.Write(grid(i,j) & "  ")
			Next
			Console.WriteLine("")
		Next
	End Sub
	
	Sub Turn(ByRef grid(,) As Char, ByRef turn As Integer, ByRef mark As Char, ByVal p1 As String, ByVal p2 As String)
		Dim choice As Integer
		Dim player As String
		Dim flag As Boolean
		Dim test As Boolean = True
		Console.Clear
		
		Do
			PlayerTurn(turn, p1, p2, mark, player)
			
			If (test = False) Then
				Console.Clear
			End If
			
			Console.WriteLine("Please select a column: ")
			DisplayBoard(grid)
		
			
		
			Try	
				choice = Console.ReadLine()
				test = True
			Catch exception As InvalidCastException
				test = False
				Console.Clear
			End Try
		
			flag = True
		
		Do
				
				If (flag = False) Then
					Console.Clear
					PlayerTurn(turn, p1, p2)
					Console.WriteLine("Please select a column thats not entirely full: ")
					DisplayBoard(grid)
					Try
						choice = Console.ReadLine()
						test = True
					Catch exception As InvalidCastException
						test = False
						Console.Clear
					End Try
				End If
				
				flag = True
				
				While (choice <1 Or choice > 7)
					Console.Clear
					PlayerTurn(turn, p1, p2)
					Console.WriteLine("Please enter a number from 1 to 7: ")
					DisplayBoard(grid)
					Try
						choice = Console.ReadLine()
						test = True
					Catch exception As InvalidCastException
						test = False
						Console.Clear
					End Try
				End While
				
				For i = 6 To 1 Step -1
					If (grid(i,choice) = "-") Then
						grid(i,choice) = mark
						Exit For
					End If
					If (i = 1) Then
						flag = False
					End If
				Next
			Loop Until (flag = True)
		Loop Until (test = True)
			
	End Sub
	
	Sub Check(ByVal grid(,) As Char, ByRef win As String, Byval mark As Char, ByVal p1 As String, ByVal p2 As String)
		Dim x As Integer = 0
		
		'Checking Horizontally
		For i = 1 To 6
			For j= 1 To 4
				If (grid(i,j) = mark And grid(i,j+1) = mark And grid(i,j+2) = mark And grid(i,j+3) = mark) Then
					If mark = "X" Then
						win = p1
					Else
						win = p2
					End If
				End If
			Next
		Next
		
		'Checking Vertically
		For i = 1 To 7
			For j = 1 To 3
				If (grid(j,i) = mark And grid(j+1,i) = mark And grid(j+2,i) = mark And grid(j+3,i) = mark) Then
					If mark = "X" Then
						win = p1
					Else
						win = p2
					End If
				End If
			Next
		Next
		
		'Checking diagonally (top left to bottom right)
		
		For i = 4 To 6
			For j = 1 To 4
				If (grid(i,j) = mark And grid(i-1,j+1) = mark And grid(i-2,j+2) = mark And grid(i-3,j+3) = mark) Then
					If mark = "X" Then
						win = p1
					Else
						win = p2
					End If
				End If
			Next	
		Next
		
		'Checking diagonally (bottom left to top right)
		
		For i = 1 To 3
			For j = 1 To 4
				If (grid(i,j) = mark And grid(i+1,j+1) = mark And grid(i+2,j+2) = mark And grid(i+3,j+3) = mark) Then
					If mark = "X" Then
						win = p1
					Else
						win = p2
					End If
				End If
			Next	
		Next
		
	End Sub
	
	Sub Register(ByRef p1 As String, ByRef p2 As String)
		Console.WriteLine("Enter the first player's name 'X' :")
		p1 = Console.ReadLine()
		Console.Clear
		Console.WriteLine("Enter the second player's name 'O' :")
		p2 = Console.ReadLine()
	End Sub
	
	Function PlayAgain(p1 As String, p2 As String, score1 As Integer, score2 As Integer) As Boolean
		Dim Answer,flag As String
		flag = "NULL"
		Do
			If (flag <> "NULL") Then
				CallScore(p1, p2, score1, score2)
			End If
			Console.WriteLine("Do you wanna play again? (Y/N) : ")
			Answer = Console.ReadLine()
			If (Answer.ToLower = "y" Or Answer.ToLower = "yea" Or Answer.ToLower = "yeah" Or Answer.ToLower = "yes" Or Answer.ToLower = "ye") Then
				Return True
			Else If (Answer.ToLower = "n" Or Answer.ToLower = "nah" Or Answer.ToLower = "nope" Or Answer.ToLower = "no" Or Answer.ToLower = "na")
				Return False
			Else 
				flag = "repeated"
			End If
			Console.Clear
		Loop Until (False)
	End Function
	
	Sub Score(ByRef win As String, ByRef score1 As Integer, ByRef score2 As Integer, ByVal p1 As String, ByVal p2 As String)
		If (win = p1) Then
			score1 = score1 + 1
		End If
		If (win = p2) Then
			score2 = score2 + 1
		End If
		CallScore(p1, p2, score1, score2)
		win = "NULL"
	End Sub
	
	Sub CallScore(ByVal p1 As String, ByVal p2 As String, ByVal score1 As Integer, ByVal score2 As Integer)
		Console.WriteLine("The score is: ")
		Console.WriteLine(p1 & ": " & score1)
		Console.WriteLine(p2 & ": " & score2)
	End Sub
	
	Sub PlayerTurn(ByVal turn As Integer, ByVal p1 As String, ByVal p2 As String)
		If (Turn Mod 2 = 1) Then
			Console.WriteLine(p1 & "'s turn: ")
		Else
			Console.WriteLine(p2 & "'s turn: ")
		End If
	End Sub
	
	Sub PlayerTurn(ByVal turn As Integer, ByVal p1 As String, ByVal p2 As String, ByRef mark As Char, ByRef player As String)
		If (turn Mod 2 = 1) Then
			Console.WriteLine(p1 & "'s turn: ")
			player = p1
			mark = "X"
		Else	
			Console.WriteLine(p2 & "'s turn: ")
			player = p2
			mark = "O"
		End If
	End Sub
End Module
