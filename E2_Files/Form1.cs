using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E2_Files
{
    public partial class Form1 : Form
    {
        private RGBSelectorForm rgbSelector;
        private SaveFileDialog saveDialog;
        private OpenFileDialog openDialog;
        private bool textIsSaved, saveConfirmed;
        private TxtDataHandler dataHandler;
        private string dataPath;

        public Form1()
        {
            dataPath = Path.Combine(Environment.GetEnvironmentVariable("homepath"), "AppData", "nopepad.bin");

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-En");

            textIsSaved = true;
            saveConfirmed = true;

            saveDialog = new SaveFileDialog();
            saveDialog.Title = Properties.Resources.SAVE_TITLE;
            saveDialog.Filter = Properties.Resources.FILE_FILTER;
            saveDialog.InitialDirectory = Environment.GetEnvironmentVariable("homepath");
            saveDialog.ValidateNames = true;
            saveDialog.OverwritePrompt = true;

            openDialog = new OpenFileDialog();
            openDialog.Title = Properties.Resources.OPEN_TITLE;
            openDialog.Filter = Properties.Resources.FILE_FILTER;
            openDialog.InitialDirectory = Environment.GetEnvironmentVariable("homepath");
            openDialog.ValidateNames = true;

            rgbSelector = new RGBSelectorForm();

            dataHandler = new TxtDataHandler();

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveConfirmed = false;
            if (string.IsNullOrWhiteSpace(saveDialog.FileName))
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    saveConfirmed = true;
                }
                else
                {
                    saveConfirmed = false;
                }
            }
            else
            {
                saveConfirmed = true;
            }
            if (saveConfirmed)
            {
                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                {
                    writer.Write(txbWorkplace.Text);
                }
                textIsSaved = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = unsavedChangesPrompt();

            if (res != DialogResult.Cancel && saveConfirmed)
            {
                if (openDialog.ShowDialog() == DialogResult.OK && openDialog.CheckFileExists)
                {
                    loadTextFile(openDialog.FileName);
                    txbWorkplace.ForeColor = rgbSelector.CurrentColor;
                }
            }
        }

        private void loadTextFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                txbWorkplace.Text = reader.ReadToEnd();
                saveDialog.FileName = openDialog.FileName;
            }
            textIsSaved = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult res = unsavedChangesPrompt();
            if (res != DialogResult.Cancel && saveConfirmed)
            {
                saveDialog.FileName = null;
                txbWorkplace.Clear();
            }
        }

        private DialogResult unsavedChangesPrompt()
        {
            DialogResult res = DialogResult.Yes;
            if (!string.IsNullOrWhiteSpace(txbWorkplace.Text) && !textIsSaved)
            {
                res = MessageBox.Show(Properties.Resources.UNSAVED_WARNING_TEXT,
                    Properties.Resources.UNSAVED_WARNING_TITLE,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                }
            }
            return res;
        }

        private void txbWorkplace_TextChanged(object sender, EventArgs e)
        {
            textIsSaved = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                DialogResult dr = rgbSelector.ShowDialog();

                Debug.WriteLine(dr.ToString());
                if (dr == DialogResult.OK)
                {
                    txbWorkplace.ForeColor = rgbSelector.CurrentColor;
                }
                else if (dr == DialogResult.Cancel)
                {
                    rgbSelector.CurrentColor = txbWorkplace.ForeColor;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            if (!textIsSaved)
            {
                dr = unsavedChangesPrompt();
            }
            else
            {
                dr = DialogResult.Yes;
            }
            if (dr != DialogResult.Cancel && saveConfirmed)
            {
                TxtFileData txtFileData = new TxtFileData(
                    saveDialog.FileName, txbWorkplace.ForeColor.R, txbWorkplace.ForeColor.G, txbWorkplace.ForeColor.B);
                using (TxtDataHandler.TxtDataWriter writer = new TxtDataHandler.TxtDataWriter(new FileStream(dataPath, FileMode.Create)))
                {
                    writer.Write(txtFileData);
                }
            }
            else if (dr != DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TxtFileData txtFileData;
            if (File.Exists(dataPath))
            {
                try
                {
                    using (TxtDataHandler.TxtDataReader reader = new TxtDataHandler.TxtDataReader(new FileStream(dataPath, FileMode.Open)))
                    {
                        txtFileData = reader.ReadTxtFileData();
                    }
                    txbWorkplace.ForeColor = Color.FromArgb(txtFileData.rComponent, txtFileData.gComponent, txtFileData.bComponent);
                    rgbSelector.CurrentColor = Color.FromArgb(txtFileData.rComponent, txtFileData.gComponent, txtFileData.bComponent);
                    if (!string.IsNullOrWhiteSpace(txtFileData.path))
                    {
                        loadTextFile(txtFileData.path);
                        saveDialog.FileName = txtFileData.path;
                    }
                }
                catch (IOException io)
                {
                    MessageBox.Show(string.Format(Properties.Resources.IO_ERROR_TXT, io.Message), Properties.Resources.IO_ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

