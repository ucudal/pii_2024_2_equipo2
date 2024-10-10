using Library.Interfaces;

namespace Library.FamilyType;

public class NormalType: IType
{ 
    public float CalculateEffectivity(IType attackType)
    {
        return 1.0f;
    }
}