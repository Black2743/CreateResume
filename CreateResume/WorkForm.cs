using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateResume
{
    public partial class WorkForm : Form
    {
        public String Position;
        public String Name;
        public String Location;
        public String Expiriense;
        
        public WorkForm()
        {
            InitializeComponent();
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {

        }
    }
}
