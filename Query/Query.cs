using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project2Starter
{
    public class Query<Key1, Key2, Data>
    {
		private DBEngine<Key1, DBElement<Key2, Data>> db;
		private DBElement<Key2, Data> temp = new DBElement<Key2, Data>();
		
        public Query(DBEngine<Key1, DBElement<Key2, Data>> database)
		{
			db = new DBEngine<Key1, DBElement<Key2, Data>>();
			db = database;
		}
		
		public bool checkValueByKey(Key1 key, out DBElement<Key2, Data> val)
		{
			return db.getValue(key, out val);
		}
		
		public List<Key2> childrenByKey(Key1 key)
		{
				db.getValue(key, out temp);
				return temp.children;
		}
		
		public List<string> keysWithPattern(DBEngine<string, DBElement<Key2, Data>> db1, string pattern)
		{
			IEnumerable<string> keys = db1.Keys();
			List<string> keylist = new List<string>();
			
			foreach(var key in keys)
			{
				if(key.Contains(pattern))
					keylist.Add(key);
			}
			
			return keylist;
		}
		
		public List<Key1> keysSameMdataPattern(string pattern)
		{
			IEnumerable<Key1> keys = db.Keys();
			List<Key1> keylist = new List<Key1>();
			
			foreach(var key in keys)
			{
				db.getValue(key, out temp);
				if(temp.name.Contains(pattern)||temp.descr.Contains(pattern))
					keylist.Add(key);
			}
		
			return keylist;
		}
		
		public List<Key1> keysSameTinterval(DateTime t1, DateTime t2)
		{
			List<Key1> keylist = new List<Key1>();
			IEnumerable<Key1> keys = db.Keys();
			
			foreach(var key in keys)
			{
				db.getValue(key, out temp);
				if((DateTime.Compare(temp.timeStamp,t1)>=0)&&(DateTime.Compare(temp.timeStamp,t2)<=0))
					keylist.Add(key);
			}
			
			return keylist;
		}
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
