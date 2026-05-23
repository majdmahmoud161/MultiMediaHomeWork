using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using Emgu.CV.Util;

namespace MultiMediaProject
{
    public partial class Form1 : Form
    {

        Bitmap originalImage;
        
        private PictureBox pictureBoxCube;
        private PictureBox pictureBoxHsv;
        private PictureBox pictureBoxYCrCb;


        private Bitmap hsvBitmapCache;
        private Bitmap ycrcbBitmapCache;



        private Bitmap cubeBitmapCache;

        private const int cubeSize = 12;


        private double angleX = 0.45;
        private double angleY = 0.65;
        private double zoomScale = 0.80;
        private bool isDragging = false;
        private Point lastMousePosition;


        public Form1()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;

        }
        //تحميل الصورة من  اللابتوب عالبرنامج
        private void button1_Click(object sender, EventArgs e)
        {


            OpenFileDialog openfiledealog = new OpenFileDialog();
            if (openfiledealog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openfiledealog.FileName);
                pictureBox1.Image = originalImage;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            //يعني عم قول للويندوز الملف اللي ماسكتو الفارة مسموح ينحط بمكان البكتشر بوكس
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            //عم ناخد بيانات الصورة اللي جبناها من اللابتوب وزتيناها بالمكان الصح
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                //عم نخزن معلومات الصورة ب مصفوفة سترنغات ضمن الفايل نيم
                var filename = data as string[];
                if (filename.Length > 0)
                {
                    pictureBox1.Image = Image.FromFile(filename[0]);
                }



            }

        }
        //convert to HSV
        private void button2_Click(object sender, EventArgs e)
        {


            Bitmap image = new Bitmap(originalImage);

            Mat rgbImage = image.ToMat();

            Mat HsvImage = new Mat();

            CvInvoke.CvtColor(rgbImage, HsvImage, ColorConversion.Bgr2Hsv);

            pictureBox1.Image = HsvImage.ToBitmap();

        }
        //convert to YCrCb
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(originalImage);

            Mat rgbImage = image.ToMat();

            Mat HsvImage = new Mat();

            CvInvoke.CvtColor(rgbImage, HsvImage, ColorConversion.Bgr2YCrCb);

            pictureBox1.Image = HsvImage.ToBitmap();
        }
        //convert to YUV
        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(originalImage);

            Mat rgbImage = image.ToMat();

            Mat HsvImage = new Mat();

            CvInvoke.CvtColor(rgbImage, HsvImage, ColorConversion.Bgr2Yuv);

            pictureBox1.Image = HsvImage.ToBitmap();

        }
        //convert to LAB
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(originalImage);

            Mat rgbImage = image.ToMat();

            Mat HsvImage = new Mat();

            CvInvoke.CvtColor(rgbImage, HsvImage, ColorConversion.Bgr2Lab);

            pictureBox1.Image = HsvImage.ToBitmap();

        }

        // التحويل إلى نظام CMY (المستخدم للوصول لـ CMYK)
        private void button6_Click(object sender, EventArgs e)
        {


            // 1. إنشاء صورة فارغة بنفس أبعاد الصورة الأصلية لتخزين النتيجة
            Bitmap cmyImage = new Bitmap(originalImage);

            // 2. استخدام حلقات For للمرور على كل بكسل (طولاً وعرضاً)
            for (int i = 0; i < originalImage.Height; i++)
            {
                for (int j = 0; j < originalImage.Width; j++)
                {
                    // الحصول على لون البكسل الحالي من الصورة الأصلية
                    Color pixelColor = originalImage.GetPixel(j, i);

                    // حساب قيم CMY (طرح قيم RGB من 255)
                    // Cyan = 255 - Red
                    // Magenta = 255 - Green
                    // Yellow = 255 - Blue
                    int c = 255 - pixelColor.R;
                    int m = 255 - pixelColor.G;
                    int y = 255 - pixelColor.B;

                    // إنشاء اللون الجديد باستخدام القيم المحسوبة
                    Color cmyColor = Color.FromArgb(c, m, y);

                    // وضع اللون الجديد في الصورة الناتجة
                    cmyImage.SetPixel(j, i, cmyColor);
                }
            }

            // 3. عرض النتيجة في الـ PictureBox
            pictureBox1.Image = cmyImage;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ApplyChannels();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ApplyChannels();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ApplyChannels();
        }

        private void ApplyChannels()
        {
            if (originalImage == null) return;

            Mat bgrImage = originalImage.ToMat();

            Mat[] channels = bgrImage.Split();

            // Blue channel
            if (checkBox3.Checked)
                channels[0].SetTo(new MCvScalar(0));

            // Green channel
            if (checkBox2.Checked)
                channels[1].SetTo(new MCvScalar(0));

            // Red channel
            if (checkBox1.Checked)
                channels[2].SetTo(new MCvScalar(0));

            Mat result = new Mat();

            CvInvoke.Merge(new Emgu.CV.Util.VectorOfMat(channels), result);

            pictureBox1.Image = result.ToBitmap();
        }
    

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            Mat img = originalImage.ToMat();

            Mat result = new Mat();

            int brightness = trackBar1.Value;
            // تعديل السطوع بسرعة
            img.ConvertTo(result, DepthType.Cv8U, 1, brightness);

            pictureBox1.Image = result.ToBitmap();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (originalImage == null) return;

            // 1. تحويل الصورة إلى مصفوفة Mat
            Mat bgrImage = originalImage.ToMat();

            // 2. فصل القنوات الثلاث كصور رمادية
            Mat[] channels = bgrImage.Split();

            // 3. إنشاء صورة سوداء فارغة لتعويض القنوات الملغاة
            Mat blank = new Mat(bgrImage.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            blank.SetTo(new Emgu.CV.Structure.MCvScalar(0));

            // --- تشكيل وعرض الصورة الحمراء (R) ---
            // OpenCV ترتيبها (B, G, R). سنضع الأحمر في مكانه والأزرق والأخضر كأصفار
            Mat redImage = new Mat();
            CvInvoke.Merge(new Emgu.CV.Util.VectorOfMat(blank, blank, channels[2]), redImage);
            pictureBox2.Image = redImage.ToBitmap();

            // --- تشكيل وعرض الصورة الخضراء (G) ---
            Mat greenImage = new Mat();
            CvInvoke.Merge(new Emgu.CV.Util.VectorOfMat(blank, channels[1], blank), greenImage);
            pictureBox3.Image = greenImage.ToBitmap();

            // --- تشكيل وعرض الصورة الزرقاء (B) ---
            Mat blueImage = new Mat();
            CvInvoke.Merge(new Emgu.CV.Util.VectorOfMat(channels[0], blank, blank), blueImage);
            pictureBox4.Image = blueImage.ToBitmap();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxCube = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            };
            panel1.Controls.Add(pictureBoxCube);

            pictureBoxCube.MouseDown += PictureBoxCube_MouseDown;

            pictureBoxCube.MouseMove += PictureBoxCube_MouseMove;
            pictureBoxCube.MouseUp += PictureBoxCube_MouseUp;
            pictureBoxCube.MouseWheel += PictureBoxCube_MouseWheel;


            pictureBoxCube.MouseClick += PictureBoxCube_MouseClick;


            RenderCubeInPanel();
        }

        private void PictureBoxCube_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
        }

        private void PictureBoxCube_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {

                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;


                angleY += deltaX / 200.0;
                angleX += deltaY / 200.0;


                lastMousePosition = e.Location;


                RenderCubeInPanel();

                RenderYCrCbShape();

                RenderHSVCylinder();
            }
        }

        private void PictureBoxCube_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void PictureBoxCube_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
                zoomScale += 0.03;
            else
                zoomScale -= 0.03;

            RenderCubeInPanel();

            RenderHSVCylinder();

            RenderYCrCbShape();
        }
        private void RenderCubeInPanel()
        {

            int width = panel1.Width;
            int height = panel1.Height;

            using (Image<Bgr, byte> canvas = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0)))
            {
                int centerX = width / 2;
                int centerY = height / 2;
                double scale = width * zoomScale;

                double cosX = Math.Cos(angleX), sinX = Math.Sin(angleX);
                double cosY = Math.Cos(angleY), sinY = Math.Sin(angleY);


                for (int r = 0; r < cubeSize; r++)
                {
                    for (int g = 0; g < cubeSize; g++)
                    {
                        for (int b = 0; b < cubeSize; b++)
                        {

                            double x = (double)r / (cubeSize - 1) - 0.5;
                            double y = (double)g / (cubeSize - 1) - 0.5;
                            double z = (double)b / (cubeSize - 1) - 0.5;


                            double y1 = y * cosX - z * sinX;
                            double z1 = y * sinX + z * cosX;

                            double x2 = x * cosY + z1 * sinY;
                            double z2 = -x * sinY + z1 * cosY;


                            double distance = 2.0;
                            double projectionScale = scale / (distance + z2);

                            int screenX = centerX + (int)(x2 * projectionScale);
                            int screenY = centerY + (int)(y1 * projectionScale);


                            byte colorR = (byte)(r * 255 / (cubeSize - 1));
                            byte colorG = (byte)(g * 255 / (cubeSize - 1));
                            byte colorB = (byte)(b * 255 / (cubeSize - 1));

                            // حذف القنوات بشكل Real-Time
                            if (checkBox1.Checked) // Red
                                colorR = 0;

                            if (checkBox2.Checked) // Green
                                colorG = 0;

                            if (checkBox3.Checked) // Blue
                                colorB = 0;

                            if (screenX >= 0 && screenX < canvas.Width && screenY >= 0 && screenY < canvas.Height)
                            {
                                CvInvoke.Circle(canvas, new Point(screenX, screenY), 2, new MCvScalar(colorB, colorG, colorR), -1);
                            }
                        }
                    }

                }
                if (cubeBitmapCache != null) cubeBitmapCache.Dispose();
                cubeBitmapCache = canvas.ToBitmap();

                pictureBoxCube.Image = cubeBitmapCache;
                pictureBoxCube.Image = canvas.ToBitmap();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxHsv = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black
            }
           ;
            panel2.Controls.Add(pictureBoxHsv);

            pictureBoxHsv.MouseDown += PictureBoxCube_MouseDown;

            pictureBoxHsv.MouseMove += PictureBoxCube_MouseMove;
            pictureBoxHsv.MouseUp += PictureBoxCube_MouseUp;
            pictureBoxHsv.MouseWheel += PictureBoxCube_MouseWheel;

            pictureBoxHsv.MouseClick += PictureBoxHsv_MouseClick;

            RenderHSVCylinder();
        }

        private void RenderHSVCylinder()
        {
            int width = panel2.Width;
            int height = panel2.Height;


            using (Image<Bgr, byte> canvas = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0)))
            {
                int centerX = width / 2;
                int centerY = height / 2;
                double scale = width * zoomScale;
                double cosX = Math.Cos(angleX), sinX = Math.Sin(angleX);
                double cosY = Math.Cos(angleY), sinY = Math.Sin(angleY);


                int hSteps = 30;
                int sSteps = 6;
                int vSteps = 8;

                for (int v = 0; v < vSteps; v++)
                {
                    for (int s = 0; s < sSteps; s++)
                    {
                        for (int h = 0; h < hSteps; h++)
                        {
                            double hue = (double)h / hSteps * 360.0;
                            double sat = (double)s / (sSteps - 1);
                            double val = (double)v / (vSteps - 1);


                            double angleRad = hue * Math.PI / 180.0;
                            double radius = sat * 0.5;

                            double x = radius * Math.Cos(angleRad);
                            double z = radius * Math.Sin(angleRad);
                            double y = val - 0.5;


                            double y1 = y * cosX - z * sinX;
                            double z1 = y * sinX + z * cosX;
                            double x2 = x * cosY + z1 * sinY;
                            double z2 = -x * sinY + z1 * cosY;

                            double distance = 2.0;
                            double projectionScale = scale / (distance + z2);
                            int screenX = centerX + (int)(x2 * projectionScale);
                            int screenY = centerY + (int)(y1 * projectionScale);


                            using (Image<Hsv, byte> hsvPixel = new Image<Hsv, byte>(1, 1, new Hsv(hue / 2.0, sat * 255.0, val * 255.0)))
                            using (Image<Bgr, byte> bgrPixel = hsvPixel.Convert<Bgr, byte>())
                            {
                                Bgr color = bgrPixel[0, 0];


                                if (screenX >= 0 && screenX < canvas.Width && screenY >= 0 && screenY < canvas.Height)
                                {
                                    CvInvoke.Circle(canvas, new Point(screenX, screenY), 2, new MCvScalar(color.Blue, color.Green, color.Red), -1);
                                }
                            }
                        }
                    }
                }
                if (hsvBitmapCache != null) hsvBitmapCache.Dispose();
                hsvBitmapCache = canvas.ToBitmap();

                pictureBoxHsv.Image = hsvBitmapCache;

                pictureBoxHsv.Image = canvas.ToBitmap();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxYCrCb = new PictureBox { Dock = DockStyle.Fill, BackColor = Color.Black };
            panel3.Controls.Add(pictureBoxYCrCb);


            pictureBoxYCrCb.MouseDown += PictureBoxCube_MouseDown;

            pictureBoxYCrCb.MouseMove += PictureBoxCube_MouseMove;
            pictureBoxYCrCb.MouseUp += PictureBoxCube_MouseUp;
            pictureBoxYCrCb.MouseWheel += PictureBoxCube_MouseWheel;

            pictureBoxYCrCb.MouseClick += PictureBoxYCrCb_MouseClick;

            RenderYCrCbShape();
        }

        private void RenderYCrCbShape()
        {
            int width = panel3.Width;
            int height = panel3.Height;


            using (Image<Bgr, byte> canvas = new Image<Bgr, byte>(width, height, new Bgr(0, 0, 0)))
            {
                int centerX = width / 2;
                int centerY = height / 2;
                double scale = width * zoomScale;


                double cosX = Math.Cos(angleX), sinX = Math.Sin(angleX);
                double cosY = Math.Cos(angleY), sinY = Math.Sin(angleY);


                int ySteps = 10;
                int cbSteps = 10;
                int crSteps = 10;

                for (int yIdx = 0; yIdx < ySteps; yIdx++)
                {
                    for (int cbIdx = 0; cbIdx < cbSteps; cbIdx++)
                    {
                        for (int crIdx = 0; crIdx < crSteps; crIdx++)
                        {

                            byte yVal = (byte)(yIdx * 255 / (ySteps - 1));
                            byte cbVal = (byte)(cbIdx * 255 / (cbSteps - 1));
                            byte crVal = (byte)(crIdx * 255 / (crSteps - 1));


                            double x = (double)cbIdx / (cbSteps - 1) - 0.5;
                            double z = (double)crIdx / (crSteps - 1) - 0.5;
                            double y = (double)yIdx / (ySteps - 1) - 0.5;


                            double y1 = y * cosX - z * sinX;
                            double z1 = y * sinX + z * cosX;
                            double x2 = x * cosY + z1 * sinY;
                            double z2 = -x * sinY + z1 * cosY;

                            double distance = 2.0;
                            double projectionScale = scale / (distance + z2);
                            int screenX = centerX + (int)(x2 * projectionScale);
                            int screenY = centerY + (int)(y1 * projectionScale);


                            using (Image<Ycc, byte> yccPixel = new Image<Ycc, byte>(1, 1, new Ycc(yVal, crVal, cbVal)))
                            using (Image<Bgr, byte> bgrPixel = yccPixel.Convert<Bgr, byte>())
                            {
                                Bgr color = bgrPixel[0, 0];


                                if (color.Blue == 0 && color.Green == 0 && color.Red == 0 && (yVal > 0 && yVal < 255))
                                    continue;

                                if (screenX >= 0 && screenX < canvas.Width && screenY >= 0 && screenY < canvas.Height)
                                {
                                    CvInvoke.Circle(canvas, new Point(screenX, screenY), 2, new MCvScalar(color.Blue, color.Green, color.Red), -1);
                                }
                            }
                        }
                    }
                }
                if (ycrcbBitmapCache != null) ycrcbBitmapCache.Dispose();
                ycrcbBitmapCache = canvas.ToBitmap();

                pictureBoxYCrCb.Image = ycrcbBitmapCache;
                pictureBoxYCrCb.Image = canvas.ToBitmap();
            }
        }
        private void PictureBoxYCrCb_MouseClick(object sender, MouseEventArgs e)
        {
            if (ycrcbBitmapCache == null) return;


            if (e.X >= 0 && e.X < ycrcbBitmapCache.Width && e.Y >= 0 && e.Y < ycrcbBitmapCache.Height)
            {

                Color clickedColor = ycrcbBitmapCache.GetPixel(e.X, e.Y);


                if (clickedColor.R == 0 && clickedColor.G == 0 && clickedColor.B == 0)
                {
                    return;
                }


                label1.Text = $"RGB → ({clickedColor.R}, {clickedColor.G}, {clickedColor.B})";


                float hue = clickedColor.GetHue();
                float saturation = clickedColor.GetSaturation();
                float value = Math.Max(clickedColor.R, Math.Max(clickedColor.G, clickedColor.B)) / 255f;

                int satPercent = (int)(saturation * 100);
                int valPercent = (int)(value * 100);

                label2.Text = $"HSV → ({(int)hue}, {satPercent}%, {valPercent}%)";


                using (Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(1, 1, new Bgr(clickedColor.B, clickedColor.G, clickedColor.R)))
                using (Image<Ycc, byte> yccImage = bgrImage.Convert<Ycc, byte>())
                {
                    byte yVal = yccImage.Data[0, 0, 0];
                    byte crVal = yccImage.Data[0, 0, 1];
                    byte cbVal = yccImage.Data[0, 0, 2];

                    label3.Text = $"YCrCb → ({yVal}, {crVal}, {cbVal})";
                }
            }
        }

        private void PictureBoxCube_MouseClick(object sender, MouseEventArgs e)
        {
            if (cubeBitmapCache == null) return;


            if (e.X >= 0 && e.X < cubeBitmapCache.Width && e.Y >= 0 && e.Y < cubeBitmapCache.Height)
            {

                Color clickedColor = cubeBitmapCache.GetPixel(e.X, e.Y);


                if (clickedColor.R == 0 && clickedColor.G == 0 && clickedColor.B == 0)
                {
                    return;
                }

                label1.Text = $"RGB → ({clickedColor.R}, {clickedColor.G}, {clickedColor.B})";


                float hue = clickedColor.GetHue();
                float saturation = clickedColor.GetSaturation();
                float value = Math.Max(clickedColor.R, Math.Max(clickedColor.G, clickedColor.B)) / 255f;

                int satPercent = (int)(saturation * 100);
                int valPercent = (int)(value * 100);

                label2.Text = $"HSV → ({(int)hue}, {satPercent}%, {valPercent}%)";


                using (Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(1, 1, new Bgr(clickedColor.B, clickedColor.G, clickedColor.R)))
                using (Image<Ycc, byte> yccImage = bgrImage.Convert<Ycc, byte>())
                {

                    byte yVal = yccImage.Data[0, 0, 0];
                    byte crVal = yccImage.Data[0, 0, 1];
                    byte cbVal = yccImage.Data[0, 0, 2];

                    label3.Text = $"YCrCb → ({yVal}, {crVal}, {cbVal})";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void PictureBoxHsv_MouseClick(object sender, MouseEventArgs e)
        {
            if (hsvBitmapCache == null) return;


            if (e.X >= 0 && e.X < hsvBitmapCache.Width && e.Y >= 0 && e.Y < hsvBitmapCache.Height)
            {

                Color clickedColor = hsvBitmapCache.GetPixel(e.X, e.Y);

                if (clickedColor.R == 0 && clickedColor.G == 0 && clickedColor.B == 0)
                {
                    return;
                }


                float hue = clickedColor.GetHue();
                float saturation = clickedColor.GetSaturation();
                float value = Math.Max(clickedColor.R, Math.Max(clickedColor.G, clickedColor.B)) / 255f;

                int satPercent = (int)(saturation * 100);
                int valPercent = (int)(value * 100);

                label1.Text = $"HSV → ({(int)hue}, {satPercent}%, {valPercent}%)";


                label2.Text = $"RGB → ({clickedColor.R}, {clickedColor.G}, {clickedColor.B})";


                using (Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(1, 1, new Bgr(clickedColor.B, clickedColor.G, clickedColor.R)))
                using (Image<Ycc, byte> yccImage = bgrImage.Convert<Ycc, byte>())
                {
                    byte yVal = yccImage.Data[0, 0, 0];
                    byte crVal = yccImage.Data[0, 0, 1];
                    byte cbVal = yccImage.Data[0, 0, 2];

                    label3.Text = $"YCrCb → ({yVal}, {crVal}, {cbVal})";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Mat matImage = originalImage.ToMat();

            int width = matImage.Width;
            int height = matImage.Height;
            long totalPixels = matImage.Total;
            int channels = matImage.NumberOfChannels;
            var depth = matImage.Depth;

            double sizeInMB = (double)(width * height * channels) / (1024 * 1024);

            string colorSpaceInfo = " ";
            if (channels == 1)
                colorSpaceInfo = "(Grayscale / 1-Channel)";
            else if (channels == 3)
                colorSpaceInfo = " (RGB / BGR - 3 Channels)";
            else if (channels == 4)
                colorSpaceInfo = " (RGBA / BGRA - 4 Channels)";

            string infoMessage = $" Image Information :**\n\n" +
                                 $" Resolution : {width} × {height} Pixel\n" +
                                 $"Total Pixel : {totalPixels:N0} Pisel\n" +
                                 $"Nomber of Color Channel : {channels} channel\n" +
                                 $"Defult Color System : {colorSpaceInfo}\n" +
                                 $" Depth : {depth} bits/channel\n" +
                                 $" Memory : {sizeInMB:F2} (MB)";

            MessageBox.Show(infoMessage, "  Picture Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            pictureBox1.Image = originalImage;


            label1.Text = "RGB → (-, -, -)";
            label2.Text = "HSV → (-, -%, -%)";
            label3.Text = "YCrCb → (-, -, -)";


        }

        private void button10_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "صورة PNG (*.png)|*.png|صورة JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|صورة بيتماب (*.bmp)|*.bmp";
            saveFileDialog.Title = "Choose File Location";
            saveFileDialog.FileName = "Picture";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    if (extension == ".jpg" || extension == ".jpeg")
                    {
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }
                    else if (extension == ".bmp")
                    {
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                    }


                    pictureBox1.Image.Save(saveFileDialog.FileName, format);


                    MessageBox.Show("saved ", "successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("faild to save image " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }

}


