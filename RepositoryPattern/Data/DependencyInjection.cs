using RepositoryPattern.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.Data
{
    public class DependencyInjection
    {
        // This is a simple dependency injection class that used to simplyfiy the demo
        // In real application you should use a real dependency injection technology.
        public static string Option { get; set; } = "Memory";
        public static Type Type { get; set; } = typeof(IDataRepository);
        static List<IDataRepository> objects = new List<IDataRepository>();
        public static IDataRepository GetInstance()
        {
            if (Type == typeof(IDataRepository))
            {
                if (Option == "SQL")
                {
                    IDataRepository obj = objects.FirstOrDefault(x => x.GetType() == typeof(EFRepository));
                    if (obj == null)
                    {
                        obj = new EFRepository();
                        objects.Add(obj);
                    }
                    return obj;
                }
                else if (Option == "Memory")
                {
                    IDataRepository obj = objects.FirstOrDefault(x => x.GetType() == typeof(MemoryRepository));
                    if (obj == null)
                    {
                        obj = new MemoryRepository();
                        objects.Add(obj);
                    }
                    return obj;
                }
            }
            throw new Exception("Can't create required type, types are not registered");
        }
    }
}
