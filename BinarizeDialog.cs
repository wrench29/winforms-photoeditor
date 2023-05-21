using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoeditor
{
    public partial class BinarizeDialog : Form
    {
        public double Threshold { get; set; } = 0;

        public BinarizeDialog()
        {
            InitializeComponent();
        }

        private void threshold_numeric_ValueChanged(object sender, EventArgs e)
        {
            Threshold = (double)threshold_numeric.Value;
        }
    }
}
