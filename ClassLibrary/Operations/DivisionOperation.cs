namespace ClassLibrary.Operations
{
    public class DivisionOperation : IOperation
    {
        public int OperationPriority
        {
            get
            {
                return 3;
            }
        }


        public string OperationSign { 
            get
            {
                return "/";
            }
        }

        public decimal GetResult(decimal[] arguments)
        {
            return arguments[0]/arguments[1];
        }
    }
}