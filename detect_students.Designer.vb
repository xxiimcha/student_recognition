<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class detect_students
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblFaceDetectionStatus = New System.Windows.Forms.Label()
        Me.lblFaceRecognitionStatus = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(480, 360)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblFaceDetectionStatus
        '
        Me.lblFaceDetectionStatus.AutoSize = True
        Me.lblFaceDetectionStatus.Location = New System.Drawing.Point(510, 30)
        Me.lblFaceDetectionStatus.Name = "lblFaceDetectionStatus"
        Me.lblFaceDetectionStatus.Size = New System.Drawing.Size(120, 15)
        Me.lblFaceDetectionStatus.TabIndex = 1
        Me.lblFaceDetectionStatus.Text = "Face Detection Status"
        '
        'lblFaceRecognitionStatus
        '
        Me.lblFaceRecognitionStatus.AutoSize = True
        Me.lblFaceRecognitionStatus.Location = New System.Drawing.Point(510, 60)
        Me.lblFaceRecognitionStatus.Name = "lblFaceRecognitionStatus"
        Me.lblFaceRecognitionStatus.Size = New System.Drawing.Size(136, 15)
        Me.lblFaceRecognitionStatus.TabIndex = 2
        Me.lblFaceRecognitionStatus.Text = "Face Recognition Status"
        '
        'detect_students
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 411)
        Me.Controls.Add(Me.lblFaceRecognitionStatus)
        Me.Controls.Add(Me.lblFaceDetectionStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "detect_students"
        Me.Text = "Detect Students"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblFaceDetectionStatus As Label
    Friend WithEvents lblFaceRecognitionStatus As Label
End Class
