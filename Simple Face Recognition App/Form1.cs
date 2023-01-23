using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Emgu.CV.XFeatures2D;
using System.Security.Cryptography;
using ZedGraph;
using System.Drawing.Drawing2D;
using Emgu.CV.UI;
using LineType = Emgu.CV.CvEnum.LineType;

//using OpenCvSharp;
//using OpenCvSharp.cpP;
//using DlibDotNet;


namespace Simple_Face_Recognition_App
{
public partial class btnScale : Form
{
    #region Variables
    private Image<Bgr, byte> loadedImage;
    private CascadeClassifier cascadeClassifier;
    public Mat image;
    int testid = 0;
    private Capture videoCapture = null;
    private Image<Bgr, Byte> currentFrame = null;
    Mat frame = new Mat();
    private bool facesDetectionEnabled = false;
    CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_frontalface_alt.xml");
    Image<Bgr, Byte> faceResult = null;
    List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
    List<int> PersonsLabes = new List<int>();

    bool EnableSaveImage = false;
    private bool isTrained = false;
    EigenFaceRecognizer recognizer;
    List<string> PersonsNames = new List<string>();

    #endregion

    public btnScale()
    {
        InitializeComponent();
        cascadeClassifier = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_frontalface_alt.xml");
    }

    private void btnCapture_Click(object sender, EventArgs e)
    {
        //Dispose of Capture if it was created before
        if (videoCapture != null) videoCapture.Dispose();
        videoCapture = new Capture();
        //videoCapture.ImageGrabbed += ProcessFrame;
        Application.Idle += ProcessFrame;
        // videoCapture.Start();
    }

    private void ProcessFrame(object sender, EventArgs e)
    {
        //Step 1: Video Capture
        if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
        {
            videoCapture.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

            //Step 2: Face Detection
            if (facesDetectionEnabled)
            {

                //Convert from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                //Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                //If faces detected
                if (faces.Length > 0)
                {

                    foreach (var face in faces)
                    {
                        //Draw square around each face 
                        // CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                        //Step 3: Add Person 
                        //Assign the face to the picture Box face picDetected
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                        picDetected.Image = resultImage.Bitmap;

                        if (EnableSaveImage)
                        {
                            //We will create a directory if does not exists!
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            //we will save 10 images with delay a second for each image 
                            //to avoid hang GUI we will create a new task
                            Task.Factory.StartNew(() =>
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    //resize the image then saving it
                                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    Thread.Sleep(1000);
                                }
                            });

                        }
                        EnableSaveImage = false;

                        if (btnAddPerson.InvokeRequired)
                        {
                            btnAddPerson.Invoke(new ThreadStart(delegate
                            {
                                btnAddPerson.Enabled = true;
                            }));
                        }

                        // Step 5: Recognize the face 
                        if (isTrained)
                        {
                            Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);
                            pictureBox1.Image = grayFaceResult.Bitmap;
                            pictureBox2.Image = TrainedFaces[result.Label].Bitmap;
                            Debug.WriteLine(result.Label + ". " + result.Distance);
                            //Here results found known faces
                            if (result.Label != -1 && result.Distance < 2000)
                            {
                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                            }
                            //here results did not found any know faces
                            else
                            {
                                CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            }
                        }
                    }
                }
            }

            //Render the video capture into the Picture Box picCapture
            picCapture.Image = currentFrame.Bitmap;
        }

        //Dispose the Current Frame after processing it to reduce the memory consumption.
        if (currentFrame != null)
            currentFrame.Dispose();
    }

    private void btnDetectFaces_Click(object sender, EventArgs e)
    {
        facesDetectionEnabled = true;
    }

    private void btnAddPerson_Click(object sender, EventArgs e)
    {
        btnAddPerson.Enabled = false;
        EnableSaveImage = true;
    }

    private void btnTrain_Click(object sender, EventArgs e)
    {
        TrainImagesFromDir();
    }
    //Step 4: train Images .. we will use the saved images from the previous example 
    private bool TrainImagesFromDir()
    {
        int ImagesCount = 0;
        double Threshold = 2000;
        TrainedFaces.Clear();
        PersonsLabes.Clear();
        PersonsNames.Clear();
        try
        {
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
            string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                CvInvoke.EqualizeHist(trainedImage, trainedImage);
                TrainedFaces.Add(trainedImage);
                PersonsLabes.Add(ImagesCount);
                string name = file.Split('\\').Last().Split('_')[0];
                PersonsNames.Add(name);
                ImagesCount++;
                Debug.WriteLine(ImagesCount + ". " + name);

            }

            if (TrainedFaces.Count() > 0)
            {
                // recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
                recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                isTrained = true;
                //Debug.WriteLine(ImagesCount);
                //Debug.WriteLine(isTrained);
                return true;
            }
            else
            {
                isTrained = false;
                return false;
            }
        }
        catch (Exception ex)
        {
            isTrained = false;
            MessageBox.Show("Error in Train Images: " + ex.Message);
            return false;
        }

    }

    private void btnLoadImg_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            loadedImage = new Image<Bgr, byte>(openFileDialog.FileName);
            picCapture.Image = loadedImage.Bitmap;
            ZoomOutAndShowInPictureBox(picViewZoomed);

            // Set the PictureBox's SizeMode property to Zoom
            picCapture.SizeMode = PictureBoxSizeMode.Zoom;

        }

        //ZoomUpperBody(loadedImage);
        // picViewZoomed.Image = loadedImage.Bitmap;
    }


    //face detection code
    private void DetectFaces(Image<Bgr, byte> image)
    {
        using (var gray = new Mat())
        {
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(gray, gray);

            Rectangle[] faces = cascadeClassifier.DetectMultiScale(gray, 1.1, 10, Size.Empty);
            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new Bgr(0, double.MaxValue, 0).MCvScalar, 2);
            }
        }
    }

    private void btnDetectFaceFromIMG_Click(object sender, EventArgs e)
    {

        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DetectFaces(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }
    }


    //test method to detect the nose
    private void btnNose_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DetectNose(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }
    }

    //test method to detect the nose
    private void DetectNose(Image<Bgr, byte> image)
    {
        using (var gray = new Mat())
        {
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

            var noseCascade = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_mcs_nose_Other_.xml");
            Rectangle[] noses = noseCascade.DetectMultiScale(gray, 1.1, 10, Size.Empty);
            foreach (Rectangle nose in noses)
            {
                CvInvoke.Rectangle(image, nose, new Bgr(0, double.MaxValue, 0).MCvScalar, 2);
            }
        }
    }


    //test method to detect eyes
    //button click
    private void btnEye_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DetectEyes(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }
    }


    //driver code
    private void DetectEyes(Image<Bgr, byte> image)
    {
        using (var gray = new Mat())
        {
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

            var eyesCascade = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_eye.xml");
            Rectangle[] eyes = eyesCascade.DetectMultiScale(gray, 1.1, 10, Size.Empty);
            foreach (Rectangle eye in eyes)
            {
                CvInvoke.Rectangle(image, eye, new Bgr(0, double.MaxValue, 0).MCvScalar, 2);
            }
        }
    }


    //*****test code for detecting right eye****//

    //button click
    private void btnRightEye_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DetectRightEye(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }
    }

    //driver code
    private void DetectRightEye(Image<Bgr, byte> image)
    {
        using (var gray = new Mat())
        {
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

            var eyesCascade = new CascadeClassifier(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_righteye_2splits.xml");
            Rectangle[] eyes = eyesCascade.DetectMultiScale(gray, 1.1, 10, Size.Empty);
            foreach (Rectangle eye in eyes)
            {
                CvInvoke.Rectangle(image, eye, new Bgr(0, double.MaxValue, 0).MCvScalar, 2);
            }
        }
    }


    //******detecting left eye******//
    private void btnLeftEye_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DetectLeftEye(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }

    }

    //driver code
    private void DetectLeftEye(Image<Bgr, byte> image)
    {
        using (var gray = new Mat())
        {
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

            var eyesCascade = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_lefteye_2splits.xml");
            Rectangle[] eyes = eyesCascade.DetectMultiScale(gray, 1.1, 10, Size.Empty);
            foreach (Rectangle eye in eyes)
            {
                CvInvoke.Rectangle(image, eye, new Bgr(0, double.MaxValue, 0).MCvScalar, 2);
            }
        }
    }


    //test method to detect the iris
    private void btnPupil_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DetectPupil(loadedImage);
            //  picCapture.Image = loadedImage.Bitmap;
            picScale.Image = loadedImage.Bitmap;
        }
    }

    //driver code for detect iris
    private void DetectPupil(Image<Bgr, byte> image)
    {
        using (var gray = new Mat())
        {
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

            var circles = CvInvoke.HoughCircles(gray, HoughType.Gradient, 1, 20, 100, 50, 0, 0);
            foreach (CircleF circle in circles)
            {
                CvInvoke.Circle(image, Point.Round(circle.Center), (int)circle.Radius, new Bgr(0, double.MaxValue, 0).MCvScalar, 2);
            }
        }
    }


    //testing method for add a glass
    private void btnPutGlass_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            //  PutSunglass(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }
    }

    //driver method for adding glassess

    //private void PutSunglass(Image<Bgr, byte> image)
    //{
    //    // Load the sunglasses image
    //    Image<Bgr, byte> sunglasses = new Image<Bgr, byte>(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Images\\frames.png");
    //    // Detect the face in the image
    //    var faceCascade = new CascadeClassifier("@C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_frontalface_default.xml");
    //    Rectangle[] faces = faceCascade.DetectMultiScale(image, 1.1, 10, Size.Empty);
    //    foreach (Rectangle face in faces)
    //    {
    //        // Scale the sunglasses to the size of the detected face
    //        sunglasses = sunglasses.Resize(face.Width, face.Height, Inter.Linear);
    //        // Create a mask for the sunglasses
    //        Image<Gray, byte> mask = new Image<Gray, byte>(sunglasses.Size);
    //        mask.SetValue(new Gray(255));
    //        // Place the sunglasses on the face
    //        image.ROI = face;
    //        image.Copy(sunglasses, mask);
    //        image.ROI = Rectangle.Empty;
    //    }
    //}


    /******method to zoom image***/
    //Image ZoomPicture(Image img, Size size)
    // {
    //     Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width),
    //         Convert.ToInt32(img.Height * size.Height));
    //     Graphics gpu = Graphics.FromImage(bm);
    //     gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    //     return bm;
    // }

    private void ZoomUpperBody(Image<Bgr, byte> image)
    {
        var upperBodyCascade = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_upperbody.xml");
        Rectangle[] upperBodies = upperBodyCascade.DetectMultiScale(image, 1.1, 10, Size.Empty);
        foreach (Rectangle upperBody in upperBodies)
        {
            // Load the original image
            Image originalImage = Image.FromFile("path/to/image.jpg");

            // Create a new Bitmap to hold the zoomed image
            Bitmap zoomedImage = new Bitmap(originalImage.Width * 2, originalImage.Height * 2);

            // Create a Graphics object from the Bitmap
            Graphics g = Graphics.FromImage(zoomedImage);

            // Set the interpolation mode to high quality
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Define the portion of the original image to zoom in on
            Rectangle srcRect = new Rectangle(0, 0, originalImage.Width, originalImage.Height / 2);

            // Draw the zoomed portion of the original image onto the new Bitmap
            g.DrawImage(originalImage, new Rectangle(0, 0, zoomedImage.Width, zoomedImage.Height), srcRect, GraphicsUnit.Pixel);

            // Display the zoomed image in the new PictureBox
            picViewZoomed.Image = zoomedImage;
        }
    }


        
    private void btnZoomUpperBody_Click(object sender, EventArgs e)
    {
            
    }

    private void DetectEyebrows_Click(object sender, EventArgs e)
    {

        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            // Convert the image to grayscale
            Image<Gray, byte> grayImage = loadedImage.Convert<Gray, byte>();

            // Detect the face in the image using the CascadeClassifier
            CascadeClassifier faceCascade = new CascadeClassifier(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_frontalface_default.xml");
            Rectangle[] faces = faceCascade.DetectMultiScale(grayImage, 1.1, 3, new Size(20, 20));

            // Draw a rectangle around the face
            foreach (Rectangle face in faces)
            {
                loadedImage.Draw(face, new Bgr(Color.Blue), 2);
                Bitmap faceBitmap = loadedImage.ToBitmap();
                // Create a new bitmap to hold the face
                Bitmap faceWithEyebrow = new Bitmap(face.Width, face.Height);
                Graphics g = Graphics.FromImage(faceWithEyebrow);
                g.DrawImage(faceBitmap, 0, 0, face, GraphicsUnit.Pixel);

                // Convert the face image to grayscale
                Image<Gray, byte> grayFace = new Image<Gray, byte>(faceWithEyebrow);

                // Detect the eyebrows in the face image using the CascadeClassifier
                CascadeClassifier eyebrowCascade = new CascadeClassifier(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_mcs_eyepair_big.xml");
                Rectangle[] eyebrows = eyebrowCascade.DetectMultiScale(grayFace, 1.1, 3, new Size(20, 20));

                // Draw a rectangle around the eyebrows
                foreach (Rectangle eyebrow in eyebrows)
                {
                    loadedImage.Draw(eyebrow, new Bgr(Color.Green), 2);
                }
            }
            // Display the image with the detected eyebrows in the PictureBox
            picCapture.Image = loadedImage.ToBitmap();
        }
    }

    private void btnDrawOutline_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
            DrawOutline(loadedImage);
            picCapture.Image = loadedImage.Bitmap;
        }
    }


    //driver code
    private void DrawOutline(Image<Bgr, byte> image)
    {
        var faceCascade = new CascadeClassifier(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_frontalface_default.xml");
        Rectangle[] faces = faceCascade.DetectMultiScale(image, 1.1, 10, Size.Empty);
        foreach (Rectangle face in faces)
        {
            Point[] points = new Point[] {
        new Point(face.Left, face.Top),
        new Point(face.Right, face.Top),
        new Point(face.Right, face.Bottom),
        new Point(face.Left, face.Bottom),
        new Point(face.Left, face.Top)
    };
            float[] dashValues = { 5, 2 };
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                pen.DashPattern = dashValues;
                image.DrawPolyline(points, true, new Bgr(Color.Blue), 2, LineType.EightConnected);
            }
        }
    }

    //test method for detect pupil
    private void btnIris_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else
        {
                
                
                  
                DetectIris(loadedImage.Convert<Gray, byte>());
                picViewZoomed.Image = loadedImage.Bitmap;
        }
    }

    //driver code
    private void DetectIris(Image<Gray, byte> image)
    {
        var faceCascade = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_eye.xml");
        Rectangle[] eyes = faceCascade.DetectMultiScale(image, 1.1, 10, Size.Empty);
        foreach (Rectangle eye in eyes)
        {
            Image<Gray, byte> eyeROI = image.GetSubRect(eye);
            CircleF[] pupil = CvInvoke.HoughCircles(eyeROI, HoughType.Gradient, 2.0, eyeROI.Width / 4, 100, 30, 1, 30);
            foreach (CircleF p in pupil)
            {
                image.Draw(p, new Gray(255), 2);
            }
        }
    }



    //test method to zoom the image
    public void ZoomOutAndShowInPictureBox(PictureBox imageBox)
    {
        // Convert the image to a bitmap
        Bitmap originalBitmap = loadedImage.ToBitmap();

        // Define the crop rectangle
        // Change the values to adjust the size and position of the crop
        Rectangle cropRect = new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height / 2);
        Bitmap croppedBitmap = originalBitmap.Clone(cropRect, originalBitmap.PixelFormat);

        // Create a new bitmap with the desired size
        Bitmap zoomedBitmap = new Bitmap(croppedBitmap, new Size(croppedBitmap.Width * 2, croppedBitmap.Height * 2));

        // Display the zoomed image in the PictureBox
        imageBox.Image = zoomedBitmap;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (loadedImage == null)
        {
            MessageBox.Show("Please upload an image first.");
        }
        else {
            // Define the scale factor
            float scaleFactor = 50f;

            // Scale the image
            var scaledImage = loadedImage.Resize(scaleFactor, Emgu.CV.CvEnum.Inter.Linear);

            // Convert the Emgu CV image to a Bitmap
            var bitmap = scaledImage.ToBitmap();

            // Set the PictureBox's SizeMode property to Zoom
            picScale.SizeMode = PictureBoxSizeMode.Zoom;

            // Display the scaled image in the PictureBox
            picScale.Image = bitmap;
        }
            
    }


   /*test method for get the image from the user, then detect the upper body part. 
    * After that detect the face from upper body part.\
    * Then scale the face and finally display the output...
    */
        
    private void btnTest_Click(object sender, EventArgs e)
    {
            // Load the Haar cascade classifier for periorbital region detection
            var periorbitalClassifier = new CascadeClassifier(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_eye_tree_eyeglasses_default.xml");

            // Detect periorbital region in the image
            Rectangle[] periorbital = periorbitalClassifier.DetectMultiScale(loadedImage, 1.1, 10);
           
            

            // Check if any periorbital region is detected
            if (periorbital.Length > 0)
            {
                // Get the bounding rectangle of the first detected periorbital region
                Rectangle periorbitalRect = periorbital[0];
                int i = 0;
                foreach (Rectangle periorbitalRectOne in periorbital)
                {

                    // Crop the periorbital region from the image
                    Image<Bgr, byte> croppedPeriorbital = loadedImage.GetSubRect(periorbitalRectOne);

                    // Scale the cropped periorbital region by 2 times
                    Image<Bgr, byte> scaledPeriorbital = croppedPeriorbital.Resize(3.0, Inter.Linear);


                    // Display the scaled periorbital region in the first PictureBox
                    if (i == 0)
                    {
                        picScale.Image = scaledPeriorbital.Bitmap;
                        Debug.WriteLine("methnata AWAAAAA!!!");
                    }
                    // Display the scaled periorbital region in the second PictureBox
                    else if (i == 1)
                    {
                        picScale1.Image = scaledPeriorbital.Bitmap;
                        Debug.WriteLine("dan  methanta  AWAAAAA!!!");

                    }
                    i++;

                  //  Debug.WriteLine("AWAAAAA!!!");

                }
               
            }
            else
            {
                MessageBox.Show("Periorbital region not found in the image.");
            }
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {

            Rectangle leftEyeRect = new Rectangle();
            Rectangle rightEyeRect = new Rectangle();
            Rectangle nose = new Rectangle();

            Image<Gray, byte> grayLoadedImage = loadedImage.Convert<Gray, byte>();
            // Detect the periorbital region
            using (CascadeClassifier periorbitalDetector = new CascadeClassifier(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Haarcascadefiles\\haarcascade_eye_tree_eyeglasses_default.xml"))
           using (CascadeClassifier noseDetector = new CascadeClassifier(@"C:\GSIT2023 projects\sample projects\iFace\2\Simple-Face-Recognition-App-CS-master\Simple-Face-Recognition-App-CS-master\Simple Face Recognition App\Haarcascadefiles\haarcascade_mcs_nose_Other_ - Copy.xml"))
            {
                Rectangle[] periorbital = periorbitalDetector.DetectMultiScale(grayLoadedImage, 1.1, 5);
                // Iterate over all the periorbital regions
                foreach (Rectangle periorbitalRect in periorbital)
                {
                    // Check if the periorbital region is the left eye
                    if (periorbitalRect.X < loadedImage.Width / 2)
                    {
                        leftEyeRect = periorbitalRect;
                    }
                    // Check if the periorbital region is the right eye
                    else
                    {
                        rightEyeRect = periorbitalRect;
                    }
                }

                nose = noseDetector.DetectMultiScale(grayLoadedImage, 1.1, 5).FirstOrDefault();
            }
            // Crop and scale the left eye
            Image<Bgr, byte> croppedLeftEye = loadedImage.GetSubRect(leftEyeRect);
            Image<Bgr, byte> scaledLeftEye = croppedLeftEye.Resize(4.0, Inter.Linear);

            // Crop and scale the right eye
            Image<Bgr, byte> croppedRightEye = loadedImage.GetSubRect(rightEyeRect);
            Image<Bgr, byte> scaledRightEye = croppedRightEye.Resize(4.0, Inter.Linear);

            //// Crop and scale the nose
            Image<Bgr, byte> croppedNose = loadedImage.GetSubRect(nose);
            Image<Bgr, byte> scaledNose = croppedNose.Resize(2.0, Inter.Linear);

            // Display the scaled left eye in the first PictureBox
            picScale1.Image = scaledLeftEye.Bitmap;

            //// Display the scaled nose in the middle PictureBox
            picScaleMid.Image = scaledNose.Bitmap;

            // Display the scaled right eye in the second PictureBox
            picScale.Image = scaledRightEye.Bitmap;


            // Calculate the distance between the eyes
            PointF leftEye = new PointF(leftEyeRect.X + (leftEyeRect.Width / 2), leftEyeRect.Y + (leftEyeRect.Height / 2));
            PointF rightEye = new PointF(rightEyeRect.X + (rightEyeRect.Width / 2), rightEyeRect.Y + (rightEyeRect.Height / 2));
            double distance = Math.Sqrt(Math.Pow(leftEye.X - rightEye.X, 2) + Math.Pow(leftEye.Y - rightEye.Y, 2));
            double scaledDistance = distance * 2.0;
         //   double distanceBetWeenEyes = CvInvoke.Distance(leftEye, rightEye);




            // Adjust the space between the PictureBoxes to match the distance between the eyes
            //picScale1.Location = new Point(20, 20);
            //picScale.Location = new Point((int)(20 + scaledRightEye.Width + distance), 20);
            //picScaleMid.Location = new Point((int)(20 + scaledLeftEye.Width + (scaledRightEye.Width / 2)), (int)(20 + scaledLeftEye.Height));


            picScale1.Location = new Point(0, 0);
            picScaleMid.Location = new Point((int)(scaledDistance + 10), 0);

            //This line of code will set the width of the ImageBox2 to the value of the scaledDistance. 
            picScaleMid.Width = (int)scaledDistance;
            picScale.Location = new Point((int)(scaledDistance + picScale1.Width + 20), 0);


            //display the distance between two eyes
            double distanceInMM = distance * 0.264583;
            txt1.Text = distanceInMM.ToString() + " mm";
           



        }

        private void picScale_Click(object sender, EventArgs e)
        {

        }


        //test method to detect the gabella
        //private Point DetectGlabella(Array2DBase image)
        //{
        //    // Load the pre-trained model for detecting facial feature points
        //    var shapePredictor = new ShapePredictor(@"path/to/shape_predictor_68_face_landmarks.dat");

        //    // Detect face and facial feature points
        //    var face = shapePredictor.Detect(image);
        //    var shape = shapePredictor.Detect(image, face);

        //    // Find the point on the face that corresponds to the glabella
        //    Point glabella = new Point();
        //    if (shape.Parts > 0)
        //    {
        //        glabella = shape.GetPart((uint)Dlib.Dlib.NamedFaceLandmark.LEye);
        //    }
        //    return glabella;
        //}
        private void btnGabella_Click(object sender, EventArgs e)
        {
           // PointF glabella = DetectGlabella(loadedImage);
           // textBox1.Text = glabella.ToString();
        }

        private void DetectPupilIrisEyelidsButton_Click(object sender, EventArgs e)
        {
            if (loadedImage == null)
            {
                MessageBox.Show("Please upload an image first.");
            }
            else
            {
                // Load the image into a Mat object
                // Mat image = CvInvoke.Imread(@"C:\\GSIT2023 projects\\sample projects\\iFace\\2\\Simple-Face-Recognition-App-CS-master\\Simple-Face-Recognition-App-CS-master\\Simple Face Recognition App\\Images\\1.png", LoadImageType.Color);

                Mat image = new Mat();
                image = loadedImage.Mat;


                // Convert the image to grayscale
                CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);

                // Detect the pupils in the image using Hough Circle Transform
                CircleF[] pupils = CvInvoke.HoughCircles(image, HoughType.Gradient, 2.0, 20.0, 50, 100);
                foreach (CircleF pupil in pupils)
                {
                    // Draw a circle around the detected pupil
                    CvInvoke.Circle(image, Point.Round(pupil.Center), (int)pupil.Radius, new MCvScalar(0, 0, 255), 2);
                }

                // Detect the iris and eyelids in the image using a Haar Cascade classifier
                using (CascadeClassifier irisEyelidClassifier = new CascadeClassifier("iris_eyelid_classifier.xml"))
                {
                    Rectangle[] irisEyelids = irisEyelidClassifier.DetectMultiScale(image, 1.2, 3, new Size(20, 20));
                    foreach (Rectangle irisEyelid in irisEyelids)
                    {
                        // Draw a rectangle around the detected iris and eyelid
                        CvInvoke.Rectangle(image, irisEyelid, new MCvScalar(0, 255, 0), 2);
                    }
                }

                // Show the processed image in a picture box
                //Bitmap bmp = iris.Bitmap;
                //IrisPictureBox.Image = bmp;

                picScaleMid.Image = image.Bitmap;
            }
        }

        private void btnEyeArea_Click(object sender, EventArgs e)
        {
           
        }
    }


   


}
