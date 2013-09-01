<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
        imgattr.Dispose()
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ResolutionSelectionPanel = New System.Windows.Forms.Panel()
        Me.HeightTB = New System.Windows.Forms.TextBox()
        Me.WidthTB = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SkinSelectLabel = New System.Windows.Forms.Label()
        Me.ResolutionSelectLabel = New System.Windows.Forms.Label()
        Me.Gogogo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ARTrackBar = New System.Windows.Forms.TrackBar()
        Me.ARDisplayLabel = New System.Windows.Forms.Label()
        Me.CSDisplayLabel = New System.Windows.Forms.Label()
        Me.CSTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ODDisplayLabel = New System.Windows.Forms.Label()
        Me.ODTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ColorPickPB = New System.Windows.Forms.PictureBox()
        Me.BPMDisplayLabel = New System.Windows.Forms.Label()
        Me.BPMTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ResolutionSelectionPanel.SuspendLayout()
        CType(Me.ARTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ODTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPickPB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BPMTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ResolutionSelectionPanel
        '
        Me.ResolutionSelectionPanel.BackColor = System.Drawing.Color.Black
        Me.ResolutionSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ResolutionSelectionPanel.Controls.Add(Me.HeightTB)
        Me.ResolutionSelectionPanel.Controls.Add(Me.WidthTB)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label14)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label12)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label11)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label10)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label9)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label8)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label7)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label6)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label5)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label4)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label3)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label2)
        Me.ResolutionSelectionPanel.Controls.Add(Me.Label1)
        Me.ResolutionSelectionPanel.Location = New System.Drawing.Point(81, 58)
        Me.ResolutionSelectionPanel.Name = "ResolutionSelectionPanel"
        Me.ResolutionSelectionPanel.Size = New System.Drawing.Size(142, 229)
        Me.ResolutionSelectionPanel.TabIndex = 2
        Me.ResolutionSelectionPanel.Visible = False
        '
        'HeightTB
        '
        Me.HeightTB.ForeColor = System.Drawing.Color.Gray
        Me.HeightTB.Location = New System.Drawing.Point(70, 208)
        Me.HeightTB.Name = "HeightTB"
        Me.HeightTB.Size = New System.Drawing.Size(71, 20)
        Me.HeightTB.TabIndex = 14
        Me.HeightTB.Text = "Height"
        Me.HeightTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WidthTB
        '
        Me.WidthTB.ForeColor = System.Drawing.Color.Gray
        Me.WidthTB.Location = New System.Drawing.Point(-1, 208)
        Me.WidthTB.Name = "WidthTB"
        Me.WidthTB.Size = New System.Drawing.Size(71, 20)
        Me.WidthTB.TabIndex = 13
        Me.WidthTB.Text = "Width"
        Me.WidthTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(141, 16)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Custom:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "1920x1080"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "1680x1050"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "1440x900"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "1366x768"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "1280x800"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "1024x600"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Widescreen:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "1280x860"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "1024x768"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "800x600"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "640x480"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Standard:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SkinSelectLabel
        '
        Me.SkinSelectLabel.BackColor = System.Drawing.Color.White
        Me.SkinSelectLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SkinSelectLabel.Location = New System.Drawing.Point(12, 9)
        Me.SkinSelectLabel.Name = "SkinSelectLabel"
        Me.SkinSelectLabel.Size = New System.Drawing.Size(278, 22)
        Me.SkinSelectLabel.TabIndex = 3
        Me.SkinSelectLabel.Text = "Click to select skin (default osu! skin otherwise)"
        Me.SkinSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ResolutionSelectLabel
        '
        Me.ResolutionSelectLabel.BackColor = System.Drawing.Color.White
        Me.ResolutionSelectLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ResolutionSelectLabel.Location = New System.Drawing.Point(81, 36)
        Me.ResolutionSelectLabel.Name = "ResolutionSelectLabel"
        Me.ResolutionSelectLabel.Size = New System.Drawing.Size(142, 22)
        Me.ResolutionSelectLabel.TabIndex = 4
        Me.ResolutionSelectLabel.Text = "Resolution:"
        Me.ResolutionSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Gogogo
        '
        Me.Gogogo.BackColor = System.Drawing.Color.White
        Me.Gogogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Gogogo.Location = New System.Drawing.Point(53, 306)
        Me.Gogogo.Name = "Gogogo"
        Me.Gogogo.Size = New System.Drawing.Size(198, 31)
        Me.Gogogo.TabIndex = 5
        Me.Gogogo.Text = "If you're happy with these options, click here to start!"
        Me.Gogogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(117, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "ApproachRate:"
        '
        'ARTrackBar
        '
        Me.ARTrackBar.AutoSize = False
        Me.ARTrackBar.LargeChange = 1
        Me.ARTrackBar.Location = New System.Drawing.Point(98, 101)
        Me.ARTrackBar.Maximum = 11
        Me.ARTrackBar.Name = "ARTrackBar"
        Me.ARTrackBar.Size = New System.Drawing.Size(104, 21)
        Me.ARTrackBar.TabIndex = 7
        Me.ARTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ARTrackBar.Value = 9
        '
        'ARDisplayLabel
        '
        Me.ARDisplayLabel.AutoSize = True
        Me.ARDisplayLabel.Location = New System.Drawing.Point(202, 104)
        Me.ARDisplayLabel.Name = "ARDisplayLabel"
        Me.ARDisplayLabel.Size = New System.Drawing.Size(13, 13)
        Me.ARDisplayLabel.TabIndex = 8
        Me.ARDisplayLabel.Text = "9"
        Me.ARDisplayLabel.Visible = False
        '
        'CSDisplayLabel
        '
        Me.CSDisplayLabel.AutoSize = True
        Me.CSDisplayLabel.Location = New System.Drawing.Point(203, 148)
        Me.CSDisplayLabel.Name = "CSDisplayLabel"
        Me.CSDisplayLabel.Size = New System.Drawing.Size(13, 13)
        Me.CSDisplayLabel.TabIndex = 11
        Me.CSDisplayLabel.Text = "2"
        Me.CSDisplayLabel.Visible = False
        '
        'CSTrackBar
        '
        Me.CSTrackBar.AutoSize = False
        Me.CSTrackBar.LargeChange = 1
        Me.CSTrackBar.Location = New System.Drawing.Point(99, 145)
        Me.CSTrackBar.Maximum = 7
        Me.CSTrackBar.Minimum = 2
        Me.CSTrackBar.Name = "CSTrackBar"
        Me.CSTrackBar.Size = New System.Drawing.Size(104, 21)
        Me.CSTrackBar.TabIndex = 10
        Me.CSTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.CSTrackBar.Value = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(128, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Circle Size:"
        '
        'ODDisplayLabel
        '
        Me.ODDisplayLabel.AutoSize = True
        Me.ODDisplayLabel.Location = New System.Drawing.Point(201, 195)
        Me.ODDisplayLabel.Name = "ODDisplayLabel"
        Me.ODDisplayLabel.Size = New System.Drawing.Size(13, 13)
        Me.ODDisplayLabel.TabIndex = 14
        Me.ODDisplayLabel.Text = "6"
        Me.ODDisplayLabel.Visible = False
        '
        'ODTrackBar
        '
        Me.ODTrackBar.AutoSize = False
        Me.ODTrackBar.LargeChange = 1
        Me.ODTrackBar.Location = New System.Drawing.Point(97, 192)
        Me.ODTrackBar.Maximum = 6
        Me.ODTrackBar.Minimum = 1
        Me.ODTrackBar.Name = "ODTrackBar"
        Me.ODTrackBar.Size = New System.Drawing.Size(104, 21)
        Me.ODTrackBar.TabIndex = 13
        Me.ODTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.ODTrackBar.Value = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(126, 176)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Overall Difficulty:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(142, 346)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(18, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "by"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(118, 344)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(27, 13)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "osu!"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(156, 344)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(36, 13)
        Me.LinkLabel2.TabIndex = 17
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "peppy"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(89, 280)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 13)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Background Color:"
        '
        'ColorPickPB
        '
        Me.ColorPickPB.BackColor = System.Drawing.Color.Black
        Me.ColorPickPB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorPickPB.Location = New System.Drawing.Point(186, 280)
        Me.ColorPickPB.Name = "ColorPickPB"
        Me.ColorPickPB.Size = New System.Drawing.Size(16, 16)
        Me.ColorPickPB.TabIndex = 19
        Me.ColorPickPB.TabStop = False
        '
        'BPMDisplayLabel
        '
        Me.BPMDisplayLabel.AutoSize = True
        Me.BPMDisplayLabel.Location = New System.Drawing.Point(201, 241)
        Me.BPMDisplayLabel.Name = "BPMDisplayLabel"
        Me.BPMDisplayLabel.Size = New System.Drawing.Size(25, 13)
        Me.BPMDisplayLabel.TabIndex = 22
        Me.BPMDisplayLabel.Text = "167"
        Me.BPMDisplayLabel.Visible = False
        '
        'BPMTrackBar
        '
        Me.BPMTrackBar.AutoSize = False
        Me.BPMTrackBar.LargeChange = 1
        Me.BPMTrackBar.Location = New System.Drawing.Point(97, 238)
        Me.BPMTrackBar.Maximum = 197
        Me.BPMTrackBar.Minimum = 148
        Me.BPMTrackBar.Name = "BPMTrackBar"
        Me.BPMTrackBar.Size = New System.Drawing.Size(104, 21)
        Me.BPMTrackBar.TabIndex = 21
        Me.BPMTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        Me.BPMTrackBar.Value = 167
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(126, 222)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 13)
        Me.Label20.TabIndex = 20
        Me.Label20.Text = "BPM:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(302, 367)
        Me.Controls.Add(Me.ResolutionSelectionPanel)
        Me.Controls.Add(Me.BPMDisplayLabel)
        Me.Controls.Add(Me.BPMTrackBar)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ColorPickPB)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ODDisplayLabel)
        Me.Controls.Add(Me.ODTrackBar)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ResolutionSelectLabel)
        Me.Controls.Add(Me.SkinSelectLabel)
        Me.Controls.Add(Me.CSDisplayLabel)
        Me.Controls.Add(Me.CSTrackBar)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ARDisplayLabel)
        Me.Controls.Add(Me.ARTrackBar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Gogogo)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label16)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Osu Jump Trainer"
        Me.ResolutionSelectionPanel.ResumeLayout(False)
        Me.ResolutionSelectionPanel.PerformLayout()
        CType(Me.ARTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ODTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPickPB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BPMTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ResolutionSelectionPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SkinSelectLabel As System.Windows.Forms.Label
    Friend WithEvents ResolutionSelectLabel As System.Windows.Forms.Label
    Friend WithEvents Gogogo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ARTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents ARDisplayLabel As System.Windows.Forms.Label
    Friend WithEvents CSDisplayLabel As System.Windows.Forms.Label
    Friend WithEvents CSTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents HeightTB As System.Windows.Forms.TextBox
    Friend WithEvents WidthTB As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ODDisplayLabel As System.Windows.Forms.Label
    Friend WithEvents ODTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ColorPickPB As System.Windows.Forms.PictureBox
    Friend WithEvents BPMDisplayLabel As System.Windows.Forms.Label
    Friend WithEvents BPMTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class
