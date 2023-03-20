namespace FatSecretAPICall.Requests
{
    public interface IFatSecretRequest
    {
        List<(String, String)> GetParameters();
    }
}
