using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using System.Web;

namespace WorldBuilder.MVC.Models
{

    public class Element
    {
        
        public string XLName { get; set; }
        public string XLValue { get; set; }

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

        public IEnumerable<Element> Elements { get; set; }

    }

    public class TextBlock : Element
    {
        //public string XLName { get; set; }

        public IEnumerable<TextElement> Elements { get; set; }

    }

    public class Gaggle
    {
        public IEnumerable<Element> Elements {get;set;}
    }
}