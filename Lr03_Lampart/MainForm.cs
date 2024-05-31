using System.Diagnostics;
using System.Reflection;
using static Lr03_Lampart.ButtonsControl;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Lr03_Lampart
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            buttonsControl.MainForm = this;
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                case 0: buttonsControl.OType = OperationType.Word; break;
                case 1: buttonsControl.OType = OperationType.Excel; break;
            }
        }
    }
}
