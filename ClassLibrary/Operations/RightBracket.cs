namespace ClassLibrary.Operations
{
    public class RightBracket : IOperation
    {
        public int OperationPriority
        {
            get
            {
                return 1;
            }
        }


        public string OperationSign
        {
            get
            {
                return ")";
            }
        }


        public decimal GetResult(decimal[] arguments)
        {
            throw new System.NotImplementedException();
        }
    }
}