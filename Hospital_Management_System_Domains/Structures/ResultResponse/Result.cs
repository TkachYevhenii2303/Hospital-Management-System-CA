
using Hospital_Management_System_Domains.Structures.WrapperResponse.Interfaces;

namespace Hospital_Management_System_DAL.Wrapper_Response
{
    public class Result<TEntity> : IResult<TEntity>
    {
        public TEntity? Entity { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool Succeeded { get; set; } = true;

        public Exception? Exception { get; set; }
        
        public int StatusCode { get; set; }

        public static Result<TEntity> Success(TEntity result, string messages)
        {
            return new Result<TEntity>()
            {
                Succeeded = true,
                Entity = result,
                Message = messages
            };
        }

        public static Task<Result<TEntity>> SuccessAsync(TEntity result, string messages)
        {
            return Task.FromResult(Success(result, messages));
        }
    }
}
