Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Public Class user
    Private username As String
    Private firstname As String
    Private surname As String
    Private password As String
    Private ProfilePicture As Image
    Private schoollogo As Image
    Private email As String
    Private loggedIn As Boolean
    Private Role As String
    Private school As String
    Private subject As String
    Private department As String
    Private gender As String
    Private bytimage As Byte()
    Private bytmage As Byte()
    Public Property UserNme As String
        Get
            Return Me.username
        End Get
        Set(value As String)
            Me.username = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return Me.firstname
        End Get
        Set(value As String)
            Me.firstname = value
        End Set
    End Property

    Public Property Second_name As String
        Get
            Return Me.surname
        End Get
        Set(value As String)
            Me.surname = value
        End Set
    End Property

    Public Property UserEmail As String
        Get
            Return Me.email
        End Get
        Set(value As String)
            If Verify_email(value) = True Then

                Me.email = value
            Else
                'Error handler
            End If
        End Set
    End Property

    Public Property UserPassword As String
        Get
            Return Me.password
        End Get
        Set(value As String)
            Me.password = value
        End Set
    End Property

    Public Property Dp As Image
        Get
            Return Me.ProfilePicture
        End Get
        Set(value As Image)
            value = Me.ProfilePicture
        End Set
    End Property

    Public ReadOnly Property Status As String
        Get
            Dim stat As String
            stat = "Offline"
            If Me.loggedIn = True Then
                stat = "Online"
            End If
            Return stat
        End Get
    End Property
    Public Property userGender As String
        Get
            Return Me.gender
        End Get
        Set(value As String)
            Me.gender = value
        End Set
    End Property
    Public Property schoolname As String
        Get
            Return Me.school
        End Get
        Set(value As String)
            Me.school = value
        End Set
    End Property
    Public Property school_logo As Image
        Get
            Return Me.schoollogo
        End Get
        Set(value As Image)
            Me.schoollogo = value
        End Set
    End Property
    Public Property school_department As String
        Get
            Return Me.department
        End Get
        Set(value As String)
            Me.department = value
        End Set
    End Property
    Public Property subjects As String
        Get
            Return Me.subject
        End Get
        Set(value As String)
            Me.subject = value
        End Set
    End Property
    Public Sub validate_string(ByVal text As String)
        For Each i As Char In text.ToCharArray
            If Asc(i) < Asc("A") And Asc(i) > Asc("a") Then
            Else
                MsgBox("Invalid data type")
            End If
        Next
    End Sub
    Public Sub validate_number(ByVal number As Char)



    End Sub

    Public Function Verify_email(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

    Public Function SetProfile_Picture()
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
                        bmpImage = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = CropImage
                    End Using
                End If
                schoollogo = bmpImage
            Else
            End If

            Try
                Dim ms As New System.IO.MemoryStream
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                bytmage = ms.ToArray()
                ms.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Function

    Public Function SetSchoollogo()
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
                        bmpImage = CropImage
                    End Using
                Else
                    Dim CropRect As New Rectangle(OriginalImagez.Height / 10, 0, OriginalImagez.Height, OriginalImagez.Height)
                    Dim CropImage = New Bitmap(OriginalImagez.Height, OriginalImagez.Height)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImagez, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        OriginalImagez.Dispose()
                        bmpImage = CropImage
                    End Using
                End If
                ProfilePicture = bmpImage
            Else
            End If

            Try
                Dim ms As New System.IO.MemoryStream
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                bytimage = ms.ToArray()
                ms.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Function
    Public Function Get_Students()

        Return ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT * FROM tblStudents WHERE Form_Teacher = '" & Me.Name & Me.surname & "'")

    End Function
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
    Dim picturedat As Byte()
    Public Sub loginUser(ByVal id As Integer)
        Dim sql As String = "SELECT * FROM tblTeachers WHERE ID = " & id
        'If exists(sql, My.Settings.RMSDBConnectionString) = True Then

        Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, sql)
        Dim picturedata As Byte()
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                Me.Name = .Item(1).ToString
                Me.Second_name = .Item(2).ToString
                Me.UserNme = .Item(3).ToString
                Me.UserPassword = .Item(4).ToString
                Me.UserEmail = .Item(6).ToString
                Me.Role = .Item(7).ToString
                Me.school = .Item(8).ToString
                Me.subject = .Item(9).ToString
                Me.department = .Item(10).ToString
                Me.gender = .Item(11).ToString
                picturedata = DirectCast(CType(.Item(5), Object), Byte())
                picturedat = DirectCast(CType(.Item(12), Object), Byte())
            End With
            Dim stream As New IO.MemoryStream(picturedata)
            Me.Dp = Image.FromStream(stream)
            Dim strea As New IO.MemoryStream(picturedat)
            Me.schoollogo = Image.FromStream(strea)
            Form1.TblStudentsTableAdapter.Fill(Form1.RMSDBDataSet.tblStudents)
            'TODO: This line of code loads data into the 'RMSDBDataSet.tblStudentsSubjects' table. You can move, or remove it, as needed.
            Form1.TblStudentsSubjectsTableAdapter.Fill(Form1.RMSDBDataSet.tblStudentsSubjects)
            'TODO: This line of code loads data into the 'RMSDBDataSet.tblSubjects' table. You can move, or remove it, as needed.
            Form1.TblSubjectsTableAdapter.Fill(Form1.RMSDBDataSet.tblSubjects)
            'TODO: This line of code loads data into the 'RMSDBDataSet.tblTeachers' table. You can move, or remove it, as needed.
            Form1.TblTeachersTableAdapter.Fill(Form1.RMSDBDataSet.tblTeachers)
            'TODO: This line of code loads data into the 'RMSDBDataSet.tblDays' table. You can move, or remove it, as needed.
            Form1.TblDaysTableAdapter.Fill(Form1.RMSDBDataSet.tblDays)
            'MsgBox("Login successful! Welcome")
        Else
            MsgBox("Wrong Credentials!Try again")
        End If
        ' Else
        ' MsgBox("Wrong Credentials!Try again")
        'End If


    End Sub
    Public Sub addstudent(ByVal DBconnectionString As String, ByVal studentnm As String, ByVal studentsnm As String, ByVal homeaddrss As String, ByVal phonenum As String, ByVal classh As String, ByVal listofsubjects As List(Of Integer), ByVal dob As Date, dp As MemoryStream, gndr As String, parent As String, qr As MemoryStream)
        Try
            'Dim sql = "INSERT INTO tblStudents([Student_Name], [Student_Surname], [Home_Address], [Phone_Number], [Class], [Form_Teacher], [School], [Profile_Picture], [DOB], gender, [Parent_Guardian]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) "
            'Using conn As New OleDb.OleDbConnection(DBconnectionString)
            '    conn.Open()
            '    ' Dim dp As MemoryStream = GenerateRactangle(studentnm, studentsnm)  
            Dim bytimg As Byte() = dp.ToArray
            Dim bytimgqr As Byte() = qr.ToArray
            '    Using cmd As New OleDb.OleDbCommand
            '        cmd.Connection = conn
            '        cmd.CommandText = sql
            '        cmd.Parameters.AddWithValue("@?", studentnm)
            '        cmd.Parameters.AddWithValue("@?", studentsnm)
            '        cmd.Parameters.AddWithValue("@?", homeaddrss)
            '        cmd.Parameters.AddWithValue("@?", phonenum)
            '        cmd.Parameters.AddWithValue("@?", classh)
            '        cmd.Parameters.AddWithValue("@?", Me.Name & Me.surname)
            '        cmd.Parameters.AddWithValue("@?", school)
            '        cmd.Parameters.AddWithValue("@?", bytimg)
            '        cmd.Parameters.AddWithValue("@?", CType(dob.ToShortDateString, Date))
            '        cmd.Parameters.AddWithValue("@?", gndr)
            '        cmd.Parameters.AddWithValue("@?", parent)
            '        cmd.ExecuteNonQuery()
            '    End Using
            'End Using

            Dim row As DataRow = Form1.RMSDBDataSet.tblStudents.NewRow
            With row
                .Item("Student_Name") = studentnm
                .Item("Student_Surname") = studentsnm
                .Item("Home_Address") = homeaddrss
                .Item("Phone_Number") = phonenum
                .Item("Class") = classh
                .Item("Form_Teacher") = Me.Name & Me.surname
                .Item("School") = school
                .Item("Profile_Picture") = bytimg
                .Item("DOB") = CType(dob.ToShortDateString, Date)
                .Item("gender") = gndr
                .Item("Parent_Guardian") = parent
                .Item("Parents_PhoneNumberQr") = bytimgqr
                .Item("StudentName") = studentnm & " " & studentsnm
            End With

            Form1.RMSDBDataSet.tblStudents.Rows.Add(row)
            Form1.TblStudentsTableAdapter.Update(Form1.RMSDBDataSet.tblStudents)
            Dim studentsID As Integer
            Dim dt = ReadFromDatabase(My.Settings.RMSDBConnectionString, "SELECT ID FROM tblStudents WHERE [StudentName] = '" & studentnm & " " & studentsnm & "'")
            If dt.Rows.Count > 0 Then
                studentsID = dt.Rows(0).Item(0)
            End If
            ' Dim studentsID As Integer = getId("SELECT ID FROM tblStudents WHERE [StudentName] = '" & studentnm & " " & studentsnm & "'", My.Settings.RMSDBConnectionString)

            For i = 0 To listofsubjects.Count - 1
                Dim myrow As DataRow = Form1.RMSDBDataSet.tblStudentsSubjects.NewRow
                With myrow
                    .Item(1) = studentsID
                    .Item(2) = listofsubjects(i)
                End With
                Form1.RMSDBDataSet.tblStudentsSubjects.Rows.Add(myrow)
            Next
            Form1.TblStudentsSubjectsTableAdapter.Update(Form1.RMSDBDataSet.tblStudentsSubjects)
            MsgBox("Student successfully added to database", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub

    Public Function getId(ByVal sql As String, ByVal DBconnectionString As String) As Boolean
        Try
            Dim a As Integer
            'Open connection using connection string 
            Using conn As New OleDb.OleDbConnection(DBconnectionString)
                conn.Open()
                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = conn
                    cmd.CommandText = sql
                    Dim da As New OleDb.OleDbDataAdapter(cmd)
                    a = cmd.ExecuteScalar
                End Using
            End Using
            If Not (IsNothing(a)) Then
                Return a
            Else
                Return MsgBox("Error No Id found")
            End If
        Catch ex As Exception
            MsgBox("Error occured" & vbNewLine & ex.Message)
        End Try
    End Function
    Public Function exists(ByVal sql As String, ByVal DBconnectionString As String) As Boolean
        Try
            Dim a As Integer
            'Open connection using connection string 
            Using conn As New OleDb.OleDbConnection(DBconnectionString)
                conn.Open()
                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = conn
                    cmd.CommandText = sql
                    Dim da As New OleDb.OleDbDataAdapter(cmd)
                    a = cmd.ExecuteNonQuery()
                End Using
            End Using
            If a > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error occured" & vbNewLine & ex.Message)
        End Try
    End Function
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

    Public Sub New()

    End Sub
    Public Sub New(User_Name As String, Name As String, secondname As String, User_Password As String, emailAddress As String, sex As String, bytim As Byte(), depatment As String, schol As String, subjet As String, issignup As Boolean)

        If issignup = True Then
            firstname = Name
            username = User_Name
            surname = secondname
            password = User_Password
            gender = sex
            school = schol
            department = depatment
            subject = subjet
            Dim dp As MemoryStream = GenerateRactangle(firstname, surname)
            '   Dim bmpImagex As Bitmap = New Bitmap(schoollog)


            ProfilePicture = Image.FromStream(dp)
            bytimage = dp.ToArray

            If (Verify_email(emailAddress)) = True Then
                email = emailAddress
            Else
                email = "No valid email"
                Exit Sub
            End If
            loggedIn = False
            Try
                '###########################################ACCESS##################################
                Dim row As Data.DataRow = Form1.RMSDBDataSet.tblTeachers.NewRow
                With row
                    .Item(1) = firstname
                    .Item(2) = surname
                    .Item(3) = username
                    .Item(4) = password
                    .Item(5) = bytimage
                    .Item(6) = email
                    .Item(7) = "Form teacher"
                    .Item(8) = school
                    .Item(9) = subject
                    .Item(10) = department
                    .Item(11) = gender
                    .Item(12) = bytim
                End With

                Form1.RMSDBDataSet.tblTeachers.Rows.Add(row)
                Form1.TblTeachersTableAdapter.Update(Form1.RMSDBDataSet.tblTeachers)
                '#####################################################################################

                '###########################################MONGODB###################################
                'Dim collection As IMongoCollection(Of BsonDocument) = dbd.GetCollection(Of BsonDocument)("Appointments")
                'Dim emp As BsonDocument = New BsonDocument
                'With emp
                '    .Add("Name", name)
                '    .Add("Surname", surname)
                '    .Add("Password",User_Password)
                '    .Add("ProfilePicture", bmpimage)
                '    .Add("Email", email)
                '    .Add("IsDoctor", isdoctor)
                'End With
                'collection.InsertOne(emp)
                '########################################################################################   
                MsgBox("New user account successfully created")
            Catch ex As Exception
                MsgBox("Failed to create new user account." & vbNewLine & ex.Message)
            End Try
        Else
            '  loginUser(username, User_Password)
        End If
    End Sub

End Class
