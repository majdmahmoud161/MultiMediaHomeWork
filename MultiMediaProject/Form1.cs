using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Windows.Forms;
using System.IO;


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

        private void button1_Click(object sender, EventArgs e)
        {
            //youtube
            //OpenFileDialog openfiledealog = new OpenFileDialog();
            //DialogResult re = openfiledealog.ShowDialog();
            //if (re==DialogResult.OK) {
            //    i = Image.FromFile(openfiledealog.FileName);
            //    b = (Bitmap)i;
            //    pictureBox1 .Image = b;


            //}
            OpenFileDialog openfiledealog = new OpenFileDialog();
            if (openfiledealog.ShowDialog()==DialogResult.OK) {
                originalImage = new Bitmap(openfiledealog.FileName);
                pictureBox1.Image = originalImage;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            //عم ناخد بيانات الصورة اللي جبناها من اللابتوب وزتيناها بالمكان الصح
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data !=null) {
                var filename = data as string[];
                if (filename.Length>0) {
                    pictureBox1.Image = Image.FromFile(filename[0]);
                }
            }

        }

      
      
    }
}
