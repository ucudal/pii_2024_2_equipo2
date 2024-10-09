using Library.Interfaces;

namespace Library.FamilyType;

public class GrassType: IType
{
    public string Name { get; set; }

    public float CalculateEffectivity(IType attackType)
    {
        if (attackType is WaterType)
        {
            return 0.5f;
        }
        else if (attackType is FireType)
        {
            return 2.0f;
        }
        else
        {
            return 1.0f;
        }
    }
}