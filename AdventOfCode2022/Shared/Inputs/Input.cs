using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared.Inputs;
internal abstract class Input
{
    public abstract IEnumerable<char> Characters { get; }
}
