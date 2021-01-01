using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProgressDialog : Form
    {      
        public string Status { 
            set 
            {
                this.Invoke(new Action(() =>
                {
                    lblMessage.Text = value;
                }));                
            } 
        }
        

        private Action action;

        public ProgressDialog(string title)
        {
            InitializeComponent();
            this.Text = title;
        }
        public void Init(Action action)
        {
            this.action = action;
        }

        public void Run()
        {            
            this.ShowDialog();
        }

        private void ProgressDialog_Activated(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                action();
                this.Invoke(new Action(() =>
                {
                    this.Dispose(); ;
                }));                
            }));
        }
    }
}
