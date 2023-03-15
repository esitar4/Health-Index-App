using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
