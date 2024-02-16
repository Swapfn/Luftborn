namespace Models.DTO
{
    public class Response<T> where T : class
    {
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public List<Error>? Error { get; set; } 

    }
    public class Error()
    {
        public string ErrorMessage { get; set; } = null!;
    }
}
