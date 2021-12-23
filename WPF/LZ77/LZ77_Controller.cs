using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZ77
{
    public class LZ77_Controller
    {
        public bool IsCompressionEnd { get { return coder.IsEnd; } }
        public bool IsDecompressionEnd { get { return compressedResult.Count == 0; } }

        private LZ77_Coder coder = new LZ77_Coder();
        private LZ77_Decoder decoder = new LZ77_Decoder();
        private List<LZ77_Node> compressedResult = new List<LZ77_Node>();

        #region Coder

        public void InitCompress(string sourceMessage, int bufSize)
        {
            coder.Init(sourceMessage, bufSize);
        }

        public LZ77_Node GetCodingString()
        {
            var result = coder.IsEnd ? null : coder.CoderIteration();
            if (result != null)
            {
                compressedResult.Add(result);
            }
            return result;
        }

        public List<LZ77_Node> GetRemainingCodingStrings()
        {
            var result = new List<LZ77_Node>();
            if (coder.IsEnd)
            {
                return null;
            }

            while (!coder.IsEnd)
            {
                var newStr = coder.CoderIteration();
                compressedResult.Add(newStr);
                result.Add(newStr);
            }
            return result;
        }

        #endregion

        #region Decoder

        public void InitDecompress()
        {
            decoder.Init(compressedResult);
        }

        public LZ77_Decoder_String GetDecodingString()
        {
            var result = compressedResult.Count == 0 ? null : decoder.DecoderIteration();
            
            compressedResult.RemoveAt(0);

            return result;
        }

        public List<LZ77_Decoder_String> GetRemainingDecodingStrings()
        {
            var result = new List<LZ77_Decoder_String>();
            if (compressedResult.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < compressedResult.Count; i++)
            {
                result.Add(decoder.DecoderIteration());
            }
            compressedResult.Clear();

            return result;
        }

        #endregion
    }
}
