using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    class Neuron
    {
        public int maxV = 1;
        public List<Dendrit> dendrits = new List<Dendrit>();
        public Neuron(int count, int max)
        {
            for (int i = 0; i < count; i++)
            {
                dendrits.Add(new Dendrit());
            }
            maxV = max;
        }
    }
}
