using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISS.Areas.admin.Models
{
    public class GenerateId
    {
        static Random _random = new Random();
        public string geneID()
        {

            string alfa = "";
            for (int i = 0; i < 4; i++)
            {
                int num = _random.Next(2, 24); // 2 to 23
                char let = (char)('a' + num);
                alfa += let;
            }

            string XC = DateTime.Now.ToString();
            long ZC = DateTime.Now.Ticks;
            ZC = ((ZC / 500) + 1994) * 16 - 11;

            string XX = safeName(ZC.ToString()) + alfa + safeName(XC);
            return XX;
            //string XC = DateTime.Now.ToString();
            //string XX = safeName(XC);

        }

        public string safeName(string safe)
        {
            safe = safe.Replace('/', 'a')
                       .Replace(':', 'd')
                       .Replace('-', 'a')
                       .Replace('%', '4')
                       .Replace('"', 'a')
                       .Replace('<', '5')
                       .Replace('>', 'a')
                       .Replace('.', 'f')
                       .Replace(';', 'a')
                       .Replace(',', '5')
                       .Replace('&', 'a');
            return safe;
        }
    }
}
