﻿using Core.UsuallyCommon.DataBase;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class ScriptColumn
    {
        public List<Column> columns = new List<Column>();
        public ScriptColumn(List<Column> _columns)
        {
            columns = _columns;
        }
    }

    public static class ScriptsRuns
    {
        public static string GetScriptsRuns(string snippet, List<Column> columns)
        {
            string result = string.Empty;

            var options =
               ScriptOptions.Default
              //.AddReferences("System.Runtime, Version=4.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")
              .AddImports("System.Text");
            result = CSharpScript.RunAsync(snippet, options, new ScriptColumn(columns)).Result.ReturnValue.ToStringExtension();

            return result;
        }
    }
}
