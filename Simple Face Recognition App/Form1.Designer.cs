namespace Simple_Face_Recognition_App
{
    partial class btnScale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetectFaces = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.btnDetectFaceFromIMG = new System.Windows.Forms.Button();
            this.btnNose = new System.Windows.Forms.Button();
            this.btnEye = new System.Windows.Forms.Button();
            this.btnRightEye = new System.Windows.Forms.Button();
            this.btnLeftEye = new System.Windows.Forms.Button();
            this.btnPupil = new System.Windows.Forms.Button();
            this.btnPutGlass = new System.Windows.Forms.Button();
            this.picViewZoomed = new System.Windows.Forms.PictureBox();
            this.btnZoomUpperBody = new System.Windows.Forms.Button();
            this.DetectEyebrows = new System.Windows.Forms.Button();
            this.btnDrawOutline = new System.Windows.Forms.Button();
            this.btnIris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picScale = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.picScale1 = new System.Windows.Forms.PictureBox();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.picScaleMid = new System.Windows.Forms.PictureBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViewZoomed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScaleMid)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(13, 414);
            this.picCapture.Margin = new System.Windows.Forms.Padding(4);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(242, 250);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(1077, 11);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(164, 28);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "1. Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetectFaces
            // 
            this.btnDetectFaces.Location = new System.Drawing.Point(1077, 48);
            this.btnDetectFaces.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetectFaces.Name = "btnDetectFaces";
            this.btnDetectFaces.Size = new System.Drawing.Size(164, 28);
            this.btnDetectFaces.TabIndex = 2;
            this.btnDetectFaces.Text = "2. Detect Faces";
            this.btnDetectFaces.UseVisualStyleBackColor = true;
            this.btnDetectFaces.Click += new System.EventHandler(this.btnDetectFaces_Click);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(1080, 279);
            this.txtPersonName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(161, 22);
            this.txtPersonName.TabIndex = 3;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(1077, 309);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(163, 28);
            this.btnTrain.TabIndex = 5;
            this.btnTrain.Text = "4. Train Images";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(1077, 345);
            this.btnRecognize.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(163, 28);
            this.btnRecognize.TabIndex = 6;
            this.btnRecognize.Text = "5. Recognize Persons";
            this.btnRecognize.UseVisualStyleBackColor = true;
            // 
            // picDetected
            // 
            this.picDetected.Location = new System.Drawing.Point(1077, 120);
            this.picDetected.Margin = new System.Windows.Forms.Padding(4);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(164, 151);
            this.picDetected.TabIndex = 7;
            this.picDetected.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(1077, 84);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(164, 28);
            this.btnAddPerson.TabIndex = 9;
            this.btnAddPerson.Text = "3. Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1080, 381);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1170, 381);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 84);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(1248, 11);
            this.btnLoadImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(176, 28);
            this.btnLoadImg.TabIndex = 11;
            this.btnLoadImg.Text = "Load Image";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnDetectFaceFromIMG
            // 
            this.btnDetectFaceFromIMG.Location = new System.Drawing.Point(1248, 48);
            this.btnDetectFaceFromIMG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetectFaceFromIMG.Name = "btnDetectFaceFromIMG";
            this.btnDetectFaceFromIMG.Size = new System.Drawing.Size(175, 39);
            this.btnDetectFaceFromIMG.TabIndex = 12;
            this.btnDetectFaceFromIMG.Text = "Detect the face";
            this.btnDetectFaceFromIMG.UseVisualStyleBackColor = true;
            this.btnDetectFaceFromIMG.Click += new System.EventHandler(this.btnDetectFaceFromIMG_Click);
            // 
            // btnNose
            // 
            this.btnNose.Location = new System.Drawing.Point(1248, 99);
            this.btnNose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNose.Name = "btnNose";
            this.btnNose.Size = new System.Drawing.Size(175, 43);
            this.btnNose.TabIndex = 13;
            this.btnNose.Text = "detect nose";
            this.btnNose.UseVisualStyleBackColor = true;
            this.btnNose.Click += new System.EventHandler(this.btnNose_Click);
            // 
            // btnEye
            // 
            this.btnEye.Location = new System.Drawing.Point(1249, 146);
            this.btnEye.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEye.Name = "btnEye";
            this.btnEye.Size = new System.Drawing.Size(175, 43);
            this.btnEye.TabIndex = 14;
            this.btnEye.Text = "Capture Eyes";
            this.btnEye.UseVisualStyleBackColor = true;
            this.btnEye.Click += new System.EventHandler(this.btnEye_Click);
            // 
            // btnRightEye
            // 
            this.btnRightEye.Location = new System.Drawing.Point(1249, 207);
            this.btnRightEye.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRightEye.Name = "btnRightEye";
            this.btnRightEye.Size = new System.Drawing.Size(77, 70);
            this.btnRightEye.TabIndex = 15;
            this.btnRightEye.Text = "Right Eye";
            this.btnRightEye.UseVisualStyleBackColor = true;
            this.btnRightEye.Click += new System.EventHandler(this.btnRightEye_Click);
            // 
            // btnLeftEye
            // 
            this.btnLeftEye.Location = new System.Drawing.Point(1346, 207);
            this.btnLeftEye.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLeftEye.Name = "btnLeftEye";
            this.btnLeftEye.Size = new System.Drawing.Size(77, 70);
            this.btnLeftEye.TabIndex = 16;
            this.btnLeftEye.Text = "Left Eye";
            this.btnLeftEye.UseVisualStyleBackColor = true;
            this.btnLeftEye.Click += new System.EventHandler(this.btnLeftEye_Click);
            // 
            // btnPupil
            // 
            this.btnPupil.Location = new System.Drawing.Point(1254, 285);
            this.btnPupil.Margin = new System.Windows.Forms.Padding(4);
            this.btnPupil.Name = "btnPupil";
            this.btnPupil.Size = new System.Drawing.Size(169, 85);
            this.btnPupil.TabIndex = 17;
            this.btnPupil.Text = "Detect Iris";
            this.btnPupil.UseVisualStyleBackColor = true;
            this.btnPupil.Click += new System.EventHandler(this.btnPupil_Click);
            // 
            // btnPutGlass
            // 
            this.btnPutGlass.Location = new System.Drawing.Point(1254, 377);
            this.btnPutGlass.Name = "btnPutGlass";
            this.btnPutGlass.Size = new System.Drawing.Size(169, 120);
            this.btnPutGlass.TabIndex = 18;
            this.btnPutGlass.Text = "Try a Glass";
            this.btnPutGlass.UseVisualStyleBackColor = true;
            this.btnPutGlass.Click += new System.EventHandler(this.btnPutGlass_Click);
            // 
            // picViewZoomed
            // 
            this.picViewZoomed.Location = new System.Drawing.Point(858, 643);
            this.picViewZoomed.Margin = new System.Windows.Forms.Padding(4);
            this.picViewZoomed.Name = "picViewZoomed";
            this.picViewZoomed.Size = new System.Drawing.Size(238, 217);
            this.picViewZoomed.TabIndex = 19;
            this.picViewZoomed.TabStop = false;
            // 
            // btnZoomUpperBody
            // 
            this.btnZoomUpperBody.Location = new System.Drawing.Point(1254, 503);
            this.btnZoomUpperBody.Name = "btnZoomUpperBody";
            this.btnZoomUpperBody.Size = new System.Drawing.Size(170, 61);
            this.btnZoomUpperBody.TabIndex = 20;
            this.btnZoomUpperBody.Text = "zoom";
            this.btnZoomUpperBody.UseVisualStyleBackColor = true;
            this.btnZoomUpperBody.Click += new System.EventHandler(this.btnZoomUpperBody_Click);
            // 
            // DetectEyebrows
            // 
            this.DetectEyebrows.Location = new System.Drawing.Point(1254, 570);
            this.DetectEyebrows.Name = "DetectEyebrows";
            this.DetectEyebrows.Size = new System.Drawing.Size(169, 50);
            this.DetectEyebrows.TabIndex = 21;
            this.DetectEyebrows.Text = "Detect Eye brows";
            this.DetectEyebrows.UseVisualStyleBackColor = true;
            this.DetectEyebrows.Click += new System.EventHandler(this.DetectEyebrows_Click);
            // 
            // btnDrawOutline
            // 
            this.btnDrawOutline.Location = new System.Drawing.Point(1077, 472);
            this.btnDrawOutline.Name = "btnDrawOutline";
            this.btnDrawOutline.Size = new System.Drawing.Size(160, 67);
            this.btnDrawOutline.TabIndex = 22;
            this.btnDrawOutline.Text = "draw outline";
            this.btnDrawOutline.UseVisualStyleBackColor = true;
            this.btnDrawOutline.Click += new System.EventHandler(this.btnDrawOutline_Click);
            // 
            // btnIris
            // 
            this.btnIris.Location = new System.Drawing.Point(1077, 545);
            this.btnIris.Name = "btnIris";
            this.btnIris.Size = new System.Drawing.Size(160, 39);
            this.btnIris.TabIndex = 23;
            this.btnIris.Text = "Detect Iris";
            this.btnIris.UseVisualStyleBackColor = true;
            this.btnIris.Click += new System.EventHandler(this.btnIris_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "your input";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // picScale
            // 
            this.picScale.Location = new System.Drawing.Point(394, 21);
            this.picScale.Margin = new System.Windows.Forms.Padding(4);
            this.picScale.Name = "picScale";
            this.picScale.Size = new System.Drawing.Size(288, 280);
            this.picScale.TabIndex = 25;
            this.picScale.TabStop = false;
            this.picScale.Click += new System.EventHandler(this.picScale_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Scaled image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(879, 623);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Zoomed Image";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(971, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 48);
            this.button1.TabIndex = 28;
            this.button1.Text = "Scale me";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1152, 665);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(99, 73);
            this.btnTest.TabIndex = 29;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // picScale1
            // 
            this.picScale1.Location = new System.Drawing.Point(46, 21);
            this.picScale1.Margin = new System.Windows.Forms.Padding(4);
            this.picScale1.Name = "picScale1";
            this.picScale1.Size = new System.Drawing.Size(288, 280);
            this.picScale1.TabIndex = 30;
            this.picScale1.TabStop = false;
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(1271, 667);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(103, 68);
            this.btnTest2.TabIndex = 31;
            this.btnTest2.Text = "test 2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // picScaleMid
            // 
            this.picScaleMid.Location = new System.Drawing.Point(331, 21);
            this.picScaleMid.Name = "picScaleMid";
            this.picScaleMid.Size = new System.Drawing.Size(67, 280);
            this.picScaleMid.TabIndex = 32;
            this.picScaleMid.TabStop = false;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(290, 308);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(264, 22);
            this.txt1.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "distance between scaled two eyes";
            // 
            // btnScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 843);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.picScaleMid);
            this.Controls.Add(this.btnTest2);
            this.Controls.Add(this.picScale1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIris);
            this.Controls.Add(this.btnDrawOutline);
            this.Controls.Add(this.DetectEyebrows);
            this.Controls.Add(this.btnZoomUpperBody);
            this.Controls.Add(this.picViewZoomed);
            this.Controls.Add(this.btnPutGlass);
            this.Controls.Add(this.btnPupil);
            this.Controls.Add(this.btnLeftEye);
            this.Controls.Add(this.btnRightEye);
            this.Controls.Add(this.btnEye);
            this.Controls.Add(this.btnNose);
            this.Controls.Add(this.btnDetectFaceFromIMG);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnDetectFaces);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "btnScale";
            this.Text = "Simple Face Recognition App";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picViewZoomed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScaleMid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetectFaces;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button btnDetectFaceFromIMG;
        private System.Windows.Forms.Button btnNose;
        private System.Windows.Forms.Button btnEye;
        private System.Windows.Forms.Button btnRightEye;
        private System.Windows.Forms.Button btnLeftEye;
        private System.Windows.Forms.Button btnPupil;
        private System.Windows.Forms.Button btnPutGlass;
        private System.Windows.Forms.PictureBox picViewZoomed;
        private System.Windows.Forms.Button btnZoomUpperBody;
        private System.Windows.Forms.Button DetectEyebrows;
        private System.Windows.Forms.Button btnDrawOutline;
        private System.Windows.Forms.Button btnIris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox picScale1;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.PictureBox picScaleMid;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label4;
    }
}

