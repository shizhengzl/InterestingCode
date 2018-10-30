using Core.UsuallyCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitProjectALL
{
    [TestClass]
    public class ParserTest
    {
        public string context = "public class API{public string Name {get;set;}}";
        [TestMethod]
        public void TestGetClass()
        { 
            CSharpParser parser = new CSharpParser(context); 
            var classs = parser.GetClass(); 
            Assert.AreEqual(classs.FirstOrDefault().Name, "API"); 
        }

        [TestMethod]
        public void TestGetProterty()
        {
            CSharpParser parser = new CSharpParser(context);
            var classs = parser.GetClass(); 
            Assert.AreEqual(parser.GetProterty().FirstOrDefault().Name, "Name");
        }
    }
}
