namespace Library;

public class Pokemon
{
    public float Life { get; set; }
    public Type PType { get; set; }
    public List<Attack> Attacks { get; set; }
    public int Speed { get; set; }

    public Pokemon(float life, Type pType, List<Attack> attacks, int speed)
    {
        this.Life = life;
        this.PType = pType;
        this.Attacks = attacks;
        this.Speed = speed;
    }

    public void ReceiveAttack(Attack attack)
    {
        float baseDamage = attack.Damage;
        this.Life -= AttackEffectivity(attack, this.PType);
        attack.Damage = baseDamage;
    }
}