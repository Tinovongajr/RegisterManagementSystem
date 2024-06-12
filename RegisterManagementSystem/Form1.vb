Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports CsvHelper
Imports CsvHelper.Configuration
Imports MaterialSkin
Imports QRCoder
Imports Xceed


Public Class Form1
    Public systemuser As user
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Dim senderpage As TabPage
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblRegisterDays3' table. You can move, or remove it, as needed.
        Me.TblRegisterDays3TableAdapter.Fill(Me.RMSDBDataSet.tblRegisterDays3)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblRegisterDays1' table. You can move, or remove it, as needed.
        Me.TblRegisterDays1TableAdapter.Fill(Me.RMSDBDataSet.tblRegisterDays1)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblRegisterDays' table. You can move, or remove it, as needed.
        'Me.TblRegisterDaysTableAdapter.Fill(Me.RMSDBDataSet.tblRegisterDays)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblRegisterQuery' table. You can move, or remove it, as needed.
        Me.TblRegisterQueryTableAdapter.Fill(Me.RMSDBDataSet.tblRegisterQuery)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblRegister' table. You can move, or remove it, as needed.
        Me.TblRegisterTableAdapter.Fill(Me.RMSDBDataSet.tblRegister)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblStudents' table. You can move, or remove it, as needed.
        'Me.TblStudentsTableAdapter.Fill(Me.RMSDBDataSet.tblStudents)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblStudentsSubjects' table. You can move, or remove it, as needed.
        Me.TblStudentsSubjectsTableAdapter.Fill(Me.RMSDBDataSet.tblStudentsSubjects)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblSubjects' table. You can move, or remove it, as needed.
        Me.TblSubjectsTableAdapter.Fill(Me.RMSDBDataSet.tblSubjects)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblTeachers' table. You can move, or remove it, as needed.
        Me.TblTeachersTableAdapter.Fill(Me.RMSDBDataSet.tblTeachers)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblDays' table. You can move, or remove it, as needed.
        Me.TblDaysTableAdapter.Fill(Me.RMSDBDataSet.tblDays)
        ''TODO: This line of code loads data into the 'RMSDBDataSet.tblSubjects' table. You can move, or remove it, as needed.
        'Me.TblSubjectsTableAdapter.Fill(Me.RMSDBDataSet.tblSubjects)
        ''TODO: This line of code loads data into the 'RMSDBDataSet.tblRegister' table. You can move, or remove it, as needed.
        'Me.TblRegisterTableAdapter.Fill(Me.RMSDBDataSet.tblRegister)
        ''TODO: This line of code loads data into the 'RMSDBDataSet.tblStudents' table. You can move, or remove it, as needed.
        'Me.TblStudentsTableAdapter.Fill(Me.RMSDBDataSet.tblStudents)

        MaterialCard10.Padding = New Padding(0)


        'If dt.Rows.Count > 0 Then
        '    My.Settings.System_UserID = dt.Rows(0).Item(0)
        'End If
        'My.Settings.Registerinit = 1
        'My.Settings.Save()
        'MsgBox(My.Settings.System_UserID)

        tblstudentsnav = New Custom_Navigator(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents")
        If Me.RMSDBDataSet.tblTeachers.Rows.Count > 0 Then
            systemuser = New user
            systemuser.loginUser(My.Settings.System_UserID)
            'If IsNothing(systemuser.Dp) Then
            '    RoundPicturebox6.Image = Image.FromStream(GenerateRactangle(systemuser.Name, systemuser.Second_name))

            'Else
            '    RoundPicturebox6.Image = systemuser.Dp
            'End If
            'PictureBox6.Image = RoundPicturebox6.Image

            Label92.Text = systemuser.UserNme
            Label92.Tag = systemuser.UserPassword
            Timer1.Enabled = True
            Dim myrow = tblstudentsnav.GetRecord(0)
            currentrecord = 1
            'With myrow
            '    'Usercontrol21.Texts = .Item("Student_Name")
            '    'Usercontrol22.Texts = .Item("Student_Surname")
            '    'Usercontrol23.Texts = .Item("Home_Address")
            '    'Usercontrol29.Texts = .Item("Phone_Number")
            '    'Usercontrol210.Texts = .Item("ID")
            '    'Label21.Text = .Item("StudentName")
            '    Dim name(1) As String
            '    If Label21.Text <> "" Then
            '        name = Label21.Text.Split(" ")
            '        If name(1) <> Nothing Then
            '            RoundPicturebox1.Image = Image.FromStream(GenerateRactangle(name(0), name(1)))
            '        End If
            '    End If
            '    Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT Subject_Name FROM tblStudentsSubjects WHERE StudentID = " & Val(Usercontrol210.TextBox1.Text))
            '    Dim subjects As String = ""
            '    If dt.Rows.Count > 0 Then
            '        For Each i As DataRow In dt.Rows
            '            Dim v As Integer = i.Item("Subject_Name")
            '            Dim result() As DataRow = Me.RMSDBDataSet.tblSubjects.Select("ID = " & v)
            '            subjects &= result(0).Item("Subject").ToString & vbNewLine

            '            'subjects &= dtr(0(0)
            '        Next
            '        'Usercontrol24.TextBox1.Text = subjects
            '    End If
            'End With
        Else
            ' MsgBox("Signup required")
            MaterialTabControl1.SelectedTab = TabPage21
            My.Settings.Registerinit = 0
            My.Settings.Save()
        End If

        CustomButton18.Text = Now.ToShortDateString

        '  MaterialTabControl1.SelectedTab = TabPage33





        'teacher




    End Sub
    Dim tblstudentsnav As Custom_Navigator
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Static tick As Integer = 0
        tick += 1
        If tick < 3 Then
        Else


            MaterialTabControl1.SelectedTab = TabPage3
            Timer1.Stop()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MaterialTabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        MaterialTabControl1.SelectedTab = TabPage4
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TblStudentsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TblStudentsBindingSource.EndEdit()
        '  Me.TableAdapterManager.UpdateAll(Me.RMSDBDataSet)

    End Sub

    Private Sub MaterialCard4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MaterialTabControl2.SelectedTab = TabPage5
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MaterialTabControl2.SelectedTab = TabPage6

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If My.Settings.Registerinit > 0 Then
            Dim row = Me.RMSDBDataSet.tblDays.Select(" ID = " & My.Settings.TermID + 1)
            If DateDiff(DateInterval.Day, row(0).Item("Ends"), Now) <= 0 Then
                MaterialTabControl3.SelectedTab = TabPage11
            Else
                MaterialTabControl3.SelectedTab = TabPage20
            End If

        Else

            MaterialTabControl3.SelectedTab = TabPage20

        End If
        MaterialTabControl2.SelectedTab = TabPage8
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MaterialTabControl2.SelectedTab = TabPage9
    End Sub



    Private Sub CustomButton30_Click(sender As Object, e As EventArgs) Handles CustomButton30.Click
        MaterialTabControl2.SelectedTab = TabPage6
        Me.TblStudentsBindingSource7.EndEdit()
        Me.TblStudentsTableAdapter.Update(Me.RMSDBDataSet.tblStudents)
    End Sub

    Private Sub CustomButton40_Click(sender As Object, e As EventArgs) Handles CustomButton40.Click
        Dim res As String = Label29.Tag
        If Label29.Tag = "Normal" Then
            MaterialTabControl2.SelectedTab = TabPage6
        ElseIf Label29.Tag = "Home" Then
            MaterialTabControl2.SelectedTab = TabPage5
            Label29.Text = "List of all students"
            Label29.Tag = "Normal"
            loadallsstudents()
            CustomButton6.Text = ListView3.Items.Count
            CustomButton7.Text = Label77.Tag
            CustomButton8.Text = Label93.Tag

        End If

    End Sub

    Private Sub CustomButton17_Click(sender As Object, e As EventArgs)
        MaterialTabControl2.SelectedTab = TabPage10
    End Sub

    Private Sub CustomButton41_Click(sender As Object, e As EventArgs) Handles CustomButton41.Click
        If Search.ShowDialog() = DialogResult.OK Then
            Me.TblStudentsBindingSource9.Position = Search.ID
        End If
        'MaterialTabControl2.SelectedTab = TabPage7
    End Sub

    Private Sub CustomButton10_Click(sender As Object, e As EventArgs)
        'MaterialCard3.Dock = DockStyle.Fill
        'FlowLayoutPanel1.Size = New Size(272, 301)
        'CustomButton10.Hide()


        'DataGridView1.Show()
        'DataGridView1.BringToFront()
        'DataGridView1.Size = New Size(430, 347)
        'DataGridView1.Location = New Point(314, 90)
        'CustomButton42.Show()
        'CustomButton42.BringToFront()
        'Label20.Location = New Point(31, 44)
    End Sub

    Private Sub CustomButton42_Click(sender As Object, e As EventArgs)
        'MaterialCard3.Dock = DockStyle.None
        'FlowLayoutPanel1.Size = New Size(509, 107)
        'CustomButton10.Show()
        'Label20.Location = New Point(31, 14)
        'DataGridView1.Hide()
        'DataGridView1.SendToBack()
        'DataGridView1.Size = New Size(10, 10)
        'DataGridView1.Location = New Point(314, 90)
        'CustomButton42.Hide()
        'CustomButton42.SendToBack()

    End Sub

    Private Sub CustomButton12_Click(sender As Object, e As EventArgs)
        MaterialTabControl1.SelectedTab = TabPage4
        'systemuser = New user()
        'systemuser.loginUser(Usercontrol215.TextBox1.Text, Usercontrol217.TextBox1.Text)
        'Getstarted(systemuser)
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage13_Click(sender As Object, e As EventArgs)

    End Sub
    Dim selectedbtn As CustomButton
    Private Sub Btn_Click(sender As Object, e As EventArgs)
        'The code below allows a context menu strip to show up at click position on the button 
        selectedbtn = sender
        ContextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y)
    End Sub


    Private Sub CustomButton37_Click(sender As Object, e As EventArgs)
        MaterialTabControl2.SelectedTab = TabPage6
    End Sub



    Private Sub CustomButton21_Click(sender As Object, e As EventArgs)
        MaterialTabControl2.SelectedTab = TabPage7 'Student's records in detail
    End Sub

    Private Sub CustomButton49_Click(sender As Object, e As EventArgs)
        MaterialTabControl2.SelectedTab = TabPage6
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Public Function GenerateRactangle(ByVal firstName As String, ByVal lastName As String) As MemoryStream
        Dim avatarString = String.Format("{0}{1}", firstName(0), lastName(0)).ToUpper()
        Dim randomIndex = New Random().[Next](0, _BackgroundColours.Count - 1)
        Dim bgColour = _BackgroundColours(randomIndex)
        Dim bmp = New Bitmap(192, 192)
        Dim sf = New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        Dim font = New Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim graphic = Graphics.FromImage(bmp)
        graphic.Clear(CType(New ColorConverter().ConvertFromString("#" & bgColour), Color))
        graphic.SmoothingMode = SmoothingMode.AntiAlias
        graphic.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        graphic.DrawString(avatarString, font, New SolidBrush(Color.WhiteSmoke), New RectangleF(0, 0, 192, 192), sf)
        graphic.Flush()
        Dim ms = New MemoryStream()
        bmp.Save(ms, ImageFormat.Png)
        Return ms
    End Function

    Private _BackgroundColours As List(Of String) = New List(Of String) From {
    "339966",
    "3366CC",
    "CC33FF",
    "FF5050"
}
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text <> "" Then
            Dim a() As DataRow = Me.RMSDBDataSet.tblStudentsSubjects.Select("Subject_Name = " & ComboBox2.SelectedValue)

            Dim male, female As Integer
            male = 0
            female = 0

            ListView2.Items.Clear()
            For Each i As DataRow In a

                Dim dts = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents WHERE ID = " & i.Item("StudentID")) 'Me.RMSDBDataSet.tblStudents.Select("ID = " & i.Item("StudentID"))
                For j = 0 To dts.Rows.Count - 1
                    Dim lst(6) As String
                    lst(0) = dts.Rows(j).Item("Student_Name")
                    lst(1) = dts.Rows(j).Item("Student_Surname")
                    lst(2) = dts.Rows(j).Item("gender")
                    lst(3) = dts.Rows(j).Item("Class")
                    lst(4) = dts.Rows(j).Item("DOB")
                    lst(5) = dts.Rows(j).Item("Phone_Number")
                    Dim list As ListViewItem = New ListViewItem(lst)
                    ListView2.Items.Add(list)
                    If dts.Rows(j).Item("gender") = "Male" Then
                        male += 1
                    ElseIf dts.Rows(j).Item("gender") = "Female" Then
                        female += 1
                    End If
                Next
            Next
            CustomButton52.Text = "Total Students: " & ListView2.Items.Count
            CustomButton13.Text = "Girls: " & female
            CustomButton25.Text = "Boys: " & male
        End If
    End Sub

    Private Sub CustomButton36_Click(sender As Object, e As EventArgs) Handles CustomButton36.Click
        CustomButton36.Hide()
        MaterialTabControl3.SelectedTab = TabPage11
        Label27.Hide()
        Label32.Show()
    End Sub

    Private Sub CustomButton32_Click(sender As Object, e As EventArgs) Handles CustomButton32.Click


        MaterialTabControl2.SelectedTab = TabPage24

    End Sub

    Private Sub CustomButton33_Click(sender As Object, e As EventArgs) Handles CustomButton33.Click
        Label32.Hide()
        Label27.Show()
        Label27.Text = "Class attendance record"
        MaterialTabControl3.SelectedTab = TabPage12
        CustomButton36.Show()
    End Sub

    Private Sub CustomButton62_Click(sender As Object, e As EventArgs) Handles CustomButton62.Click
        Label32.Hide()
        Label27.Show()
        Label27.Text = "Student attendance record"
        MaterialTabControl3.SelectedTab = TabPage15
        CustomButton36.Show()
    End Sub

    Private Sub CustomButton43_Click(sender As Object, e As EventArgs) Handles CustomButton43.Click
        If CheckBox1.CheckState = CheckState.Checked Then
            If Usercontrol221.TextBox1.Text = Usercontrol218.TextBox1.Text Then

                Dim prefix As String
                If gender = "Male" Then
                    prefix = "Mr"
                Else
                    prefix = "Mrs/Miss"
                End If

                systemuser = New user(prefix & " " & Usercontrol220.TextBox1.Text, Usercontrol219.TextBox1.Text, Usercontrol220.TextBox1.Text, Usercontrol221.TextBox1.Text, Usercontrol222.TextBox1.Text, gender, bitmage, Usercontrol224.TextBox1.Text, Usercontrol217.TextBox1.Text, Usercontrol238.TextBox1.Text, True)
                Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT ID FROM tblTeachers WHERE [Username] = '" & prefix & " " & Usercontrol220.TextBox1.Text & "'")
                If dt.Rows.Count > 0 Then
                    My.Settings.System_UserID = dt.Rows(0).Item(0)
                End If
                My.Settings.Save()
                Usercontrol241.Focus()
                MaterialTabControl1.SelectedTab = TabPage22

            Else
                MsgBox("Password mismatch!! Try again")
            End If
        End If


    End Sub

    Private Sub CustomButton55_Click(sender As Object, e As EventArgs) Handles CustomButton55.Click
        MaterialTabControl1.SelectedTab = TabPage18
    End Sub


    Private Sub CustomButton57_Click(sender As Object, e As EventArgs) Handles CustomButton57.Click
        MaterialTabControl1.SelectedTab = TabPage17

    End Sub

    Private Sub CustomButton64_Click(sender As Object, e As EventArgs) Handles CustomButton64.Click
        Usercontrol217.Focus()
        MaterialTabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub CustomButton58_Click(sender As Object, e As EventArgs)
        '    Usercontrol215.Focus()
        MaterialTabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub CustomButton51_Click(sender As Object, e As EventArgs) Handles CustomButton51.Click
        MaterialTabControl2.SelectedTab = TabPage30
    End Sub
    Public Function ReadFromDatabase(ByVal DBconnectionString As String, ByVal SQL As String) As DataTable
        Dim dtreturn As DataTable = New DataTable
        Try
            'Open connection using connection string 
            Using conn As New OleDb.OleDbConnection(DBconnectionString)
                conn.Open()
                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    Dim da As New OleDb.OleDbDataAdapter(cmd)
                    da.Fill(dtreturn)
                End Using
            End Using
            Return dtreturn
        Catch ex As Exception

        End Try
    End Function
    Private Sub TabPage7_Click(sender As Object, e As EventArgs) Handles TabPage7.Click

    End Sub
    Dim bitmage As Byte()
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        PictureBox3.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        PictureBox3.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                PictureBox3.Image = bmpImage
            End If

            Try
                Dim ms As New System.IO.MemoryStream
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                bitmage = ms.ToArray()
                ms.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If

    End Sub
    Dim gender As String
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            gender = "Female"
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            gender = "Male"
        End If
    End Sub

    Private Sub CustomButton54_Click(sender As Object, e As EventArgs) Handles CustomButton54.Click
        If Not (FlowLayoutPanel2.Controls.Count <= 0) Then
            Dim a As List(Of Integer) = New List(Of Integer)
            For i = 0 To FlowLayoutPanel2.Controls.Count - 1
                Dim btn As CustomButton = FlowLayoutPanel2.Controls(i)
                a.Add(btn.Tag)
            Next

            If RoundPicturebox5.Tag = "Unchanged" Then
                RoundPicturebox5.Image = New Bitmap(GenerateRactangle(TextBox21.Text, TextBox23.Text))
            End If

            dp = New MemoryStream
            RoundPicturebox5.Image.Save(dp, ImageFormat.Png)

            RoundPicturebox5.Border_Color = Color.White
            RoundPicturebox5.Border_Color2 = Color.White
            RoundPicturebox5.SizeMode = PictureBoxSizeMode.CenterImage

            Dim pay_load As PayloadGenerator.PhoneNumber = New PayloadGenerator.PhoneNumber(TextBox24.Text)
            Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
            Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode(pay_load, QRCodeGenerator.ECCLevel.Q)
            Dim QRCode_ As QRCode = New QRCode(qrcode_data)

            Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, True)

            dpqr = New MemoryStream

            qrcodeimage.Save(dpqr, System.Drawing.Imaging.ImageFormat.Jpeg)

            systemuser.addstudent(My.Settings.RMSDBConnectionString, Usercontrol241.TextBox1.Text, Usercontrol242.TextBox1.Text, Usercontrol243.TextBox1.Text, Usercontrol240.TextBox1.Text, CustomButton54.Tag, a, DateTimePicker1.Value, dp, gndr, Usercontrol239.TextBox1.Text, dpqr)

            TextBox21.Clear()
            TextBox23.Clear()
            TextBox22.Clear()
            TextBox25.Clear()
            TextBox24.Clear()
            RoundPicturebox5.Image = My.Resources.contacts_32px
            FlowLayoutPanel2.Controls.Clear()
            RoundPicturebox5.Tag = "Unchanged"
            Me.Invalidate()

        End If
    End Sub



    Private Sub CustomButton11_Click(sender As Object, e As EventArgs)
        Dim clas = Usercontrol255.TextBox1.Text
        CustomButton54.Tag = clas
        Label57.Text = "Add students to " & clas
        Label59.Text = "Students in " & clas
        Label30.Text = clas

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Usercontrol223.TextBox1.Clear()
        Usercontrol223.TextBox1.Text = DateTimePicker1.Value
    End Sub
    Dim dp As MemoryStream
    Dim dpqr As MemoryStream
    Private Sub Usercontrol242_Leave(sender As Object, e As EventArgs) Handles Usercontrol242.Leave
        dp = GenerateRactangle(Usercontrol241.TextBox1.Text, Usercontrol242.TextBox1.Text)
        RoundPicturebox5.Image = Image.FromStream(dp)
        RoundPicturebox5.Border_Color = Color.White
        RoundPicturebox5.Border_Color2 = Color.White
        RoundPicturebox5.SizeMode = PictureBoxSizeMode.CenterImage
        Label58.Text = Usercontrol241.TextBox1.Text & " " & Usercontrol242.TextBox1.Text
    End Sub

    Private Sub CustomButton14_Click(sender As Object, e As EventArgs) Handles CustomButton14.Click
        '  Usercontrol215.Focus()
        Me.Invalidate()
        ' systemuser = New user
        systemuser.loginUser(My.Settings.System_UserID)
        If IsNothing(systemuser.Dp) Then
            RoundPicturebox6.Image = Image.FromStream(GenerateRactangle(systemuser.Name, systemuser.Second_name))

        Else
            RoundPicturebox6.Image = systemuser.Dp
        End If
        PictureBox6.Image = RoundPicturebox6.Image

        Label92.Text = systemuser.UserNme
        Label92.Tag = systemuser.UserPassword

        MaterialTabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub CustomButton18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CustomButton18_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub TabPage17_Click(sender As Object, e As EventArgs) Handles TabPage17.Click

    End Sub

    Private Sub CustomButton22_Click(sender As Object, e As EventArgs) Handles CustomButton22.Click
        If Label30.Text <> "" Then
            Label57.Text = "Add students to " & Label30.Text
            Label59.Text = "Students in " & Label30.Text
            CustomButton54.Tag = Label30.Text
            MaterialTabControl1.SelectedTab = TabPage17
        End If

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub
    Dim listofbtn As List(Of Controls.MaterialButton)
    Dim shortlistofbtn As List(Of Controls.MaterialButton)
    Public Function Getstarted(sysuser As user)
        listofbtn = New List(Of Controls.MaterialButton)
        shortlistofbtn = New List(Of Controls.MaterialButton)
        Me.TblStudentsTableAdapter.ClearBeforeFill = True
        Me.TblStudentsTableAdapter.Fill(Me.RMSDBDataSet.tblStudents)
        Dim myclas As String
        Dim genderprefix As String
        If sysuser.userGender = "Male" Then
            genderprefix = "Mr"
        Else
            genderprefix = "Miss/Mrs"
        End If

        Label18.Text = "Hello , " & vbNewLine & genderprefix & " " & systemuser.Second_name
        Label12.Text = genderprefix & " " & systemuser.Name(0).ToString.ToUpper & ". " & systemuser.Second_name
        Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents WHERE [Form_Teacher] = '" & sysuser.Name & sysuser.Second_name & "'")
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            myclas = dr.Item("Class")
        End If
        Label15.Text = myclas
        Label78.Text = sysuser.schoolname
        PictureBox8.Image = sysuser.school_logo
        Label48.Text = myclas
        Label76.Text = dt.Rows.Count
        RoundPicturebox6.Image = sysuser.Dp
        Dim result() As DataRow = dt.Select("gender = 'Male'")
        'result.length will give the total number of male students
        Label71.Text = result.Length

        FlowLayoutPanel4.Controls.Clear()
        FlowLayoutPanel3.Controls.Clear()
        Dim result2() As DataRow = dt.Select("gender = 'Female'")
        'result.length will give the total number of female students
        Label25.Text = result2.Length

        Dim tbl As DataTable = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblSubjects")
        Dim session As Integer = 0
        For j = 0 To tbl.Rows.Count - 1
            Dim btntxt As String
            Dim a() As DataRow = Me.RMSDBDataSet.tblStudentsSubjects.Select("Subject_Name = " & j)
            btntxt = tbl.Rows.Item(j).Item("Subject").ToString '& " (" & a.Length & ")"

            Dim btn As MaterialSkin.Controls.MaterialButton = New Controls.MaterialButton
            btn.UseAccentColor = False
            btn.AutoSize = True
            btn.HighEmphasis = True
            'btn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            btn.Text = btntxt
            btn.Tag = tbl.Rows.Item(j).Item("ID")

            AddHandler btn.Click, AddressOf Btn_clik
            listofbtn.Add(btn)
            Static count As Integer = 0
            count += 1
            If count <= 7 Then
                shortlistofbtn.Add(btn)
            End If
            ' FlowLayoutPanel3.Controls.Add(btn)
            '  MsgBox(FlowLayoutPanel3.Controls.Count)
        Next
        'MsgBox(listofbtn.Count)


        Dim bt As MaterialSkin.Controls.MaterialButton = New Controls.MaterialButton
        bt.UseAccentColor = False
        bt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text
        bt.AutoSize = True
        bt.Text = "View All"
        AddHandler bt.Click, AddressOf Viewallbtn_Clicked
        shortlistofbtn.Add(bt)

        For f = 0 To shortlistofbtn.Count - 1
            FlowLayoutPanel4.Controls.Add(shortlistofbtn.Item(f))
        Next
        For j = 0 To Me.RMSDBDataSet.tblSubjects.Rows.Count - 1
            Dim b() As DataRow = Me.RMSDBDataSet.tblStudentsSubjects.Select("Subject_Name = " & j)
            Dim btntxte = Me.RMSDBDataSet.tblSubjects.Rows.Item(j).Item("Subject").ToString '& " (" & b.Length & ")"

            Dim btnz As MaterialSkin.Controls.MaterialButton = New Controls.MaterialButton
            btnz.UseAccentColor = False
            btnz.AutoSize = True
            btnz.HighEmphasis = True
            'btn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            btnz.Text = btntxte
            btnz.Tag = tbl.Rows.Item(j).Item("ID")

            AddHandler btnz.Click, AddressOf Btn_clik
            FlowLayoutPanel3.Controls.Add(btnz)
        Next
        CustomButton20.Text = "Total number of subjects = " & Me.RMSDBDataSet.tblSubjects.Rows.Count

        loadallsstudents()
        Label46.Text = sysuser.school_department
        Label47.Text = sysuser.subjects
        CustomButton7.Text = result.Length
        CustomButton8.Text = result2.Length
        Label77.Tag = result.Length
        Label93.Tag = result2.Length

        'For Each roe As DataRow In Me.RMSDBDataSet.tblRegister
        '    Dim lst(5) As String
        '    With roe
        '        lst(0) = CDate(.Item("RegisterDate")).Year
        '        Dim stud = (Me.RMSDBDataSet.tblStudents.Select("ID = " & .Item("StudentID")))
        '        lst(1) = stud(0).Item("StudentName").ToString

        '        '#############################################################
        '        Dim dayspresent As Integer = 0
        '        Dim daysabsent As Integer = 0
        '        Dim row2() = Me.RMSDBDataSet.tblRegister.Select("StudentID = " & .Item("StudentID"))
        '        For Each i As DataRow In row2

        '            If i.Item("Mark_Register = Present") Then
        '                dayspresent += 1
        '            ElseIf i.Item("Mark_Register = Absent") Then
        '                daysabsent += 1
        '            End If

        '        Next
        '        '#############################################################

        '        lst(2) = dayspresent
        '        lst(3) = daysabsent

        '        '#############################################################

        '        Dim term = Me.RMSDBDataSet.tblDays.Select("ID = ")
        '    End With
        'Next

        Dim lst(6) As String
        ListView6.Items.Clear()



        For Each i As DataRow In Me.RMSDBDataSet.tblDays
            With i
                lst(0) = CDate(.Item("School_Year").ToString).Year
                lst(1) = .Item("Term").ToString
                '#####################################################################

                For Each k As DataRow In Me.RMSDBDataSet.tblStudents
                    lst(2) = k.Item("StudentName")
                    Dim dayspresent As Integer = 0
                    Dim daysabsent As Integer = 0
                    Dim row2() = Me.RMSDBDataSet.tblRegister.Select("StudentID = " & k.Item("ID"))

                    For j = 0 To row2.Length - 1
                        If Val(row2(j).Item("TermID").ToString) + 1 = i.Item("ID") Then
                            If row2(j).Item("Mark_Register").ToString = "Present" Then
                                dayspresent += 1
                            ElseIf row2(j).Item("Mark_Register").ToString = "Absent" Then
                                daysabsent += 1
                            End If
                        End If
                    Next

                    lst(3) = dayspresent
                    lst(4) = daysabsent
                    lst(5) = i.Item("Total_Days").ToString
                    lst(6) = i.Item("Status")

                    Dim lstv As ListViewItem = New ListViewItem(lst)

                    ListView6.Items.Add(lstv)

                Next
                '#####################################################################
            End With
        Next

        If Me.RMSDBDataSet.tblRegister.Rows.Count > 0 Then
            Dim row = Me.RMSDBDataSet.tblRegister.Rows
            Dim ro = row(Me.RMSDBDataSet.tblRegister.Rows.Count - 1)
            If DateDiff(DateInterval.Day, ro("RegisterDate"), Now) = 0 Then
                CustomButton1.Text = "Register already marked for today " & Now.ToShortDateString
                CustomButton32.Text = "Register already marked for today " & Now.ToShortDateString
                CustomButton1.Enabled = False
                CustomButton32.Enabled = False
            End If
        End If
        ' Find the last date entered and see if it is today if today then block the following buttons custombutton1.text = "Register already marked " change colour to  green       



    End Function
    Private Sub Viewallbtn_Clicked(sender As Object, e As EventArgs)
        MaterialTabControl2.SelectedTab = TabPage13
    End Sub
    Dim gndr As String
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            gndr = "Male"
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            gndr = "Female"
        End If
    End Sub
    Private Sub Btn_clik(sender As Object, e As EventArgs)
        Dim sd = Me.RMSDBDataSet.tblStudentsSubjects.Select("Subject_Name = " & sender.tag)
        ListView3.Items.Clear()
        Dim dts As DataTable = New DataTable
        Static count As Integer
        count = 0


        For Each i As DataRow In sd
            dts = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents WHERE ID = " & i.Item("StudentID")) 'Me.RMSDBDataSet.tblStudents.Select("ID = " & i.Item("StudentID"))
            For j = 0 To dts.Rows.Count - 1
                Dim lst(7) As String

                lst(0) = dts.Rows(j).Item("Student_Name")
                lst(1) = dts.Rows(j).Item("Student_Surname")
                lst(2) = dts.Rows(j).Item("gender")
                lst(3) = Label48.Text
                lst(4) = dts.Rows(j).Item("DOB")
                lst(5) = dts.Rows(j).Item("Parent_Guardian")
                lst(6) = dts.Rows(j).Item("Phone_Number")
                lst(7) = DateDiff(DateInterval.Year, CDate(dts.Rows(j).Item("DOB")), Now.Date)
                If count = 0 Then
                    '  clas = dts.Rows(j).Item("Class")
                    count += 1
                End If
                Dim list As ListViewItem = New ListViewItem(lst)
                ListView3.Items.Add(list)
            Next
        Next
        CustomButton6.Text = ListView3.Items.Count
        Dim male, female As Integer
        male = 0
        female = 0
        Dim clasx As String
        For Each i As ListViewItem In ListView3.Items
            If i.SubItems(2).Text = ("Male") Then
                male += 1
            ElseIf i.SubItems(2).Text = ("Female") Then
                female += 1
            End If

        Next
        CustomButton7.Text = male
        CustomButton8.Text = female


        'ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents WHERE (tblStudents.ID = tblStudentsSubjects.Student) AND (tblStudentsSubjects.Subject = " & sender.tag & ")")
        'Add code here to use the table to display the list of students doing that subject *probably a listview would*
        MaterialTabControl2.SelectedTab = TabPage10
        'TblStudentsDataGridView.Rows.Clear()

        'TblStudentsDataGridView.Rows.Add(dt.Rows)
        Dim clas() = Me.RMSDBDataSet.tblSubjects.Select("ID = " & sender.tag)

        Label29.Text = "List of all " & clas(0).Item("Subject").ToString & " students"
        Label29.Tag = "Home"

    End Sub

    Public Sub loadallsstudents()
        ListView3.Items.Clear()
        CheckedListBox1.Items.Clear()
        CheckedListBox3.Items.Clear()
        Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents")
        For j = 0 To dt.Rows.Count - 1
            Dim lst(7) As String

            lst(0) = dt.Rows(j).Item("Student_Name")
            lst(1) = dt.Rows(j).Item("Student_Surname")
            lst(2) = dt.Rows(j).Item("gender")
            lst(3) = dt.Rows(j).Item("Class")
            lst(4) = dt.Rows(j).Item("DOB")
            lst(5) = dt.Rows(j).Item("Parent_Guardian")
            lst(6) = dt.Rows(j).Item("Phone_Number")
            lst(7) = DateDiff(DateInterval.Year, CDate(dt.Rows(j).Item("DOB")), Now.Date)
            CheckedListBox1.Items.Add(dt.Rows(j).Item("StudentName"), False)
            CheckedListBox3.Items.Add(dt.Rows(j).Item("StudentName"), False)
            Dim list As ListViewItem = New ListViewItem(lst)
            ListView3.Items.Add(list)

        Next
        CustomButton6.Text = dt.Rows.Count

    End Sub


    Private Sub _TextChangd(sender As Object, e As EventArgs)
        'Usercontrol21.Texts = TextBox1.Text
        'Usercontrol22.Texts = TextBox3.Text
        'Usercontrol23.Texts = TextBox4.Text
        'Usercontrol29.Texts = TextBox5.Text
        'Usercontrol210.Texts = TextBox6.Text
        'Dim picturedata As Byte()
        ''picturedata = DirectCast(CType(TextBox2.Tag, Object), Byte())

        ''Dim stream As New IO.MemoryStream(picturedata)
        'RoundPicturebox1.Image = Image.FromStream(GenerateRactangle(TextBox1.Text, TextBox3.Text))
        'Label21.Text = TextBox1.Text & " " & TextBox3.Text
        'If Val(TextBox1.Text) > 0 Then

        '    'Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT Subject_Name FROM tblStudentsSubjects WHERE StudentID = " & Val(TextBox1.Text))
        '    'Dim subjects As String = ""
        '    'If dt.Rows.Count > 0 Then
        '    '    For Each i As DataRow In dt.Rows
        '    '        Dim v As Integer = i.Item("Subject_Name")
        '    '        Dim result() As DataRow = Me.RMSDBDataSet.tblSubjects.Select("ID = " & v)
        '    '        subjects &= result(0).Item("Subject").ToString & vbNewLine

        '    '        'subjects &= dtr(0(0)
        '    '    Next
        '    '    Usercontrol24.TextBox1.Text = subjects
        '    'End If

        'End If
        'RoundPicturebox1.Image = Image.FromStream(GenerateRactangle(TextBox1.Text, TextBox3.Text))

        ' RoundPicturebox1.Image = Image.FromStream(GenerateRactangle(TextBox1.Text, TextBox3.Text))
        'Timer2.Enabled = True
    End Sub

    Private Sub CustomButton16_Click(sender As Object, e As EventArgs) Handles CustomButton16.Click
        Me.TblStudentsBindingSource9.MoveNext()


    End Sub

    Dim currentrecord As Integer
    Private Sub CustomButton15_Click(sender As Object, e As EventArgs) Handles CustomButton15.Click

        Me.TblStudentsBindingSource9.MovePrevious()
    End Sub

    Private Sub RoundPicturebox6_Click(sender As Object, e As EventArgs) Handles RoundPicturebox6.Click

    End Sub

    Private Sub CustomButton3_Click(sender As Object, e As EventArgs)
        If Label92.Tag = Usercontrol216.TextBox1.Text Then
            Getstarted(systemuser)
            MaterialTabControl1.SelectedTab = TabPage4
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Static tick As Integer = 0
        tick += 1
        If tick <= 1 Then
        Else
            tick = 0

            'After delay do this
            ' RoundPicturebox1.Image = Image.FromStream(GenerateRactangle(TextBox1.Text, TextBox3.Text))
            ' Label21.Text = TextBox1.Text & " " & TextBox3.Text
            'Usercontrol21.TextBox1.Text = TextBox1.Text
            'Usercontrol22.TextBox1.Text = TextBox3.Text
            'Usercontrol23.TextBox1.Text = TextBox4.Text
            'Usercontrol29.TextBox1.Text = TextBox5.Text
            'Usercontrol210.TextBox1.Text = TextBox6.Text
            '    Dim picturedata As Byte()
            '    picturedata = DirectCast(CType(TextBox2.Tag, Object), Byte())

            '    Dim stream As New IO.MemoryStream(picturedata)
            '    RoundPicturebox1.Image = Image.FromStream(stream)
            '    Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT Subject FROM tblStudentsSubjects WHERE StudentID = " & Val(TextBox6.Text))
            '    Dim subjects As String = ""
            'If dt.Rows.Count > 0 Then
            '    For Each i As DataRow In dt.Rows
            '        Dim v As Integer = i.Item("Subject")
            '            Dim result() As DataRow = Me.RMSDBDataSet.tblSubjects.Select("ID = " & v).GetValue(0) & vbNewLine
            '            subjects &= result(0).Item("Subject")
            '            'subjects &= dtr(0(0)
            '        Next
            '    Usercontrol24.TextBox1.Text = subjects
            'End If

            Timer2.Enabled = False
        End If
    End Sub

    Public Sub Usercontrol2KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Label92.Tag = Usercontrol216.TextBox1.Text Then
                Getstarted(systemuser)
                MaterialTabControl1.SelectedTab = TabPage4
            End If
        End If
    End Sub

    Private Sub Usercontrol216_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Usercontrol216.KeyPress

    End Sub

    Private Sub CustomButton46_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Usercontrol227__TextChangedd(sender As Object, e As EventArgs)

    End Sub

    Private Sub Usercontrol216_Leave(sender As Object, e As EventArgs) Handles Usercontrol216.Leave

    End Sub

    Private Sub Usercontrol216_KeyDown(sender As Object, e As KeyEventArgs) Handles Usercontrol216.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Label92.Tag = Usercontrol216.TextBox1.Text Then
                Getstarted(systemuser)
                MaterialTabControl1.SelectedTab = TabPage4
            End If
        End If
    End Sub

    Private Sub CustomButton4_Click(sender As Object, e As EventArgs) Handles CustomButton4.Click
        If Label92.Tag = Usercontrol216.TextBox1.Text Then
            Getstarted(systemuser)
            MaterialTabControl1.SelectedTab = TabPage4
        Else
            MsgBox("Invalid credentials. Try again", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub TblRegisterDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        'Usercontrol21.DataBindings.Add()
    End Sub

    Private Sub Usercontrol23__TextChangedd(sender As Object, e As EventArgs)

    End Sub



    Private Sub Label38_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Label21_TextChanged(sender As Object, e As EventArgs) Handles Label21.TextChanged


    End Sub

    Private Sub CustomButton27_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CustomButton26_Click(sender As Object, e As EventArgs)
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateStudent's_profile.docx")

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label12.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)


        Dim dpimage = document.AddImage(GenerateRactangle(TextBox7.Text, TextBox9.Text))
        Dim profpic = dpimage.CreatePicture(90, 90)



        ms.Close()
        ms2.Close()
        document.ReplaceText("<StudentName>", Label28.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<DOB>", TextBox14.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Gender>", TextBox13.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Subs>", TextBox16.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        Dim txt = InputBox("Enter your general comment on about the student below")
        document.ReplaceText("<Comment>", txt, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Teacher’s_name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)
        document.ReplaceTextWithObject("<Profile>", profpic, False, RegexOptions.IgnoreCase)
        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)

        universalfilename = Label28.Text.Trim & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub
    Dim universaldocstream As MemoryStream
    Private Sub CustomButton24_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        MaterialTabControl2.SelectedTab = TabPage9
    End Sub





    Public Sub markregister(listofabsentees As List(Of String))
        'Try
        For Each dr As DataRow In Me.RMSDBDataSet.tblStudents
            Dim row As DataRow = Me.RMSDBDataSet.tblRegister.NewRow
            With row
                .Item("RegisterDate") = Date.Now.ToShortDateString
                .Item("StudentID") = dr.Item("ID")
                .Item("TermID") = My.Settings.TermID

                If ListBox2.Items.Count > 0 Then
                    For j = 0 To listofabsentees.Count - 1
                        If listofabsentees(j) <> "" And ListBox2.Items.Item(j) = dr.Item("StudentName") Then
                            .Item("Mark_Register") = "Absent"
                            .Item("Comment") = listofabsentees(j)
                            Exit For
                        Else
                            .Item("Mark_Register") = "Present"
                            .Item("Comment") = "N/A"
                        End If
                    Next
                Else
                    .Item("Mark_Register") = "Present"
                    .Item("Comment") = "N/A"
                End If
            End With
            Me.RMSDBDataSet.tblRegister.Rows.Add(row)
            Me.TblRegisterTableAdapter.Update(Me.RMSDBDataSet.tblRegister)


        Next
        MsgBox("Register succesfully marked for date " & Now.ToShortDateString, MsgBoxStyle.Information)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub



    'Private Sub CustomButton35_Click(sender As Object, e As EventArgs)
    '    markregister()
    'End Sub

    Private Sub CustomButton12_Click_1(sender As Object, e As EventArgs)

    End Sub





    Private Sub Label49_TextChanged(sender As Object, e As EventArgs)
        'If Label49.Text <> "" Then
        '    If IsDBNull(RoundPicturebox4.Tag) = False Then
        '        Dim i As New MemoryStream(CType(RoundPicturebox4.Tag, Byte()))
        '        RoundPicturebox4.Image = Image.FromStream(i)
        '    End If
        'End If

    End Sub



    Private Sub Usercontrol231__TextChangedd(sender As Object, e As EventArgs)

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim cntrl As FlowLayoutPanel = selectedbtn.Parent
        If MsgBox("Are you sure you want to delete/remove the subject?", MsgBoxStyle.YesNoCancel, "Remove Subject") = DialogResult.Yes Then

            cntrl.Controls.RemoveAt(cntrl.Controls.IndexOf(selectedbtn))
        End If

    End Sub

    Private Sub Usercontrol249__TextChangedd(sender As Object, e As EventArgs)

    End Sub

    Private Sub CustomButton2_Click(sender As Object, e As EventArgs) Handles CustomButton2.Click
        Static click As Integer = 0
        click += 1
        If click = 1 Then
            RoundPicturebox7.Enabled = True
            TextBox32.Enabled = True
            TextBox35.Enabled = True
            TextBox34.Enabled = True
            TextBox33.Enabled = True
            TextBox31.Enabled = True
            TextBox36.Enabled = True
            TextBox38.Enabled = True
            TextBox37.Enabled = True
            TextBox37.UseSystemPasswordChar = False

        Else

            RoundPicturebox7.Enabled = False
            TextBox32.Enabled = False
            TextBox35.Enabled = False
            TextBox34.Enabled = False
            TextBox33.Enabled = False
            TextBox31.Enabled = False
            TextBox36.Enabled = False
            TextBox38.Enabled = False
            TextBox37.Enabled = False
            TextBox37.UseSystemPasswordChar = True
            If MsgBox("Do you want to save your updates", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.TblTeachersBindingSource1.EndEdit()
                Me.TblTeachersTableAdapter.Update(Me.RMSDBDataSet.tblTeachers)
            End If
            click = 0
        End If

        '  RoundPicturebox7.DataBindings.Add("Tag", TblTeachersBindingSource1, "Profile_Picture")

    End Sub



    Private Sub CustomButton61_Click(sender As Object, e As EventArgs) Handles CustomButton61.Click
        Try
            'set a your database file
            Dim CurDir As String = System.AppDomain.CurrentDomain.BaseDirectory
            Dim FPath As String = CurDir & "\RMSDB.accdb"
            Dim restorefile As String = FPath
            'declare a variable for storing the text message.
            Dim msgText As String
            'filtering the file
            OpenFileDialog1.Filter = "Access | *.accdb"
            'open the file directory
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                'set a text message
                msgText = "Are you sure you want to restore your database? It will overwite your database since the backup have made."
                'validate if you want to restore or not
                If MessageBox.Show(msgText, "Restore", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
                    'restore your database
                    FileCopy(OpenFileDialog1.FileName, restorefile)
                    MsgBox("Database has been restored")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function GetAllControls(control As Windows.Forms.Control) As IEnumerable(Of Windows.Forms.Control)
        Dim controls = control.Controls.Cast(Of Windows.Forms.Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function
    Private Sub CustomButton60_Click(sender As Object, e As EventArgs) Handles CustomButton60.Click
        Dim CurDir As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim FPath As String = CurDir & "\SupremeSparkleDetergentsDB.accdb"
        Using saveDialog As New SaveFileDialog()
            saveDialog.CheckFileExists = False
            saveDialog.CheckPathExists = True
            saveDialog.FileName = Date.Now.ToString("yyyyMMdd") & ".accdb"
            saveDialog.Filter = "Microsoft Access Database (*.accdb)|*.accdb"
            saveDialog.RestoreDirectory = True

            If saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If File.Exists(FPath) Then 'And File.Exists(My.Settings.PdfSavefilepath) Then
                    File.Copy(Path.GetFileName(FPath), saveDialog.FileName)
                    ' File.Copy(Path.GetFileName(My.Settings.PdfSavefilepath), saveDialog.FileName)
                End If
            End If
        End Using
    End Sub

    Private Sub Usercontrol255_Enter(sender As Object, e As EventArgs) Handles Usercontrol255.Enter
        AddHandler Usercontrol255.TextBox1.TextChanged, AddressOf _TextChanged
        Label30.Show()
    End Sub
    Dim s_name As String
    Private Sub _TextChanged(sender As Object, e As EventArgs)
        Label30.Text = Usercontrol255.TextBox1.Text
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub



    Private Sub CustomButton53_Click_1(sender As Object, e As EventArgs) Handles CustomButton53.Click
        Dim myrow = Me.RMSDBDataSet.tblDays.NewRow
        Dim date1 = DateTimePicker2.Value
        Dim date2 = DateTimePicker3.Value
        With myrow
            .Item("Term") = Val(ComboBox1.Text)
            .Item("Begins") = date1
            .Item("Ends") = date2
            Dim totdays As Integer = 0

            Dim dayval As Integer = DateDiff(DateInterval.Day, date1, date2)
            For i = 1 To dayval
                Dim dateval As Date = DateAdd(DateInterval.Day, i, date1)
                If dateval.Day = Day.Saturday Or dateval.Day = Day.Sunday Then
                Else
                    totdays += 1
                End If
            Next

            .Item("Total_Days") = totdays
            .Item("School_Year") = DateTimePicker4.Value
            .Item("Status") = "Ongoing"
        End With
        Me.RMSDBDataSet.tblDays.AddtblDaysRow(myrow)
        Me.TblDaysTableAdapter.Update(Me.RMSDBDataSet.tblDays)
        MsgBox("Setup successful!!", MsgBoxStyle.Information)
        Dim j As Integer = Me.RMSDBDataSet.tblDays.Rows.IndexOf(myrow)
        My.Settings.Registerinit = 1
        My.Settings.TermID = j
        My.Settings.Save()

        Me.Invalidate()
        MaterialTabControl3.SelectedTab = TabPage11
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT Subject_Name FROM tblStudentsSubjects WHERE StudentID = " & Val(TextBox17.Text))
        Dim subjects As String = ""
        If dt.Rows.Count > 0 Then
            For Each i As DataRow In dt.Rows
                Dim v As Integer = i.Item("Subject_Name")
                Dim result() As DataRow = Me.RMSDBDataSet.tblSubjects.Select("ID = " & v)
                subjects &= result(0).Item("Subject").ToString & vbNewLine

                'subjects &= dtr(0(0)
            Next
            TextBox16.Text = subjects
        End If
    End Sub

    Private Sub ComboBox11_TextChanged(sender As Object, e As EventArgs)
        Me.TblStudentsBindingSource8.Position = Search.ID
    End Sub





    'Private Sub CustomButton29_Click(sender As Object, e As EventArgs) Handles CustomButton29.Click
    '    markregister()
    'End Sub

    Private Sub CustomButton27_Click_1(sender As Object, e As EventArgs)
        MaterialTabControl2.SelectedTab = TabPage8
        Label32.Show()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.SelectedIndex > -1 Then
            Label22.Text = ComboBox6.Text
            ListView1.Items.Clear()
            Dim row() = Me.RMSDBDataSet.tblDays.Select("Status = 'Ongoing'")
            With row(0)
                Usercontrol234.Texts = .Item("Term")
                Usercontrol235.Texts = .Item("Total_days")
                Usercontrol232.Texts = .Item("Status")
            End With
            Dim list(2) As String
            Dim dayspresent As Integer = 0
            Dim daysabsent As Integer = 0
            Dim row2() = Me.RMSDBDataSet.tblRegister.Select("StudentID = " & ComboBox6.SelectedValue)
            For Each i As DataRow In row2
                If Val(i.Item("TermID").ToString) = My.Settings.TermID Then
                    If i.Item("Mark_Register").ToString = "Present" Then
                        dayspresent += 1
                    ElseIf i.Item("Mark_Register").ToString = "Absent" Then
                        daysabsent += 1
                    End If
                    'listview data
                    list(0) = i.Item("RegisterDate")
                    list(1) = Label22.Text
                    list(2) = i.Item("Comment")

                    Dim lstrow As ListViewItem = New ListViewItem(list)

                    ListView1.Items.Add(lstrow)


                End If
            Next

            Usercontrol236.Texts = dayspresent
            Usercontrol237.Texts = daysabsent
        End If
    End Sub

    Private Sub CustomButton19_Click(sender As Object, e As EventArgs) Handles CustomButton19.Click
        MaterialTabControl2.SelectedTab = TabPage5
    End Sub

    Private Sub CustomButton3_Click_1(sender As Object, e As EventArgs)
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslistPerSubject.docx")
        Dim table = document.Tables(0)
        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        For i = 0 To ListView2.Items.Count - 1
            Dim row As Document.NET.Row = table.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append((i + 1).ToString)
                .Cells(1).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(0).Text & " " & ListView2.Items.Item(i).SubItems.Item(1).Text)
                .Cells(2).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(2).Text)
                .Cells(3).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(4).Text)
                .Cells(4).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(5).Text)
            End With
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text & " " & ComboBox2.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)




        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label15.Text & "" & ComboBox2.Text & Now.Year

        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub CustomButton5_Click(sender As Object, e As EventArgs)
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslisty.docx")
        Dim table = document.Tables(0)
        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        For i = 0 To ListView3.Items.Count - 1
            Dim row As Document.NET.Row = table.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append((i + 1).ToString)
                .Cells(1).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(0).Text & ListView3.Items.Item(i).SubItems.Item(1).Text)
                .Cells(2).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(2).Text)
                .Cells(3).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(4).Text)
                .Cells(4).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(6).Text)
                .Cells(5).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(5).Text)
            End With
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)




        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label29.Text.Trim & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub TabPage19_Click(sender As Object, e As EventArgs) Handles TabPage19.Click

    End Sub

    Private Sub CustomButton21_Click_1(sender As Object, e As EventArgs) Handles CustomButton21.Click
        MaterialTabControl2.SelectedTab = TabPage7
    End Sub

    Private Sub CustomButton17_Click_1(sender As Object, e As EventArgs) Handles CustomButton17.Click
        MaterialTabControl2.SelectedTab = TabPage10
        Label29.Tag = "Normal"
    End Sub

    Private Sub CustomButton50_Click(sender As Object, e As EventArgs) Handles CustomButton50.Click
        MaterialTabControl3.SelectedTab = TabPage23
    End Sub



    Private Sub CustomButton10_Click_1(sender As Object, e As EventArgs)
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateAttendanceRecord.docx")
        Dim table = document.Tables(0)

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)



        For i = 0 To ListView3.Items.Count - 1
            Dim row As Document.NET.Row = table.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(0).Text)
                .Cells(1).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(1).Text)
                .Cells(2).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(2).Text)
                .Cells(3).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(3).Text)
                .Cells(4).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(4).Text)
                .Cells(5).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(5).Text)
            End With
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)



        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label15.Text & "ClassAttendanceRecord" & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub
    Dim universalfilename As String
    Private Sub CustomButton42_Click_1(sender As Object, e As EventArgs) Handles CustomButton42.Click
        Dim document = Xceed.Words.NET.DocX.Load(universaldocstream)
        Dim opd As New SaveFileDialog
        opd.FileName = universalfilename & ".docx"

        Dim result = opd.ShowDialog()
        If result = DialogResult.OK Then
            document.SaveAs(Path.GetFullPath(opd.FileName))
            MsgBox("File successfully saved at location")
        End If
    End Sub

    Private Sub CustomButton31_Click(sender As Object, e As EventArgs)
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateStudent's attendance.docx")
        Dim table = document.Tables(1)
        Dim table2 = document.Tables(2)
        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        Dim rows As Document.NET.Row = table.InsertRow
        With rows
            .Cells(0).Paragraphs.First().Append(Now.Year.ToString)
            .Cells(1).Paragraphs.First().Append(Usercontrol234.TextBox1.Text)
            .Cells(2).Paragraphs.First().Append(Usercontrol236.TextBox1.Text)
            .Cells(3).Paragraphs.First().Append(Usercontrol237.TextBox1.Text)
        End With
        table.RemoveRow(2)
        For i = 0 To ListView1.Items.Count - 1
            Dim row As Document.NET.Row = table2.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append((i + 1).ToString)
                .Cells(1).Paragraphs.First().Append(ListView1.Items.Item(i).SubItems.Item(0).Text)
                .Cells(2).Paragraphs.First().Append(ListView1.Items.Item(i).SubItems.Item(2).Text)

            End With
        Next
        table2.RemoveRow(2)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<student>", Label22.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<status>", Usercontrol232.TextBox1.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<studentname>", Label22.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<term>", Usercontrol234.TextBox1.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label22.Text & "ClassAttendanceRecord" & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub Label63_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ComboBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim btn As CustomButton = New CustomButton
            btn.Size = New Size(104, 27)
            btn.Text = ComboBox7.Text
            btn.Tag = ComboBox7.SelectedValue
            btn.BackColor = Color.FromArgb(38, 50, 56)
            btn.ForeColor = Color.White
            btn.BorderRadiuses = 5
            btn.BorderSizes = 0

            FlowLayoutPanel2.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Btn_Click
        End If
    End Sub

    Private Sub MaterialButton4_Click(sender As Object, e As EventArgs) Handles MaterialButton4.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslistPerSubject.docx")
        Dim table = document.Tables(0)
        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        For i = 0 To ListView2.Items.Count - 1
            Dim row As Document.NET.Row = table.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append((i + 1).ToString)
                .Cells(1).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(0).Text & " " & ListView2.Items.Item(i).SubItems.Item(1).Text)
                .Cells(2).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(2).Text)
                .Cells(3).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(4).Text)
                .Cells(4).Paragraphs.First().Append(ListView2.Items.Item(i).SubItems.Item(5).Text)
            End With
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text & " " & ComboBox2.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)
        If Label101.Text <> "" Then
            document.ReplaceText("<Classteacher>", "Class Teacher: " & Label101.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        End If




        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label15.Text & "" & ComboBox2.Text & Now.Year

        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub MaterialButton5_Click(sender As Object, e As EventArgs) Handles MaterialButton5.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslisty.docx")
        Dim table = document.Tables(0)
        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        For i = 0 To ListView3.Items.Count - 1
            Dim row As Document.NET.Row = table.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append((i + 1).ToString)
                .Cells(1).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(0).Text & ListView3.Items.Item(i).SubItems.Item(1).Text)
                .Cells(2).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(2).Text)
                .Cells(3).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(4).Text)
                .Cells(4).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(6).Text)
                .Cells(5).Paragraphs.First().Append(ListView3.Items.Item(i).SubItems.Item(5).Text)
            End With
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)




        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)

        universalfilename = Label29.Text.Trim & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub MaterialButton6_Click(sender As Object, e As EventArgs) Handles MaterialButton6.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateStudent's attendance.docx")
        Dim table = document.Tables(1)
        Dim table2 = document.Tables(2)
        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        Dim rows As Document.NET.Row = table.InsertRow
        With rows
            .Cells(0).Paragraphs.First().Append(Now.Year.ToString)
            .Cells(1).Paragraphs.First().Append(Usercontrol234.TextBox1.Text)
            .Cells(2).Paragraphs.First().Append(Usercontrol236.TextBox1.Text)
            .Cells(3).Paragraphs.First().Append(Usercontrol237.TextBox1.Text)
        End With
        table.RemoveRow(2)
        For i = 0 To ListView1.Items.Count - 1
            Dim row As Document.NET.Row = table2.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append((i + 1).ToString)
                .Cells(1).Paragraphs.First().Append(ListView1.Items.Item(i).SubItems.Item(0).Text)
                .Cells(2).Paragraphs.First().Append(ListView1.Items.Item(i).SubItems.Item(2).Text)

            End With
        Next
        table2.RemoveRow(2)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<student>", Label22.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<status>", Usercontrol232.TextBox1.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<studentname>", Label22.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<term>", Usercontrol234.TextBox1.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label22.Text & "ClassAttendanceRecord" & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub MaterialButton7_Click(sender As Object, e As EventArgs) Handles MaterialButton7.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateAttendanceRecord.docx")
        Dim table = document.Tables(0)

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)



        For i = 0 To ListView3.Items.Count - 1
            Dim row As Document.NET.Row = table.InsertRow
            With row
                .Cells(0).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(0).Text)
                .Cells(1).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(1).Text)
                .Cells(2).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(2).Text)
                .Cells(3).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(3).Text)
                .Cells(4).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(4).Text)
                .Cells(5).Paragraphs.First().Append(ListView6.Items.Item(i).SubItems.Item(5).Text)
            End With
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)



        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)

        universalfilename = Label15.Text & "ClassAttendanceRecord" & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        Usercontrol241.Texts = TextBox21.Text
    End Sub

    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles TextBox23.TextChanged
        Usercontrol242.Texts = TextBox23.Text
    End Sub

    Private Sub CustomButton5_Click_1(sender As Object, e As EventArgs) Handles CustomButton5.Click

        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        PictureBox3.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        PictureBox3.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                PictureBox3.Image = bmpImage
            End If

            Try
                Dim ms As New System.IO.MemoryStream
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                bitmage = ms.ToArray()
                ms.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If

    End Sub

    Private Sub CustomButton3_Click_2(sender As Object, e As EventArgs) Handles CustomButton3.Click

        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox5.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox5.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                RoundPicturebox5.Image = bmpImage
            End If
            RoundPicturebox5.SizeMode = PictureBoxSizeMode.Zoom
            RoundPicturebox5.Tag = "Changed"
            'Try
            '    Dim ms As New System.IO.MemoryStream
            '    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            '    bitmage = ms.ToArray()
            '    ms.Close()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


        End If

    End Sub

    Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs) Handles TextBox25.TextChanged
        Usercontrol239.Texts = TextBox25.Text
    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged
        Usercontrol243.Texts = TextBox22.Text
    End Sub

    Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs) Handles TextBox24.TextChanged
        Usercontrol240.Texts = TextBox24.Text
    End Sub
    Dim listofabsentstudents As List(Of String)
    Dim lstreasons As List(Of String)
    Private Sub MaterialButton9_Click(sender As Object, e As EventArgs) Handles MaterialButton9.Click
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, True)
        Next
        'listofabsentstudents = New List(Of String)
        'lstreasons = New List(Of String)
        'If CheckedListBox1.CheckedItems.Count > 1 Or CheckedListBox1.Items.Count > 0 Then

        '    Dim listofbsentstudents As New List(Of String)
        '    Dim rasd As New List(Of String)
        '    'For i = 0 To CheckedListBox1.Items.Count - 1

        '    '    For j = 0 To CheckedListBox1.CheckedItems.Count - 1
        '    '        If CheckedListBox1.Items.Item(i).ToString <> CheckedListBox1.CheckedItems.Item(j).ToString Then
        '    '            listofbsentstudents(j) = CheckedListBox1.Items.Item(i)
        '    '        End If
        '    '    Next

        '    'Next

        '    For i = 0 To CheckedListBox1.Items.Count - 1

        '        If CheckedListBox1.GetItemChecked(i) = False Then
        '            listofbsentstudents.Append(CheckedListBox1.Items.Item(i))
        '        End If

        '    Next
        '    MsgBox(listofbsentstudents)

        '    If listofbsentstudents.Count > 0 Then

        '        ListBox2.Items.Clear()

        '        For Each i As String In listofbsentstudents
        '            ListBox2.Items.Add(i)
        '            rasd.Append("Reason of absence unknown")
        '            '    Dim a() = Me.RMSDBDataSet.tblStudents.Select("StudentName = " & i)
        '            '    Dim lst(1) As String
        '            '    lst(0) = "Absent"
        '            '    lst(1) = universalstringcomment
        '        Next

        '        listofabsentstudents.AddRange(listofbsentstudents)
        '        lstreasons.AddRange(rasd)
        '        MaterialTabControl2.SelectedTab = TabPage25
        '    Else

        '        MsgBox("No students absent")
        '        markregister(Nothing)
        '    End If
        'ElseIf CheckedListBox1.CheckedItems.Count = 1 Then

        '    For i = 0 To CheckedListBox1.Items.Count - 1

        '        If CheckedListBox1.GetItemChecked(i) = False Then
        '            ListBox2.Items.Add(CheckedListBox1.Items(i))
        '            listofabsentstudents.Append(CheckedListBox1.Items.Item(i))
        '            lstreasons.Add("Reason of absence unknown")
        '        End If

        '    Next



        '    MaterialTabControl2.SelectedTab = TabPage25
        'End If








    End Sub

    Private Sub TabPage24_Click(sender As Object, e As EventArgs) Handles TabPage24.Click

    End Sub
    Dim lsd As List(Of ListViewItem)
    Private Sub MaterialButton2_Click(sender As Object, e As EventArgs) Handles MaterialButton2.Click
        If ListBox2.SelectedIndex <> -1 Then
            lstreasons(ListBox2.SelectedIndex) = Usercontrol25.Texts
            MsgBox("Record saved", MsgBoxStyle.Information)
        End If
    End Sub



    Private Sub MaterialButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CustomButton10_Click_2(sender As Object, e As EventArgs) Handles CustomButton10.Click
        MaterialTabControl2.SelectedTab = TabPage26
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox3.SelectedIndexChanged

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        MaterialTabControl2.SelectedTab = TabPage28
    End Sub

    Private Sub CustomButton23_Click(sender As Object, e As EventArgs) Handles CustomButton23.Click
        MaterialTabControl2.SelectedTab = TabPage28
    End Sub

    Private Sub CustomButton35_Click(sender As Object, e As EventArgs) Handles CustomButton35.Click
        MaterialTabControl2.SelectedTab = TabPage6
    End Sub
    Dim gndr2 As String
    Private Sub CustomButton34_Click(sender As Object, e As EventArgs) Handles CustomButton34.Click
        If Not (FlowLayoutPanel1.Controls.Count <= 0) Then
            Try


                Dim a As List(Of Integer) = New List(Of Integer)
                For i = 0 To FlowLayoutPanel1.Controls.Count - 1
                    Dim btn As CustomButton = FlowLayoutPanel1.Controls(i)
                    a.Add(btn.Tag)
                Next

                If RoundPicturebox2.Tag = "Unchanged" Then
                    RoundPicturebox2.Image = New Bitmap(GenerateRactangle(TextBox28.Text, TextBox30.Text))
                End If

                dp = New MemoryStream
                RoundPicturebox2.Image.Save(dp, ImageFormat.Png)

                RoundPicturebox2.Border_Color = Color.White
                RoundPicturebox2.Border_Color2 = Color.White
                RoundPicturebox2.SizeMode = PictureBoxSizeMode.CenterImage

                Dim pay_load As PayloadGenerator.PhoneNumber = New PayloadGenerator.PhoneNumber(TextBox26.Text)
                Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
                Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode(pay_load, QRCodeGenerator.ECCLevel.Q)
                Dim QRCode_ As QRCode = New QRCode(qrcode_data)

                Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, True)

                dpqr = New MemoryStream

                qrcodeimage.Save(dpqr, System.Drawing.Imaging.ImageFormat.Jpeg)

                systemuser.addstudent(My.Settings.RMSDBConnectionString, TextBox28.Text, TextBox30.Text, TextBox29.Text, TextBox26.Text, Label15.Text, a, DateTimePicker6.Value, dp, gndr2, TextBox27.Text, dpqr)
                TextBox28.Text = ""
                TextBox30.Text = ""
                TextBox29.Text = ""
                TextBox26.Text = ""
                TextBox27.Text = ""
                ' Usercontrol223.Texts = ""
                FlowLayoutPanel1.Controls.Clear()
                Me.TblStudentsTableAdapter.Update(Me.RMSDBDataSet.tblStudents)
                Me.Invalidate()
                Me.TblStudentsTableAdapter.Fill(Me.RMSDBDataSet.tblStudents)
                Me.TblStudentsSubjectsTableAdapter.Fill(Me.RMSDBDataSet.tblStudentsSubjects)
                loadallsstudents()
                RoundPicturebox2.Tag = "Unchanged"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub CustomButton31_Click_1(sender As Object, e As EventArgs) Handles CustomButton31.Click

        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox2.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox2.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                RoundPicturebox2.Image = bmpImage
            End If
            RoundPicturebox2.SizeMode = PictureBoxSizeMode.Zoom
            RoundPicturebox2.Tag = "Changed"
            'Try
            '    Dim ms As New System.IO.MemoryStream
            '    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            '    bitmage = ms.ToArray()
            '    ms.Close()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


        End If
    End Sub

    Private Sub ComboBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim btn As CustomButton = New CustomButton
            btn.Size = New Size(104, 27)
            btn.Text = ComboBox7.Text
            btn.Tag = ComboBox7.SelectedValue
            btn.BackColor = Color.FromArgb(38, 50, 56)
            btn.ForeColor = Color.White
            btn.BorderRadiuses = 5
            btn.BorderSizes = 0

            FlowLayoutPanel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Btn_Click
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            gndr2 = "Male"
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton3.Checked = True Then
            gndr2 = "Female"
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem2.Click
        If MsgBox("Do you want to remove student from list", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)

        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If MsgBox("Do you want to save your updates", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.TblStudentsBindingSource7.EndEdit()
            Me.TblStudentsTableAdapter.Update(Me.RMSDBDataSet.tblStudents)
        End If
    End Sub

    Private Sub MaterialTabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MaterialTabControl2.SelectedIndexChanged

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex <> -1 Then

            Usercontrol25.TextBox1.Text = lstreasons(ListBox2.SelectedIndex)
        End If
    End Sub

    Private Sub CustomButton24_Click_1(sender As Object, e As EventArgs) Handles CustomButton24.Click

        markregister(lstreasons)

        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslisty - Copy.docx")
        Dim table = document.Tables(0)

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)



        For i = 0 To Me.RMSDBDataSet.tblRegister.Rows.Count - 1


            Dim itm = Me.RMSDBDataSet.tblRegister.Rows(i)
            Dim nam() = Me.RMSDBDataSet.tblStudents.Select("ID = " & itm.Item("StudentID"))
            If DateDiff(DateInterval.Day, (itm.Item("RegisterDate")), Now) = 0 Then
                Dim row As Document.NET.Row = table.InsertRow
                With row
                    .Cells(0).Paragraphs.First().Append(nam(0).Item("StudentName"))
                    .Cells(1).Paragraphs.First().Append(itm.Item("Mark_Register"))
                    .Cells(2).Paragraphs.First().Append(itm.Item("Comment"))
                End With
            End If
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Date>", Now.ToShortDateString, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = "Register[" & Now.ToShortDateString.Replace("/", "_") & "]"
        MaterialTabControl2.SelectedTab = TabPage19
        Me.TblRegisterDays3TableAdapter.Fill(Me.RMSDBDataSet.tblRegisterDays3)
        CustomButton1.Text = "Register already marked for today " & Now.ToShortDateString
        CustomButton32.Text = "Register already marked for today " & Now.ToShortDateString
        CustomButton1.Enabled = False
        CustomButton32.Enabled = False
    End Sub

    Private Sub CustomButton29_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MaterialButton10_Click(sender As Object, e As EventArgs) Handles MaterialButton10.Click
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemCheckState(i, False)
        Next
    End Sub

    Private Sub CustomButton11_Click_1(sender As Object, e As EventArgs) Handles CustomButton11.Click
        If CheckedListBox3.CheckedItems.Count > 0 Then
            ListBox1.Items.Clear()
            Dim listofstudents(CheckedListBox3.CheckedItems.Count - 1) As String
            For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                listofstudents(i) = CheckedListBox3.CheckedItems(i)
            Next
            ListBox1.Items.AddRange(listofstudents)
            MaterialTabControl2.SelectedTab = TabPage27
            Usercontrol22.Texts = Usercontrol21.TextBox1.Text
        End If
    End Sub

    Private Sub CustomButton27_Click_2(sender As Object, e As EventArgs) Handles CustomButton27.Click
        MaterialTabControl2.SelectedTab = TabPage26
        ListBox1.Items.Clear()
    End Sub

    Private Sub MaterialButton8_Click(sender As Object, e As EventArgs) Handles MaterialButton8.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateList2.docx")

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)

        Dim lst As String
        For i = 0 To ListBox1.Items.Count - 1
            lst &= ListBox1.Items(i) & vbNewLine
        Next
        ms.Close()
        ms2.Close()

        document.ReplaceText("<class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<list>", lst, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<ListName>", Usercontrol22.TextBox1.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Usercontrol22.TextBox1.Text & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub
    Private Sub CustomButton1_Click(sender As Object, e As EventArgs) Handles CustomButton1.Click
        MaterialTabControl2.SelectedTab = TabPage24
    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub
    Dim universaldb As DataTable
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex <> -1 Then
            Try
                universaldb = New DataTable

                Me.TblRegisterQueryTableAdapter.FillBy(Me.RMSDBDataSet.tblRegisterQuery, New System.Nullable(Of Date)(CType(ComboBox3.Text, Date)))
                Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblRegisterQuery WHERE [RegisterDate] = #" & New Date?(CType(ComboBox3.Text, Date)) & "#")

                universaldb = dt
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub CustomButton29_Click_1(sender As Object, e As EventArgs) Handles CustomButton29.Click

        MaterialTabControl2.SelectedTab = TabPage14
    End Sub

    Private Sub CustomButton28_Click(sender As Object, e As EventArgs) Handles CustomButton28.Click
        MaterialTabControl2.SelectedTab = TabPage8
        Me.TblRegisterTableAdapter.Fill(Me.RMSDBDataSet.tblRegister)
    End Sub

    Private Sub CustomButton37_Click_1(sender As Object, e As EventArgs)
        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox7.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox7.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                RoundPicturebox5.Image = bmpImage
            End If
            RoundPicturebox5.SizeMode = PictureBoxSizeMode.Zoom
            Me.TblTeachersBindingSource1.EndEdit()
            Me.TblTeachersTableAdapter.Update(Me.RMSDBDataSet.tblTeachers)
            'Try
            '    Dim ms As New System.IO.MemoryStream
            '    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            '    bitmage = ms.ToArray()
            '    ms.Close()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


        End If

    End Sub

    Private Sub MaterialButton3_Click_1(sender As Object, e As EventArgs) Handles MaterialButton3.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslisty - Copy.docx")
        Dim table = document.Tables(0)

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))
        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)


        For i = 0 To universaldb.Rows.Count - 1


            Dim itm = universaldb.Rows(i)

            If DateDiff(DateInterval.Day, (itm.Item("RegisterDate")), Now) = 0 Then
                Dim row As Document.NET.Row = table.InsertRow
                With row
                    .Cells(0).Paragraphs.First().Append(itm.Item("StudentName"))
                    .Cells(1).Paragraphs.First().Append(itm.Item("Mark_Register"))
                    .Cells(2).Paragraphs.First().Append(itm.Item("Comment"))
                End With
            End If
        Next
        table.RemoveRow(1)
        'For i = 1 To 60

        '    table.Rows.Add(row)
        'Next

        ms.Close()
        ms2.Close()

        document.ReplaceText("<class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Date>", Now.ToShortDateString, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = "Register [" & Now.ToShortDateString.Replace("/", "_") & "]"
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub FillByToolStripButton_Click_1(sender As Object, e As EventArgs)


    End Sub
    Dim bmage As Byte()
    Private Sub ChangeImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeImageToolStripMenuItem.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox7.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox7.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                RoundPicturebox7.Image = bmpImage
            End If
            RoundPicturebox7.SizeMode = PictureBoxSizeMode.Zoom


        End If
    End Sub

    Private Sub ContextMenuStrip5_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip5.Opening

    End Sub

    Private Sub ChangeImageToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChangeImageToolStripMenuItem1.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim bmpImage As Bitmap
            Dim OriginalImagez As Image = Image.FromFile(dialog.FileName)
            If OriginalImagez.Height <> OriginalImagez.Width Then
                If OriginalImagez.Height > OriginalImagez.Width Then
                    Dim CropRect As New Rectangle(OriginalImagez.Width / 100, 0, OriginalImagez.Width, OriginalImagez.Width)
                    Dim CropImage = New Bitmap(OriginalImagez.Width, OriginalImagez.Width)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox3.Image = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = New Bitmap(CropImage)
                        RoundPicturebox3.Image = CropImage
                    End Using
                End If

            Else
                bmpImage = New Bitmap(OriginalImagez)
                RoundPicturebox3.Image = bmpImage
            End If
            RoundPicturebox1.SizeMode = PictureBoxSizeMode.Zoom

        End If
    End Sub

    Private Sub ContextMenuStrip6_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip6.Opening

    End Sub

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        listofabsentstudents = New List(Of String)
        lstreasons = New List(Of String)
        If CheckedListBox1.CheckedItems.Count > 1 Or CheckedListBox1.Items.Count > 1 Then

            Dim listofbsentstudents As New List(Of String)
            Dim rasd As New List(Of String)
            'For i = 0 To CheckedListBox1.Items.Count - 1

            '    For j = 0 To CheckedListBox1.CheckedItems.Count - 1
            '        If CheckedListBox1.Items.Item(i).ToString <> CheckedListBox1.CheckedItems.Item(j).ToString Then
            '            listofbsentstudents(j) = CheckedListBox1.Items.Item(i)
            '        End If
            '    Next

            'Next
            Dim bypass As Boolean
            If CheckedListBox1.Items.Count > 0 And CheckedListBox1.CheckedItems.Count = 0 Then
                bypass = True
            Else
                bypass = False
            End If

            For i = 0 To CheckedListBox1.Items.Count - 1

                If bypass = True Or (Not CheckedListBox1.CheckedItems.Contains(CheckedListBox1.Items(i))) Then
                    listofbsentstudents.Add(CheckedListBox1.Items.Item(i))
                End If

            Next
            'MsgBox(listofbsentstudents)

            If listofbsentstudents.Count > 0 Then

                ListBox2.Items.Clear()

                For Each i As String In listofbsentstudents
                    ListBox2.Items.Add(i)
                    rasd.Add("Reason of absence unknown")
                    '    Dim a() = Me.RMSDBDataSet.tblStudents.Select("StudentName = " & i)
                    '    Dim lst(1) As String
                    '    lst(0) = "Absent"
                    '    lst(1) = universalstringcomment
                Next

                listofabsentstudents.AddRange(listofbsentstudents)
                lstreasons.AddRange(rasd)
                MaterialTabControl2.SelectedTab = TabPage25
            Else

                MsgBox("No students absent")
                markregister(Nothing)
                Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateClasslisty - Copy.docx")
                Dim table = document.Tables(0)

                Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
                Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label61.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
                Dim QRCode_ As QRCode = New QRCode(qrcode_data)

                Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



                Dim ms As New System.IO.MemoryStream
                qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

                Dim ms2 As New MemoryStream
                PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)

                Dim image = document.AddImage(ms2)

                Dim picture = image.CreatePicture(83.90551, 92.12598)
                Dim qrimage = document.AddImage(ms)
                Dim qrpic = qrimage.CreatePicture(60, 60)



                For i = 0 To Me.RMSDBDataSet.tblRegister.Rows.Count - 1


                    Dim itm = Me.RMSDBDataSet.tblRegister.Rows(i)
                    Dim nam() = Me.RMSDBDataSet.tblStudents.Select("ID = " & itm.Item("StudentID"))
                    If DateDiff(DateInterval.Day, (itm.Item("RegisterDate")), Now) = 0 Then
                        Dim row As Document.NET.Row = table.InsertRow
                        With row
                            .Cells(0).Paragraphs.First().Append(nam(0).Item("StudentName"))
                            .Cells(1).Paragraphs.First().Append(itm.Item("Mark_Register"))
                            .Cells(2).Paragraphs.First().Append(itm.Item("Comment"))
                        End With
                    End If
                Next
                table.RemoveRow(1)
                'For i = 1 To 60

                '    table.Rows.Add(row)
                'Next

                ms.Close()
                ms2.Close()

                document.ReplaceText("<class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
                document.ReplaceText("<year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)

                document.ReplaceText("<Date>", Now.ToShortDateString, False, System.Text.RegularExpressions.RegexOptions.None)

                document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)

                document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)

                document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
                document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
                universaldocstream = New MemoryStream
                document.SaveAs(universaldocstream)


                universalfilename = "Register[" & Now.ToShortDateString.Replace("/", "_") & "]"
                MaterialTabControl2.SelectedTab = TabPage19
                Me.TblRegisterDays3TableAdapter.Fill(Me.RMSDBDataSet.tblRegisterDays3)
                CustomButton1.Text = "Register already marked for today " & Now.ToShortDateString
                CustomButton32.Text = "Register already marked for today " & Now.ToShortDateString
                CustomButton1.Enabled = False
                CustomButton32.Enabled = False
            End If
        ElseIf CheckedListBox1.Items.Count = 1 Then

            For i = 0 To CheckedListBox1.Items.Count - 1

                If CheckedListBox1.GetItemChecked(i) = False Then
                    ListBox2.Items.Add(CheckedListBox1.Items(i))
                    listofabsentstudents.Append(CheckedListBox1.Items.Item(i))
                    lstreasons.Add("Reason of absence unknown")
                End If

            Next



            MaterialTabControl2.SelectedTab = TabPage25
        End If
    End Sub

    Private Sub CustomButton37_Click_2(sender As Object, e As EventArgs) Handles CustomButton37.Click
        MaterialTabControl2.SelectedTab = TabPage30
    End Sub

    Private Sub CustomButton38_Click(sender As Object, e As EventArgs) Handles CustomButton38.Click
        MaterialTabControl2.SelectedTab = TabPage31
    End Sub

    Private Sub MaterialButton11_Click(sender As Object, e As EventArgs) Handles MaterialButton11.Click
        Dim document As Xceed.Document.NET.Document = Xceed.Words.NET.DocX.Load("RMSTemplateStudent's_profile.docx")

        Dim qrcode_generator As QRCodeGenerator = New QRCodeGenerator
        Dim qrcode_data As QRCodeData = qrcode_generator.CreateQrCode("This document has been produced by RMS (version#: " & My.Application.Info.Version.ToString & ") licensed to " & Label12.Text & " (a teacher at " & Label78.Text & ") currently the class teacher of " & Label48.Text & " {" & Date.Now.ToShortDateString & "}", QRCodeGenerator.ECCLevel.Q)
        Dim QRCode_ As QRCode = New QRCode(qrcode_data)

        Dim qrcodeimage = QRCode_.GetGraphic(20, Color.Black, Color.White, New Bitmap(My.Resources.output_onlinepgtools__3_))



        Dim ms As New System.IO.MemoryStream
        qrcodeimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim ms2 As New MemoryStream
        PictureBox8.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png)


        Dim ms3 As New MemoryStream
        RoundPicturebox3.Image.Save(ms3, System.Drawing.Imaging.ImageFormat.Png)

        Dim image = document.AddImage(ms2)

        Dim picture = image.CreatePicture(83.90551, 92.12598)
        Dim qrimage = document.AddImage(ms)
        Dim qrpic = qrimage.CreatePicture(60, 60)



        Dim dpimage = document.AddImage(ms3)

        Dim profpic = dpimage.CreatePicture(90, 90)

        profpic.SetPictureShape(Xceed.Document.NET.BasicShapes.foldedCorner)

        ms.Close()
        ms2.Close()
        document.ReplaceText("<StudentName>", Label28.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<DOB>", TextBox14.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Class>", Label15.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Year>", Now.Year, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Gender>", TextBox13.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Subs>", TextBox16.Text, False, System.Text.RegularExpressions.RegexOptions.None)

        Dim txt = InputBox("Enter your general comment on about the student below")
        document.ReplaceText("<Comment>", txt, False, System.Text.RegularExpressions.RegexOptions.None)

        document.ReplaceText("<Teacher’s name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceText("<Teacher’s_name>", Label12.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        document.ReplaceTextWithObject("<SchoolLogo>", picture, False, RegexOptions.IgnoreCase)
        document.ReplaceTextWithObject("<Profile>", profpic, False, RegexOptions.IgnoreCase)
        document.ReplaceTextWithObject("<QRCODE>", qrpic, False, RegexOptions.IgnoreCase)
        document.ReplaceText("<School>", Label78.Text, False, System.Text.RegularExpressions.RegexOptions.None)
        universaldocstream = New MemoryStream
        document.SaveAs(universaldocstream)


        universalfilename = Label28.Text.Trim & Now.Year
        MaterialTabControl2.SelectedTab = TabPage19
    End Sub

    Private Sub CustomButton26_Click_1(sender As Object, e As EventArgs) Handles CustomButton26.Click
        Dim myrow = Me.RMSDBDataSet.tblSubjects.NewRow
        With myrow
            .Item("Subject") = TextBox42.Text
            .Item("Subject Teacher") = TextBox45.Text
        End With
        Me.RMSDBDataSet.tblSubjects.AddtblSubjectsRow(myrow)
        Me.TblSubjectsTableAdapter.Update(Me.RMSDBDataSet.tblSubjects)
        Getstarted(systemuser)
        MsgBox("Subject added to database", MsgBoxStyle.Information)
    End Sub

    Private Sub CustomButton39_Click(sender As Object, e As EventArgs) Handles CustomButton39.Click
        MaterialTabControl2.SelectedTab = TabPage29
    End Sub

    Private Sub CustomButton44_Click(sender As Object, e As EventArgs) Handles CustomButton44.Click
        MaterialTabControl2.SelectedTab = TabPage16
    End Sub

    Private Sub CustomButton45_Click(sender As Object, e As EventArgs) Handles CustomButton45.Click
        MaterialTabControl2.SelectedTab = TabPage30
    End Sub

    Private Sub CustomButton46_Click_1(sender As Object, e As EventArgs) Handles CustomButton46.Click
        MaterialTabControl2.SelectedTab = TabPage30
    End Sub

    Private Sub RemoveToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem3.Click
        If Not ListBox1.SelectedIndex = -1 Then
            If MsgBox("Do you want to remove item ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub MaterialButton13_Click(sender As Object, e As EventArgs) Handles MaterialButton13.Click
        For i = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub MaterialButton12_Click(sender As Object, e As EventArgs) Handles MaterialButton12.Click
        For i = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox3.KeyDown
        If ComboBox3.Text <> "" Then
            Try
                universaldb = New DataTable
                'ListView4.Items.Clear()
                '  Me.TblRegisterQueryTableAdapter.FillBy(Me.RMSDBDataSet.tblRegisterQuery, New System.Nullable(Of Date)(CType(ComboBox3.Text, Date)))
                Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblRegisterQuery WHERE [RegisterDate] = #" & New Date?(CType(ComboBox3.Text, Date)) & "#")
                'For Each i As DataRow In dt.Rows
                '    Dim lst(3) As String
                '    lst(0) = i.Item("RegisterDate")
                '    lst(1) = i.Item("StudentName")
                '    lst(2) = i.Item("Mark_Register")
                '    lst(3) = i.Item("Comment")

                '    Dim myrow As ListViewItem = New ListViewItem(lst)
                '    ListView4.Items.Add(myrow)
                'Next
                universaldb = dt
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub MaterialButton14_Click(sender As Object, e As EventArgs) Handles MaterialButton14.Click
        If ComboBox3.Text <> "" Then
            Try
                universaldb = New DataTable
                'ListView4.Items.Clear()
                Me.TblRegisterQueryTableAdapter.FillBy(Me.RMSDBDataSet.tblRegisterQuery, New System.Nullable(Of Date)(CType(ComboBox3.Text, Date)))
                Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblRegisterQuery WHERE [RegisterDate] = #" & New Date?(CType(ComboBox3.Text, Date)) & "#")
                'For Each i As DataRow In dt.Rows
                '    Dim lst(3) As String
                '    lst(0) = i.Item("RegisterDate")
                '    lst(1) = i.Item("StudentName")
                '    lst(2) = i.Item("Mark_Register")
                '    lst(3) = i.Item("Comment")

                '    Dim myrow As ListViewItem = New ListViewItem(lst)
                '    ListView4.Items.Add(myrow)
                'Next
                universaldb = dt
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        If MsgBox("Do you want to save your updates", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.TblSubjectsBindingSource3.EndEdit()
            Me.TblSubjectsTableAdapter.Update(Me.RMSDBDataSet.tblSubjects)
        End If
    End Sub

    Private Sub ViewImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewImageToolStripMenuItem.Click
        MaterialTabControl2.SelectedTab = TabPage32
        PictureBox9.Image = RoundPicturebox3.Image
    End Sub

    Private Sub CustomButton12_Click_2(sender As Object, e As EventArgs) Handles CustomButton12.Click
        MaterialTabControl2.SelectedTab = TabPage7
    End Sub

    Private Sub CustomButton47_Click(sender As Object, e As EventArgs) Handles CustomButton47.Click
        MaterialTabControl2.SelectedTab = TabPage24
    End Sub

    Private Sub CustomButton48_Click(sender As Object, e As EventArgs) Handles CustomButton48.Click
        MaterialTabControl2.SelectedTab = TabPage8
    End Sub

    Private Sub CustomButton49_Click_1(sender As Object, e As EventArgs) Handles CustomButton49.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for profile picture"
        dialog.Filter = "Image Files(*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPEG;*.JPG;*.GIF;*.PNG"

        If DialogResult = DialogResult.OK Then
            Dim reader As StreamReader = New StreamReader(dialog.FileName)
            Dim csv As CsvHelper.CsvReader = New CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture)
            ' Dim events = csv.GetRecords(_event)(k)
        End If
    End Sub

    Private Sub CustomButton56_Click(sender As Object, e As EventArgs) Handles CustomButton56.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse for csv file"
        dialog.Filter = "Image Files(*.csv)|*.csv"
        If dialog.ShowDialog() = DialogResult.OK Then

            Dim reader As New StreamReader(dialog.FileName)
            Dim csv = New CsvReader(reader, CultureInfo.InvariantCulture)
            csv.Read()
            Dim headercount As Integer = csv.ColumnCount
            Dim headers As String() = {}
            For i = 0 To headercount - 1
                headers(i) = csv.GetField(Of String)(i)
            Next

            For Each j As String In headers
                        Dim column As New ColumnHeader()
                        column.Text = j
                        column.Width = j.Length + 5
                        Me.ListView4.Columns.Add(column)
                    Next
                    While reader.Read
                        Dim itemz As New ListViewItem()
                        For i As Integer = 0 To headercount
                    itemz.SubItems.Add(csv.GetField(i))
                Next
                        ListView4.Items.Add(itemz)
                    End While
                    Label211.Text = dialog.FileName
                    PictureBox17.Visible = True
                    Label211.Visible = True

        End If
    End Sub



    Private Sub Label200_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CustomButton58_Click_1(sender As Object, e As EventArgs) Handles CustomButton58.Click
        MaterialTabControl1.SelectedTab = TabPage18
    End Sub

    Private Sub Label203_Click(sender As Object, e As EventArgs) Handles Label203.Click

    End Sub

    Private Sub TabPage34_Click(sender As Object, e As EventArgs) Handles TabPage34.Click

    End Sub
End Class
Public Class StudentsCsv
    Private dynamicproperties As Dictionary(Of String, Object)
    Public Sub addproperty(name As String, value As Object)
        dynamicproperties.Add(name, value)
    End Sub

    Public Function getProperty(name As String) As Object
        Dim value As Object
        If dynamicproperties.TryGetValue(name, value) Then
            Return value
        End If
        Return Nothing
    End Function
End Class