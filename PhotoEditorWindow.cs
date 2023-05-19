using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoeditor
{
    public partial class PhotoEditorWindow : Form
    {
        Bitmap bitmap;
        public PhotoEditorWindow(string imagePath)
        {
            InitializeComponent();

            bitmap = new(Image.FromFile(imagePath));
            Width = bitmap.Width + 18;
            Height = bitmap.Height + 47;
        }

        private void PhotoEditorWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
