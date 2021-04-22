using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KanbanProjectManager.Classes
{
    public class TimeUsed
    {
        public void CalculateTimeUsed(DateTime Start, DateTime End)
        {
            String duration = (End - Start).TotalDays.ToString();
            MessageBox.Show(string.Format("Total Duration of the project is {0} days.", duration), "Result");
        }
    }
}
