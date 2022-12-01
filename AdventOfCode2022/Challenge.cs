using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AdventOfCodeTests")]

namespace AdventOfCode2022
{
    internal abstract class Challenge
    {
        public abstract Input DefaultInput { get; set; }


        public string Execute(Input? input)
        {
            return this.ExecuteInternal(input ?? DefaultInput);
        }

        protected abstract string ExecuteInternal(Input input);
    }
}
