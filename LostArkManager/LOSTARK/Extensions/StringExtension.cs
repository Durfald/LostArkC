using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkManager.LOSTARK.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveHTMLCode(this string str)
        {
            Stack<int> IndexOpeningSymbol = new Stack<int>();
            Stack<int> IndexClosingSymbol = new Stack<int>();
            
            for(int i=0;i<str.Length;i++)
            {
                if (str[i]=='<')
                    IndexOpeningSymbol.Push(i);
                if (str[i]=='>')
                    IndexClosingSymbol.Push(i);
            }
            var builder = new StringBuilder(str);
            if (IndexOpeningSymbol.Count != IndexClosingSymbol.Count)
                throw new Exception("Длина списков открывающих скобок и закрывающих скобок разная");
            if (IndexClosingSymbol.Count == 0 || IndexOpeningSymbol.Count == 0)
                return str;
            do
            {
                var StartIndex = IndexOpeningSymbol.Pop();
                var EndIndex = IndexClosingSymbol.Pop();

                builder.Remove(StartIndex, EndIndex - StartIndex + 1);
            }
            while (IndexOpeningSymbol.Count > 0 && IndexClosingSymbol.Count > 0);
            return builder.ToString();
        }
    }
}
