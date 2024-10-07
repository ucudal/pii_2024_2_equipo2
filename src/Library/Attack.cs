namespace Library;

public class Attack
{
    public Type AType { get; }
    public float Damage;

    public Attack(Type aType, float damage)
    {
        this.AType = aType;
        this.Damage = damage;
    }

}