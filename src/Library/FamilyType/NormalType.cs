using Library.Interfaces;

namespace Library.FamilyType;

public class NormalType: IType
{
    public string Name { get; set; }

    public float CalculateEffectivity(IType oponentType)
    {
        return 1.0f;
    }
}