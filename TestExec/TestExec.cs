///////////////////////////////////////////////////////////////
// TestExec.cs - Test Requirements for Project #2            //
// Ver 1.2                                                   //
// Application: Demonstration for CSE687-OOD, Project#2      //
// Language:    C#, ver 6.0, Visual Studio 2015              //
// Platform:    Dell XPS2700, Core-i7, Windows 10            //
// Author:      Jim Fawcett, CST 4-187, Syracuse University  //
//              (315) 443-3948, jfawcett@twcny.rr.com        //
///////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package begins the demonstration of meeting requirements.
 * Much is left to students to finish.
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 *   TestExec.cs,  DBElement.cs, DBEngine, Display, 
 *   DBExtensions.cs, UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.1 : 24 Sep 15
 * ver 1.0 : 18 Sep 15
 * - first release
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Project2Starter
{
  class TestExec
  {
    private DBEngine<int, DBElement<int, string>> db = new DBEngine<int, DBElement<int, string>>();
	private DBEngine<string, DBElement<int, string>> dbString = new DBEngine<string, DBElement<int, string>>();
    //private DBEngine<int, DBElement<int, string>> db2 = new DBEngine<int, DBElement<int, string>>();

        void TestR2()
    {
      "Demonstrating Requirement #2".title();
      DBElement<int, string> elem = new DBElement<int, string>();
      elem.name = "element";
      elem.descr = "test element";
      elem.timeStamp = DateTime.Now;
      elem.children.AddRange(new List<int>{ 1, 2, 3 });
      elem.payload = "elem's payload";
      elem.showElement();
      db.insert(1, elem);
	  Write("\n\n Show key/value pairs in data base:\n");
      db.showDB();
      WriteLine();
    }
	
    void TestR3()//addition and deletion of key/value pairs
    {
      "Demonstrating Requirement #3".title();
	  WriteLine();
	  
	  Write("\n --- Test addition of key/value pairs Start---");
	  WriteLine();
	  DBElement<int, string> elem1 = new DBElement<int, string>();
      elem1.name = "element#1";//add a new key/value pairs
      elem1.descr = "test element#1";
      elem1.timeStamp = DateTime.Now;
      elem1.children.AddRange(new List<int>{ 6, 8 });
      elem1.payload = "elem#1's payload";
      elem1.showElement();
      db.insert(2, elem1);
	  Write("\n\n Show key/value pairs in data base:\n");
      db.showDB();
      WriteLine();
	  Write("\n --- Test addition of key/value pairs End---");
	  WriteLine();
	  
	  Write("\n --- Test deletion of key/value pairs Start---");
	  WriteLine();
	  db.delete(1);//delete an existing key/value pairs
	  Write("\n\n Show key/value pairs in data base:\n");
      db.showDB();
      WriteLine();
      db.delete(100);//try to delete a key/value pairs that doesn't exist
	  Write("\n --- Test deletion of key/value pairs End---");
      WriteLine();
    }
	
    void TestR4(){//support editing of value including the addition and/or deletion of relationships, 
                  //editing text metadata and replacing an existing value's instance with a new instance

            "Demonstrating Requirement #4".title();

        DBElement<int, string> temp = new DBElement<int, string>();
        ItemEditor<int, string> editItem;
		
        if (db.containsKey(2)){
            db.getValue(2, out temp);
			Write("\n\n --- value before modified---\n");
			temp.showElement();
            editItem = new ItemEditor<int, string>(temp);
			editItem.nameEdit("newName!!");//edit the name of the value with key 2
			editItem.descrEdit("new description!!");//edit description
			editItem.dateTimeEdit();//update timeStamp
			editItem.addRelationship(18);//add relationship
			editItem.deleteRelationship(6);//delete relationship
			editItem.payloadEdit("new payload!!");//modify payload
			
			DBElement<int, string> elemNew = new DBElement<int, string>();
			editItem.replaceWithInstance(out elemNew);// replace an existing value's instance with a new instance
			temp = null;
			Write("\n\n --- value after modified---\n");
			elemNew.showElement();
            editItem = null;
        }

        else
			Write("Value not found!");
		
      //Write("\n\n Show key/value pairs in data base:\n");
	  //db.showDB();
      WriteLine();
      WriteLine();
    }
	
    void TestR5()
    {
      "Demonstrating Requirement #5".title();
	  DBElement<int, string> elem2 = new DBElement<int, string>();
      elem2.name = "element#2";//add a new key/value pairs
      elem2.descr = "test element#2";
      elem2.timeStamp = DateTime.Now;
      elem2.children.AddRange(new List<int>{ 16, 48 });
      elem2.payload = "elem#2's payload";
      //elem2.showElement();
      db.insert(7, elem2);
	 
	  PersistToXML toxml  = new PersistToXML(db);
	  toxml.writeXML();
	  
	  Write("\n --- Test read XML file Start---");
      LoadXML fromxml = new LoadXML(db, @"C:\Users\lxinghe\Downloads\Project2Starter\ReadFile.xml");
	  fromxml.WriteToDBEngine();
	  
	  Write("\n\n Show key/value pairs in data base:\n");
      db.showDB();
	  
	  Write("\n --- Test read XML file End---");
      WriteLine();
    }
	
    void TestR6()
    {
      "Demonstrating Requirement #6".title();
      WriteLine();
    }
	
    void TestR7()
    {
      "Demonstrating Requirement #7".title();
	  
	  Write("\n\n --- Query the value of specified key Start---\n");
	  Query<int, int, string> query = new Query<int, int, string>(db);
	  DBElement<int, string> elemR7 = new DBElement<int, string>();
	  query.checkValueByKey(2, out elemR7);
	  elemR7.showElement();
	  Write("\n\n --- Query the value of specified key End---\n");
      WriteLine();
	  /*****************************************************************/
	  Write("\n\n --- Query the children of specified key Start---\n");
	  Write("Children of value with key #2");
	  List<int> children = new List<int>();
	  children = query.childrenByKey(2);
	  foreach(var child in children)
	  Write("\n"+child);
	  Write("\n\n --- Query the children of specified key End---\n");
	  /*****************************************************************/
	  Write("\n\n --- Query the keys share a same pattern Start---\n");
	  DBElement<int, string> elemR701 = new DBElement<int, string>();
      elemR701.name = "r701";
      elemR701.descr = "su cs";
      elemR701.timeStamp = DateTime.Now;
      elemR701.children.AddRange(new List<int>{ 1, 2, 3 });
      elemR701.payload = "cs";
	  //elemR701.showElement();
      dbString.insert("SU cs dep", elemR701);
	  DBElement<int, string> elemR702 = new DBElement<int, string>();
      elemR702.name = "r702";
      elemR702.descr = "su math";
      elemR702.timeStamp = DateTime.Now;
      elemR702.children.AddRange(new List<int>{ 4, 5, 2 });
      elemR702.payload = "math";
	  //elemR702.showElement();
      dbString.insert("SU math dep", elemR702);
	  DBElement<int, string> elemR703 = new DBElement<int, string>();
      elemR703.name = "r703";
      elemR703.descr = "cornell math";
      elemR703.timeStamp = DateTime.Now;
      elemR703.children.AddRange(new List<int>{ 4, 5, 2 });
      elemR703.payload = "music";
	  //elemR703.showElement();
      dbString.insert("CORNELL music dep", elemR703);
	  //dbString.showDBString();
	  IEnumerable<string> keys = dbString.Keys();
	  Write("All keys in this database:");
	  foreach(var key in keys)
		Write("\n"+key);
	  Query<string, int, string> queryString = new Query<string, int, string>(dbString);
	  List<string> keyString = new List<string>();
	  keyString = queryString.keysWithPattern(dbString,"SU");
	  Write("\n\nKeys with pattern SU:");
	  foreach(var key in keyString)
	  	 Write("\n"+key);
	  Write("\n\n --- Query the keys share a same pattern End---\n");
	  /*****************************************************************/
	  Write("\n\n --- Query the keys share a same pattern Start---\n");
	  db.showDB();
	  Write("\n\nKeys with pattern ‘description’ in there metadata(name & descr):");
	  List<int> keyslist = new List<int>();
	  keyslist = query.keysSameMdataPattern("description");
	  foreach(var key in keyslist)
	  	 Write("\n"+key);
	  Write("\n\n --- Query the keys share a same pattern End---\n");
	  /*****************************************************************/
	  Write("\n\n --- Query the keys of value created in the same time interval Start---\n");
	  //testElem1.timeStamp = new DateTime(2008, 8, 15, 5, 9, 05);
	  DBElement<int, string> temp = new DBElement<int, string>();
	  db.getValue(7, out temp);
	  temp.timeStamp = new DateTime(1991, 4, 15, 8, 9, 05);
	  db.getValue(82, out temp);
	  temp.timeStamp = new DateTime(1994, 9, 7, 10, 8, 55);
	  db.showDB();
	  DateTime dt1 = new DateTime(1990, 4, 15, 5, 9, 05);
	  DateTime dt2 = new DateTime(1995, 9, 7, 5, 8, 05);
	  Write("\n\nkeys of value created after 1990/4/15 05:09:05 but before 1995/9/7 05:08:05:");
	  keyslist = query.keysSameTinterval(dt1, dt2);
	  foreach(var key in keyslist)
	  	 Write("\n"+key);
	  Write("\n\n --- Query the keys of value created in the same time interval Start---\n");
    }
	
    void TestR8()
    {
      "Demonstrating Requirement #8".title();
      WriteLine();
    }
	
    static void Main(string[] args)
    {
      TestExec exec = new TestExec();
      "Demonstrating Project#2 Requirements".title('=');
      WriteLine();
      exec.TestR2();
      exec.TestR3();
      exec.TestR4();
      exec.TestR5();
      exec.TestR6();
      exec.TestR7();
      exec.TestR8();
      Write("\n\n");
    }
	
  }

}
