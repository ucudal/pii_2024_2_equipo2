using Library.Interfaces;

namespace Library;

public class Pokemon
{
    public string Name { get; set; }
    public float Life { get; set; }
    public IType PType { get; set; }
    public List<Attack> Attacks { get; set; }
    public int Speed { get; set; }

    public Pokemon(string name, float life, IType pType, List<Attack> attacks, int speed)
    {
        this.Name = name;
        this.Life = life;
        this.PType = pType;
        this.Attacks = attacks;
        this.Speed = speed;
    }

    public void ReceiveAttack(Attack attack)
    { 
        float efectividad = this.PType.CalculateEffectivity(attack.AType);
        this.Life -= attack.Damage * efectividad;
    }
    
    public void ReceiveHealing(Heal heal)
    {
        this.Life += heal.HealingAmount;
    }
    public void IncreaseSpeed(int speedAmount)
    {
        int increaseAmount = (this.Speed * speedAmount) / 100;
        this.Speed += increaseAmount;
    }
}