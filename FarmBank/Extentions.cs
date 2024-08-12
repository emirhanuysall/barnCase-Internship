using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Extentions
{
    public static Color toHex(this string value)
    {
        try
        {
            return System.Drawing.ColorTranslator.FromHtml($"#{value}");
        }
        catch
        {
            return Color.White;
        }

    }
}
