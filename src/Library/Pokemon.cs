using Library.Interfaces;

namespace Library;

public class Pokemon
{
    public float Life { get; set; }
    public IType PType { get; set; }
    public List<Attack> Attacks { get; set; }
    public int Speed { get; set; }

    public Pokemon(float life, IType pType, List<Attack> attacks, int speed)
    {
        this.Life = life;
        this.PType = pType;
        this.Attacks = attacks;
        this.Speed = speed;
    }

    public void ReceiveAttack(Attack attack, IType oponentType)
    {
        float efectividad = oponentType.CalculateEffectivity(oponentType);
        
        this.Life -= efectividad;
    }
    
    public void ReceiveHeal(Heal heal)
    {
        float healingAmount = (this.Life * 15) / 100;
        this.Life += healingAmount;
    }
}