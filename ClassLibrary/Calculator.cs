using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Operations;
using ClassLibrary.Parser;
using ClassLibrary.Validator;

namespace ClassLibrary
{
    public class Calculator
    {
        private  IList<IOperation> _operations = new List<IOperation>();
        private  IValidator _validator;
        private IParser _parser;
        private string _example;

        public Calculator AddOperation(IOperation operation)
        {
            _operations.Add(operation);
            return this;
        }

        public IEnumerable<IOperation> GetOperations()
        {
            return _operations;
        }

        public void SetExample(string example)
        {
            _example = example;
        }

        public Calculator(IValidator validator, IParser parser)
        {
            _validator = validator;
            _parser = parser;
        }

        

        public decimal Calculate()
        {
            if (_validator.Validate(_example))
            {
                _parser.SetOperationSigns(_operations);
                var result = _parser.Parse(_example);

                var stack = new Stack<string>();
                var queue = new Queue<string>(result);
                string str = queue.Dequeue();
                while (queue.Count >= 0)
                {
                    if (_operations.All(x => x.OperationSign != str))
                    {
                        stack.Push(str);
                        str = queue.Dequeue();
                    }
                    else
                    {
                        decimal summ = 0;
                        summ +=
                            _operations.First(x => x.OperationSign == str).GetResult(new[]
                                                                                         {
                                                                                             Convert.ToDecimal(
                                                                                                 stack.Pop()),
                                                                                             Convert.ToDecimal(
                                                                                                 stack.Pop())
                                                                                         });

                        stack.Push(summ.ToString());
                        if (queue.Count > 0)
                            str = queue.Dequeue();
                        else
                            break;
                    }

                }
                return Convert.ToDecimal(stack.Pop());
            }
            throw new Exception("wrong example");
        }
    }
}