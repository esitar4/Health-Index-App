namespace health_index_app.Shared.FatSecret.Requests
{
    public class FoodGetV2Request : IFatSecretRequest
    {
        private readonly string _method = "food.get.v2";
        public int FoodId { get; set; }
        public bool IncludeSubCategory { get; set; } = false;

        public List<(string, string)> GetParameters()
        {
            var headers = new List<(string, string)>();
            headers.Add(("method", _method));
            headers.Add(("food_id", FoodId.ToString()));
            headers.Add(("include_sub_categories", IncludeSubCategory.ToString()));
            return headers;
        }
    }
}
