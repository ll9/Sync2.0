using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    public class Project
    {
        [Key]
        public string Id { get; set; }

        public ICollection<ProjectTable> ProjectTables { get; set; }
    }
}
