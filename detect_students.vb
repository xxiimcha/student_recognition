Imports Emgu.CV
Imports Emgu.CV.Structure
Imports Emgu.CV.CvEnum
Imports System.Drawing
Imports System.IO
Imports MySql.Data.MySqlClient
Imports Emgu.CV.Face

Public Class detect_students
    Private WithEvents capture As VideoCapture
    Private detector As CascadeClassifier
    Private recognizer As FaceRecognizer

    Private Sub detect_students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize the capture device (webcam by default)
            capture = New VideoCapture()

            ' Load the face detection model
            detector = New CascadeClassifier(Application.StartupPath & "\haarcascades\haarcascade_frontalface_default.xml")

            ' Load the face recognition model (e.g., LBPHFaceRecognizer)
            recognizer = New LBPHFaceRecognizer()

            ' Load pre-trained data from the database
            LoadTrainedData()

            ' Start the capture process (begin capturing frames from the webcam)
            capture.Start()
        Catch ex As Exception
            MessageBox.Show("An error occurred while starting the video capture. Please check your camera and try again." & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub capture_ImageGrabbed(sender As Object, e As EventArgs) Handles capture.ImageGrabbed
        ProcessFrame(sender, e)
    End Sub

    Private Sub ProcessFrame(sender As Object, e As EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of Object, EventArgs)(AddressOf ProcessFrame), sender, e)
            Return
        End If

        Try
            Using frame As Mat = New Mat()
                capture.Retrieve(frame, 0)
                If Not frame.IsEmpty Then
                    Using grayFrame As Mat = New Mat()
                        CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray)
                        CvInvoke.EqualizeHist(grayFrame, grayFrame)
                        Dim faces = detector.DetectMultiScale(grayFrame)
                        lblFaceDetectionStatus.Text = If(faces.Length > 0, "Face(s) detected!", "No faces detected.")
                        For Each face As Rectangle In faces
                            CvInvoke.Rectangle(frame, face, New MCvScalar(0, 255, 0), 2)

                            ' Recognize the face
                            Dim faceImage As Mat = New Mat(grayFrame, face)
                            Dim result As FaceRecognizer.PredictionResult = recognizer.Predict(faceImage)
                            Dim label As Integer = result.Label
                            Dim confidence As Double = result.Distance
                            If confidence < 100 Then ' Adjust threshold as needed
                                lblFaceRecognitionStatus.Text = $"Face recognized with label: {label} and confidence: {confidence}"
                                ' Check if the face is registered in the database
                                If IsFaceRegistered(label) Then
                                    lblFaceRecognitionStatus.Text &= " - Registered"
                                Else
                                    lblFaceRecognitionStatus.Text &= " - Not Registered"
                                End If
                            Else
                                lblFaceRecognitionStatus.Text = "Face not recognized"
                            End If
                        Next
                        PictureBox1.Image = frame.ToImage(Of Bgr, Byte).ToBitmap()
                        PictureBox1.Refresh() ' Force the PictureBox to refresh
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while processing the frame: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadTrainedData()
        ' Connect to the database and load face data for training the recognizer
        Dim connectionString As String = "server=localhost;username=root;password='';database=student_recognition"
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim command As New MySqlCommand("SELECT id, student_image FROM students", connection)
            Using reader As MySqlDataReader = command.ExecuteReader()
                Dim labels As New List(Of Integer)()
                Dim faceImages As New List(Of Mat)()
                While reader.Read()
                    labels.Add(reader.GetInt32("id"))
                    Dim faceData As Byte() = CType(reader("student_image"), Byte())
                    Using ms As New MemoryStream(faceData)
                        Dim bmp As New Bitmap(ms)
                        Dim faceImage As Image(Of Gray, Byte) = bmp.ToImage(Of Gray, Byte)()
                        faceImages.Add(faceImage.Mat)
                    End Using
                End While
                recognizer.Train(faceImages.ToArray(), labels.ToArray())
            End Using
        End Using
    End Sub
    Private Function IsFaceRegistered(label As Integer) As Boolean
        ' Check if the recognized face label is registered in the database
        Dim isRegistered As Boolean = False
        Dim connectionString As String = "server=localhost;username=root;password='';database=student_recognition"
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim command As New MySqlCommand("SELECT COUNT(*) FROM students WHERE id = @Label", connection)
            command.Parameters.AddWithValue("@Label", label)
            Dim count As Integer = CInt(command.ExecuteScalar())
            isRegistered = (count > 0)
        End Using
        Return isRegistered
    End Function

    ' Release resources when the form is closing
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If capture IsNot Nothing Then
            capture.Stop()
            capture.Dispose()
        End If
        If detector IsNot Nothing Then
            detector.Dispose()
        End If
        If recognizer IsNot Nothing Then
            recognizer.Dispose()
        End If
    End Sub
End Class
