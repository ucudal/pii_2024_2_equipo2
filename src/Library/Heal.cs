using Library.Interfaces;

namespace Library;

public class Heal
{
    public string Name { get; set; }
    public int HealingAmount { get; set; }
    public IType HType { get; }

    public Heal(string name, int healingAmount, IType hType)
    {
        this.Name = name;
        this.HealingAmount = healingAmount;
        this.HType = hType;
    }

    public Heal(int healingAmount)
    {
        this.HealingAmount = healingAmount;
    }
}