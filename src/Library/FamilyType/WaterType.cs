using Library.Interfaces;

namespace Library.FamilyType;

public class WaterType: IType
{
    public float CalculateEffectivity(IType attackType)
    {
        if (attackType is FireType)
        {
            return 0.5f;
        }
        else if (attackType is GrassType)
        {
            return 2.0f;
        }
        else
        {
            return 1.0f;
        }
    }
}
