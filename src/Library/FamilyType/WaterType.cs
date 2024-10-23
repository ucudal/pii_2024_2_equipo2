using Library.Interfaces;

namespace Library.FamilyType;

public class WaterType: IType
{
    private static WaterType instance;
    private WaterType()
    {
    }
    public static WaterType GetInstance()
    {
        if (instance == null)
        {
            instance = new WaterType();
        }

        return instance;
    }
}
