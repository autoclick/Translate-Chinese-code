using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateChineseByStep
{
   public class MyLang
    {
        public string _key { get; set; }
        public string _value { get; set; }
        public override string ToString()
        {
            return _value;
        }
    }
}
