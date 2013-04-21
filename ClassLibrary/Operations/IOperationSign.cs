namespace ClassLibrary.Operations
{
    public interface IOperationSign
    {
        int OperationPriority { get; }

        string OperationSign { get; }
    }
}