using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//ctrl + . for at få en liste af suggestions frem
namespace Assignment1
{
    public static class RegExpr
    {

        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            var pattern = @"[0-9a-zA-Z]+";

            Regex defaultRegex = new Regex(pattern);

            foreach(string s in lines)
            {
                MatchCollection matches;
                matches = defaultRegex.Matches(s);

                foreach(Match m in matches)
                {
                    yield return m.Value;
                }
            }


        }

        public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
        {
            var pattern = @"(?<width>[0-9]+)x(?<height>[0-9]+)"; //two named groups, using ?. matches on x too, but is not included in result.

            Regex defaultRegex = new Regex(pattern);

            foreach(string r in resolutions)
            {
                MatchCollection matches;
                matches = defaultRegex.Matches(r);

                foreach(Match m in matches)
                {
                    int width = int.Parse(m.Groups["width"].Value);//get width value from width group
                    int height = int.Parse(m.Groups["height"].Value);//get height value from height group
                    yield return(width, height);//return it
                }
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
