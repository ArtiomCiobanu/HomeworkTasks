using System;
using DataAccessRefactor.API;
using DataAccessRefactor.API.Enums;

namespace DataAccessRefactor
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

            Enum.TryParse<AccesserType>(args[0], out var source);
            Enum.TryParse<OperationType>(args[1], out var operation);
            
            //AccesserType source = Enum.Parse<AccesserType>(args[0]);
            //OperationType operation = Enum.Parse<OperationType>(args[1]);

            UserProcessor userProcessor = new UserProcessor(source);
            userProcessor.Process(operation);
        }
    }
}