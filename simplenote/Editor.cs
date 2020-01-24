using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simplenote
{
    public partial class Editor : Form
    {
        int x = 0;
        public Editor()
        {
            InitializeComponent();
            openFileDialog1.FileName = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                StreamReader read = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = read.ReadToEnd();
                read.Close();
                this.Text = "Simple Note / File:" + openFileDialog1.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.FileName == "")
            {
                saveFileDialog1.ShowDialog();
                StreamWriter write = new StreamWriter(saveFileDialog1.FileName);
                write.Write(richTextBox1.Text);
                write.Close();
                openFileDialog1.FileName = saveFileDialog1.FileName;
            }
            else
            {
                StreamWriter write = new StreamWriter(openFileDialog1.FileName);
                write.Write(richTextBox1.Text);
                write.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            x += 4;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12+x, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        private void fontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x -= 4;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12 + x, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Blue;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ForeColor = Color.Black;
        }
    }
} 
