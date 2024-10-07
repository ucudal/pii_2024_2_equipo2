namespace Library;

public class Pokemon
{
    public float Life { get; set; }
    public FamilyType PType { get; set; }
    public List<Attack> Attacks { get; set; }
    public int Speed { get; set; }

    public Pokemon(float life, FamilyType pType, List<Attack> attacks, int speed)
    {
        this.Life = life;
        this.PType = pType;
        this.Attacks = attacks;
        this.Speed = speed;
    }

    public void ReceiveAttack(Attack attack)
    {
        this.Life -= PType.AttackEffectivity(attack, this.PType);
    }
    
}