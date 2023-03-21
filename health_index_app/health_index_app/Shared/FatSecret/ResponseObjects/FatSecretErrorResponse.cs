namespace health_index_app.Shared.FatSecret.ResponseObjects
{
    public class FatSecretErrorResponse
    {
        public FatSecretError Error { get; set; }
    }

    public class FatSecretError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
