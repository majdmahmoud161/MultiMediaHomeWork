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

        private void button7_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            Mat bgrImage = originalImage.ToMat();

            Mat[] channels = bgrImage.Split();

            // حذف الأزرق
            //channels[0].SetTo(new MCvScalar(0));
            //channels[1].SetTo(new MCvScalar(0));
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
    }
}
