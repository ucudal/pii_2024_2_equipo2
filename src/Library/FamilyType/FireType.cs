using Library.Interfaces;

namespace Library.FamilyType;

public class FireType: IType
{
   
    private static FireType instance;
    private FireType()
    {
    }
    public static FireType GetInstance()
    {
        if (instance == null)
        {
            instance = new FireType();
        }

        return instance;
    }

    
}