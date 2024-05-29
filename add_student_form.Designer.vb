<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_student_form
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
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        txtstudent_number = New TextBox()
        txtstudent_name = New TextBox()
        txtcourse = New TextBox()
        txtyear_level = New TextBox()
        save_student = New Button()
        datagrid_students = New DataGridView()
        capture_image = New Button()
        image = New PictureBox()
        CType(datagrid_students, ComponentModel.ISupportInitialize).BeginInit()
        CType(image, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(338, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 15)
        Label1.TabIndex = 2
        Label1.Text = "Student Number"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(338, 91)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 15)
        Label2.TabIndex = 2
        Label2.Text = "Student Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(338, 128)
        Label3.Name = "Label3"
        Label3.Size = New Size(44, 15)
        Label3.TabIndex = 2
        Label3.Text = "Course"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(338, 163)
        Label4.Name = "Label4"
        Label4.Size = New Size(59, 15)
        Label4.TabIndex = 2
        Label4.Text = "Year Level"
        ' 
        ' txtstudent_number
        ' 
        txtstudent_number.Location = New Point(464, 49)
        txtstudent_number.Name = "txtstudent_number"
        txtstudent_number.Size = New Size(177, 23)
        txtstudent_number.TabIndex = 3
        ' 
        ' txtstudent_name
        ' 
        txtstudent_name.Location = New Point(464, 88)
        txtstudent_name.Name = "txtstudent_name"
        txtstudent_name.Size = New Size(177, 23)
        txtstudent_name.TabIndex = 3
        ' 
        ' txtcourse
        ' 
        txtcourse.Location = New Point(464, 128)
        txtcourse.Name = "txtcourse"
        txtcourse.Size = New Size(177, 23)
        txtcourse.TabIndex = 3
        ' 
        ' txtyear_level
        ' 
        txtyear_level.Location = New Point(464, 163)
        txtyear_level.Name = "txtyear_level"
        txtyear_level.Size = New Size(177, 23)
        txtyear_level.TabIndex = 3
        ' 
        ' save_student
        ' 
        save_student.Location = New Point(338, 223)
        save_student.Name = "save_student"
        save_student.Size = New Size(303, 60)
        save_student.TabIndex = 4
        save_student.Text = "Save"
        save_student.UseVisualStyleBackColor = True
        ' 
        ' datagrid_students
        ' 
        datagrid_students.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        datagrid_students.Location = New Point(12, 326)
        datagrid_students.Name = "datagrid_students"
        datagrid_students.RowTemplate.Height = 25
        datagrid_students.Size = New Size(645, 279)
        datagrid_students.TabIndex = 5
        ' 
        ' capture_image
        ' 
        capture_image.Location = New Point(98, 223)
        capture_image.Name = "capture_image"
        capture_image.Size = New Size(139, 60)
        capture_image.TabIndex = 6
        capture_image.Text = "Capture Image"
        capture_image.UseVisualStyleBackColor = True
        ' 
        ' image
        ' 
        image.Location = New Point(81, 49)
        image.Name = "image"
        image.Size = New Size(174, 165)
        image.TabIndex = 7
        image.TabStop = False
        ' 
        ' add_student_form
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(669, 617)
        Controls.Add(image)
        Controls.Add(capture_image)
        Controls.Add(datagrid_students)
        Controls.Add(save_student)
        Controls.Add(txtyear_level)
        Controls.Add(txtcourse)
        Controls.Add(txtstudent_name)
        Controls.Add(txtstudent_number)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "add_student_form"
        Text = "New Student"
        CType(datagrid_students, ComponentModel.ISupportInitialize).EndInit()
        CType(image, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtstudent_number As TextBox
    Friend WithEvents txtstudent_name As TextBox
    Friend WithEvents txtcourse As TextBox
    Friend WithEvents txtyear_level As TextBox
    Friend WithEvents save_student As Button
    Friend WithEvents datagrid_students As DataGridView
    Friend WithEvents capture_image As Button
    Friend WithEvents image As PictureBox
End Class
