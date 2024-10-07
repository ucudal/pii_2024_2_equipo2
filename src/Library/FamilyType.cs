namespace Library
{
    public class FamilyType
    {
        public string Name { get; set; }

        public FamilyType(string name)
        {
            this.Name = name;
        }

        public float AttackEffectivity(Attack attack, FamilyType type)
        {
            if (attack.AType.Name == "Water")
            {
                if (type.Name == "Fire")
                {
                    return attack.Damage * 2;
                }
                if (type.Name == "Grass")
                {
                    return attack.Damage / 2;
                }
            }

            if (attack.AType.Name == "Fire")
            {
                if (type.Name == "Grass")
                {
                    return attack.Damage * 2;
                }
                if (type.Name == "Water")
                {
                    return attack.Damage / 2;
                }
            }

            if (attack.AType.Name == "Grass")
            {
                if (type.Name == "Water")
                {
                    return attack.Damage * 2;
                }
                if (type.Name == "Fire")
                {
                    return attack.Damage / 2;
                }
            }

            return attack.Damage;
        }
    }
}