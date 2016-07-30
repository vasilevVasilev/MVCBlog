using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Utils
{
    public class Utils
    {
        public static string CutText(string text, int maxLength)
        {
            if (text == null || text.Length <= maxLength)
                return text;
            return text.Substring(0, maxLength) + " ...";
        }
    }
}