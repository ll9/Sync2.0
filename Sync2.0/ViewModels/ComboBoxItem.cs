using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.ViewModels
{
    public class ComboBoxItem
    {
        public static readonly ComboBoxItem TextComboBoxItem = new ComboBoxItem("Text", typeof(string));
        public static readonly ComboBoxItem ZahlComboBoxItem = new ComboBoxItem("Zahl", typeof(double));
        public static readonly ComboBoxItem DatumComboBoxItem = new ComboBoxItem("Datum", typeof(DateTime));

        public ComboBoxItem(string display, Type value)
        {
            Display = display;
            Value = value;
        }

        public string Display { get; set; }
        public Type Value { get; set; }
    }
}
