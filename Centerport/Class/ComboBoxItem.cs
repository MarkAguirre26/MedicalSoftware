using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerport
{
 public    class ComboBoxItem
    {

        //public string Text { get; set; }
        //public string Item { get; set; }
        //public object Value { get; set; }
        protected string items { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string item, int cn)
        {
            items = item;
            Value = cn;

        }
        public override string ToString()
        {
            return items;
        }

    }
}
