using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerport
{
 public  class ListboxItem
    {

      protected string items { get; set;}
       public string Value { get; set; }

       public ListboxItem(string item, string cn)
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
