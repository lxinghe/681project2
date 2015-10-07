
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Project2Starter
{
    public class ItemEditor<Key, Data>
    {
        private DBElement<Key, Data> element;

        public ItemEditor(DBElement<Key, Data> val)
        {//let element points to the value's instance 

            element = val;
        }

        public void nameEdit(string newName)
        {//modify name

            element.name = newName;

        }


    }
}
