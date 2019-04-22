﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;
using System.Linq;
using Core.UsuallyCommon.DataBase;
using System.Reflection;
using VSBussinessExtenstion;
using ScriptCs.Engine;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Core.ConsoleLog
{ 
   
    class Program
    {
        static DefaultSqlite defaultSqlite = new DefaultSqlite();
        static void Main(string[] args)
        {
            List<Column> columns = new List<Column>();
            columns.Add(new Column() { ColumnName = "Name", IsRequire = true, IsIdentity = true, CSharpType = "String" });
            columns.Add(new Column() { ColumnName = "Age", IsRequire = false, IsIdentity = true, CSharpType = "Int32" });


            var res = @" StringBuilder ssb = new StringBuilder();
            foreach (var item in columns)
            {
                ssb.AppendLine(item.ColumnName );
            }
             return   ssb.ToString();";

          

            var script = ScriptRuns.GetScriptRuns(res, columns);

            Console.WriteLine(script);
            //var result = script.ContinueWithAsync<string>("new GeneratorClass().GetGeneratorString()").Result;

           
            //var sb = "(column.IsRequire) ? \"?\" : \"\"";
            //var script = CSharpScript.RunAsync(sb, options,columns).Result;
            Console.ReadLine();
        }

        public static string GetPropertys<T>(T model,List<string> listdbtype)
        {
            StringBuilder sb = new StringBuilder();
            var propertieses = typeof(T).GetProperties().ToList().Where(x => listdbtype.Contains(x.PropertyType.Name)).ToList();
            propertieses.ForEach(x => { sb.AppendLine(GetPropertyInfo<T>(model, x)); });
            return sb.ToStringExtension();
        }

        public static string GetPropertyInfo<T>(T model, PropertyInfo propertyInfo)
        {
            StringBuilder sb = new StringBuilder();
            List<String> types = new List<string>() { "Int32","Boolean","Byte","Int64","Int16","Decimal" };
            var value = UsuallyCommon.Extensions.GetPropertyValue(model, propertyInfo.Name);


            if (propertyInfo.PropertyType.Name == "Boolean")
                value = value == "True" ? "true" : "false";

            if (types.Any(x => x == propertyInfo.PropertyType.Name))
                sb.Append($"{propertyInfo.Name} = {value},");
            else
                sb.Append($"{propertyInfo.Name} = \"{value}\",");

            return sb.ToStringExtension();
        }


        public static string GetString<T>(List<T> list,string snippet) where T : class
        { 
            List<string> listdbtype = defaultSqlite.DataTypeConfigs.Select(x => x.CSharpType).ToList();
            string nclass = @"
            using System;
            using System.Text;
            using System.Collections.Generic;  ";

            string nproperties = @"public @PropertyType @PropertyName{get;set;}";

            var types = typeof(T).GetProperties().ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(nclass);
            sb.AppendLine("public class @ClassName {");
            types.ForEach(x => {
                if (listdbtype.Contains(x.PropertyType.Name)) sb.AppendLine($"public {x.PropertyType.Name}  {x.Name} {{get;set;}}");
            });

            sb.AppendLine("}");
             
            sb.AppendLine("public class GeneratorClass {");

            string generator = @"
            public string GetGeneratorString()
            {
                StringBuilder sb = new StringBuilder();
                list.ForEach(column => {
                    sb.AppendLine(@snippet);
                });
                return sb.ToString();
            }";
            generator = generator.Replace("@snippet",   snippet );
            sb.AppendLine(generator);

            sb.AppendLine("public List<@ClassName> list = new List<@ClassName>();");

            sb.AppendLine("public GeneratorClass() {");

            list.ForEach(x =>
            { 
                
                var result = GetPropertys(x,listdbtype);
                sb.AppendLine($"list.Add(new @ClassName(){{ { result.TrimEnd(',')}  }});");
            });  
            sb.AppendLine("}");
            sb.AppendLine("}");
            return sb.ToString().Replace("@ClassName", typeof(T).Name);
        }

    }
}

