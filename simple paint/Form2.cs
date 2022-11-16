using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_paint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string name
        {
            get
            {
                string text = textBox1.Text;
                return text;
            }
            set { }

        }
        public int W
        {
            get
            {
                try
                {
                    string text = textBox2.Text;
                    int value = Convert.ToInt32(text);
                    return value;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }

        public int H
        {
            get
            {
                try
                {
                    string text = textBox3.Text;
                    int value = Convert.ToInt32(text);
                    return value;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }

        bool _canceled = true;
        public bool Canceled
        { get { return _canceled; } }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {  
            _canceled = false; 
            Close();
        }
        private void Create_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }

        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
