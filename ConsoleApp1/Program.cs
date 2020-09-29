using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ConsoleApp1.API;
using ConsoleApp1.API.DataSourceAccessers;
using ConsoleApp1.API.Static_classes;
using ConsoleApp1.Models;
using Dapper;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    /*
        This program can add and read employee data to/from different types of sources: memory, file, database.
        args[0] -> source of data
        args[1] -> operation
     */
    internal static class Program
    {
        static void Main(string[] args)
        {
            //For debug use only
            args = "Memory Get".Split();
            
            string source = args[0];
            string operation = args[1];

            UserProcessor userProcessor = new UserProcessor();
            IDataSourceAccesser dataSourceAccesser = DataSourceAccesserManager.GetSaverForSource(source);

            userProcessor.SetSaver(dataSourceAccesser);
            userProcessor.Process(operation);
        }
    }
}