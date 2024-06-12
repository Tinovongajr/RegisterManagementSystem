Public Class Custom_Navigator
    Private dbconnector As String
    Private sql As String
    Private dt As DataTable

    Public Property dbconnection As String
        Get
            Return Me.dbconnector
        End Get
        Set
            Me.dbconnector = Value
        End Set
    End Property

    Public Property querySQL As String
        Get
            Return Me.sql
        End Get
        Set
            Me.sql = Value
        End Set
    End Property

    Public Property data_table As DataTable
        Get
            Return Me.dt
        End Get
        Set
            Me.dt = Value
        End Set
    End Property
    Public Sub New(connectionstring As String, SQL_string As String)
        dbconnection = connectionstring
        querySQL = SQL_string
        Dim datbl = ReadFromDatabase(dbconnection, querySQL)
        data_table = datbl

    End Sub
    Public Function GetNextRecord(currentrecord As Integer) As DataRow
        If Not (currentrecord + 1 > data_table.Rows.Count - 1) Then
            Return data_table.Rows.Item(currentrecord + 1)
        Else

        End If
    End Function
    Public Function GetPreviousRecord(currentrecord As Integer) As DataRow
        If Not (currentrecord - 1 < 0) Then
            Return data_table.Rows(currentrecord - 1)
        End If
    End Function
    Public Function GetRecord(index As Integer) As DataRow
        If Not (index > data_table.Rows.Count - 1) And Not (index < 0) Then
            Return data_table.Rows(index)
        End If
    End Function
    Private Function ReadFromDatabase(ByVal DBconnectionString As String, ByVal SQL As String) As DataTable
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
End Class
