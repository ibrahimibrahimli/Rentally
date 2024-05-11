namespace Core.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string Message) : base(Message, false)
        {
        }
    }
}
