namespace Library;

public class Type
{
    public string Name { get; set; }

    public Type(string name)
    {
        this.Name = name;
    }

    public float AttackEffectivity(Attack attack, Type type)
    {
        if (attack.AType.Name == "Water")
        {
            if (type.Name == "Fire")
            {
                attack.Damage = attack.Damage * 2;
            }
            if (type.Name == "Grass")
            {
                attack.Damage = attack.Damage / 2;
            }
        }
        
        if (attack.AType.Name == "Fire")
        {
            if (type.Name == "Grass")
            {
                attack.Damage = attack.Damage * 2;
            }
            if (type.Name == "Water")
            {
                attack.Damage = attack.Damage / 2;
            }
        }
        
        if (attack.AType.Name == "Grass")
        {
            if (type.Name == "Water")
            {
                attack.Damage = attack.Damage * 2;
            }
            if (type.Name == "Fire")
            {
                attack.Damage = attack.Damage / 2;
            }
        }

        return attack.Damage;
    }
}