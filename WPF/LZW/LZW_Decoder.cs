using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZW
{
    public class LZW_Decoder
    {
        private Dictionary<int, string> fullNoteDictionary;
        private Dictionary<int, string> partNoteDictionary;
        private LZW_Decoding_String currentDecString;
        private int currentIteration;

        public void Init(Dictionary<int, string> baseDictionary)
        {
            currentIteration = 0;
            currentDecString = new LZW_Decoding_String();
            fullNoteDictionary = new Dictionary<int, string>();
            partNoteDictionary = new Dictionary<int, string>();
            for (int i = 0; i < baseDictionary.Count; i++)
            {
                fullNoteDictionary.Add(i, baseDictionary[i]);
                partNoteDictionary.Add(i, baseDictionary[i]);
            }
        }

        public LZW_Decoding_String DecoderIteration(string bytes)
        {
            currentDecString.Bytes = bytes;
            currentDecString.Code = Convert.ToInt32(bytes, 2);

            string OE = fullNoteDictionary[currentDecString.Code];
            currentDecString.OnExit = OE;

            if (!string.IsNullOrEmpty(currentDecString.PartNewNote))
            {
                fullNoteDictionary.Add(fullNoteDictionary.Count, currentDecString.PartNewNote +
                  (OE.Length == 1 ? OE : OE.TrimEnd(OE[OE.Length - 1])));
                currentDecString.FullNewNote = currentDecString.PartNewNote +
                  (OE.Length == 1 ? OE : OE.TrimEnd(OE[OE.Length - 1]));
            }

            partNoteDictionary.Add(partNoteDictionary.Count, currentDecString.OnExit);
            currentDecString.PartNewNote = currentDecString.OnExit;

            currentIteration++;
            return currentDecString.Copy();
        }
    }

    public class LZW_Decoding_String
    {
        public string Bytes;
        public int Code;
        public string OnExit;
        public string FullNewNote;
        public string PartNewNote;

        public override string ToString()
        {
            string space = "    ";
            return Bytes + space + Code + space + OnExit + space +
                FullNewNote + space + PartNewNote;
        }

        public LZW_Decoding_String Copy()
        {
            return new LZW_Decoding_String()
            {
                Bytes = this.Bytes,
                Code = this.Code,
                OnExit = this.OnExit,
                FullNewNote = this.FullNewNote,
                PartNewNote = this.PartNewNote
            };
        }
    }
}
