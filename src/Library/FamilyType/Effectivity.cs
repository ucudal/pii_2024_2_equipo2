using Library.Interfaces;

namespace Library.FamilyType;

public class Effectivity
{
    public static readonly WaterType waterType = new WaterType();
    public static readonly FireType fireType = new FireType();
    public static readonly NormalType normalType = new NormalType();
    public static readonly GrassType grassType = new GrassType();

    private readonly Dictionary<IType, Dictionary<IType, float>> _effectivityTable;

        public Effectivity()
        {
            // Inicializar la tabla de efectividad
            _effectivityTable = new Dictionary<IType, Dictionary<IType, float>>
            {
                { fireType, new Dictionary<IType, float>
                {
                    { waterType, 0.5f }, 
                    { fireType, 1.0f }, 
                    { normalType, 1.0f }, 
                    { grassType, 2.0f }
                } 
                },
                
                { waterType, new Dictionary<IType, float>
                {
                    { fireType, 2.0f }, 
                    { grassType, 0.5f }, 
                    { waterType, 1.0f }, 
                    { normalType, 1.0f }
                } 
                },
                
                { grassType, new Dictionary<IType, float>
                {
                    { waterType, 2.0f }, 
                    { fireType, 0.5f }, 
                    { grassType, 1.0f }, 
                    { normalType, 1.0f }
                } 
                },
                
                { normalType, new Dictionary<IType, float>
                {
                    { fireType, 1.0f }, 
                    { waterType, 1.0f }, 
                    { grassType, 1.0f }, 
                    { normalType, 1.0f }
                } 
                },
            };
        }

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
}
