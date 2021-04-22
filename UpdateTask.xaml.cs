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
    /// Interaction logic for UpdateTask.xaml
    /// </summary>
    public partial class UpdateTask : Window
    {
        KanbanTask selectedKanbanTask;
        public UpdateTask(KanbanTask selectedKanbanTask)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TextRange textRange = new TextRange(rtbRemarks.Document.ContentStart, rtbRemarks.Document.ContentEnd);
            this.selectedKanbanTask = selectedKanbanTask;
            projectNameTextBox.Text = this.selectedKanbanTask.ProjectName;
            projectDescriptionTextBox.Text = this.selectedKanbanTask.ProjectDescription;
            startDatePicker.SelectedDate = this.selectedKanbanTask.Start;
            endDatePicker.SelectedDate =this.selectedKanbanTask.Stop;
            textRange.Text = this.selectedKanbanTask.Remarks;
        }


        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbRemarks.Document.ContentStart, rtbRemarks.Document.ContentEnd);
            selectedKanbanTask.ProjectName = projectNameTextBox.Text;
            selectedKanbanTask.ProjectDescription = projectDescriptionTextBox.Text;
            selectedKanbanTask.Start = (DateTime)startDatePicker.SelectedDate;
            selectedKanbanTask.Stop = (DateTime)endDatePicker.SelectedDate;
            selectedKanbanTask.Remarks = textRange.Text;
            SQLDatabaseHandler.Update(selectedKanbanTask);
            this.Close();
        }
        
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            SQLDatabaseHandler.Delete(selectedKanbanTask);
            this.Close();
        }
        
        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime startTime = (DateTime)startDatePicker.SelectedDate;
            DateTime stopTime = (DateTime)endDatePicker.SelectedDate;
            TimeUsed timeUsed = new TimeUsed();
            timeUsed.CalculateTimeUsed(startTime, stopTime);
          
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
