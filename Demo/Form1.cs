using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgressDialog dlg = new ProgressDialog("Test");
            dlg.Run(new Action(() =>
            {                
                for (int i = 0; i < 10; i++)
                {
                    dlg.Status = i.ToString();
                    //if (i == 5)
                    //    throw new Exception("testException");
                    Thread.Sleep(500);
                }                                
            }));

            if (dlg.exception != null)
            {
                MessageBox.Show(dlg.exception.Message);
            }
            else
            {
                MessageBox.Show("Done");
            }
        }       
    }
}
