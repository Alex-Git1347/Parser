using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserWF.Kurs
{
    class CurrencySettings : IParserSettings
    {
        public CurrencySettings()
        {

        }
        public string BaseUrl { get; set; } = "https://kurs.com.ua/?gclid=Cj0KCQjwqfz6BRD8ARIsAIXQCf2X10YlprZPDEO2-b0WGFcjFZBkOJJ4aroosSYWpVCnrDyFHcQfUcwaAkzHEALw_wcB";
        public string Prefix { get; set; } = "page{CurrentId}";
    }
}
