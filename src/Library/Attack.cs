using Library.Interfaces;
namespace Library;

public class Attack
{
    public string Name { get; set; }
    public float Damage { get; set; }
    public IType AType { get; }

    public Attack(string name, float damage, IType aType)
    {
        this.Name = name;
        this.AType = aType;
        this.Damage = damage;
    }
}