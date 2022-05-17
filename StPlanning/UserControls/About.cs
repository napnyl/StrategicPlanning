using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StPlanning.UserControls
{
    public partial class About : System.Windows.Forms.Form//DevExpress.XtraEditors.XtraForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            //Se cargan los controles necesario para la carga del formulario.
            OpenWithAnimation();
        }

        void CloseWithAnimation()
        {
            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_TickClose);
            timer.Start();
        }

        void OpenWithAnimation()
        {
            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_TickOpen);
            timer.Start();
        }

        void timer_TickClose(object sender, EventArgs e)
        {
            if (this.Opacity < 0.1d)
            {
                (sender as Timer).Stop();
                this.Close();
            }
            else
            {
                Opacity -= 0.1d;
            }
        }

        void timer_TickOpen(object sender, EventArgs e)
        {
            if (this.Opacity > 0.89d)
            {
                (sender as Timer).Stop();
                //this.Close();
            }
            else
            {
                Opacity += 0.1d;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CloseWithAnimation();
        }

    }
}
