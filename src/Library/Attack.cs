namespace Library;

public class Attack
{
    public FamilyType AType { get; }
    public float Damage;

    public Attack(FamilyType aType, float damage)
    {
        this.AType = aType;
        this.Damage = damage;
    }

}