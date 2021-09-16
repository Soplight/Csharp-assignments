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
            var pattern = @"<("+tag+@")[^>]*>([\s\S]*?(?=(</\1>)))";;//match on the given tag, then on content inside tags
            
            Regex firstRegex = new Regex(pattern);

            MatchCollection matches = firstRegex.Matches(html);

            foreach (Match m in matches)
            {
                string matchedTagContent = m.Groups[2].Value;

                var secondPattern = @"(?<nestedTag>[<].*?[a-zA-Z0-9 ]*[>])";

                Regex secondRegex = new Regex(secondPattern);

                MatchCollection matchForNestedContent = secondRegex.Matches(matchedTagContent);

                foreach (Match mNest in matchForNestedContent)
                {
                    matchedTagContent = matchedTagContent.Replace(mNest.Groups["nestedTag"].Value, "");
                }
                yield return matchedTagContent; //Contains the text from the nested HTML tag that we want.
            }
        }
    }
}
