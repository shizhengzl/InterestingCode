using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class ClassHelper
    {
        public static List<Assembly> GetAssemblies(string path)
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            path = string.IsNullOrEmpty(path) ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) : path;
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));
            return allAssemblies;
        }

        public static List<Type> GetInterfaces<T>(string path) 
        {
            var allAssemblies = GetAssemblies(path);
            var instance = allAssemblies
                .SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(T))))
                .ToList();
            return instance;
        }

        public static List<Type> GetInterfaces(string path)
        {
            var allAssemblies = GetAssemblies(path);
            var instance = allAssemblies
                .SelectMany(a => a.GetTypes().Where(t => t.IsInterface))
                .ToList();
            return instance;
        }

        public static List<Type> GetEnums(string path)
        {
            var allAssemblies = GetAssemblies(path);
            var instance = allAssemblies
                .SelectMany(a => a.GetTypes().Where(t => t.IsEnum))
                .ToList();
            return instance;
        }
    }
}
