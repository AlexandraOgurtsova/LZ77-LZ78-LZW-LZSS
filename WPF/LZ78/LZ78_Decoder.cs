using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZ78
{
    public class LZ78_Decoder
    {
        public bool IsEnded { get; private set; }

        private List<string> dict;
        private LZ78_Coding_String currentString;

        public void Init()
        {
            dict = new List<string>();
            dict.Add(string.Empty);
            currentString = new LZ78_Coding_String();
        }

        public LZ78_Coding_String DecoderIteration(int pos, char next)
        {
            currentString.SetCode(pos, next);
            String word = dict[pos] + next;
            currentString.RemainingMessage += word;
            currentString.Dictionary = word;

            dict.Add(word);

            return currentString.Copy();
        }
    }
}
