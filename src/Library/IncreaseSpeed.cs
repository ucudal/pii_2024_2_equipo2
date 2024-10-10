using Library.Interfaces;

namespace Library;

public class IncreaseSpeed
{
    public string Name { get; set; }
    public int SpeedAmount { get; set; }
    public IType IncType { get; }

    public IncreaseSpeed(string name, int speedAmount, IType incType)
    {
        this.Name = name;
        this.SpeedAmount = speedAmount;
        this.IncType = incType;
    }

    public IncreaseSpeed(int speedAmount)
    {
        this.SpeedAmount = speedAmount;
    }
}