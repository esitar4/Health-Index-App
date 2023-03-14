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
        /*
         * calories is a Decimal – the energy content in kcal.
carbohydrate is a Decimal – the total carbohydrate content in grams.
protein is a Decimal – the protein content in grams.
fat is a Decimal – the total fat content in grams.
saturated_fat is a Decimal – the saturated fat content in grams (where available).
polyunsaturated_fat is a Decimal – the polyunsaturated fat content in grams (where available).
monounsaturated_fat is a Decimal – the monounsaturated fat content in grams (where available).
trans_fat is a Decimal – the trans fat content in grams (where available).
cholesterol is a Decimal – the cholesterol content in milligrams (where available).
sodium is a Decimal – the sodium content in milligrams (where available).
potassium is a Decimal – the potassium content in milligrams (where available).
fiber is a Decimal – the fiber content in grams (where available).
sugar is a Decimal – the sugar content in grams (where available).
added_sugars is a Decimal – the Added Sugars content in grams (where available).
vitamin_d is a Decimal – the Vitamin D content in micrograms (where available).
vitamin_a is a Decimal – the Vitamin A content in micrograms (where available).
vitamin_c is a Decimal – the Vitamin C content in milligrams (where available).
calcium is a Decimal – the Calcium content in milligrams (where available).
iron i
         */

    }
}
