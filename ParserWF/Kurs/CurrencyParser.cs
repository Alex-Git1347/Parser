using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserWF.Kurs
{
    class CurrencyParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var itemsTagA = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("dotted"));
            var itemsTagDiv = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("course"));
            //int i = itemsTagA.Count();
            int i = 0;


            foreach (var tagDiv in itemsTagDiv)
            {
                if (i % 4 == 0 && i < (itemsTagA.Count() * 4) - 1)
                { list.Add("NameCurrency"); }
                if (tagDiv.TextContent.ToString() != "")
                {
                    string s = tagDiv.TextContent.ToString();
                    int ind = s.IndexOf('\n');
                    s = s.Remove(ind);
                    list.Add(s);
                    i++;
                }
            }

            foreach (var tagA in itemsTagA)
            {
                string s = tagA.TextContent.ToString();
                int index = list.IndexOf("NameCurrency");
                list.RemoveAt(index);
                list.Insert(index, s);
            }


            return list.ToArray();
        }
    
    }
}
