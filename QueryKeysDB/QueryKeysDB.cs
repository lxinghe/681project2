using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project2Starter
{
    public class QueryKeysDB<T>
    {
		private DBElement<int, List<T>> elem;
		private List<T> keylist;
		private DBEngine<int, DBElement<int, List<T>>> db;
		
        public QueryKeysDB(DBEngine<int, DBElement<int, List<T>>> database, List<T> ls)
		{
			elem = new DBElement<int, List<T>>();
			keylist = ls;
			db = database;
		}
		
		public void storeKeys(int keyName, string elemName, string elemDescr)
		{
			elem.name = elemName;
			elem.descr = elemDescr;
			elem.payload = keylist;
			db.insert(keyName, elem);
		}
		
		
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
