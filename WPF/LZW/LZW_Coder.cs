using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZW
{
    class LZW_Coder
    {
        public bool IsEnd { get; private set; }

        private LZW_Coding_String currentString;
        private Dictionary<int, string> dictionary;
        private string sourceMessage;
        private int currentIteration;
        private bool isDictionaryIncreased;


        public void Init(string sourceMessage, out Dictionary<int, string> baseDictionary)
        {
            IsEnd = false;
            this.sourceMessage = sourceMessage;
            currentIteration = 0;
            currentString = new LZW_Coding_String();
            InitDictionary(out baseDictionary);
            isDictionaryIncreased = true;
        }

        private void InitDictionary(out Dictionary<int, string> baseDictionary)
        {
            dictionary = new Dictionary<int, string>();
            baseDictionary = new Dictionary<int, string>();

            for (int i = 0, j = 0; i < sourceMessage.Length; i++)
            {
                if (!dictionary.ContainsValue(sourceMessage[i].ToString()))
                {
                    dictionary.Add(j, sourceMessage[i].ToString());
                    baseDictionary.Add(j, sourceMessage[i].ToString());
                    j++;
                }
            }
        }

        public LZW_Coding_String CoderIteration()
        {
            RefreshString();
            isDictionaryIncreased = false;

            if (!dictionary.ContainsValue(currentString.CurrentString))
            {
                string CS = currentString.CurrentString;
                dictionary.Add(dictionary.Count, CS);
                currentString.Code = dictionary.First(k => k.Value == CS.Remove(CS.Length - 1)).Key;
                currentString.Bytes = Convert.ToString(currentString.Code, 2);
                currentString.Dictionary = dictionary.Count - 1 + ": " + CS;

                isDictionaryIncreased = true;
            }
            else
            {
                currentString.Code = 0;
                currentString.Bytes = string.Empty;
                currentString.Dictionary = string.Empty;
            }

            currentIteration++;
            return currentString.Copy();
        }

        private void RefreshString()
        {
            currentString.CurrentSymbol = sourceMessage[currentIteration];

            if (currentIteration + 1 < sourceMessage.Length)
            {
                currentString.NextSymbol = sourceMessage[currentIteration + 1];
            }
            else if (currentIteration + 1 == sourceMessage.Length)
            {
                currentString.NextSymbol = ' ';
                IsEnd = true;
            }

            if (!isDictionaryIncreased)
            {
                currentString.CurrentString += sourceMessage[currentIteration + 1];
            }
            else
            {
                currentString.CurrentString = currentString.CurrentSymbol.ToString() +
                    currentString.NextSymbol.ToString();
            }
        }
    }

    public class LZW_Coding_String
    {
        public string CurrentString;
        public char CurrentSymbol;
        public char NextSymbol;
        public int Code;
        public string Bytes;
        public string Dictionary;

        public override string ToString()
        {
            string space = "    ";
            return CurrentString + space + CurrentSymbol + space + NextSymbol + space +
                Code + space + Bytes + space + Dictionary;
        }

        public LZW_Coding_String Copy()
        {
            return new LZW_Coding_String()
            {
                CurrentString = this.CurrentString,
                CurrentSymbol = this.CurrentSymbol,
                NextSymbol = this.NextSymbol,
                Code = this.Code,
                Bytes = this.Bytes,
                Dictionary = this.Dictionary
            };
        }
    }
}
