using System.Collections.Generic;
using ClassLibrary.Operations;

namespace ClassLibrary.Parser
{
    public interface IParser
    {
        string[] Parse(string example);
        void SetOperationSigns(IEnumerable<IOperationSign> operatorSigns);
    }
}