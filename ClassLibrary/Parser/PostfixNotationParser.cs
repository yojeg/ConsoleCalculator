using System;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary.Operations;

namespace ClassLibrary.Parser
{
    public class PostfixNotationParser : IParser
    {
        public void SetOperationSigns(IEnumerable<IOperationSign> operatorSigns)
        {
            _signs = new List<IOperationSign>(operatorSigns);
        }

        private List<IOperationSign> _signs;

        private IEnumerable<string> Separate(string input)
        {
            var pos = 0;
            while (pos < input.Length)
            {
                var s = string.Empty + input[pos];
                if (!_signs.Any(x=>x.OperationSign == input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }

        public string[] Parse(string input)
        {
            var outputSeparated = new List<string>();

            var stack = new Stack<string>();

            foreach (string c in Separate(input))
            {
                if (_signs.Any(x => x.OperationSign == c))
                {
                    var sign = _signs.First(x => x.OperationSign == c);

                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (sign.OperationPriority > _signs.First(x=>x.OperationSign == stack.Peek()).OperationPriority)
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && sign.OperationPriority <= _signs.First(x => x.OperationSign == stack.Peek()).OperationPriority)
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    outputSeparated.Add(c);
            }
            if (stack.Count > 0)
            {
                outputSeparated.AddRange(stack);
            }

            return outputSeparated.ToArray();
        }
    }
}