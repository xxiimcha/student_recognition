<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class home_page
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        add_student = New Button()
        detect_students = New Button()
        SuspendLayout()
        ' 
        ' add_student
        ' 
        add_student.Location = New Point(97, 124)
        add_student.Name = "add_student"
        add_student.Size = New Size(243, 73)
        add_student.TabIndex = 0
        add_student.Text = "Add Student"
        add_student.UseVisualStyleBackColor = True
        ' 
        ' detect_students
        ' 
        detect_students.Location = New Point(97, 250)
        detect_students.Name = "detect_students"
        detect_students.Size = New Size(243, 73)
        detect_students.TabIndex = 1
        detect_students.Text = "Detect Students"
        detect_students.UseVisualStyleBackColor = True
        ' 
        ' home_page
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(441, 459)
        Controls.Add(detect_students)
        Controls.Add(add_student)
        Name = "home_page"
        Text = "Home Page"
        ResumeLayout(False)
    End Sub

    Friend WithEvents add_student As Button
    Friend WithEvents detect_students As Button
End Class
