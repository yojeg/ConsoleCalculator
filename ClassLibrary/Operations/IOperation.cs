namespace ClassLibrary.Operations
{
    public interface IOperation : IOperationSign
    {
        decimal GetResult(decimal[] arguments);
    }
}