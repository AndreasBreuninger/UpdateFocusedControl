using System;
using System.Windows;
using System.Windows.Forms;

namespace UpdateFocusedControl
{
    public partial class HostFormControl : UserControl
    {
        public HostFormControl(FrameworkElement control)
        {
            InitializeComponent();

            elementHost1.Child = control;

            Leave += OnLeave;
        }

        private void OnLeave(object sender, EventArgs e)
        {
            
        }
    }
}
