Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class webcam_form
    Private webcam As FilterInfoCollection
    Private cam As VideoCaptureDevice

    Private Sub webcam_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the webcam collection
        webcam = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        ' Check if any webcam is detected
        If webcam.Count > 0 Then
            ' Create a video capture device using the first webcam detected
            cam = New VideoCaptureDevice(webcam(0).MonikerString)

            ' Try to set the desired resolution for the video capture device
            Dim resolution As VideoCapabilities = cam.VideoCapabilities.FirstOrDefault(Function(r) r.FrameSize.Width = 640 AndAlso r.FrameSize.Height = 480)
            If resolution IsNot Nothing Then
                cam.VideoResolution = resolution
            Else
                ' If the desired resolution is not supported, notify the user
                MessageBox.Show("Desired resolution not supported by this webcam.")
            End If

            ' Set the PictureBox's SizeMode to Zoom to show the entire image within the PictureBox bounds
            student_image.SizeMode = PictureBoxSizeMode.Zoom

            ' Add a handler to process each frame captured by the webcam
            AddHandler cam.NewFrame, AddressOf cam_NewFrame

            ' Start capturing video
            cam.Start()
        Else
            ' Notify the user if no webcam is detected
            MessageBox.Show("No webcam detected.")
        End If
    End Sub

    Private Sub cam_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        ' Capture each frame and assign it to the PictureBox
        Dim bitmap As Bitmap = CType(eventArgs.Frame.Clone(), Bitmap)
        Invoke(Sub()
                   student_image.Image = bitmap
               End Sub)
    End Sub

    Private Sub webcam_form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Safely stop and dispose of the video capture device
        If Not IsNothing(cam) AndAlso cam.IsRunning Then
            cam.SignalToStop()
            cam.WaitForStop()
        End If

        ' Dispose the video capture device to free up resources
        If Not IsNothing(cam) Then
            cam = Nothing
        End If
    End Sub

    Private Sub take_photo_Click(sender As Object, e As EventArgs) Handles take_photo.Click
        If Not IsNothing(student_image.Image) Then
            ' Save the captured image to a file
            student_image.Image.Save("capturedImage.jpg", Imaging.ImageFormat.Jpeg)
            MessageBox.Show("Image captured!")
            ' Close the form
            Me.Close()
        End If
    End Sub

End Class
