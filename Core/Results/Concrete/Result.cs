using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool IsSucces) 
        {
            this.IsSuccess = IsSucces;
        }

        public Result(string Message, bool IsSucces) : this(IsSucces)
        {
            this.Message = Message;
        }
        public string Message { get; }

        public bool IsSuccess { get; }
    }
}
