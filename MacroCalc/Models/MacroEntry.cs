using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MacroCalc.Models
{
    public class MacroEntry
    {
        public int Id { get; set; }
        public int Calorie { get; set; }
        public int Fat { get; set; }

        public int Carb { get; set; }

        public int Protein { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        public void CalculateCalorie()
        {
            Calorie = Fat * 9 + Carb * 4 + Protein * 4;
        }
    }
}
