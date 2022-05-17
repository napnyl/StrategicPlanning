using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StPlanning.BL;
using StPlanning.Core;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace StPlanning.UserControls
{
    public partial class InitScreen : System.Windows.Forms.Form
    {
        RepositoryItemComboBox riCombo = new RepositoryItemComboBox();

        public InitScreen()
        {
            InitializeComponent();

        }

        private void InitScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
