using System;
using MahApps.Metro.Controls;
using SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KanbanProjectManager.Classes;

namespace KanbanProjectManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public int btnPressedIdentification = 0;
        List<KanbanTask> kanbanTasks;
        public MainWindow()
        {
            InitializeComponent();
            UpdateListView();
                       

        }

        //New Item
        private void Backlog_NewItem_Button_Click(object sender, RoutedEventArgs e)
        {
            btnPressedIdentification = 1;
            NewTask newBacklogItem = new NewTask(btnPressedIdentification);
            newBacklogItem.ShowDialog();
            UpdateListView();
        }

        private void Progress_NewItem_Button_Click(object sender, RoutedEventArgs e)
        {
            btnPressedIdentification = 2;
            NewTask newProgressItem = new NewTask(btnPressedIdentification);
            newProgressItem.ShowDialog();
            UpdateListView();
        }

        private void Completed_NewItem_Button_Click(object sender, RoutedEventArgs e)
        {
            btnPressedIdentification = 3;
            NewTask newCompletedItem = new NewTask(btnPressedIdentification);
            newCompletedItem.ShowDialog();
            UpdateListView();
            
        }


        // Update Item
        private void BacklogListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            KanbanTask selectedKanbanTask = BacklogListView.SelectedItem as KanbanTask;
            if (selectedKanbanTask != null)
            {
                UpdateTask updateTask = new UpdateTask(selectedKanbanTask);
                updateTask.ShowDialog();
                UpdateListView();
            }
        }

        private void ProgressListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            KanbanTask selectedKanbanTask = ProgressListView.SelectedItem as KanbanTask;
            if (selectedKanbanTask != null)
            {
                UpdateTask updateTask = new UpdateTask(selectedKanbanTask);
                updateTask.ShowDialog();
                UpdateListView();
            }
        }

        private void CompletedListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            KanbanTask selectedKanbanTask = CompletedListView.SelectedItem as KanbanTask;
            if (selectedKanbanTask != null)
            {
                UpdateTask updateTask = new UpdateTask(selectedKanbanTask);
                updateTask.ShowDialog();
                UpdateListView();
            }
        }




        //Menu Items
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Exit application
        }

        private void MnuHelp_Click(object sender, RoutedEventArgs e)
        {
            //Help Window
        }


        //UpdateListView Function
        private void UpdateListView()
        {
            kanbanTasks = new List<KanbanTask>();
            kanbanTasks = SQLDatabaseHandler.Read<KanbanTask>();

            if (kanbanTasks != null)
            {
                BacklogListView.ItemsSource = kanbanTasks.Where(c => c.ColumnId.ToString().Contains("1"));
                ProgressListView.ItemsSource = kanbanTasks.Where(c => c.ColumnId.ToString().Contains("2"));
                CompletedListView.ItemsSource = kanbanTasks.Where(c => c.ColumnId.ToString().Contains("3"));
            }
            TaskCountUpdate();

        }

        private void TaskCountUpdate()
        {
            BacklogCount.Text = String.Format("({0})", BacklogListView.Items.Count.ToString());
            ProgressCount.Text = String.Format("({0})", ProgressListView.Items.Count.ToString());
            CompletedCount.Text = String.Format("({0})", CompletedListView.Items.Count.ToString());
        }
    }




}
