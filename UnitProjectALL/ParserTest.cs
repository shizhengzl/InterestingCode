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
        [TestMethod]
        public void TestConnectin()
        {
            var context = "public class API{public string Name {get;set;}}";

            CSharpParser parser = new CSharpParser(context);

            var classs = parser.GetClass();
           
                Assert.AreEqual(classs.FirstOrDefault().Name, "API");
            
        }
    }
}
