using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    public class ProjectTable
    {
        public ProjectTable(string name)
        {
            Name = name;
        }

        [Key]
        public string Name { get; set; }
    }
}
