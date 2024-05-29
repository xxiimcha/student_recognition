Imports System.IO
Imports MySql.Data.MySqlClient

Public Class add_student_form

    Dim conn As MySqlConnection
    Dim cmd As MySqlCommand

    Private Sub save_student_Click(sender As Object, e As EventArgs) Handles save_student.Click
        Try
            conn = New MySqlConnection
            conn.ConnectionString = "server=localhost;username=root;password='';database=student_recognition"
            conn.Open()

            Dim student_number As String = txtstudent_number.Text
            Dim student_name As String = txtstudent_name.Text
            Dim course As String = txtcourse.Text
            Dim year As String = txtyear_level.Text
            ' Convert the selected image to a byte array.
            Dim student_image As Byte() = Nothing
            If image.Image IsNot Nothing Then
                Using ms As New MemoryStream()
                    image.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                    student_image = ms.ToArray()
                End Using
            End If


            Dim query As String = "INSERT INTO students (student_number, student_name, course, year, student_image) VALUES (@student_number, @student_name, @course, @year, @student_image)"
            cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@student_number", student_number)
            cmd.Parameters.AddWithValue("@student_name", student_name)
            cmd.Parameters.AddWithValue("@course", course)
            cmd.Parameters.AddWithValue("@year", year)
            cmd.Parameters.AddWithValue("@student_image", student_image)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Student added successfully.")

            LoadData()

        Catch ex As MySqlException
            MessageBox.Show("Error in adding student: " & ex.Message)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Sub

    Private Sub add_student_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Public Sub LoadData()
        Dim connStr As String = "server=localhost;username=root;password='';database=student_recognition"
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                ' Specify the columns you want to select, excluding 'student_image'.
                Dim query As String = "SELECT student_number, student_name, course, year FROM students"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim table As New DataTable()
                        adapter.Fill(table)
                        ' Set the DataSource of the DataGridView to the DataTable.
                        datagrid_students.DataSource = table

                        ' Optionally, you can adjust the column headers here if needed.
                        ' For example:
                        datagrid_students.Columns("student_number").HeaderText = "Student Number"
                        datagrid_students.Columns("student_name").HeaderText = "Name"
                        datagrid_students.Columns("course").HeaderText = "Course"
                        datagrid_students.Columns("year").HeaderText = "Year Level"
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub datagrid_students_SelectionChanged(sender As Object, e As EventArgs) Handles datagrid_students.SelectionChanged
        If datagrid_students.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = datagrid_students.SelectedRows(0)
            txtstudent_number.Text = row.Cells("student_number").Value.ToString()
            txtstudent_name.Text = row.Cells("student_name").Value.ToString()
            txtcourse.Text = row.Cells("course").Value.ToString()
            txtyear_level.Text = row.Cells("year").Value.ToString()

            ' Assuming you have a method to fetch the image from the database by student number.
            Dim img As Image = GetStudentImage(row.Cells("student_number").Value.ToString())

            save_student.Text = "Update"
        End If
    End Sub
    Private Function GetStudentImage(studentNumber As String) As Image
        Dim connStr As String = "server=localhost;username=root;password='';database=student_recognition"
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim query As String = "SELECT student_image FROM students WHERE student_number = @studentNumber"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@studentNumber", studentNumber)
                    Dim imgBytes As Byte() = CType(cmd.ExecuteScalar(), Byte())
                    If imgBytes IsNot Nothing AndAlso imgBytes.Length > 0 Then
                        Using ms As New MemoryStream(imgBytes)
                            Return Drawing.Image.FromStream(ms)
                        End Using
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred fetching image: " & ex.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Private Sub capture_image_Click(sender As Object, e As EventArgs) Handles capture_image.Click
        Using webcamForm As New webcam_form()
            webcamForm.ShowDialog()
            LoadCapturedImage()
        End Using
    End Sub

    ' Make sure this method is inside your 'add_student_form' class.
    Private Sub LoadCapturedImage()
        Dim imagePath As String = Path.Combine(Application.StartupPath, "capturedImage.jpg")
        If File.Exists(imagePath) Then
            image.SizeMode = PictureBoxSizeMode.StretchImage ' or use PictureBoxSizeMode.Zoom
            image.Image = System.Drawing.Image.FromFile(imagePath)
        Else
            MessageBox.Show("Image not found.")
        End If
    End Sub

End Class
