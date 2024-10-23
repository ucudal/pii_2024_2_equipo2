using Library.Interfaces;

namespace Library.FamilyType;

public class Effectivity
{
    public static readonly IType waterType = WaterType.GetInstance();
    public static readonly IType fireType =  FireType.GetInstance();
    public static readonly IType normalType = NormalType.GetInstance();
    public static readonly IType grassType = GrassType.GetInstance();

    private Dictionary<IType, Dictionary<IType, float>> _effectivityTable;

    public Effectivity()
    {
        // Inicializar la tabla de efectividad
        _effectivityTable = new Dictionary<IType, Dictionary<IType, float>>
        {
            {
                fireType, new Dictionary<IType, float>
                {
                    { waterType, 0.5f },
                    { fireType, 1.0f },
                    { normalType, 1.0f },
                    { grassType, 2.0f }
                }
            },

            {
                waterType, new Dictionary<IType, float>
                {
                    { fireType, 2.0f },
                    { grassType, 0.5f },
                    { waterType, 1.0f },
                    { normalType, 1.0f }
                }
            },

            {
                grassType, new Dictionary<IType, float>
                {
                    { waterType, 2.0f },
                    { fireType, 0.5f },
                    { grassType, 1.0f },
                    { normalType, 1.0f }
                }
            },

            {
                normalType, new Dictionary<IType, float>
                {
                    { fireType, 1.0f },
                    { waterType, 1.0f },
                    { grassType, 1.0f },
                    { normalType, 1.0f }
                }
            },
        };
    }

    /*

     public float CalculateEffectivity(IType attackType, IType opponentType)
     {
         if (_effectivityTable.TryGetValue(attackType, out var opponents))
         {
             if (opponents.TryGetValue(opponentType, out var effectivity))
             {
                 return effectivity;
             }
         }
         return 111.0f; // Efectividad por defecto
     }
     */
    public float CalculateEffectivity(IType attackType, IType opponentType)
    {
        foreach (KeyValuePair<IType, Dictionary<IType, float> > kvp in _effectivityTable)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        if (_effectivityTable.ContainsKey(attackType))
        {
            
            if (_effectivityTable.TryGetValue(attackType, out var effec))
            {
                if (effec.TryGetValue(opponentType, out float effectivity))
                {
                    Console.WriteLine(effectivity);
                    return effectivity;
                }

                return 123;
            }

            return 234;
        }

        return 345;
    }

}
