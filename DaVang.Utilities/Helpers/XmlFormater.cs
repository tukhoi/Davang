using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.Helpers
{
    public class XmlFormater
    {
        /// <summary>
        /// This method to make sure xmlData passed in
        /// has correct xml format
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static void Format(ref string xmlData)
        {
            RemoveInCorrectCommentSigns(ref xmlData);
        }

        private static void RemoveInCorrectCommentSigns(ref string xmlData)
        {
            xmlData = xmlData.Replace("<!---", "<!--");
            xmlData = xmlData.Replace("--->", "-->");
        }
    }
}
