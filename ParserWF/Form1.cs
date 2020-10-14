using ParserWF.Kurs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserWF
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new CurrencyParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OneNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new CurrencySettings();
            parser.Start();
        }
    }
}
