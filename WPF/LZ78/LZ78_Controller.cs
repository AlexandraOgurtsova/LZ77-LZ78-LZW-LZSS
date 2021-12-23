using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WPF.LZ78
{
    public class LZ78_Controller
    {
        public bool IsCompressionEnd { get { return coder.IsEnd; } }
        public bool IsDecompressionEnd { get { return compressedResult.Count == 0; } }

        private LZ78_Coder coder = new LZ78_Coder();
        private LZ78_Decoder decoder = new LZ78_Decoder();
        private List<Node> compressedResult = new List<Node>();

        #region Coder

        public void InitCompress(string sourceMessage)
        {
            coder.Init(sourceMessage);
        }

        public LZ78_Coding_String GetCodingString()
        {
            var result = coder.IsEnd ? null : coder.CoderIteration();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.Code))
                    compressedResult.Add(new Node(){ next = result.next, pos = result.pos});
            }
            return result;
        }

        public List<LZ78_Coding_String> GetRemainingCodingStrings()
        {
            var result = new List<LZ78_Coding_String>();
            if (coder.IsEnd)
            {
                return null;
            }

            while (!coder.IsEnd)
            {
                var newStr = coder.CoderIteration();
                if (!string.IsNullOrEmpty(newStr.Code))
                    compressedResult.Add(new Node() { next = newStr.next, pos = newStr.pos });
                result.Add(newStr);
            }
            return result;
        }

        #endregion

        #region Decoder

        public void InitDecompress()
        {
            decoder.Init();
        }

        public LZ78_Coding_String GetDecodingString()
        {
            var result = compressedResult.Count == 0 ? null : decoder.DecoderIteration(compressedResult[0].pos, compressedResult[0].next);
           // do
           // {
                compressedResult.RemoveAt(0);
           // } while (compressedResult.Count > 1 && string.IsNullOrEmpty(compressedResult[0].next.ToString()));

            return result;
        }

        public List<LZ78_Coding_String> GetRemainingDecodingStrings()
        {
            var result = new List<LZ78_Coding_String>();
            if (compressedResult.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < compressedResult.Count; i++)
            {
                result.Add(decoder.DecoderIteration(compressedResult[i].pos, compressedResult[i].next));
            }
            compressedResult.Clear();

            return result;
        }

        #endregion
    }

    public class Node
    {
        public int pos;
        public char next;
    }
}