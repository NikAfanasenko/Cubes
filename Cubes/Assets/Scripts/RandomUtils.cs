using UnityEngine;

public static class RandomUtils 
{
    public const int MinChance = 0;
    public const int MaxChance = 100;    

    private const int MinCount = 2;
    private const int MaxCount = 6;

    private const int MinPosition = -3;
    private const int MaxPosition = 3;    

    private static System.Random _random = new System.Random();

    public static int GetRandomCubeCount()
    {
        return _random.Next(MinCount, MaxCount + 1);
    } 

    public static Color GetRandomColor()
    {
        return Random.ColorHSV(); 
    }

    public static Vector3 GetRandomPosition()
    {
        return new Vector3(GetRandomFloatNumber(), 0, GetRandomFloatNumber()); 
    }

    public static float GetRandomFloatNumber()
    {
        return (float)_random.NextDouble() * _random.Next(MinPosition, MaxPosition);
    }

    public static bool IsFallOut(float chance)
    {
        return _random.Next(MinChance, MaxChance + 1) < chance;
    }
}
