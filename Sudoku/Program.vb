'' Things to add:                                                                              Status:
'' - Add a counter for how many mistakes were made during the game                                     DONE
'' - Add exception handling methods for every input                                                    DONE
'' - Ability to choose the cell several times before guessing a number..                               DONE
'' - Ability to play another game                                                                      DONE
'' - Take the user's name as an input     ( nvm fakes awy )                                            SOON
'' - Display numbers to add (1-9) and if all the numbers had been placed then don't display them       SOON
'' - Selected cell highlights other similar numbers present on the grid                                SOON 

Module Program
	Sub Main()
		
		Dim Grid(9,9), SolutionGrid(9,9) As String
		Dim repeat As Boolean = False
		
		Do
			
		SetGrid(grid)

		Create(grid)

		''Creating a solution grid:
		CopyArray(Grid,SolutionGrid)
		
		'GetSolution(SolutionGrid)
		
		''Setting difficulty and accordingly removing a number of cells.
		Difficulty(Grid)
		
		Console.WriteLine("Time starts as soon as you select a cell!")
		Console.WriteLine("")
		DisplayGrid(Grid)
		
		Play(Grid,SolutionGrid)
		
		repeat = PlayAgain()
		Loop Until (repeat = False)
		
		Console.Write("Press any key to continue . . . ")
		Console.ReadKey(True)
	End Sub
	
	Sub DisplayGrid(ByVal array(,) As String) ''Displays grid
		Console.Write("      ") '' The small indentation in the beginning
		For i = 1 To 9
			Console.Write(i & "   ") '' gap between each number
			If (i = 3 Or i = 6) Then
				Console.Write("     ") '' The Gap between every 3 cells' headers
			End If
		Next
		
		
		Console.WriteLine(Environment.NewLine & "                  ██               ██")
		
		For i = 1 To 9
			Console.Write(" " & i & "    ") '' headers for rows then a gap
			For j = 1 To 9
				Console.Write(array(i,j) & "   ") '' displaying the grid's known values
				If (j = 3 Or j = 6) Then
					Console.Write("██   ")
				End If
			Next
			If Not (i = 3 Or i = 6)
				Console.WriteLine(Environment.NewLine & "                  ██               ██")
			End If	
			If (i = 3 Or i = 6) Then
				Console.Write(Environment.NewLine & "                  ██               ██" & Environment.NewLine)
				Console.Write("    ███████████████████████████████████████████████" & Environment.NewLine)
				Console.Write("                  ██               ██" & Environment.NewLine)
			End If
		Next
	End Sub
	
	Sub DisplayGrid(ByVal array(,) As String, ByVal flag As Boolean) ''Displays grid for 2 char cells (if required)
		Console.Write("       ") '' same as the previous procedure
		For i = 1 To 9
			Console.Write(i & "   ")
			If (i = 3 Or i = 6) Then
				Console.Write("    ")
			End If
		Next
		
		
		Console.WriteLine("" & Environment.NewLine)
		
		For i = 1 To 9
			Console.Write(" " & i & "    ")
			For j = 1 To 9
				Console.Write(array(i,j) & "  ")
				If (j = 3 Or j = 6) Then
					Console.Write("██  ")
				End If
			Next
			Console.WriteLine()
			If (i = 3 Or i = 6) Then
				Console.Write("                  ██              ██" & Environment.NewLine)
				Console.Write("      ██████████████████████████████████████████" & Environment.NewLine)
				Console.Write("                  ██              ██" & Environment.NewLine)
			End If
		Next
	End Sub
	
	Function Div(ByVal number As Integer, ByVal Divisor As Integer) As Integer ''Function to get the number of times a number was divided by a number, just like in the O level
		Dim times As Integer = 1
		Dim num As Integer
		num = number - Divisor
		
		If (number > 0 And number <=9) Then
			Return times
		End If
		
		times = times + 1
		Do	
			If (num <= Divisor And num > 0)  Then
				Return times
			Else If (times = 8 And num <> 0)
				Return 9
			End If
			times = times + 1
			num = num - Divisor
		Loop Until False
	End Function
	
	Sub SetGridNumbers(ByRef array(,) As String) ''Setting grid cells from 0 to 1, made for the overloaded displaygrid procedure.
		For i = 1 To 9
			For j = 1 To 9
				array(i,j) = (j + i*9 - 9)
				If (i = 1) Then
					array(i,j) = "0" + array(i,j)
				End If
			Next
		Next
		Console.WriteLine("New Grid: ")
		DisplayGrid(array, True)
	End Sub
	
	Sub SetGrid(ByRef array(,) As String) ''Setting the values of all grid cells to a certain character "?"
		For i = 1 To 9
			For j = 1 To 9
				array(i,j) = "☻ "
			Next
		Next
		'Console.WriteLine("New Grid: ")
		'DisplayGrid(array, True)
	End Sub
	
	Sub TranslateChoice(ByVal choice As Integer, ByRef grid(,) As String, ByVal Number As String) ''Turns a number to its corresponding 2d array number.. eg: 25 is row:2 column:7. After that it sets the cell to a specific number
		Dim row,column As Integer
		row = Div(choice,9)
		column = choice Mod 9
		If column = 0 Then
			column = 9
		End If
		grid(row,column) = Number
	End Sub
	
	Sub Create(ByRef grid(,) As String) ''This is the procedure where the grid is generated
		Dim number As Integer
		Dim r As New Random
		Dim row, column As Integer
		Dim i, j, x, z As Integer
		Dim flag As Boolean = True
		
	'' First, Empty the grid
		For i = 1 To 9
			For j = 1 To 9
				grid(i,j) = "0"
			Next
		Next
	
		'Console.Clear
		'Console.WriteLine("Loading screen, please wait...")
		Dim timer,t2 As New Time
		Dim TimeFlag As Boolean = True
		Dim t As Integer = 1
		'z = 0
		't = 1
		Dim time As New Time
		Do
			'Console.WriteLine(time.GetTimeTakenInt Mod 4)
			Loading(TimeFlag,time,t,t2)
			
			flag = True
			j = 1
			i = 1
			While (i <= 81)
				x = i
				number = r.Next(1,10)
				'TranslateChoice(i,grid,number)
				GridInput(i, grid, number, row, column) ''The procedure where a number is generated, then checks whether its suitable or not
				i = i + 1
				If (x = i) Then
					j = j + 1
				Else
					z = z + j
					j = 1
				End If
				If (j >= 20) Then
					For m = 1 To 9
						For n = 1 To 9
							grid(m,n) = "0"
						Next
					Next
					't = t + 1
					'z = z + j
					flag = False
					Exit While
				End If
			End While
		Loop Until (flag = True)
		Console.Clear
		'Console.Write("It took: ")
		'timer.SetTimeTaken

	End Sub
	
	Sub GridInput(ByRef choice As Integer, ByRef grid(,) As String, ByVal Number As Integer, ByRef row As Integer, ByRef column As Integer) 
		''Used with the Create() procedure. It's the method of determining whether a number is appropriate to place in a certain cell or not.
		
		Dim i As Integer
		Dim flag As Boolean = True
		
		'Changing the input to a 2d input
		row = Div(choice,9)
		column = choice Mod 9
		If column = 0 Then
			column = 9
		End If
		
		''Checks:
		'Horizontally
		For i = 1 To 9
			If (Number = grid(row, i)) Then
				flag = False
			End If
		Next	
		
		'Vertically
		For i = 1 To 9
			If (Number = grid(i, column)) Then
				flag = False
			End If
		Next
		
		'Cell Rows 1,2,3
		If (row >= 1 And row <=3) Then
			If (column >=1 And column <=3) Then
				For i = 1 To 3
					For j = 1 To 3
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
			If (column >=4 And column <=6) Then
				For i = 1 To 3
					For j = 4 To 6
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
			If (column >=7 And column <=9) Then
				For i = 1 To 3
					For j = 7 To 9
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
		End If
		
		
		'Cell Rows 4,5,6
		If (row >= 4 And row <=6) Then
			If (column >=1 And column <=3) Then
				For i = 4 To 6
					For j = 1 To 3
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
			If (column >=4 And column <=6) Then
				For i = 4 To 6
					For j = 4 To 6
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
			If (column >=7 And column <=9) Then
				For i = 4 To 6
					For j = 7 To 9
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
		End If
		
		
		'Cell Rows 7,8,9
		If (row >=7 And row <=9) Then
			If (column >=1 And column <=3) Then
				For i = 7 To 9
					For j = 1 To 3
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
			If (column >=4 And column <=6) Then
				For i = 7 To 9
					For j = 4 To 6
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
			If (column >=7 And column <=9) Then
				For i = 7 To 9
					For j = 7 To 9
						If (Number = grid(i,j)) Then
							flag = False
						End If
					Next
				Next
			End If
		End If
		If (flag = True) Then
			grid(row,column) = Integer.Parse(Number)
		Else
			choice = choice - 1
		End If	
		
	End Sub
	
	Sub Difficulty(ByRef array(,) As String) ''Sets difficulty of the level for the user. Then removes accordingly the number of cells as demonstrated below:
		Dim difficulty As String
		Dim i, j, cellNumber As Integer
		Dim r,ran As New Random
		Dim flag As Boolean = True
		
		' Very Easy = 50-60 given
		' Easy = 36-49 given
		' Medium = 32-35 given
		' Hard = 28-31 given
		' Expert = 22-27 given
		
		Console.WriteLine(Environment.NewLine)
		PrintSudoku()
		Console.WriteLine(Environment.NewLine)
		
		Console.WriteLine("Choose a difficulty: " & Environment.NewLine)
		Console.WriteLine("Very Easy" & Environment.NewLine & "Easy" & Environment.NewLine & "Medium" & Environment.NewLine & "Hard" & Environment.NewLine & "Expert")
		Console.WriteLine()
		
		difficulty = Console.ReadLine()
		
		''Setting the difficulty
		Do
			If (flag = False) Then
				Console.Clear
				Console.WriteLine("Write the exact name of the difficulty you intend to play: " & Environment.NewLine)
				Console.WriteLine("Very Easy" & Environment.NewLine & "Easy" & Environment.NewLine & "Medium" & Environment.NewLine & "Hard" & Environment.NewLine & "Expert")
				difficulty = Console.ReadLine()
			End If
			
			flag = True
			
			Select Case difficulty.ToLower
				Case "very easy"
					i = 31
					j = r.Next(0,10)
				Case "easy"
					i = 45
					j = r.Next(0,14)
				Case "medium"
					i = 49
					j = r.Next(0,4)
				Case "hard"
					i = 53
					j = r.Next(0,4)
				Case "expert"
					i = 59
					j = r.Next(0,6)
				Case Else
					flag = False
			End Select
		Loop Until (flag = True)
		
		'' Removing cells from the board according to the difficulty
		For i = 1 To i - j
			cellNumber = ran.Next(1,82)
			CollisionPrevention(cellNumber,array,"☻",i)
			
		Next
		Console.Clear
	End Sub
	
	Sub CopyArray(ByVal array(,) As String, ByRef copyArray(,) As String) '' Copies the grid into another array to be used for later as the "solution"
		For i = 1 To 9
			For j = 1 To 9
				copyArray(i,j) = array(i,j)
			Next
		Next
	End Sub
	
	Sub GetSolution(ByVal SolutionGrid(,) As String) ''It's probably completely useless, but I made it so that I could display the solution ... told ya, useless. xD
		Console.WriteLine("The solution is:")
		DisplayGrid(SolutionGrid)
	End Sub
	
	Sub CollisionPrevention(ByVal choice As Integer, ByRef grid(,) As String, ByVal Character As String, ByRef Counter As Integer) 
		'' This procedure is made so that difficulty() won't remove the cell twice increasing the number of cells that are left which in turn understates the actual difficulty.
		
		Dim row,column As Integer
		row = Div(choice,9)
		column = choice Mod 9
		If (column = 0) Then
			column = 9
		End If
		If (grid(row,column) = Character) Then
			Counter = Counter - 1
			Exit Sub
		Else
			grid(row,column) = Character
		End If
	End Sub
	
	Sub Play(ByRef Grid(,) As String, ByVal Solution(,) As String) ''This is where all the things are done during the game: the input, the checks, etc.
		
		Dim row, column, number, mistakes As Integer
		Dim choice As String
		Dim flag As Boolean = True
		Dim f As Boolean = False
		Dim timer As New Time
		Dim f1 As Boolean = False
		
		row = 0
		column = 0
		mistakes = 0
		
		Do
			Do
				flag = True
				
				InputCell(row,column,number,f1,Solution)
				
				If (f = False) Then
					timer.Reset
					f = True
				End If
				
				Console.Clear
				If (number = -1 Or row = 0 Or column = 0) Then
					If Not(row = 0 Or column = 0) Then
						Console.WriteLine("Displaying cell number " & row & "-" & column & "     Mistakes:" & mistakes & Environment.NewLine & Environment.NewLine)
						DisplayGrid(Grid, row, column)
					Else
						Console.WriteLine("Select a cell" & "                  Mistakes:" & mistakes & Environment.NewLine & Environment.NewLine)
						DisplayGrid(Grid, row, column)
					End If
				End If
			Loop Until (number <> -1 And Not(row = 0 Or column = 0))
			
			Console.WriteLine("Displaying cell number " & row & "-" & column & "     Mistakes:" & mistakes)
			If number = Solution(row,column) Then
				Console.WriteLine("Correct!")
				Grid(row,column) = number
				f1 = False
				number = -1
			Else If (Not(Grid(row,column) = Solution(row,column)))
				Console.WriteLine("Wrong!")
				mistakes = mistakes + 1
				f1 = True
				number = -1
			End If
			
			Try
				For i = 1 To 9
					For j = 1 To 9
						If (Grid(i,j) = "☻") Then
							flag = False
						End If
					Next
				Next
			Catch
			End Try
			
			Console.WriteLine()
			DisplayGrid(Grid, row, column)
			
		Loop Until (flag = True)
		Console.Write("Congrats!! You've finished the puzzle in ")
		timer.SetTimeTaken
		Console.WriteLine(Environment.NewLine & "You have made " & mistakes & " mistakes solving the puzzle!")
		End Sub
	
	Sub Loading(ByRef f As Boolean, ByRef time1 As Time, ByRef i As Integer, ByVal time2 As Time) ''Responsible for the loading... screen
		
		Dim flag As Boolean = False
		
		If (i = time1.GetTimeTakenInt) Then
			flag = True
			i = i + 1
		End If
		
		'' and... it works with a clock I made :)
		
		If (flag = True)
			If (f = False) Then
				Exit Sub
			End If
			If (time1.GetTimeTakenInt = 0) Then
				Console.Clear
				Console.WriteLine("Welcome to " & Environment.NewLine)
				PrintSudoku()
				Console.WriteLine(Environment.NewLine & "Loading screen, please wait    (Estimated Time:15s)   " & time2.GetTimeTakenInt & "s")
				flag = False
			Else If (time1.GetTimeTakenInt = 1)
				Console.Clear
				Console.WriteLine("Welcome to " & Environment.NewLine)
				PrintSudoku()
				Console.WriteLine(Environment.NewLine & "Loading screen, please wait.   (Estimated Time:15s)   " & time2.GetTimeTakenInt & "s")
				flag = False
			Else If (time1.GetTimeTakenInt = 2)
				Console.Clear
				Console.WriteLine("Welcome to " & Environment.NewLine)
				PrintSudoku()
				Console.WriteLine(Environment.NewLine & "Loading screen, please wait..  (Estimated Time:15s)   " & time2.GetTimeTakenInt & "s")
				flag = False
			Else If (time1.GetTimeTakenInt = 3)
				Console.Clear
				Console.WriteLine("Welcome to " & Environment.NewLine)
				PrintSudoku()
				Console.WriteLine(Environment.NewLine & "Loading screen, please wait... (Estimated Time:15s)   " & time2.GetTimeTakenInt & "s")
				flag = False
				time1.Reset
				i = 1
			End If
		End If
	End Sub
	
	Sub PrintSudoku() ''Obvious... prints out the word sudoku as follows:
		Console.WriteLine("███████████████████████████████████████████████████████████████████████████████")
		Console.WriteLine("██          ███  ██████  ███     ████████▀        ▀███  ███▀  ▄▄███  ██████  ██")
		Console.WriteLine("██  ███████████  ██████  ███  ██   ██████  ██████  ███  ██  ▄██████  ██████  ██")
		Console.WriteLine("██  ███████████  ██████  ███  ████   ████  ██████  ███  █  ████████  ██████  ██")
		Console.WriteLine("██          ███  ██████  ███  ██████  ███  ██████  ███    █████████  ██████  ██")
		Console.WriteLine("██████████  ███  ██████  ███  ████   ████  ██████  ███  █  ████████  ██████  ██")
		Console.WriteLine("██████████  ███  ██████  ███  ██   ██████  ██████  ███  ██  ▀██████  ██████  ██")
		Console.WriteLine("██          ███          ███     ████████▄        ▄███  ███▄  ▀▀███          ██")
		Console.WriteLine("███████████████████████████████████████████████████████████████████████████████")
	End Sub
	
	Sub InputCell(ByRef row As Integer, ByRef column As Integer, ByRef num As Integer, ByVal flag As Boolean, ByVal SolutionGrid(,) As String) 
		'' Connected to the Play() procedure, prompts the user for input and checks if there's something wrong with the input
		
		Dim choice As String
		Dim s1, s2 As Integer
		
		'' Also notice how there's two ways of inputing numbers:
		'' 1- Enter a <row>-<column> as an input then a number between 1-9
		'' 2- do it all in one shot..
		'' yeahhh, I figured that I should have told the user so.. don't bother. 
		
		s1 = row
		s2 = column
		
		If Not(row = 0 Or column = 0) Then
			flag = True
		End If
		If flag = False
			Console.WriteLine(Environment.NewLine & "Please enter the cell's row followed by a dash and it's column numbers")
			Console.WriteLine("If you're willing to input a number, you should consider adding a number seperated by a space")
		Else
			Console.WriteLine(Environment.NewLine & "Enter a number")
		End If
		Try	
			choice = Console.ReadLine()
			
			If Left(choice,1) = "/" Then ''COMMANDS
				Console.Clear
				Commands(choice,SolutionGrid)
				Exit Sub
			End If
			
			If choice.Length > 1 Then
				flag = False
			End If
			
			If (((num = -1) And choice.Length = 1) Or flag = True) Then
				num = CInt(choice)
				Exit Sub
			End If
			row = CInt(Mid(choice,choice.IndexOf("-"),1))
			column = CInt(Mid(choice,choice.IndexOf("-")+2,1))
			
			If ((row = s1) And (column = s2)) Then
				row = 0
				column = 0
			End If
			
			Try
				If (choice.Length - choice.IndexOf("-") > 3) Then
					num = Integer.Parse(choice(choice.IndexOf("-")+3))
				Else
					num = -1
				End If
			Catch
			End Try
		Catch
		End Try
	End Sub
	
	Sub DisplayGrid(ByVal array(,) As String, ByVal row As Integer, ByVal column As Integer) ''Displays grid
		
		'' Ps: this was so far the hardest part in the program thanks to the console the game is displayed on :)
		'' It doesn't only display the grid, it displays the grid with the select <row>-<column> cell
		'' Cool huh?
		
		If ((row > 9 Or row < 1) Or (column > 9 Or column < 1)) Then
			DisplayGrid(array)
			Exit Sub
		End If
		
		Dim flag As Boolean
		Dim s, x, z As Integer
		Dim line As String = "     ═════════════██═══════════════██═════════════"
		Dim space As String = "                  ██               ██            "
		
		Console.Write("      ") '' For the small indentation
		For i = 1 To 9 '' For the headers
			Console.Write(i & "   ")
			If (i = 3 Or i = 6) Then '' For the space between the headers 3,6,9
				Console.Write("     ")
			End If
		Next
		
		If column = 0 Then
			s = 0
		Else If column < 4
			s = 1
		Else If column < 7
			s = 2
		Else If column < 10
			s = 3
		End If
		
		If row = 1 Then '' For creating a seperation between the headers and the grid
			line = "     ═════════════██═══════════════██═════════════"
			x = column*4
			Select Case s
				Case 1
					x = column*4
					line = Mid(line,1,x+4) + "╬" + Mid(line,x+6,54-x)
					line = Mid(line,1,x+0) + "╬" + Mid(line,x+2,54-x)
				Case 2
					x = column*4
					line = Mid(line,1,x+9) + "╬" + Mid(line,x+11,54-x)
					line = Mid(line,1,x+5) + "╬" + Mid(line,x+7,54-x)
				Case 3
					x = column*4
					line = Mid(line,1,x+14) + "╬" + Mid(line,x+16,54-x)
					line = Mid(line,1,x+10) + "╬" + Mid(line,x+12,54-x)
				Case 0
					line = "             ██               ██             "
			End Select
			Console.WriteLine(Environment.NewLine & line)
		Else If (row < 10 And row > 1)
			space = "                  ██               ██             "
			Select Case s
				Case 1
					x = column*4
					space = Mid(space,1,x+4) + "║" + Mid(space,x+6,54-x)
					space = Mid(space,1,x+0) + "║" + Mid(space,x+2,54-x)
				Case 2
					x = column*4
					space = Mid(space,1,x+9) + "║" + Mid(space,x+11,54-x)
					space = Mid(space,1,x+5) + "║" + Mid(space,x+7,54-x)
				Case 3
					x = column*4
					If column = 9 Then
						space = Mid(space,1,x+14) + "║" '+ 'Mid(space,x+16,54-x)
						space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)	
						Exit Select
					End If
					space = Mid(space,1,x+14) + "║" + Mid(space,x+16,54-x)
					space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)
				Case 0
					space = "             ██               ██             "
			End Select
			Console.WriteLine(Environment.NewLine & space)
		End If
		
		line = "     ═════════════██═══════════════██═════════════"
		space = "                  ██               ██            "
		
		For i = 1 To 9
			If (column > 1)
				Console.Write(" " & i & "    ") '' Headers for the rows
				z = 1
			Else
				Console.Write(" " & i & "  ")
				z = 0
			End If
			For j = z To 9
				If j > 0 Then
					Console.Write(array(i,j))
					Select Case s
						Case 1
							If (j = column - 1 Or j = column) Then
								Console.Write(" ║ ")
							Else
								Console.Write("   ")
							End If
							If (j = 3 Or j = 6) Then
								Console.Write("██   ")
							End If
						Case 2
							If (column = 4 And j = column - 1) Then
								Console.Write("   ██")
								Console.Write(" ║ ")
								Exit Select
							End If
							If (j = column - 1 Or j = column) Then
								Console.Write(" ║ ")
							Else
								Console.Write("   ")
							End If
							If (j = 3 Or j = 6) Then
								Console.Write("██   ")
							End If
						Case 3
							If (column = 7 And j = column - 1) Then
								Console.Write("   ██")
								Console.Write(" ║ ")
								Exit Select
							End If
							If (j = column - 1 Or j = column) Then
								Console.Write(" ║ ")
							Else
								Console.Write("   ")
							End If
							If (j = 3 Or j = 6) Then
								Console.Write("██   ")
							End If
						Case 0
							Console.Write("   ")
							If (j = 3 Or j = 6) Then
								Console.Write("██   ")
							End If
					End Select
				Else
					Console.Write("║ ")
				End If
			Next
			
			
			If (i = row - 1 Or i = row) Then
				Console.Write(Environment.NewLine)
				Select Case s
					Case 1
						x = column*4
						line = Mid(line,1,x+4) + "╬" + Mid(line,x+6,54-x)
						line = Mid(line,1,x+0) + "╬" + Mid(line,x+2,54-x)
					Case 2
						x = column*4
						line = Mid(line,1,x+9) + "╬" + Mid(line,x+11,54-x)
						line = Mid(line,1,x+5) + "╬" + Mid(line,x+7,54-x)
					Case 3
						x = column*4
						line = Mid(line,1,x+14) + "╬" + Mid(line,x+16,54-x)
						line = Mid(line,1,x+10) + "╬" + Mid(line,x+12,54-x)
					Case 0
						line = "             ██               ██             "
				End Select
				If row = 4 And i = 3 Then
					If column = 9 Then
						space = Mid(space,1,x+14) + " ║" '+ 'Mid(space,x+16,54-x)
						space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)	
					Else
						Writing(space,s,column,"║")
					End If 
					Console.Write(space & Environment.NewLine)
					Console.Write("    ███████████████████████████████████████████████" & Environment.NewLine)
					Console.Write(line & Environment.NewLine)
				Else If row = 7 And i = 6
					If column = 9 Then
						space = Mid(space,1,x+14) + " ║" '+ 'Mid(space,x+16,54-x)
						space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)	
					Else
						Writing(space,s,column,"║")
					End If
					Console.Write(space & Environment.NewLine)
					Console.Write("    ███████████████████████████████████████████████" & Environment.NewLine)
					Console.Write(line & Environment.NewLine)
				Else
					Console.Write(line)
					Console.WriteLine()
				End If
				
					
				
			Else If (i < 9)
				Select Case s
					Case 1
						x = column*4
						space = Mid(space,1,x+4) + "║" + Mid(space,x+6,54-x)
						space = Mid(space,1,x+0) + "║" + Mid(space,x+2,54-x)
					Case 2
						x = column*4
						space = Mid(space,1,x+9) + "║" + Mid(space,x+11,54-x)
						space = Mid(space,1,x+5) + "║" + Mid(space,x+7,54-x)
					Case 3
						x = column*4
						If column = 9 Then
							space = Mid(space,1,x+14) + " ║" '+ 'Mid(space,x+16,54-x)
							space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)	
							Exit Select
						End If
						space = Mid(space,1,x+14) + "║" + Mid(space,x+16,54-x)
						space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)
					Case 0
						space = "             ██               ██             "
				End Select
				
				Console.WriteLine(Environment.NewLine & space)
				
				
			Else
				Console.WriteLine()
			End If
			If (i = 3 Or i = 6) Then
				If row = 4 And i = 3 Then
				Else If row = 7 And i = 6
				Else
					Console.Write("    ███████████████████████████████████████████████" & Environment.NewLine)
				End If
				
				If row = 3 Or row = 6 Then
					space = "                  ██               ██             "
					x = column*4
					Select Case s
						Case 1
							space = Mid(space,1,x+4) + "║" + Mid(space,x+6,54-x)
							space = Mid(space,1,x+0) + "║" + Mid(space,x+2,54-x)
						Case 2
							space = Mid(space,1,x+9) + "║" + Mid(space,x+11,54-x)
							space = Mid(space,1,x+5) + "║" + Mid(space,x+7,54-x)
						Case 3	
							space = Mid(space,1,x+14) + "║" + Mid(space,x+16,54-x)
							space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)
					End Select
					
					
					x = column*4
					
					
				End If
				If row = 4 And i = 3 Then
				Else If row = 7 And i = 6
				Else
					Console.Write(space & Environment.NewLine)
				End If
				
			End If
			space = "                  ██               ██            "
		Next
		If row < 9 Then
			space = "                  ██               ██               "
			Select Case s
				Case 1
					space = Mid(space,1,x+4) + "║" + Mid(space,x+6,54-x)
					space = Mid(space,1,x+0) + "║" + Mid(space,x+2,54-x)
				Case 2
					space = Mid(space,1,x+9) + "║" + Mid(space,x+11,54-x)
					space = Mid(space,1,x+5) + "║" + Mid(space,x+7,54-x)
				Case 3	
					space = Mid(space,1,x+14) + "║" + Mid(space,x+16,54-x)
					space = Mid(space,1,x+10) + "║" + Mid(space,x+12,54-x)
			End Select
			Console.WriteLine(space)
		End If
	End Sub	
	
	Sub Writing(ByRef Str As String,ByVal section As Integer, ByVal column As Integer, ByVal Character As Char) ''Something releating to the selected cell display grid procedure thingy
		
		Dim x As Integer
		
		Select Case section
			Case 1
				x = column*4
				Str = Mid(Str,1,x+4) + Character + Mid(Str,x+6,54-x)					
				Str = Mid(Str,1,x+0) + Character + Mid(Str,x+2,54-x)
			Case 2
				x = column*4
				Str = Mid(Str,1,x+9) + Character + Mid(Str,x+11,54-x)
				Str = Mid(Str,1,x+5) + Character + Mid(Str,x+7,54-x)
			Case 3
				If column = 9 Then
					Str = Mid(Str,1,x+14) + " " + Character '+ 'Mid(Str,x+16,54-x)
					Str = Mid(Str,1,x+10) + Character + Mid(Str,x+12,54-x)	
					Exit Select
				End If
				x = column*4
				Str = Mid(Str,1,x+14) + Character + Mid(Str,x+16,54-x)
				Str = Mid(Str,1,x+10) + Character + Mid(Str,x+12,54-x)
			Case 0
				Str = "             ██               ██             "
		End Select
	End Sub
	
	Function PlayAgain() As Boolean '' Doesn't really require a comment but here we go. It allows the player to play again a different level once he/she's done with their current level!
		
		Dim answer As String
		Dim choice As Boolean
		Dim flag As Boolean = False
		
		Do
			Try
				If flag = True Then
					Console.Clear
				End If
				
				Console.WriteLine("Do you wanna play again? (y/n)")
				answer = Console.ReadLine().ToLower
				
				If answer = "yes" Or answer = "yeah" Or answer = "y" Or answer = "ye" Or answer = "yea" Then
					choice = True
					flag = False
				Else If answer = "no" Or answer = "nah" Or answer = "n" Or answer = "na" Or answer = "nope"
					choice = False
					flag = False
				Else
					flag = True
				End If
			Catch ex As Exception
				flag = True
			End Try
		Loop Until (flag = False)
		
		Return choice
	End Function
	
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Commands
	
	Sub Commands(ByVal choice As String, ByVal SolutionGrid(,) As String)
		If Right(choice.ToLower,choice.Length - 1) = "show commands" Then ''' To show Commands
			ShowCommands()
		End If
		
		If Right(choice.ToLower,choice.Length - 1) = "show answer" Then ''' To show the solution
			ShowAnswer(SolutionGrid)
		End If
		
	'	If Right(choice.ToLower,choice.Length - 1) = "hint" Or Right(choice.ToLower,choice.Length - 1) = "solve") Then
	'		Hint()
	'	End If
		
		Console.WriteLine("Press enter to skip...")
		Console.WriteLine("Or enter another command.")
		choice = Console.ReadLine()
		If Left(choice,1) = "/" Then
			Commands(choice,SolutionGrid)
		End If
	End Sub
	
	Sub ShowCommands()
		Console.WriteLine("/Show Answer ---------- To show the solution.")
		Console.WriteLine("/Hint ----------------- To solve the selected cell.")
	End Sub
	
	Sub ShowAnswer(ByVal SolutionGrid(,) As String)
		Console.Clear
		DisplayGrid(SolutionGrid)
	End Sub
	
	Sub Hint(ByRef grid(,) As String, ByVal SolutionGrid(,) As String)
		
	End Sub
	
End Module
