Public Class Form1
    Private Declare Function SetProcessDPIAware Lib "user32.dll" () As Boolean
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Label4.Text = Format(Me.NumericUpDown1.Value, "00") + ":" + Format(Me.NumericUpDown2.Value, "00") + ":" + Format(Me.NumericUpDown3.Value, "00")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1_Click(Nothing, Nothing)
        On Error Resume Next
        Me.TextBox1.Text = Application.StartupPath + "\RING.wav"
        On Error Resume Next
        Dim isDPI As String = My.Application.CommandLineArgs(0)
        If isDPI = Nothing Then isDPI = ""
        isDPI = isDPI.ToLower()
        If isDPI = "usingdpi" Then
            SetProcessDPIAware()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.CheckBox1.Checked = False Then
            Me.TopMost = False
        Else
            Me.TopMost = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.OpenFileDialog1.ShowDialog()
        Me.TextBox1.Text = Me.OpenFileDialog1.FileName
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim str As String = Me.Label4.Text
        Dim hour As Integer
        Dim minute As Integer
        Dim second As Integer
        hour = CInt(Mid(str, 1, 2))
        minute = CInt(Mid(str, 4, 2))
        second = CInt(Mid(str, 7, 2))
        second = second - 1
        If second = -1 Then
            second = 59
            minute = minute - 1
        End If
        If minute = -1 Then
            minute = 59
            hour = hour - 1
        End If
        If hour = -1 Then
            Me.Label4.Text = "00:00:00"
            Me.AxWindowsMediaPlayer1.URL = Me.TextBox1.Text
            Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
            Me.Timer2.Enabled = False
            Me.Label4.Text = "00:00:00"
            Me.Button2.Text = "开始倒计时"
            Me.Button2.Enabled = False
            Me.Button3.Enabled = True
        End If
        If Not hour = -1 Then
            Me.Label4.Text = Format(hour, "00") + ":" + Format(minute, "00") + ":" + Format(second, "00")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.Button2.Text = "开始倒计时" Then
            Me.Timer2.Enabled = True
            Me.Button2.Text = "暂停倒计时"
            Me.Panel1.Enabled = False
            Me.Button3.Enabled = False
        Else
            Me.Timer2.Enabled = False
            Me.Button2.Text = "开始倒计时"
            Me.Panel1.Enabled = True
            Me.Button3.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        On Error Resume Next
        Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Button1_Click(Nothing, Nothing)
        Me.Panel1.Enabled = True
        Me.Button2.Text = "开始倒计时"
        Me.Button2.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (Me.Button5.Text = "显示设置项") Then
            Me.Button5.Text = "隐藏设置项"
            Me.Panel1.Visible = True
        Else
            Me.Button5.Text = "显示设置项"
            Me.Panel1.Visible = False
        End If
    End Sub
End Class
