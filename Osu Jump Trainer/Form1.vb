Public Class Form1

#Region "Variables"
    Dim e_backcolor As Color = Color.Black
    Dim e_combocolors As New ArrayList

    Dim e_blankimage As Image = My.Resources.blank
    Dim e_cursorimage As Image = My.Resources.cursor
    Dim e_cursortrailimage As Image = My.Resources.cursortrail
    Dim e_cursormiddleimage As Image = My.Resources.cursormiddle
    Dim e_followpointimage As Image = My.Resources.followpoint
    Dim e_hitcircleimage As Image = My.Resources.hitcircle
    Dim e_hitcircleoverlayimage As Image = My.Resources.hitcircleoverlay
    Dim e_approachcircleimage As Image = My.Resources.approachcircle
    Dim e_0image As Image = My.Resources.hit0
    Dim e_50image As Image = My.Resources.hit50
    Dim e_100image As Image = My.Resources.hit100
    Dim e_300image As Image = My.Resources.hit300
    Dim e_number0 As Image = My.Resources.default_0
    Dim e_number1 As Image = My.Resources.default_1
    Dim e_number2 As Image = My.Resources.default_2
    Dim e_number3 As Image = My.Resources.default_3
    Dim e_number4 As Image = My.Resources.default_4
    Dim e_number5 As Image = My.Resources.default_5
    Dim e_number6 As Image = My.Resources.default_6
    Dim e_number7 As Image = My.Resources.default_7
    Dim e_number8 As Image = My.Resources.default_8
    Dim e_number9 As Image = My.Resources.default_9
    Dim e_numberdot As Image = My.Resources.score_dot
    Dim e_numberperc As Image = My.Resources.score_percent
    Dim e_count1 As Image = My.Resources.count1
    Dim e_count2 As Image = My.Resources.count2
    Dim e_count3 As Image = My.Resources.count3

    'e_circles example:
    'xpos(int), ypos(int), combo(int), number(int), approachcircleinflation(double), lifetime(double), spawnedhitcircle(0|1)
    Dim e_circles As New ArrayList(1)
    Dim e_combocoloredcircles As New ArrayList(7)
    Dim e_combocoloredapproachcircles As New ArrayList(7)

    Dim e_maxapproachcircleinflation As Double = 4
    Dim e_minapproachcircleinflation As Double = 0.99

    Dim e_pointimages As New ArrayList
    Dim e_fpointimages As New ArrayList


    Dim e_started As Boolean = False

    'Extra vars
    Dim newskinselected As Boolean = False

    Dim w_width As Integer = Me.Width - Me.ClientSize.Width
    Dim w_height As Integer = Me.Height - Me.ClientSize.Height

    Dim s_resolution As String
    Dim s_circlesize As Integer = 128
    Dim s_approachrate As String
    Dim s_overalldifficulty As String
    Dim s_bpm As Integer = 20
    Dim s_skin As String

    'The following go by the formula: for every millisecond, difference in inflation
    'is equal to: (maxinfl-mininfl)/(ar11time+arincrement*(ar11-approachrate))
    Dim a_ar11time As Integer = 300
    Dim a_arincrement As Integer = 150

    Dim s_score As Integer = 0
    Dim s_maxscore As Integer = 0

    Dim c_cursorrotation As Double = 0

    Dim alphaclrmtrx As New Imaging.ColorMatrix
    Dim imgattr As New Imaging.ImageAttributes

    Dim m_mousedown As Boolean = False
    Dim t_starttime As Integer
    Dim s_iscountdownstage As Boolean = True

    Dim c_lastframe As Integer

    Dim t_escapeopacity As Integer = 1
    Dim t_mainthreadstate As String = "-1"

#End Region

#Region "Form1_Load (starting form)"

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            mainthread.Suspend() 'Because fuck obsoletion!
            t_mainthreadstate = "0"
            e_started = False
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            End If
            Me.Cursor = Cursors.Default
            Me.Size = New Point(308, 396)
            Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2)
            Me.BackColor = Color.White
            For Each c As Control In Me.Controls
                c.Visible = True
                c.Enabled = True
            Next

            'Reinitialize all important variables
            s_score = 0
            s_maxscore = 0
            e_circles = New ArrayList(1)
            e_combocoloredcircles = New ArrayList(7)
            e_combocoloredapproachcircles = New ArrayList(7)
            e_pointimages = New ArrayList
            e_fpointimages = New ArrayList
            s_iscountdownstage = True
            ResolutionSelectLabel.TextAlign = ContentAlignment.MiddleCenter
            ResolutionSelectionPanel.Visible = False
            ARDisplayLabel.Visible = False
            ODDisplayLabel.Visible = False
            CSDisplayLabel.Visible = False
            BPMDisplayLabel.Visible = False

            Me.Refresh()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        Me.UpdateStyles()
        Control.CheckForIllegalCrossThreadCalls = False

        'Fill initial combocolors: 
        e_combocolors.Add("249,145,145")
        e_combocolors.Add("248,243,141")
        e_combocolors.Add("142,227,141")
        e_combocolors.Add("240,152,192")
        e_combocolors.Add("221,238,184")
        e_combocolors.Add("247,190,161")
        e_combocolors.Add("149,149,149")
        e_combocolors.Add("210,210,210")
        'Fill initial "necessities" (idk wtf to call them LOL) (mostly extra eye-candy because I'm OCD)
        For Each c As Control In ResolutionSelectionPanel.Controls
            If (c.Name <> "Label1") And (c.Name <> "Label6") And (c.Name <> "Label14") And (c.Name <> "WidthTB") And (c.Name <> "HeightTB") Then
                AddHandler c.MouseEnter, AddressOf LabelME
                AddHandler c.MouseLeave, AddressOf LabelML
                AddHandler c.MouseClick, AddressOf LabelMC
                If (c.Text.Substring(0, c.Text.IndexOf("x")) = Screen.GetBounds(Me.Location).Width) And (c.Text.Substring(c.Text.IndexOf("x") + 1) = Screen.GetBounds(Me.Location).Height) Then
                    c.Text = c.Text & " (fullscreen)"
                End If
            End If
        Next
        For Each c As Control In Me.Controls
            If (c.Name <> "Label15") And (c.Name <> "Label20") And (c.Name <> "Label13") And (c.Name <> "Label16") And (c.Name <> "Label17") And (c.Name <> "LinkLabel1") And (c.Name <> "LinkLabel2") And (c.Name <> "Label18") And (c.Name <> "ColorPickPB") Then
                AddHandler c.MouseEnter, AddressOf LabelME
                AddHandler c.MouseLeave, AddressOf LabelML
            End If
            If (c.Name <> "Label16") And (c.Name <> "LinkLabel1") And (c.Name <> "LinkLabel2") And (c.Name <> "Label18") And (c.Name <> "ColorPickPB") Then
                c.Location = New Point(Me.ClientSize.Width / 2 - c.Width / 2, c.Location.Y)
            End If
        Next
        CSDisplayLabel.Location = New Point(CSTrackBar.Location.X + CSTrackBar.Width, CSDisplayLabel.Location.Y)
        ARDisplayLabel.Location = New Point(ARTrackBar.Location.X + ARTrackBar.Width, ARDisplayLabel.Location.Y)
        ODDisplayLabel.Location = New Point(ODTrackBar.Location.X + ODTrackBar.Width, ODDisplayLabel.Location.Y)
        BPMDisplayLabel.Location = New Point(BPMTrackBar.Location.X + BPMTrackBar.Width, BPMDisplayLabel.Location.Y)
    End Sub
#End Region

#Region "Extra Functions"
    Sub UpdateSkinImages()
        If My.Computer.FileSystem.FileExists(s_skin & "\hitcircle.png") Then
            e_hitcircleimage = Image.FromFile(s_skin & "\hitcircle.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\hitcircleoverlay.png") Then
            e_hitcircleoverlayimage = Image.FromFile(s_skin & "\hitcircleoverlay.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\cursor.png") Then
            e_cursorimage = Image.FromFile(s_skin & "\cursor.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\cursortrail.png") Then
            e_cursortrailimage = Image.FromFile(s_skin & "\cursortrail.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\cursormiddle.png") Then
            e_cursormiddleimage = Image.FromFile(s_skin & "\cursormiddle.png")
        Else
            e_cursormiddleimage = My.Resources.blank
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\followpoint.png") Then
            e_followpointimage = Image.FromFile(s_skin & "\followpoint.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\approachcircle.png") Then
            e_approachcircleimage = Image.FromFile(s_skin & "\approachcircle.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_0.png") Then
            e_number0 = Image.FromFile(s_skin & "\default_0.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_1.png") Then
            e_number1 = Image.FromFile(s_skin & "\default_1.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_2.png") Then
            e_number2 = Image.FromFile(s_skin & "\default_2.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_3.png") Then
            e_number3 = Image.FromFile(s_skin & "\default_3.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_4.png") Then
            e_number4 = Image.FromFile(s_skin & "\default_4.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_5.png") Then
            e_number5 = Image.FromFile(s_skin & "\default_5.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_6.png") Then
            e_number6 = Image.FromFile(s_skin & "\default_6.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_7.png") Then
            e_number7 = Image.FromFile(s_skin & "\default_7.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\default_8.png") Then
            e_number8 = Image.FromFile(s_skin & "\default_8.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\hit0.png") Then
            e_0image = Image.FromFile(s_skin & "\hit0.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\hit50.png") Then
            e_50image = Image.FromFile(s_skin & "\hit50.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\hit100.png") Then
            e_100image = Image.FromFile(s_skin & "\hit100.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\hit300.png") Then
            e_300image = Image.FromFile(s_skin & "\hit300.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\score-dot.png") Then
            e_numberdot = Image.FromFile(s_skin & "\score-dot.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\score-percent.png") Then
            e_numberperc = Image.FromFile(s_skin & "\score-percent.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\count1.png") Then
            e_count1 = Image.FromFile(s_skin & "\count1.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\count2.png") Then
            e_count2 = Image.FromFile(s_skin & "\count2.png")
        End If
        If My.Computer.FileSystem.FileExists(s_skin & "\count3.png") Then
            e_count3 = Image.FromFile(s_skin & "\count3.png")
        End If
    End Sub
    Function TranslateNum(ByVal number As String) As Image
        If number = "1" Then
            Return e_number1
        ElseIf number = "2" Then
            Return e_number2
        ElseIf number = "3" Then
            Return e_number3
        ElseIf number = "4" Then
            Return e_number4
        ElseIf number = "5" Then
            Return e_number5
        ElseIf number = "6" Then
            Return e_number6
        ElseIf number = "7" Then
            Return e_number7
        ElseIf number = "8" Then
            Return e_number8
        ElseIf number = "9" Then
            Return e_number9
        ElseIf number = "0" Then
            Return e_number0
        ElseIf number = "." Then
            Return e_numberdot
        ElseIf number = "%" Then
            Return e_numberperc
        End If
        Return Nothing
    End Function
    Function Rotate(ByVal x As Integer, ByVal y As Integer, ByVal angle As Double) As Point
        Dim newx As Integer = x * Math.Cos(angle) + y * Math.Sin(angle)
        Dim newy As Integer = -x * Math.Sin(angle) + y * Math.Cos(angle)
        Return New Point(newx, newy)
    End Function
#End Region

#Region "Mouse/click events for starting form"
    Private Sub Gogogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gogogo.Click
        s_approachrate = ARTrackBar.Value
        s_overalldifficulty = ODTrackBar.Value

        If s_resolution = "" Then
            MsgBox("Please select a resolution!")
            Exit Sub
        End If

        If newskinselected = True Then
            'This following section was too long thus it was put into a called sub... And I'm too lazy to find an amazing method to do it programmatically
            UpdateSkinImages()

            If My.Computer.FileSystem.FileExists(s_skin & "\skin.ini") Then
                Dim reader As New IO.StreamReader(s_skin & "\skin.ini")
                While reader.Peek <> -1
                    Dim l As String = reader.ReadLine
                    If l.Contains("Combo1") Or l.Contains("Combo2") Or l.Contains("Combo3") Or l.Contains("Combo4") Or l.Contains("Combo5") Or l.Contains("Combo6") Or l.Contains("Combo7") Or l.Contains("Combo8") Then
                        Dim combonumber As String = l.Substring(5, 1)
                        Dim value As String = l.Substring(l.IndexOf(":") + 1).Replace(" ", "")
                        e_combocolors(combonumber - 1) = value
                    End If
                End While
            End If
        End If

        For Each c As Control In Me.Controls
            c.Visible = False
            c.Enabled = False
        Next
        If (s_resolution.Substring(0, s_resolution.IndexOf("x")) = Screen.GetBounds(Me.Location).Width) And (s_resolution.Substring(s_resolution.IndexOf("x") + 1) = Screen.GetBounds(Me.Location).Height) Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        End If
        Me.Size = New Point(s_resolution.Substring(0, s_resolution.IndexOf("x")) + w_width, s_resolution.Substring(s_resolution.IndexOf("x") + 1) + w_height)
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2)
        Me.Cursor = New Cursor(My.Resources.Empty.Handle)
        Me.BackColor = e_backcolor
        e_circles.Add(Me.ClientSize.Width / 2 & "," & Me.ClientSize.Height / 2 & ",0,1," & e_maxapproachcircleinflation & ",-1")

        For Each qs As String In e_combocolors.ToArray
            'I'm lazy, the following line just creates a color variables from a string value such as "xxx,xxx,xxx" by splitting into RGB based on ',' locations
            'Side note, I do NOT know how to alpha blend as well as DirectX, so don't send me into the corner because my alpha blending isn't as good as
            'peppy's...
            Dim D As Color = Color.FromArgb(255, qs.Substring(0, qs.IndexOf(",")), qs.Substring(qs.IndexOf(",") + 1, qs.IndexOf(",", qs.IndexOf(",") + 1) - (qs.IndexOf(",") + 1)), qs.Substring(qs.IndexOf(",", qs.IndexOf(",") + 1) + 1))
            Dim b As New Bitmap(e_hitcircleimage)
            Dim b1 As New Bitmap(e_approachcircleimage)
            Dim newapproachcircle As New Bitmap(b1.Width, b1.Height)
            Dim newhitcircle As New Bitmap(b.Width, b.Height)
            For w = 0 To b.Width - 1
                For h = 0 To b.Height - 1
                    Dim S As Color = b.GetPixel(w, h)
                    Dim sA As Double = S.A / 255 : Dim sR As Double = S.R / 255 : Dim sG As Double = S.G / 255 : Dim sB As Double = S.B / 255
                    Dim dR As Double = D.R / 255 : Dim dG As Double = D.G / 255 : Dim dB As Double = D.B / 255
                    Dim outA As Double = sA
                    Dim outR, outG, outB As Double
                    If outA <> 0 Then
                        outR = dR * sR
                        outG = dG * sG
                        outB = dB * sB
                    End If
                    newhitcircle.SetPixel(w, h, Color.FromArgb(S.A, outR * 255, outG * 255, outB * 255))
                Next
            Next
            For w = 0 To b1.Width - 1
                For h = 0 To b1.Height - 1
                    Dim S As Color = b1.GetPixel(w, h)
                    Dim sA As Double = S.A / 255 : Dim sR As Double = S.R / 255 : Dim sG As Double = S.G / 255 : Dim sB As Double = S.B / 255
                    Dim dR As Double = D.R / 255 : Dim dG As Double = D.G / 255 : Dim dB As Double = D.B / 255
                    Dim outA As Double = sA
                    Dim outR, outG, outB As Double
                    If outA <> 0 Then
                        outR = dR * sR
                        outG = dG * sG
                        outB = dB * sB
                    End If
                    newapproachcircle.SetPixel(w, h, Color.FromArgb(S.A, outR * 255, outG * 255, outB * 255))
                Next
            Next
            e_combocoloredcircles.Add(newhitcircle)
            e_combocoloredapproachcircles.Add(newapproachcircle)
        Next

        'FINALLY>>>>>>>>>>>>>>>>>>>>
        e_started = True 'STARTU!
        '!!!!!!!!!!!!!!!!!!!!!!
        '!!!!!!!!!!!!!!!!!!!!!!
        '!!!!!!!!!YAY!!!!!!!!!!
        '!!!!!!!!!!!!!!!!!!!!!!
        '!!!!!!!!!!!!!!!!!!!!!! (nosrsly thank fuck that's over, now onto the fun stuff!)
        t_starttime = Date.Now.TimeOfDay.TotalMilliseconds
        If t_mainthreadstate = "-1" Then
            mainthread.IsBackground = True
            mainthread.Start()
            t_mainthreadstate = "1"
        Else
            mainthread.Resume()
            t_mainthreadstate = "1"
        End If

    End Sub
    'Below are mostly mouse/click events for eye-candy
    Private Sub Form1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Click
        If e_started = False Then
            ResolutionSelectionPanel.Visible = False
        End If
    End Sub
    Private Sub SkinSelectLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkinSelectLabel.Click
        Dim fd As New FolderBrowserDialog
        fd.Description = "Select the folder of the skin you want to use"
        If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
            SkinSelectLabel.Text = fd.SelectedPath
            s_skin = fd.SelectedPath
            SkinSelectLabel.Text = "Click to select skin (" & s_skin.Substring(s_skin.LastIndexOf("\") + 1) & " otherwise)"
            newskinselected = True
        End If
    End Sub
    Private Sub ResolutionSelectLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolutionSelectLabel.Click
        If ResolutionSelectionPanel.Visible = True Then
            ResolutionSelectionPanel.Visible = False
        Else
            ResolutionSelectionPanel.Visible = True
            ResolutionSelectionPanel.Focus()
        End If
    End Sub

    Sub LabelME(ByVal sender As System.Object, ByVal e As EventArgs) 'Because fuck calling it LabelMouseEnter, amirite? guys?
        sender.BackColor = Color.Gainsboro
    End Sub
    Sub LabelML(ByVal sender As System.Object, ByVal e As EventArgs)
        sender.BackColor = Color.White
    End Sub
    Sub LabelMC(ByVal sender As System.Object, ByVal e As EventArgs)
        ResolutionSelectionPanel.Visible = False
        ResolutionSelectLabel.Text = "Resolution: " & sender.Text
        s_resolution = sender.Text.Replace(" (fullscreen)", "")
    End Sub
    Private Sub Gogogo_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Gogogo.MouseDown
        ResolutionSelectionPanel.Visible = False
    End Sub

    Private Sub ODTrackBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ODTrackBar.MouseDown
        ODDisplayLabel.Visible = True
    End Sub

    Private Sub ODTrackBar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ODTrackBar.MouseUp
        ODDisplayLabel.Visible = False
    End Sub

    Private Sub ODTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ODTrackBar.Scroll
        ODDisplayLabel.Text = ODTrackBar.Value
        s_overalldifficulty = ODTrackBar.Value
    End Sub

    Private Sub BPMTrackBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BPMTrackBar.MouseDown
        BPMDisplayLabel.Visible = True
    End Sub

    Private Sub BPMTrackBar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BPMTrackBar.MouseUp
        BPMDisplayLabel.Visible = False
    End Sub

    Private Sub BPMTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPMTrackBar.Scroll
        BPMDisplayLabel.Text = BPMTrackBar.Value
        s_bpm = BPMTrackBar.Value - 147
    End Sub
    Private Sub ARTrackBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ARTrackBar.MouseDown
        ARDisplayLabel.Visible = True
    End Sub

    Private Sub ARTrackBar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ARTrackBar.MouseUp
        ARDisplayLabel.Visible = False
    End Sub

    Private Sub ARTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARTrackBar.Scroll
        ARDisplayLabel.Text = ARTrackBar.Value
        s_approachrate = ARTrackBar.Value
    End Sub

    Private Sub CSTrackBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CSTrackBar.MouseDown
        CSDisplayLabel.Visible = True
    End Sub

    Private Sub CSTrackBar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CSTrackBar.MouseUp
        CSDisplayLabel.Visible = False
    End Sub

    Private Sub CSTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSTrackBar.Scroll
        CSDisplayLabel.Text = CSTrackBar.Value
        s_circlesize = 64 + (7 - (CSTrackBar.Value - 2)) * 9.14
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        m_mousedown = True
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        m_mousedown = False
    End Sub

    Private Sub WidthTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthTB.Click
        If WidthTB.Text = "Width" Then
            WidthTB.Text = ""
        End If
    End Sub

    Private Sub WidthTB_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthTB.LostFocus
        If WidthTB.Text = "" Then
            WidthTB.ForeColor = Color.Gray
            WidthTB.Text = "Width"
        End If
    End Sub

    Private Sub WidthTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WidthTB.TextChanged
        If WidthTB.Text <> "Width" Then
            WidthTB.ForeColor = Color.Black
            s_resolution = WidthTB.Text & "x" & HeightTB.Text
        End If
    End Sub
    Private Sub HeightTB_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HeightTB.LostFocus
        If HeightTB.Text = "" Then
            HeightTB.ForeColor = Color.Gray
            HeightTB.Text = "Height"
        End If
    End Sub
    Private Sub HeightTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HeightTB.Click
        If HeightTB.Text = "Height" Then
            HeightTB.Text = ""
        End If
    End Sub

    Private Sub HeightTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HeightTB.TextChanged
        If HeightTB.Text <> "Height" Then
            HeightTB.ForeColor = Color.Black
            s_resolution = WidthTB.Text & "x" & HeightTB.Text
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://osu.ppy.sh")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://ppy.sh")
    End Sub

    Private Sub ColorPickPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickPB.Click
        Dim cd As New ColorDialog
        If cd.ShowDialog = DialogResult.OK Then
            ColorPickPB.BackColor = cd.Color
            e_backcolor = cd.Color
        End If
    End Sub
#End Region

    Dim mainthread As New System.Threading.Thread(AddressOf Main)
    Sub Main()
        Do
            Me.Refresh()
        Loop
    End Sub

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If e_started = True Then
            'Do Countdown
            If s_iscountdownstage = True Then
                Dim timediff As Integer = Date.Now.TimeOfDay.TotalMilliseconds - t_starttime
                If timediff > 3000 Then
                    s_iscountdownstage = False
                ElseIf timediff > 2000 Then
                    e.Graphics.DrawImage(e_count1, CInt(Me.ClientSize.Width / 2 - e_count1.Width / 2), CInt((Me.ClientSize.Height - w_height) / 2 - e_count1.Height / 2), e_count1.Width, e_count1.Height)
                    e.Graphics.DrawImage(e_count2, Me.ClientSize.Width - e_count2.Width, 0, e_count2.Width, e_count2.Height)
                    e.Graphics.DrawImage(e_count3, 0, 0, e_count3.Width, e_count3.Height)
                ElseIf timediff > 1000 Then
                    e.Graphics.DrawImage(e_count2, Me.ClientSize.Width - e_count2.Width, 0, e_count2.Width, e_count2.Height)
                    e.Graphics.DrawImage(e_count3, 0, 0, e_count3.Width, e_count3.Height)
                ElseIf timediff > 0 Then
                    e.Graphics.DrawImage(e_count3, 0, 0, e_count3.Width, e_count3.Height)
                End If
                Dim values() As String = e_circles(0).Split(",")

                e.Graphics.DrawImage(e_combocoloredcircles(values(2)), CInt(values(0) - s_circlesize / 2), CInt(values(1) - s_circlesize / 2), s_circlesize, s_circlesize)
                e.Graphics.DrawImage(e_hitcircleoverlayimage, CInt(values(0) - s_circlesize / 2), CInt(values(1) - s_circlesize / 2), s_circlesize, s_circlesize)
                Dim numberimage As Image = TranslateNum(values(3))
                e.Graphics.DrawImage(numberimage, CInt(values(0) - numberimage.Width / (128 / (0.769 * s_circlesize)) / 2), CInt(values(1) - numberimage.Height / (128 / (0.769 * s_circlesize)) / 2), CInt(numberimage.Width / (128 / (0.769 * s_circlesize))), CInt(numberimage.Height / (128 / (0.769 * s_circlesize))))

                alphaclrmtrx.Matrix33 = 1 - (Date.Now.TimeOfDay.TotalMilliseconds - t_starttime) / 2000
                imgattr.SetColorMatrix(alphaclrmtrx)
                Dim s As String = "Press escape to exit"
                Dim b As New Bitmap(500, 60)
                Dim g As Graphics = Graphics.FromImage(b)
                g.DrawString(s, New Font("Segoe UI", 20), Brushes.White, New Point(0, b.Height / 2 - g.MeasureString(s, New Font("Segoe UI", 12)).Height / 2))
                g.Dispose()
                e.Graphics.DrawImage(b, New Rectangle(0, ClientSize.Height - b.Height - 10, b.Width, b.Height), 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, imgattr)
                GoTo B
            End If

            'Draw score and accuracy
            Dim scorestring As String = s_score

            Dim accstring As String = ""
            If s_maxscore = 0 Then
                accstring = "0%"
            Else
                accstring = Math.Round((s_score / s_maxscore) * 100, 2) & "%"
            End If
            Dim scoreimages As New ArrayList
            Dim accuracyimages As New ArrayList
            For Each c As Char In scorestring
                scoreimages.Add(TranslateNum(c.ToString))
            Next
            For Each c In accstring
                accuracyimages.Add(TranslateNum(c.ToString))
            Next
            Dim currentwidth As Integer = 0
            For i = accuracyimages.Count - 1 To 0 Step -1
                e.Graphics.DrawImage(accuracyimages(i), Me.Width - 20 - currentwidth - CInt(accuracyimages(i).Width / 1.5), 10 + scoreimages(0).Height + 10, CInt(accuracyimages(i).Width / 1.5), CInt(accuracyimages(i).Height / 1.5))
                currentwidth += accuracyimages(i).Width / 1.5
            Next
            currentwidth = 0
            For i = scorestring.Length - 1 To 0 Step -1
                e.Graphics.DrawImage(scoreimages(i), Me.Width - 20 - currentwidth - scoreimages(i).Width, 10, scoreimages(i).Width, scoreimages(i).Height)
                currentwidth += scoreimages(i).Width
            Next

            'Draw followpoints
            For Each fp In e_fpointimages.ToArray
                Dim values() As String = fp.Split(",")
                Dim newalpha As Double = 1.0
                If values.Length = 5 Then
                    If Date.Now.TimeOfDay.TotalMilliseconds - values(4) >= (50 + 25 * (11 - s_approachrate)) Then
                        If Date.Now.TimeOfDay.TotalMilliseconds - (values(4) + (50 + 25 * (11 - s_approachrate))) >= 200 Then
                            e_fpointimages.Remove(fp)
                            GoTo A 'LOL GOTO AMRITE? fml..
                        Else
                            newalpha = 1 - ((Date.Now.TimeOfDay.TotalMilliseconds - (values(4) + (50 + 25 * (11 - s_approachrate)))) / 200)
                        End If
                    End If
                End If
                Dim upperLeft As Point = Rotate(-e_followpointimage.Width / 2, e_followpointimage.Height / 2, values(3))
                Dim upperRight As Point = Rotate(e_followpointimage.Width / 2, e_followpointimage.Height / 2, values(3))
                Dim lowerLeft As Point = Rotate(-e_followpointimage.Width / 2, -e_followpointimage.Height / 2, values(3))
                Dim center As New Point(values(1), values(2))
                Dim newpoints() As Point = {upperLeft + center, upperRight + center, lowerLeft + center}
                alphaclrmtrx.Matrix33 = newalpha
                imgattr.SetColorMatrix(alphaclrmtrx)
                e.Graphics.DrawImage(e_followpointimage, newpoints, New Rectangle(0, 0, e_followpointimage.Width, e_followpointimage.Height), GraphicsUnit.Pixel, imgattr)
A:
            Next

            'Draw hitcircles
            If e_circles.Count = 0 Then
                Dim r As New Random
                Dim randomposition As New Point(r.Next(e_hitcircleimage.Width, ClientSize.Width - e_hitcircleimage.Width), r.Next(e_hitcircleimage.Height, ClientSize.Height - e_hitcircleimage.Height))
                e_circles.Add(randomposition.X & "," & randomposition.Y & "," & 0 & "," & 1 & "," & e_maxapproachcircleinflation & ",-1,0")
            End If
            For Each circle In e_circles.ToArray
                Dim values() As String = circle.split(",")
                e.Graphics.DrawImage(e_combocoloredcircles(values(2)), CInt(values(0) - s_circlesize / 2), CInt(values(1) - s_circlesize / 2), s_circlesize, s_circlesize)
                e.Graphics.DrawImage(e_hitcircleoverlayimage, CInt(values(0) - s_circlesize / 2), CInt(values(1) - s_circlesize / 2), s_circlesize, s_circlesize)
                Dim numberimage As Image = TranslateNum(values(3))
                e.Graphics.DrawImage(numberimage, CInt(values(0) - numberimage.Width / (128 / (0.769 * s_circlesize)) / 2), CInt(values(1) - numberimage.Height / (128 / (0.769 * s_circlesize)) / 2), CInt(numberimage.Width / (128 / (0.769 * s_circlesize))), CInt(numberimage.Height / (128 / (0.769 * s_circlesize))))
                If values(5) = -1 Then 'initial time value for new circle
                    'Set the initial time
                    values(5) = Date.Now.TimeOfDay.TotalMilliseconds
                    Dim newcircle As String = ""
                    For i = 0 To values.Length - 1
                        newcircle += values(i) & ","
                    Next
                    newcircle += "0"
                    e_circles(e_circles.IndexOf(circle)) = newcircle
                Else
                    Dim timeelapsed As Double = Date.Now.TimeOfDay.TotalMilliseconds - values(5)
                    Dim inflationamnt As Double = (e_maxapproachcircleinflation - e_minapproachcircleinflation) - ((e_maxapproachcircleinflation - e_minapproachcircleinflation) / (a_ar11time + a_arincrement * (11 - s_approachrate))) * timeelapsed
                    If inflationamnt < e_minapproachcircleinflation Then
                        'Create virtual boundaries for 50, 100 and 300 hitcircles
                        Dim gp300, gp100, gp50 As New System.Drawing.Drawing2D.GraphicsPath
                        gp300.AddEllipse(CInt(values(0) - s_circlesize / 2 / 2 / s_overalldifficulty), CInt(values(1) - s_circlesize / 2 / 2 / s_overalldifficulty), CInt(s_circlesize / 2 / s_overalldifficulty), CInt(s_circlesize / 2 / s_overalldifficulty))
                        gp100.AddEllipse(CInt(values(0) - 3 * s_circlesize / 2 / 4 / s_overalldifficulty), CInt(values(1) - 3 * s_circlesize / 2 / 4 / s_overalldifficulty), CInt(3 * s_circlesize / 4 / s_overalldifficulty), CInt(3 * s_circlesize / 4 / s_overalldifficulty))
                        gp50.AddEllipse(CInt(values(0) - s_circlesize / 2), CInt(values(1) - s_circlesize / 2), CInt(s_circlesize), CInt(s_circlesize))
                        If gp300.IsVisible(PointToClient(Cursor.Position)) Then
                            e_pointimages.Add(values(0) & "," & values(1) & ",300," & Date.Now.TimeOfDay.TotalMilliseconds)
                            s_score += 300
                        ElseIf gp100.IsVisible(PointToClient(Cursor.Position)) Then
                            e_pointimages.Add(values(0) & "," & values(1) & ",100," & Date.Now.TimeOfDay.TotalMilliseconds)
                            s_score += 100
                        ElseIf gp50.IsVisible(PointToClient(Cursor.Position)) Then
                            e_pointimages.Add(values(0) & "," & values(1) & ",50," & Date.Now.TimeOfDay.TotalMilliseconds)
                            s_score += 50
                        Else
                            e_pointimages.Add(values(0) & "," & values(1) & ",0," & Date.Now.TimeOfDay.TotalMilliseconds)
                        End If
                        s_maxscore += 300
                        e_circles.Remove(circle)
                        Dim currentfp As Integer = 0
                        For Each fp In e_fpointimages.ToArray
                            If fp.Substring(0, fp.Indexof(",")) = values(3) Then
                                e_fpointimages(e_fpointimages.IndexOf(fp)) = fp & "," & Date.Now.TimeOfDay.TotalMilliseconds + (10 / ((s_approachrate + 1) / 2)) * currentfp
                                currentfp += 1
                            End If
                        Next
                    ElseIf (inflationamnt <= e_minapproachcircleinflation + (s_bpm / 100) * (e_maxapproachcircleinflation - e_minapproachcircleinflation)) Then
                        Dim approachcirclesize As New Point(s_circlesize * inflationamnt, s_circlesize * inflationamnt)
                        e.Graphics.DrawImage(e_combocoloredapproachcircles(values(2)), CInt(values(0) - approachcirclesize.X / 2), CInt(values(1) - approachcirclesize.Y / 2), approachcirclesize.Y, approachcirclesize.Y)
                        Dim newcircle As String = ""
                        If values.Length >= 7 Then
                            If values(6) = "0" Then
                                Dim r As New Random(CType(Date.Now.Ticks Mod System.Int32.MaxValue, Integer))
                                Dim randomposition As New Point(r.Next(s_circlesize, ClientSize.Width - s_circlesize), r.Next(s_circlesize, ClientSize.Height - s_circlesize))
                                Dim combonumber As Integer = IIf(values(3) = 9, 1, values(3) + 1)
                                Dim combo As Integer = IIf(values(3) = 9, IIf(values(2) = 7, 0, values(2) + 1), values(2))
                                e_circles.Add(randomposition.X & "," & randomposition.Y & "," & combo & "," & combonumber & "," & e_maxapproachcircleinflation & ",-1,0")
                                For i = 0 To values.Length - 1
                                    If i = 6 Then
                                        newcircle += "1"
                                    Else
                                        newcircle += values(i) & ","
                                    End If
                                Next
                                e_circles(e_circles.IndexOf(circle)) = newcircle

                                Dim dx As Integer = randomposition.X - values(0)
                                Dim dy As Integer = randomposition.Y - values(1)
                                Dim tht As Double = Math.Atan(Math.Abs(dy) / Math.Abs(dx))
                                Dim newtht As Double = 0
                                Dim hyp As Double = Math.Sqrt(dy ^ 2 + dx ^ 2)
                                If (dx < 0) And (dy < 0) Then
                                    newtht = Math.PI - tht
                                ElseIf (dx < 0) And (dy > 0) Then
                                    newtht = Math.PI + tht
                                ElseIf (dx > 0) And (dy > 0) Then
                                    newtht = 2 * Math.PI - tht
                                Else
                                    newtht = tht
                                End If
                                Dim n As Integer = Math.Sqrt(e_followpointimage.Width ^ 2 + e_followpointimage.Height ^ 2) + 30
                                For i = 1 To hyp / n - 1
                                    e_fpointimages.Add(values(3) & "," & values(0) + (dx * n * i) / hyp & "," & values(1) + (dy * n * i) / hyp & "," & newtht)
                                Next
                            End If
                        End If
                    Else
                        Dim approachcirclesize As New Point(s_circlesize * inflationamnt, s_circlesize * inflationamnt)
                        e.Graphics.DrawImage(e_combocoloredapproachcircles(values(2)), CInt(values(0) - approachcirclesize.X / 2), CInt(values(1) - approachcirclesize.Y / 2), approachcirclesize.Y, approachcirclesize.Y)
                    End If
                End If
            Next

            'Draw points (300s,100s,50s)
            For Each point In e_pointimages.ToArray
                Dim values() As String = point.Split(",")
                If values(3) + 500 < Date.Now.TimeOfDay.TotalMilliseconds Then
                    e_pointimages.Remove(point)
                Else
                    Dim pointimg As Image = IIf(values(2) = 300, e_300image, IIf(values(2) = 100, e_100image, IIf(values(2) = 50, e_50image, e_0image)))
                    alphaclrmtrx.Matrix33 = 1 - ((Date.Now.TimeOfDay.TotalMilliseconds - values(3)) / 500)
                    imgattr.SetColorMatrix(alphaclrmtrx)
                    e.Graphics.DrawImage(pointimg, New Rectangle(CInt(values(0) - pointimg.Width / 2), CInt(values(1) - pointimg.Height / 2), pointimg.Width, pointimg.Height), 0, 0, pointimg.Width, pointimg.Height, GraphicsUnit.Pixel, imgattr)
                End If
            Next
B:
            'Draw Cursor & Cursortrail
            Dim mousepos As Point = PointToClient(MousePosition)
            e.Graphics.DrawImage(e_cursortrailimage, New Point(mousepos.X - e_cursortrailimage.Width / 2, mousepos.Y - e_cursortrailimage.Height / 2))        
            e.Graphics.DrawImage(e_cursorimage, New Point(mousepos.X - e_cursorimage.Width / 2, mousepos.Y - e_cursorimage.Height / 2))         
            e.Graphics.DrawImage(e_cursormiddleimage, New Point(mousepos.X - e_cursormiddleimage.Width / 2, mousepos.Y - e_cursormiddleimage.Height / 2))

        End If
    End Sub
End Class
