using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E1_Files
{
    public partial class FormFileViewer : Form
    {
        public FormFileViewer(string fileAsText)
        {
            InitializeComponent();
            this.AutoSize = true;
            richTextBox1.AutoSize = true;
            richTextBox1.Text = fileAsText;
        }

        private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            richTextBox1.Size = new Size(this.ClientSize.Width-24, this.ClientSize.Height-24);
        }
    }
}
