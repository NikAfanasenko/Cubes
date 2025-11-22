using System;
using UnityEngine;

public class Cube
{
    public Cube(float chance, Vector3 scale)
    {
        if (chance / 2 <= 0 || scale.x / 2 <= 0)
        {
            throw new ArgumentException();
        }

        AppearChance = chance;
        Scale = scale;
    }

    public float AppearChance { get; private set; }

    public Vector3 Scale { get; private set; }
}