using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.LZ77
{
    public class LZ77_Decoder
    {
        public bool IsEnd { get; private set; }

        List<LZ77_Node> nodes = new List<LZ77_Node>();
        private LZ77_Decoder_String curAnsv = new LZ77_Decoder_String();

        public void Init(List<LZ77_Node> nodes)
        {
            foreach (var node in nodes)
            {
                this.nodes.Add(node);
            }
        }

        public LZ77_Decoder_String DecoderIteration()
        {
            curAnsv.Node = nodes[0].Copy();
            if (nodes[0].Length > 0)
            {
                int start = curAnsv.Answer.Length - nodes[0].Offset;
                for (int i = 0; i < nodes[0].Length; i++)
                {
                    curAnsv.Answer += curAnsv.Answer[start + i];
                }
            }
            curAnsv.Answer += nodes[0].Next;

            nodes.RemoveAt(0);
            if (nodes.Count == 0)
            {
                IsEnd = true;
            }

            return curAnsv.Copy();
        }
    }

    public class LZ77_Decoder_String
    {
        public LZ77_Node Node;
        public string Answer = string.Empty;

        public LZ77_Decoder_String Copy() => new LZ77_Decoder_String { Node = this.Node.Copy(), Answer = this.Answer };
    }
}
