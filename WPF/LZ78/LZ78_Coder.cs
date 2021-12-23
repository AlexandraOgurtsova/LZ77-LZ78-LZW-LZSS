using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZ78
{
    public class LZ78_Coder
    {
        public bool IsEnd { get; private set; }

        private LZ78_Coding_String currentString;
        private string sourceMessage;
        private string buffer;
        private Dictionary<string, int> dict;
        private int currentIteration;

        public void Init(string sourceMessage)
        {
            dict = new Dictionary<string, int>();
            dict.Add("", 0);
            currentIteration = 0;
            this.sourceMessage = sourceMessage;
            buffer = string.Empty;
            currentString = new LZ78_Coding_String();
            IsEnd = false;
        }

        public LZ78_Coding_String CoderIteration()
        {
            currentString.RemainingMessage = sourceMessage.Substring(currentIteration, sourceMessage.Length - currentIteration);

            if (dict.ContainsKey(buffer + sourceMessage[currentIteration]) && currentIteration != sourceMessage.Length - 1)
            {
                currentString.SetNullCode();
                currentString.FoundPrefix = string.Empty;

                buffer += sourceMessage[currentIteration];
            }
            else
            {
                currentString.SetCode(dict[buffer], sourceMessage[currentIteration]);
                currentString.Dictionary = buffer + sourceMessage[currentIteration];
                currentString.FoundPrefix = buffer;

                dict[buffer + sourceMessage[currentIteration]] = dict.Count;
                buffer = "";
            }

            currentIteration++;
            if (currentIteration == sourceMessage.Length)
            {
                IsEnd = true;
            }
            return currentString.Copy();
        }
    }

    public class LZ78_Coding_String
    {
        private string _dictionary = string.Empty;
        public string Dictionary
        {
            get { return _dictionary; }
            set
            {
                if (_dictionary.Length == 0)
                {
                    _dictionary = value;
                }
                else
                {
                    _dictionary += ", " + value;
                }
            }
        }
        public string RemainingMessage;
        public string FoundPrefix;
        public string Code { get; private set; }

        public int pos;
        public char next;

        public override string ToString()
        {
            string space = "    ";
            return Dictionary + space + RemainingMessage + space + FoundPrefix + space + Code;
        }

        public void SetCode(int number, char prefix)
        {
            Code = "[" + number + ", " + prefix + "]";

            pos = number;
            next = prefix;
        }

        public void SetNullCode()
        {
            Code = string.Empty;
        }

        public LZ78_Coding_String Copy()
        {
            return new LZ78_Coding_String()
            {
                FoundPrefix = this.FoundPrefix,
                Code = this.Code,
                RemainingMessage = this.RemainingMessage,
                Dictionary = this.Dictionary,
                pos = this.pos,
                next = this.next
            };
        }
    }
}
