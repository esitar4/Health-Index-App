namespace FatSecretAPICall.Requests
{
    public class FoodGetV2Request : IFatSecretRequest
    {
        private readonly string _method = "food.get.v2";
        public int FoodId { get; set; }

        public List<(string, string)> GetParameters()
        {
            var headers = new List<(string, string)>();
            headers.Add(("method", _method));
            headers.Add(("food_id", FoodId.ToString()));
            return headers;
        }
    }
}
