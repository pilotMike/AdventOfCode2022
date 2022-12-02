using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared.Tools
{
    internal struct SpanLineEnumerable : IEnumerable<(Range range, string text)>
    {
        private readonly string text;

        public SpanLineEnumerable(string text) => this.text = text;
        public SpanLineEnumerator GetEnumerator() => new (text);

        IEnumerator IEnumerable.GetEnumerator() => new SpanLineEnumerator(text);

        IEnumerator<(Range range, string text)> IEnumerable<(Range range, string text)>.GetEnumerator() => new SpanLineEnumerator(text);
    }

    internal struct SpanLineEnumerator : IEnumerator<(Range range, string text)>
    {
        private static readonly int NewLineLength = System.Environment.NewLine.Length;
        private readonly string text;
        private int offset, end;
        private bool eof;

        public SpanLineEnumerator(string text)
        {
            this.text = text;
            offset = 0;
            end = -NewLineLength;
        }

        public bool MoveNext()
        {
            if (eof) return false;
            int next = text.IndexOf("\r\n", end + NewLineLength);
            if (next != -1)
            {
                offset = end + NewLineLength;
                end = next;
                return true;
            }
            else
            {
                // to ensure the last segment is hit or return the whole length
                offset = end + NewLineLength;
                end = text.Length;
                eof = true;
                return true;
            }
        }

        public (Range range, string text) Current => (new(offset, end), text);

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }


        object IEnumerator.Current => Current;
    }
}
