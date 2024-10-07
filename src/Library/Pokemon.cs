namespace Library;

public class Pokemon
{
    private float Life { get; set; }
    private Type PType { get; set; }
    private List<Attack> Attacks { get; set; }
    private int Speed { get; set; }

    public Pokemon(float life, Type pType, List<attack> attacks, int speed)
    {
        this.Life = life;
        this.PType = pType;
        this.Attack = attacks;
        this.Speed = speed;
    }

    public void ReceiveAttack(Attack attack)
    {
        baseDamage = attack.damage;
        this.Life -= AttackEffectivity(attack, this.PType);
        attack.damage = baseDamage;
    }
}