using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DataAccessRefactor.Old
{
    public static class BadProgram
    {
        static void MainMethod(string[] args)
        {
            List<object> it = new List<object>();
            if (args[0] == "Memory")
            {
                if (args[1] == "Add")
                {
                    it.Add(new
                    {
                        Name = "Name",
                        Location = "Location",
                        Job = "Job",
                        Project = "Project"
                    });
                }
                else if (args[1] == "Get")
                {
                    for (int i = 0; i < it.Count(); i++)
                    {
                        Console.WriteLine(i + " " +((dynamic)it[i]).Name);
                    }
                }
            }
            else if (args[0] == "File")
            {
                if (args[1] == "Add")
                {
                    it.Add(new
                    {
                        Name = "Name",
                        Location = "Location",
                        Job = "Job",
                        Project = "Project"
                    });
                    System.IO.File.WriteAllText(@"test.json", JsonConvert.SerializeObject(it));
                }
                else if (args[1] == "Get")
                {
                    it = JsonConvert.DeserializeObject<List<object>>(System.IO.File.ReadAllText("test.json"));
                    for (int i = 0; i < it.Count(); i++)
                    {
                        Console.WriteLine(i + " " + ((dynamic)it[i]).Name);
                    }
                }
            }
            else if (args[0] == "Database")
            {
                if (args[1] == "Add")
                {
                    //new SqlConnection("connString");
                }
                else if (args[1] == "Get")
                {
                    //it = new SqlConnection("connString").Query<object>("SELECT * FROM SomeTable").ToList();
                    for (int i = 0; i < it.Count(); i++)
                    {
                        Console.WriteLine(i + " " + ((dynamic)it[i]).Name);
                    }
                }
            }
        }
    }
}