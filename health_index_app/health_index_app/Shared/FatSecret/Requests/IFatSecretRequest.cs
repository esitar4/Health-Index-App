namespace health_index_app.Shared.FatSecret.Requests
{
    public interface IFatSecretRequest
    {
        List<(String, String)> GetParameters();
    }
}
