using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace DemoCamera1
{
    public partial class Form1 : Form
    {
        String path = "";
        Image <Bgr, byte> img = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                img = new Image<Bgr, byte>(path);
                image0.Image = img;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(img != null)
            {
                image1.Image = convert2Gray(img)
            }
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        public static Image<Gray, byte> convert2Gray(Image<Bgr, Byte>, image0)
        {
            Image<Gray, byte> image1 = image0.Convert<Gray, Byte>();
            return image1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                Image<Gray, byte> gray
            }
        }
    }
}