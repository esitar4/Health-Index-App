using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared.Models
{
    public class Food
    {
        [Key]
        //use food_id from fatsecret api
        public int Id { get; set; }
        [Required]
        public string FoodName { get; set; } = null!;
        public string FoodType { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        [Required]
        public string FoodURL { get; set; } = null!;
        public int ServingId { get; set; }
        [Required]
        public string ServingDescription { get; set; } = null!;
        public string ServingURL { get; set; } = null!;
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Metric Serving Amount must be larger than 0")]
        [Column(TypeName = "double")]
        public double MetricServingAmount { get; set; }
        [Required]
        public string MetricServingUnit { get; set; } = null!;
        public double NumberOfUnits { get; set; }
        [Required]
        public string MeasurementDescription { get; set; } = null!;

        [Column(TypeName = "double")]
        public double? Calories { get; set; }

        [Column(TypeName = "double")]
        public double? CarboHydrate { get; set; }

        [Column(TypeName = "double")]
        public double? Protein { get; set; }

        [Column(TypeName = "double")]
        public double? Fat { get; set; }

        [Column(TypeName = "double")]
        public double? SaturatedFat { get; set; }

        [Column(TypeName = "double")]
        public double? PolyunsaturatedFat { get; set; }

        [Column(TypeName = "double")]
        public double? MonounsaturatedFat { get; set; }

        [Column(TypeName = "double")]
        public double? Cholesterol { get; set; }

        [Column(TypeName = "double")]
        public double? Sodium { get; set; }

        [Column(TypeName = "double")]
        public double? Potassium { get; set; }

        [Column(TypeName = "double")]
        public double? Fiber { get; set; }

        [Column(TypeName = "double")]
        public double? Sugar { get; set; }

        [Column(TypeName = "double")]
        public double? AddedSugar { get; set; }

        [Column(TypeName = "double")]
        public double? VitaminD { get; set; }

        [Column(TypeName = "double")]
        public double? VitaminA { get; set; }

        [Column(TypeName = "double")]
        public double? VitaminC { get; set; }

        [Column(TypeName = "double")]
        public double? Calcium { get; set; }

        [Column(TypeName = "double")]
        public double? Iron { get; set; }
    }
}
