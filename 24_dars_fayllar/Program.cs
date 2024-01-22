using System.Text;
using System.Text.RegularExpressions;

namespace FayllarBilanIshlash

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\lessonsfile\\myTex";
            string source = "Don't sleep, great works are waitig you";
            File.WriteAllText (path, source);

        }
    }
}
