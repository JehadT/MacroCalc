namespace MacroCalc.Domain.Entities;

public class MacroEntry
{
    public int Id { get; set; }
    public int Calorie { get; private set; }
    public int Fat { get; set; }

    public int Carb { get; set; }

    public int Protein { get; set; }

    public DateTime Date { get; set; }
    public string UserId { get; set; } = null!;

    public void CalculateCalorie()
    {
        Calorie = Fat * 9 + Carb * 4 + Protein * 4;
    }
}
