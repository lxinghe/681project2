﻿///////////////////////////////////////////////////////////////
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
    void TestR4()
    {
      "Demonstrating Requirement #4".title();
      WriteLine();
    }
    void TestR5()
    {
      "Demonstrating Requirement #5".title();
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
      WriteLine();
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
