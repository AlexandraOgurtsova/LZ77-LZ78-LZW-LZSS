using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZW
{
    public class LZW_Controller
    {
        public bool IsCompressionEnd { get { return coder.IsEnd; } }
        public bool IsDecompressionEnd { get { return compressedBytes.Count == 0; } }

        private LZW_Coder coder = new LZW_Coder();
        private LZW_Decoder decoder = new LZW_Decoder();
        private List<string> compressedBytes = new List<string>();
        private Dictionary<int, string> baseDictionary;

        #region Coder

        public void InitCompress(string sourceMessage)
        {
            coder.Init(sourceMessage, out baseDictionary);
        }

        public LZW_Coding_String GetCodingString()
        {
            var result = coder.IsEnd ? null : coder.CoderIteration();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.Bytes))
                    compressedBytes.Add(result.Bytes);
            }
            return result;
        }

        public List<LZW_Coding_String> GetRemainingCodingStrings()
        {
            var result = new List<LZW_Coding_String>();
            if (coder.IsEnd)
            {
                return null;
            }

            while (!coder.IsEnd)
            {
                var newStr = coder.CoderIteration();
                if (!string.IsNullOrEmpty(newStr.Bytes))
                    compressedBytes.Add(newStr.Bytes);
                result.Add(newStr);
            }
            return result;
        }

        #endregion

        #region Decoder

        public void InitDecompress()
        {
            decoder.Init(baseDictionary);
        }

        public LZW_Decoding_String GetDecodingString()
        {
            var result = compressedBytes.Count == 0 ? null : decoder.DecoderIteration(compressedBytes[0]);
            compressedBytes.RemoveAt(0);

            return result;
        }

        public List<LZW_Decoding_String> GetRemainingDecodingStrings()
        {
            var result = new List<LZW_Decoding_String>();
            if (compressedBytes.Count == 0)
            {
                return null;
            }
            
            for (int i = 0; i < compressedBytes.Count; i++)
            {
                result.Add(decoder.DecoderIteration(compressedBytes[i]));
            }
            compressedBytes.Clear();

            return result;
        }

        #endregion
    }
}
