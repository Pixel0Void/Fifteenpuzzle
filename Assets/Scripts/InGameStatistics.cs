using UnityEngine;

public class InGameStatistics : MonoBehaviour
{
    private static int m_MoveCount;
    public static int MoveCount => m_MoveCount;

    private float m_Time;
    private static bool m_IsTimerRunning;

    private void Update()
    {
        if (m_IsTimerRunning)
            m_Time += Time.deltaTime;
    }

    public static void StartTimer()
    {
        m_IsTimerRunning = true;
    }

    public static void StopTimer()
    {
        m_IsTimerRunning = false;
    }

    public static void TileMoved()
    {
        ++m_MoveCount;
        Debug.Log(MoveCount);
    }
}
