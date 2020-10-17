using System.Xml.Linq;

namespace LinqToXML.Extentions
{
    public static class Extentions
    {
        public static string ElementValue(this XElement xElement, string value)
        {
            return xElement.Element(value)?.Value;
        }
    }
}