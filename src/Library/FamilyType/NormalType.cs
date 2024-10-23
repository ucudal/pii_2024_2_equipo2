using Library.Interfaces;

namespace Library.FamilyType;

public class NormalType: IType
{ 
    private static NormalType instance;
    private NormalType()
    {
    }
    public static NormalType GetInstance()
    {
        if (instance == null)
        {
            instance = new NormalType();
        }

        return instance;
    }
}