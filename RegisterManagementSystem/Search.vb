Public Class Search
    Public ID As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ID = ComboBox1.SelectedValue - 1
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblStudents' table. You can move, or remove it, as needed.
        Me.TblStudentsTableAdapter.Fill(Me.RMSDBDataSet.tblStudents)
        'TODO: This line of code loads data into the 'RMSDBDataSet.tblStudentsQuery' table. You can move, or remove it, as needed.
        Me.TblStudentsQueryTableAdapter.Fill(Me.RMSDBDataSet.tblStudentsQuery)

    End Sub
End Class
