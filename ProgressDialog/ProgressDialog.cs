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

        public Exception exception { get; private set; }

        public ProgressDialog(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        public void Run(Action action)
        {
            this.action = action;
            this.ShowDialog();
        }

        private void ProgressDialog_Activated(object sender, EventArgs e)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                try
                {
                    action();                    
                }
                catch (Exception ex)
                {
                    this.exception = ex;
                }
                finally
                {
                    TaskDispose();
                }
                
            }));
        }

        private void TaskDispose()
        {
            this.Invoke(new Action(() =>
            {
                this.Dispose(); ;
            }));
        }    
    }
}
