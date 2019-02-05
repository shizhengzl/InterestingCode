using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Core.UsuallyCommon
{
    public class XmlParser
    {
        public void Parser(string xmlstring)
        {

            //    <item type="text" field="Remark" title="备注" colspan="2">
            //xmlstring 是傳入 XML 格式的 string

            //取得第一個 result 節點內的值
        }

        public static string GetElementAttributteValueByPath(string context,string path, string name)
        {
            XDocument doc;
            try
            { 
                doc = XDocument.Parse(context);  
                var elemment = doc.XPathSelectElement( path);
                if (elemment != null)
                    return elemment.Attributes().FirstOrDefault(x => x.Name == name).Value;
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Empty;
            } 

        }

        public static string GetElementValueByPath(string context, string path)
        {
            XDocument doc;
            try
            {
                doc = XDocument.Parse(context);
                var elemment = doc.XPathSelectElement(path);
                if (elemment != null)
                    return elemment.Value;
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Empty;
            }

        }

        public static XElement GetCurrentLineElement(string context)
        {
            XDocument doc;
            try
            {
                try
                {
                    doc = XDocument.Parse(context);

                }
                catch (Exception)
                {
                    context = context.Replace(">", "/>");
                    doc = XDocument.Parse(context);
                }

                return doc.Elements().FirstOrDefault();
                
               
            }
            catch (Exception)
            {
                return null;
            }



        }
    }
}
