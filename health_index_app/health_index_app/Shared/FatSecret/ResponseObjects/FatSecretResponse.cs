namespace health_index_app.Shared.FatSecret.ResponseObjects
{
    public class FatSecretResponse
    {
        public bool Successful => Error == null;
        public FatSecretError Error { get; set; }
    }
}
