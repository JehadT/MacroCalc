using System.ComponentModel.DataAnnotations;

namespace MacroCalc.Models
{
    public class MacroEntry
    {
        public int Id { get; set; }
        public int Calorie { get; set; }
        public int? Fat { get; set; } = int.MinValue;

        public int? Carb { get; set; } = int.MinValue;

        public int? Protein { get; set; } = int.MinValue;

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        public void CalculateCalorie()
        {
            Calorie = (Fat ?? 0) * 9 + (Carb ?? 0) * 4 + (Protein ?? 0) * 4;
        }
    }
}
