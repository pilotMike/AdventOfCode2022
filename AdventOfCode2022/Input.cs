using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Input
    {
        private readonly string lines;

        public Input(string lines)
        {
            this.lines = lines;
        }

        public T ParseLines<T>(Func<IEnumerable<string>, T> selector)
        {
            return selector(this.lines.Split(Environment.NewLine)); 

        }
    }
}
