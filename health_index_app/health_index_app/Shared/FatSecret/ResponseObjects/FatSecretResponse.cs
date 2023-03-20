namespace FatSecretAPICall.ResponseObjects
{
    public class FatSecretResponse
    {
        public bool Successful => Error == null;
        public FatSecretError Error { get; set; }
    }
}
