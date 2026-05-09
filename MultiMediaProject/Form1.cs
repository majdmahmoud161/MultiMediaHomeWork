using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Windows.Forms;
using System.IO;
using Emgu.CV.CvEnum;


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
    }
}
