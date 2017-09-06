using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = File.ReadAllLines(@"INPUT.TXT");
            
            string query = "(?=(" + f[0].Replace("\\", "\\\\").Replace(" ", "(\\s)+").Replace("\t", "(\\s)+")+ "))";
            var text = string.Join("\r\n", f.Skip(1).ToArray()).TrimEnd('\n', '\r');

            Regex regex = new Regex(query, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string res_old = regex.Replace(text, @"@${0}");
            string res_new = regex.Replace(res_old, @"@${0}");


            File.WriteAllText("OUTPUT.TXT", res_new.Replace("@@", "@"));
        }
    }
}
