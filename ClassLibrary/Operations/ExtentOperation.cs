namespace ClassLibrary.Operations
{
    public class ExtentOperation : IOperation
    {
        public int OperationPriority
        {
            get
            {
                return 3;
            }
        }


        public string OperationSign
        {
            get
            {
                return "^";
            }
        }


        public decimal GetResult(decimal[] arguments)
        {
            return (decimal)System.Math.Pow((double)arguments[0], (double)arguments[1]);
        }
    }
}