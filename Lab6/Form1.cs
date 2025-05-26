using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string s;
        string[] strings;
        int ArrayCounter = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float LeftMargin = e.MarginBounds.Left;// отступ слева
            float TopMargin = e.MarginBounds.Top;// отступ сверху
            float MyLines = 0;// количество линей
            float YPosition = 0;// позиция курсора
            int Counter = 0;// счетчик
            string CurrentLine;// линия текста
            MyLines = e.MarginBounds.Height / this.Font.GetHeight(e.Graphics);

            while (Counter < MyLines && ArrayCounter <= strings.Length - 1)
            {
                CurrentLine = strings[ArrayCounter];
                YPosition = TopMargin + Counter * this.Font.GetHeight(e.Graphics);
                e.Graphics.DrawString(CurrentLine, this.Font, Brushes.Black, LeftMargin, YPosition, new StringFormat());
                Counter++;
                ArrayCounter++;
            }
            if (!(ArrayCounter >= strings.GetLength(0) - 1))
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) 
            { 
                printDocument1.Print();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //printPreviewDialog1.ShowDialog(this);
            Form2 aForm = new Form2();
            System.Windows.Forms.DialogResult aResult;
            aForm.printPreviewControl1.Document = printDocument1;
            aResult = aForm.ShowDialog();
            if (aResult == System.Windows.Forms.DialogResult.OK)
                printDocument1.Print();
        }

        private void open_file_Click(object sender, EventArgs e)
        {


            System.Windows.Forms.DialogResult aResult;

            aResult = openFileDialog1.ShowDialog(this);

            if (aResult == DialogResult.OK) {
            System.IO.StreamReader aReader = new System.IO.StreamReader(openFileDialog1.FileName);
                s = aReader.ReadToEnd();
                aReader.Close();
                strings = s.Split('\n');
            }
        }
    }
}
