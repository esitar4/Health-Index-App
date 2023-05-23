using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Shared.Models
{
    [Index(nameof(Id), nameof(ServingId), IsUnique = true)]
    public class Food
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //use food_id from fatsecret api
        public int Id { get; set; }

        [Required]
        public string FoodName { get; set; } = "";
        public string FoodType { get; set; } = "";
        public string BrandName { get; set; } = "";
        [Required]
        public string FoodURL { get; set; } = "";

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServingId { get; set; }
        [Required]
        public string ServingDescription { get; set; } = "";
        public string ServingURL { get; set; } = "";

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Metric Serving Amount must be larger than 0")]
        public double MetricServingAmount { get; set; }

        public string MetricServingUnit { get; set; } = "";
        public double NumberOfUnits { get; set; }
        [Required]
        public string MeasurementDescription { get; set; } = "";


        public double? Calories { get; set; }


        public double? CarboHydrate { get; set; }


        public double? Protein { get; set; }


        public double? Fat { get; set; }


        public double? SaturatedFat { get; set; }


        public double? PolyunsaturatedFat { get; set; }


        public double? MonounsaturatedFat { get; set; }


        public double? Cholesterol { get; set; }


        public double? Sodium { get; set; }


        public double? Potassium { get; set; }


        public double? Fiber { get; set; }


        public double? Sugar { get; set; }


        public double? AddedSugar { get; set; }


        public double? VitaminD { get; set; }


        public double? VitaminA { get; set; }


        public double? VitaminC { get; set; }


        public double? Calcium { get; set; }


        public double? Iron { get; set; }

    }
}
