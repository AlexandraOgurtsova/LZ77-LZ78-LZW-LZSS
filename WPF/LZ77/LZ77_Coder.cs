using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF.LZ77
{
    public class LZ77_Coder
    {
        public bool IsEnd { get; private set; }

        private LZ77_Node currentString;
        private string sourceMessage;
        private string remainingString;
        private int position;
        private string buffer;
        int startBufInd = 0;
        int bufLength;

        public void Init(string sourceMessage, int bufSize)
        {
            bufLength = bufSize;
            buffer = string.Empty;
            position = 0;
            this.sourceMessage = sourceMessage;//Regex.Replace(sourceMessage, " ", "_");
            remainingString = string.Empty;
            currentString = new LZ77_Node();
            IsEnd = false;
        }

        public LZ77_Node CoderIteration()
        {
            var m = FindMatching();
            currentString.Offset = m.Offset;
            currentString.Length = m.Length;

            ShiftBuffer(m.Length + 1);

            currentString.Next = position >= sourceMessage.Length ? ' ' : sourceMessage[position];
            position++;

            if (position >= sourceMessage.Length)
            {
                IsEnd = true;
            }
            currentString.Buffer = buffer;
            return currentString.Copy();
        }

        private Matching FindMatching()
        {
            if (string.IsNullOrEmpty(buffer) || !buffer.Contains(sourceMessage[position]))
            {
                return new Matching(0, 0);
            }

            string foundPrefix = string.Empty;
            for (; position < sourceMessage.Length; position++)
            {
                if (buffer.Contains(foundPrefix + sourceMessage[position]))
                {
                    foundPrefix += sourceMessage[position];
                }
                else
                {
                    break;
                }
            }

            int index = buffer.Length - buffer.IndexOf(foundPrefix, 0);

            currentString.FoundPrefix = foundPrefix;
            return new Matching(index, foundPrefix.Length);
        }

        private void ShiftBuffer(int length)
        {
            var curBufLength = 0;
            if (startBufInd == 0 && buffer.Length + length <= bufLength)
            {
                curBufLength = buffer.Length + length;
            }
            else
            {
                startBufInd += length - (bufLength - buffer.Length);
                curBufLength = bufLength;
            }
            var l = curBufLength + startBufInd > sourceMessage.Length ? sourceMessage.Length : curBufLength + startBufInd;

            buffer = string.Empty;
            for (int i = startBufInd; i < l; i++)
            {
                buffer += sourceMessage[i];
            }
        }
    }

    public class LZ77_Node
    {
        public int Offset;
        public int Length;
        public char Next;
        public string Buffer;
        public string FoundPrefix;

        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}> {3}", Offset, Length, Next, Buffer);
        }

        public LZ77_Node Copy() => new LZ77_Node
        {
            Offset = this.Offset,
            Length = this.Length,
            Next = this.Next,
            Buffer = this.Buffer
        };
    }

    public class Matching
    {
        public int Offset;
        public int Length;

        public Matching(int offset, int length)
        {
            Offset = offset;
            Length = length;
        }

        public override string ToString()
        {
            return string.Format("<{0}, {1}>", Offset, Length);
        }
    }
}
