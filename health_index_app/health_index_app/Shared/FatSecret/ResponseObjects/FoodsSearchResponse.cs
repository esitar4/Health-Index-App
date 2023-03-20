namespace FatSecretAPICall.ResponseObjects
{
    public class FoodsSearchResponse : FatSecretResponse
    {
        public SearchedFoods Foods { get; set; }
    }
    public class SearchedFoods
    {
        public List<SearchedFood> Food { get; set; }
        public string Max_Results { get; set; }
        public string Page_Number { get; set; }
        public string Total_Results { get; set; }

        public override string ToString()
        {
            string s = "";
            s += $"Max_Results:{Max_Results},\n";
            s += $"Page_Number:{Page_Number},\n";
            s += $"Total_Results:{Total_Results},\n";
            return s;
        }
    }
    public class SearchedFood
    {
        public string Brand_Name { get; set; } = "Generic";
        public string Food_Description { get; set; }
        public string Food_Id { get; set; }
        public string Food_Name { get; set; }
        public string Food_Type { get; set; }
        public string Food_Url { get; set; }

        public override string ToString()
        {
            string s = "";
            s += $"Brand_Name:{Brand_Name},\n";
            s += $"Food_Description:{Food_Description},\n";
            s += $"Food_Id:{Food_Id},\n";
            s += $"Food_Name:{Food_Name},\n";
            s += $"Food_Type:{Food_Type},\n";
            s += $"Food_Url:{Food_Url},\n";
            return s;
        }
    }
}
