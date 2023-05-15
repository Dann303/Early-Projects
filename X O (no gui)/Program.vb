'
' Created by SharpDevelop.
' User: miche
' Date: 12/21/2020
' Time: 6:37 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Module Program
	
	Sub Main()
		
		Dim numbers(3, 3) As Char
		Dim win As String = "NULL"
		Dim i As Integer
		Dim p1, p2 As String
		Dim retry As String = "no"
		Dim score1, score2, round As Integer
		score1 = 0
		score2 = 0
		round = 0
		
		Register(p1,p2)
		
		Do
			Console.Clear
			For i = 1 To 3
				For j = 1 To 3
					numbers(i, j) = "-"
				Next
			Next
			
			Console.WriteLine("Enter a number from 1 to 9")
			
			i = 1
			While (i < 10 And win = "NULL")
				Turn((i+round), numbers, p1, p2)
				If (i > 4)
					test(win, numbers, p1, p2)
				End If
				i = i + 1
				If (i > 1) Then
					Console.Clear
				End If
			End While
			
			If (win <> "NULL")
				Console.WriteLine(win & " has won!")
			Else
				Console.WriteLine("The game is a tie.")
			End If
			DisplayBoard(numbers)
			
			Score(win, score1, score2, p1, p2)
			
			retry = PlayAgain(p1, p2, score1, score2)
			round = round + 1
		Loop Until (retry = False)
		Console.Clear
		
		Console.Write("Press any key to continue . . . ")
		Console.ReadKey(True)
		
	End Sub
	
	
	
	
	
	
	
	
	
	
	Sub DisplayBoard(ByRef list(,) As Char)
		For i = 1 To 3
			Console.WriteLine(list(i, 1) & list(i, 2) & list(i, 3))
		Next
	End Sub
	
	Sub Turn(turn As Integer, ByRef numbers(,) As Char, ByVal p1 As String, ByVal p2 As String)
		Dim choice, row, column As Integer
		Dim flag, r As Boolean
		Dim player As String
		
		If (turn Mod 2 = 1) Then
			Console.WriteLine(p1 & "'s turn 'X' : ")
			player = p1
		Else
			Console.WriteLine(p2 & "'s turn 'O' : ")
			player = p2
		End If
		
		DisplayBoard(numbers)
		choice = Console.ReadLine()
		
		Do
			If (r = True) Then		
				Console.Clear
				If (turn Mod 2 = 1) Then
					Console.WriteLine(p1 & "'s turn 'X' : ")
				Else				
					Console.WriteLine(p2 & "'s turn 'O' : ")
				End If
				Console.WriteLine("Please enter an unentered number: ")
				DisplayBoard(numbers)
				choice = Console.ReadLine()					
				r = False
			End If
			
			While (choice > 9 Or choice < 1)
				Console.Clear
				If (turn Mod 2 = 1) Then		
					Console.WriteLine(p1 & "'s turn 'X' : ")
				Else
					Console.WriteLine(p2 & "'s turn 'O' : ")
				End If
				Console.WriteLine("Enter a number between 1 and 9")
				DisplayBoard(numbers)		
				choice = Console.ReadLine()
			End While
			
			row = Div(choice, 3)
			column = choice Mod 3
			
			If (column = 0) Then
				column = 3
			End If
			
			flag = True
			
			If (numbers(row, column) <> "-") Then
				r = True
			Else If (player = p1)
				numbers(row, column) = "X"
			Else
				numbers(row, column) = "O"
			End If
				
			Loop Until (r = False)
		
	End Sub
	
	Sub test(ByRef Win As String, ByRef numbers(,) As Char, ByVal p1 As String, ByVal p2 As String)
		
		' For the straight horizontal and vertical lines
		For i = 1 To 3
			If ((numbers(i, 1) = "X" And numbers(i, 2) = "X" And numbers(i, 3) = "X") Or (numbers(1, i) = "X" And numbers(2, i) = "X" And numbers(3, i) = "X")) Then
				Win = p1
			Else If ((numbers(i, 1) = "O" And numbers(i, 2) = "O" And numbers(i, 3) = "O") Or (numbers(1, i) = "O" And numbers(2, i) = "O" And numbers(3, i) = "O")) Then
				Win = p2
			End If
		Next
		
		'For the diagonal straight lines:
		If ((numbers(1, 1) = "X" And numbers(2, 2) = "X" And numbers(3, 3) = "X") Or (numbers(1, 3) = "X" And numbers(2, 2) = "X" And numbers(3, 1) = "X")) Then
			Win = p1
		Else If ((numbers(1, 1) = "O" And numbers(2, 2) = "O" And numbers(3, 3) = "O") Or (numbers(1, 3) = "O" And numbers(2, 2) = "O" And numbers(3, 1) = "O")) Then
			Win = p2
		End If
	End Sub
	
	Function Div(ByVal Number As Integer, ByVal Divisor As Integer) As Integer
		Dim times As Integer = 0
		While (Number > 0)
			Number = Number - Divisor
			times = times + 1
		End While
		Return times
	End Function
	
	Sub Register(ByRef p1 As String, ByRef p2 As String)
		Console.WriteLine("Enter the first player's name 'X' : ")
		p1 = Console.ReadLine()
		Console.Clear
		Console.WriteLine("Enter the second player's name 'O' : ")
		p2 = Console.ReadLine()
		Console.Clear
	End Sub
	
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
	
	Sub CallScore(ByVal p1 As String, ByVal p2 As String, ByVal score1 As Integer, ByVal score2 As Integer)
		Console.WriteLine("The score is: ")
		Console.WriteLine(p1 & ": " & score1)
		Console.WriteLine(p2 & ": " & score2)
	End Sub
	
End Module
