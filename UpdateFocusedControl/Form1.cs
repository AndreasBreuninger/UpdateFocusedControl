using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataGrid = System.Windows.Controls.DataGrid;

namespace UpdateFocusedControl
{
    public partial class Form1 : Form
    {

        private readonly WorkspaceViewModel _workspace = new WorkspaceViewModel();

        public Form1()
        {
            InitializeComponent();

            elementHost1.Child = new MainControl() { DataContext = _workspace };



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dataGrid = createDataGrid();

            _workspace.Worksheets.Add(new WpfWorksheetViewModel(new System.Windows.Controls.Button() { Content = "WPF", Width = 200, Height = 16 }));
            _workspace.Worksheets.Add(new WinformsWorksheetViewModel(new HostFormControl(dataGrid)));
        }

        private DataGrid createDataGrid()
        {
            var users = new List<User>
            {
                new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) },
                new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) },
                new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) }
            };

            return new DataGrid() { ItemsSource = users };
        }
    }


    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }

}
