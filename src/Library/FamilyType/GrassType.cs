using Library.Interfaces;

namespace Library.FamilyType;

public class GrassType: IType
{
    private static GrassType instance;
    private GrassType()
    {
    }
    public static GrassType GetInstance()
    {
        if (instance == null)
        {
            instance = new GrassType();
        }

        return instance;
    }
}