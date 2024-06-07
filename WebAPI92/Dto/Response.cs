namespace WebAPI92.Dto
{
    public class Response<T>
    {
        public Response(T data, string? message = null) { 
            Success = true;
            Message = message;
            Result = data;
        }

        public Response(string? message = null) {
            Success = false;
            Message = message;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public T Result { get; set; }
    }
}
