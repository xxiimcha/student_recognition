<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class webcam_form
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
        student_image = New PictureBox()
        take_photo = New Button()
        CType(student_image, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' student_image
        ' 
        student_image.Location = New Point(105, 53)
        student_image.Name = "student_image"
        student_image.Size = New Size(607, 262)
        student_image.TabIndex = 0
        student_image.TabStop = False
        ' 
        ' take_photo
        ' 
        take_photo.Location = New Point(320, 346)
        take_photo.Name = "take_photo"
        take_photo.Size = New Size(150, 58)
        take_photo.TabIndex = 1
        take_photo.Text = "Take Photo"
        take_photo.UseVisualStyleBackColor = True
        ' 
        ' webcam_form
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(take_photo)
        Controls.Add(student_image)
        Name = "webcam_form"
        Text = "webcam_form"
        CType(student_image, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents student_image As PictureBox
    Friend WithEvents take_photo As Button
End Class
