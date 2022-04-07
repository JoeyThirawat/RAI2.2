using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Step 1 Add library
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        // Step 3 connect to webcam
        public VideoCapture _capture;
        public Image<Bgr, byte> img;
        public Form1()
        {
            InitializeComponent();
            if (_capture == null)
            {
                try
                {
                    _capture = new VideoCapture();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //label1.Text = "0";
        }
        /*
        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 255;
            trackBar1.TickStyle = TickStyle.BottomRight;
            trackBar1.TickFrequency = 10;
        }*/

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Step 5 Call RUN method
            RUN();

        }

        //Step 4 create the RUN  method
        public void RUN()
        {
            if (_capture != null && _capture.IsOpened)
            {
                img = _capture.QueryFrame().ToImage<Bgr, byte>();
                imageBox1.Image = img;
                // Set 9 Call precess 
                Process(img);
                Process2(img);
            }
        }

        // Step 8 Create Precess Method
        public void Process(Image<Bgr, byte> img)
        {
            //Convert BGR to GRAY
            Image<Gray, byte> gray = img.Convert<Gray, byte>();
            //Threshold image with 100
            Image<Gray, byte> bw = gray.ThresholdBinary(new Gray(trackBar1.Value), new Gray(255));
            imageBox2.Image = bw;
        }
        public void Process2(Image<Bgr, byte> image)
        {
            // Ex. Threshold
            Image<Hsv, byte> hsv = img.Convert<Hsv, byte>();
            Image<Gray, byte> mask = hsv.InRange(new Hsv(trackBar2.Value, 50, 50), new Hsv(trackBar3.Value, 255, 255));

            Image<Bgr, byte> img2 = img.CopyBlank();
            CvInvoke.BitwiseAnd(img, img, img2, mask);
            imageBox3.Image = img2;
        }
        private void imageBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Step 6
            if (checkBox1.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Step 7 Read the data from the webcam
            RUN();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }

        private void imageBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Upper Hue : " + trackBar3.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {

        }
        private void trackBar3_Scroll_1(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll_2(object sender, EventArgs e)
        {
            label1.Text = "Lower Hue : " + trackBar2.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}