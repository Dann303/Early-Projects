Public Class Time ''This is a class that I made so that I could create a clock and accordingly carry out procedures and functions at a specific time
	'' You really shouldn't bother looking into this, it's probably useless
	'' I just couldn't grasp how the built-in timer thingy works here...
	
	Private TStart As Date
	Private TEnd As Date
	Private TimeTaken As String
	
	Public Sub New()
		Me.TStart = Now
		Me.TEnd = Now
		Me.TimeTaken = "0"
	End Sub
	
	Public Sub SetTimeTaken()
		Console.WriteLine(Me.GetTimeTaken())
	End Sub
	
	Public Function GetTimeTaken() As String
		Me.TEnd = Now
		Me.TimeTaken = TimeDiff(Me.TStart,Me.TEnd)
		
		Return Me.TimeTaken
	End Function
	
	Public Function GetTimeTakenInt() As Integer
		Me.TEnd = Now
		Return (TimeCInt(Me.TEnd) - TimeCInt(Me.TStart))
	End Function
	
	Public Sub Reset()
		Me.TStart = Now
	End Sub
	
	Private Function TimeCInt(ByVal time As Date) As Integer
		Dim stime As String = time.ToLongTimeString
		Dim itime As Integer
		Dim i As Integer = 0
		
		If (Len(stime) = 11) Then
			i = 1
		End If
		
		itime = Int(Mid(stime,1,1+i)) * 3600
		itime = itime + Int(Mid(stime,3+i,2)) * 60
		itime = itime + Int(Mid(stime,6+i,2))
		Return itime
	End Function
	
	Private Function TimeDiff(ByVal t1 As Date, ByVal t2 As Date) As String
		Dim time1 As Integer = TimeCInt(t1)
		Dim time2 As Integer = TimeCInt(t2)
		Dim tdiff As Integer = TimeCInt(t2) - TimeCInt(t1)
		Dim minutes As Integer = 0
		Dim time As String
		
		While tdiff >= 60
			minutes = minutes + 1
			tdiff = tdiff - 60
		End While
		
		time = CStr(minutes) + ":" + CStr(tdiff)
		If minutes < 10 Then
			time = "0" + time
		End If
		If (tdiff < 10) Then
			time = Mid(time,1,3) + "0" + Right(time,1)
		End If
		Return time
	End Function
End Class
