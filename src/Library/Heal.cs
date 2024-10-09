namespace Library;

public class Heal
{
    public string Name { get; set; }
    public float HealingAmount { get; set; }

    public Heal(float healingAmount)
    {
        this.HealingAmount = healingAmount;
    }
}