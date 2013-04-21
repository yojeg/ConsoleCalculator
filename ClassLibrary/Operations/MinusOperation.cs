namespace ClassLibrary.Operations
{
    public class MinusOperation : IOperation
    {
        public int OperationPriority
        {
            get
            {
                return 2;
            }
        }


        public string OperationSign {
            get
            {
                return "-";
            }
        }

        public decimal GetResult(decimal[] arguments)
        {
            return arguments[0] - arguments[1];
        }
    }
}