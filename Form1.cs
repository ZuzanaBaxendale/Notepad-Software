using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace notepad
{
    public partial class Form1 : Form

    {
        StringReader reading = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newNotepad()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            newNotepad();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNotepad();
        }

        private void Save()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter notepad_streamWriter = new StreamWriter(file);
                    notepad_streamWriter.Flush();
                    notepad_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    notepad_streamWriter.Write(this.richTextBox1.Text);
                    notepad_streamWriter.Flush();
                    notepad_streamWriter.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error creating the file" + ex.Message, "Error writing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void Open()
        {
            this.openFileDialog1.Multiselect = false;

            this.openFileDialog1.Title = "Open file";
            openFileDialog1.InitialDirectory = @"C:\Users\matheus\Dropbox\PROJETOS\notepad\notepad";
            openFileDialog1.Filter = "(*.TXT)|*TXT";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader notepad_streamReader = new StreamReader(file);
                    notepad_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = notepad_streamReader.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = notepad_streamReader.ReadLine();
                    }

                    notepad_streamReader.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error reading" + ex.Message, "Error reading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Copy()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Paste()
        {
            richTextBox1.Paste();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Bold()
        {
            string source_name = null;
            float font_size = 0;
            bool b = false;

            source_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            b = richTextBox1.Font.Bold;

            if(b == false)
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size,FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size, FontStyle.Regular);
            }

        }

        private void Regular()
        {
            string source_name = null;
            float font_size = 0;
            bool b = false;

            source_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            b = richTextBox1.Font.Bold;

            if (b == false)
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size, FontStyle.Regular);
            }
        }

        private void Italic()
        {
            string source_name = null;
            float font_size = 0;
            bool it = false;

            source_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            it = richTextBox1.Font.Italic;

            if (it == false)
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size, FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size, FontStyle.Italic);
            }

        }

        private void Underlined()
        {
            string source_name = null;
            float font_size = 0;
            bool sub = false;

            source_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            sub = richTextBox1.Font.Underline;

            if (sub == false)
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size, FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(source_name, font_size, FontStyle.Underline);
            }

        }

        private void boldBtn_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void italicBtn_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void underlineBtn_Click(object sender, EventArgs e)
        {
            Underlined();
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Underlined();
        } 

        private void alignLeft()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void alignRight()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void alignCenter()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignCenter();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignLeft();
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignRight();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linePage = 0;
            float PosY = 0;
            int cont = 0;
            float marginLeft = e.MarginBounds.Left - 50;
            float marginTop = e.MarginBounds.Top - 50;

            if(marginLeft < 5)
            {
                marginLeft = 20;
            }
            if(marginTop < 5)
            {
                marginTop = 20;
            }

            string line = null;

            Font font = this.richTextBox1.Font;
            SolidBrush brush = new SolidBrush(Color.Black);
            linePage = e.MarginBounds.Height / font.GetHeight(e.Graphics);
            line = reading.ReadLine();
            while(cont < linePage)
            {
                PosY = (marginTop + (cont * font.GetHeight(e.Graphics)));
                e.Graphics.DrawString(line, font, brush, marginLeft, PosY, new StringFormat());
                cont++;
                line = reading.ReadLine();
            }

            if(line != null)
            {
                e.HasMorePages = true; 
            }
            else
            {
                e.HasMorePages = false;
            }

            brush.Dispose();

        }

        private void regularBtn_Click(object sender, EventArgs e)
        {
            Regular();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
