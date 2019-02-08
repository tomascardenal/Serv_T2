using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E1_Files
{
    //TODO Control excepciones completo y caracteres especiales
    public partial class Form1 : Form
    {
        readonly string HOMEPATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string INVALIDCHARS;
        public Form1()
        {
            InitializeComponent();
            txbDir.Text = HOMEPATH;
            foreach (char ch in Path.GetInvalidPathChars())
            {
                INVALIDCHARS += ch.ToString() + " ";
            }
            //Environment.GetEnvironmentVariable("homepath");
        }

        private void goToSelectedDirectory()
        {
            if (listDirectories.SelectedIndex != -1)
            {
                txbDir.Text += listDirectories.Items[listDirectories.SelectedIndex].ToString().Remove(0, 1);
                btnGo.PerformClick();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ERR_GOTONONE_MSG,
                           Properties.Resources.ERR_GOTONONE_TITLE,
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void viewSelectedFileAsText()
        {
            if (listFiles.SelectedIndex != -1)
            {
                string fileAsText;
                string file = Directory.GetCurrentDirectory() + "\\" + listFiles.Items[listFiles.SelectedIndex];
                if (File.Exists(file))
                {
                    try
                    {
                        using (StreamReader sr = File.OpenText(file))
                        {
                            fileAsText = sr.ReadToEnd();
                        }
                        FormFileViewer formSec = new FormFileViewer(fileAsText);
                        formSec.ShowDialog();
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ERR_OPENFILE_MSG, io.Message),
                            Properties.Resources.ERR_OPENFILE_TITLE,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.ERR_OPENNONE_MSG,
                           Properties.Resources.ERR_OPENNONE_TITLE,
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txbDir.Text))
            {
                try
                {
                    string dir;
                    if (txbDir.Text[0] == '%' && txbDir.Text[txbDir.Text.Length - 1] == '%'
                        && Environment.GetEnvironmentVariable(txbDir.Text.Replace("%", "")) != null)
                    {
                        dir = Environment.GetEnvironmentVariable(txbDir.Text.Replace("%", ""));
                    }
                    else
                    {
                        dir = txbDir.Text;
                    }
                    Directory.SetCurrentDirectory(dir);
                    string[] files = Directory.GetFiles(".");
                    string[] directories = Directory.GetDirectories(".");
                    listFiles.Items.Clear();
                    listDirectories.Items.Clear();
                    listFiles.Items.AddRange(files);
                    listDirectories.Items.AddRange(directories);
                }
                catch (IOException exc)
                {
                    MessageBox.Show(
                        Properties.Resources.ERR_PATH_MSG + " " + exc.Message,
                        Properties.Resources.ERR_PATH_TITLE,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(Properties.Resources.ERR_ACCESS_MSG,
                        Properties.Resources.ERR_ACCESS_TITLE,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Directory.SetCurrentDirectory("..");
                    txbDir.Text = Directory.GetCurrentDirectory();
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(Properties.Resources.ERR_ILLEGALPATH_MSG + "" + INVALIDCHARS,
                        Properties.Resources.ERR_ILLEGALPATH_TITLE,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(
                        Properties.Resources.ERR_NOPATH_MSG,
                        Properties.Resources.ERR_NOPATH_TITLE,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbDir.Text = HOMEPATH;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem sndr = sender as ToolStripMenuItem;
            ContextMenuStrip menu = sndr.Owner as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;
            bool fromDir = sourceControl.Name == "listDirectories" && listDirectories.SelectedIndex != -1;
            bool fromFile = sourceControl.Name == "listFiles" && listFiles.SelectedIndex != -1;

            if (fromDir || fromFile)
            {
                DialogResult dr = MessageBox.Show(
                    string.Format(Properties.Resources.CONFIRMDELETE_MSG, fromDir ? Properties.Resources.DIR_SNIPPET : Properties.Resources.FILE_SNIPPET),
                    Properties.Resources.CONFIRMDELETE_TITLE,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (fromDir)
                        {
                            Directory.Delete(Path.Combine(txbDir.Text, listDirectories.Items[listDirectories.SelectedIndex].ToString()));
                        }
                        else if (fromFile)
                        {
                            File.Delete(Path.Combine(txbDir.Text, listFiles.Items[listFiles.SelectedIndex].ToString()));
                        }
                        btnGo.PerformClick();
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ERR_DELETING_MSG, io.Message),
                                Properties.Resources.ERR_DELETING_TITLE,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (UnauthorizedAccessException ua)
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ERR_DELETING_MSG, ua.Message),
                                Properties.Resources.ERR_DELETING_TITLE,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.ERR_DELETENOSELECTION_MSG,
                            Properties.Resources.ERR_DELETENOSELECTION_TITLE,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem sndr = sender as ToolStripMenuItem;
            ContextMenuStrip menu = sndr.Owner as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;
            if (sourceControl.Name == "listDirectories")
            {
                goToSelectedDirectory();
            }
            else if (sourceControl.Name == "listFiles")
            {
                viewSelectedFileAsText();
            }
        }

        private void listDirectories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            goToSelectedDirectory();
        }

        private void listFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            viewSelectedFileAsText();
        }
    }
}
