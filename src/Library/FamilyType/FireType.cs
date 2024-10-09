using Library.Interfaces;

namespace Library.FamilyType;

public class FireType: IType
{
    public string Name { get; set; }

    public float CalculateEffectivity(IType attackType)
    {
        if (attackType is GrassType)
        {
            return 0.5f;
        }
        else if (attackType is WaterType)
        {
            return 2.0f;
        }
        else
        {
            return 1.0f;
        }
    }
}
