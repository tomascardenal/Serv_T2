using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E2_Files
{
    public partial class RGBSelectorForm : Form
    {
        private Color currentColor;
        public int rComp, gComp, bComp;
        public Color CurrentColor
        {
            get
            {
                return this.currentColor;
            }
            set
            {
                currentColor = value;
                DoColorUpdate = false;
                numericRed.Value = currentColor.R;
                numericGreen.Value = currentColor.G;
                numericBlue.Value = currentColor.B;
                DoColorUpdate = true;
                updateColor();
            }
        }
        public bool DoColorUpdate;

        public RGBSelectorForm()
        {
            InitializeComponent();
            updateColor();
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            if (sender == numericRed)
            {
                trackBarRed.Value = decimal.ToInt32(numericRed.Value);
            }
            else if (sender == numericGreen)
            {
                trackBarGreen.Value = decimal.ToInt32(numericGreen.Value);
            }
            else
            {
                trackBarBlue.Value = decimal.ToInt32(numericBlue.Value);
            }
            if (DoColorUpdate)
            {
                updateColor();
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (sender == trackBarRed)
            {
                numericRed.Value = trackBarRed.Value;
            }
            else if (sender == trackBarGreen)
            {
                numericGreen.Value = trackBarGreen.Value;
            }
            else
            {
                numericBlue.Value = trackBarBlue.Value;
            }
            if (DoColorUpdate)
            {
                updateColor();
            }
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void updateColor()
        {
            currentColor = Color.FromArgb(
                decimal.ToInt32(numericRed.Value),
                decimal.ToInt32(numericGreen.Value),
                decimal.ToInt32(numericBlue.Value));
            panelColorSample.BackColor = currentColor;
        }
    }
}
