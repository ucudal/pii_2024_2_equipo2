﻿using Library.Interfaces;

namespace Library.FamilyType;

public class GrassType: IType
{
    public string Name { get; set; }

    public float CalculateEffectivity(IType oponentType)
    {
        if (oponentType is WaterType)
        {
            return 2.0f;
        }
        else if (oponentType is FireType)
        {
            return 0.5f;
        }
        else
        {
            return 1.0f;
        }
    }
}