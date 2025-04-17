using UnityEngine;

public static class Direction
{
    public enum DirectionEnum
    {
        up, down, left, right, MAX
    }

    private static DirectionEnum m_Type;
    public static DirectionEnum TypeDir => m_Type;

    public static DirectionEnum GetRandomDirection()
    {
        m_Type = (DirectionEnum)Random.Range(0, (int)DirectionEnum.MAX);
        return m_Type;
    }
}
