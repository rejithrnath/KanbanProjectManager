using ControlzEx.Theming;
using KanbanProjectManager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KanbanProjectManager
{
    /// <summary>
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {
        public int columnIdtemp;
        public NewTask(int btnPressedIdentification)
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Dark.Red");
            projectNameTextBox.Text = "";
            projectDescriptionTextBox.Text = "";
            startDatePicker.SelectedDate = DateTime.Now;
            endDatePicker.SelectedDate = DateTime.Now;
            columnIdtemp = btnPressedIdentification;
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbRemarks.Document.ContentStart, rtbRemarks.Document.ContentEnd);

            KanbanTask tasknew = new KanbanTask()
            {
                ColumnId = columnIdtemp,
                ProjectName = projectNameTextBox.Text,
                ProjectDescription = projectDescriptionTextBox.Text,
                Start =(DateTime)(startDatePicker.SelectedDate),
                Stop = (DateTime)(endDatePicker.SelectedDate),
                Remarks = textRange.Text

            };

            SQLDatabaseHandler.Insert(tasknew);
            this.Close();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
