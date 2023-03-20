namespace FatSecretAPICall.ResponseObjects
{
    public class GetFoodResponse : FatSecretResponse
    {
        public Food Food { get; set; }
    }

    public class Food
    {
        public string Food_Id { get; set; }
        public string Food_Name { get; set; }
        public string Brand_Name { get; set; }
        public string Food_Type { get; set; }
        public string Food_Url { get; set; }
        public Servings Servings { get; set; }

        public override string ToString()
        {
            string s = "";
            s += $"Food_Id:{Food_Id},\n";
            s += $"Food_Name:{Food_Name},\n";
            s += $"Brand_Name:{Brand_Name},\n";
            s += $"Food_Type:{Food_Type},\n";
            s += $"Food_Url:{Food_Url},\n";
            return s;
        }
    }

    public class Servings
    {
        public List<Serving> Serving { get; set; }
    }

    public class Serving
    {
        public string Calcium { get; set; }
        public string Calories { get; set; }
        public string Carbohydrate { get; set; }
        public string Cholesterol { get; set; }
        public string Fat { get; set; }
        public string Fiber { get; set; }
        public string Iron { get; set; }
        public string Measurement_Description { get; set; }
        public string Metric_Serving_Amount { get; set; }
        public string Metric_Serving_Unit { get; set; }
        public string Monounsaturated_Fat { get; set; }
        public string Number_Of_Units { get; set; }
        public string Polyunsaturated_Fat { get; set; }
        public string Potassium { get; set; }
        public string Protein { get; set; }
        public string Saturated_Fat { get; set; }
        public string Serving_Description { get; set; }
        public string Serving_Id { get; set; }
        public string Serving_Url { get; set; }
        public string Sodium { get; set; }
        public string Sugar { get; set; }
        public string Vitamin_A { get; set; }
        public string Vitamin_C { get; set; }
        public string Vitamin_D { get; set; }

        public override string ToString()
        {
            string s = "";
            s += $"Calcium:{Calcium},\n";
            s += $"Calories:{Calories},\n";
            s += $"Carbohydrate:{Carbohydrate},\n";
            s += $"Cholesterol:{Cholesterol},\n";
            s += $"Fat:{Fat},\n";
            s += $"Fiber:{Fiber},\n";
            s += $"Iron:{Iron},\n";
            s += $"Measurement_Description:{Measurement_Description},\n";
            s += $"Metric_Serving_Amount:{Metric_Serving_Amount},\n";
            s += $"Metric_Serving_Unit:{Metric_Serving_Unit},\n";
            s += $"Monounsaturated_Fat:{Monounsaturated_Fat},\n";
            s += $"Number_Of_Units:{Number_Of_Units},\n";
            s += $"Polyunsaturated_Fat:{Polyunsaturated_Fat},\n";
            s += $"Potassium:{Potassium},\n";
            s += $"Protein:{Protein},\n";
            s += $"Saturated_Fat:{Saturated_Fat},\n";
            s += $"Serving_Description:{Serving_Description},\n";
            s += $"Serving_Id:{Serving_Id},\n";
            s += $"Serving_Url:{Serving_Url},\n";
            s += $"Sodium:{Sodium},\n";
            s += $"Sugar:{Sugar},\n";
            s += $"Vitamin_A:{Vitamin_A},\n";
            s += $"Vitamin_C:{Vitamin_C},\n";
            s += $"Vitamin_D:{Vitamin_D},\n";
            return s;
        }
    }
}
