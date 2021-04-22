using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProjectManager.Classes
{
    public class KanbanTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ColumnId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        //public DateTime Duration { get; set; }
        public string Remarks { get; set; }

        public override string ToString()
        {
            return $"{ProjectName} \n {ProjectDescription}";
        }
    }

   
}
