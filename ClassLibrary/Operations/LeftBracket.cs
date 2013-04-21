namespace ClassLibrary.Operations
{
    public class LeftBracket : IOperation
    {
        public int OperationPriority
        {
            get
            {
                return 0;
            }
        }


        public string OperationSign
        {
            get
            {
                return "(";
            }
        }


        public decimal GetResult(decimal[] arguments)
        {
            throw new System.NotImplementedException();
        }
    }
}