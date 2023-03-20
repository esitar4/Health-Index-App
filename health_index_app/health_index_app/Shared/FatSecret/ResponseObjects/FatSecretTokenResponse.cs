namespace health_index_app.Shared.FatSecret.ResponseObjects
{
    public class FatSecretTokenResponse
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_In { get; set; }
    }
}
