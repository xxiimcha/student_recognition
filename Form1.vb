Imports MySql.Data.MySqlClient

Public Class home_page
    Dim conn As MySqlConnection
    Dim cmd As MySqlCommand

    Private Sub add_student_Click(sender As Object, e As EventArgs) Handles add_student.Click
        Dim add_student_form As New add_student_form()

        add_student_form.Show()
        Me.Hide()

    End Sub

    Private Sub home_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;username=root;password='';database=student_recognition"

        Try
            conn.Open()
            MessageBox.Show("Connection to MySQL test database was successful!!!!", "TESTING      CONNECTION TO MySQL DATABASE")
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub detect_students_Click(sender As Object, e As EventArgs) Handles detect_students.Click
        Dim detect_students As New detect_students()

        detect_students.Show()
        Me.Hide()
    End Sub
End Class
