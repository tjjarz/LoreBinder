using System.Collections.Generic;

namespace WorldBuilder.MVC.Models
{

    public class Element
    {
        //public string position { get; set; }
        public string XLName { get; set; }
        public string XLValue { get; set; }

        public Element(string xlname, string xlvalue)
        {
            XLName = xlname;
            XLValue = xlvalue;
        }
        // to allow empty models, turned off for debugging
        public Element()
        {
            XLName = "!-dummyitem";
            XLValue = "!-dummyvalue";
        }
    }

    public class TextElement : Element
    {
        public string XLNameFormatting { get; set; }
        public string XLValueFormatting { get; set; }
    }

    public class NestedElement : Element
    {
        //public string XLName { get; set; }

        //new public string XLValue { get; } //here to hopefully keep me from accidentally giving this thing a value

        new public List<Element> XLValue { get; set; }

    }

    public class TextBlock : Element
    {
        //public string XLName { get; set; }

        new public List<TextElement> XLValue { get; set; }

    }

    public class Gaggle
    {
        public List<Element> Elements { get; set; }
    }
}