using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameStatistics : MonoBehaviour
{
    public Text MoveCountTxt;
    public Text TimeTxt;

    private static int m_MoveCount;
    public static int MoveCount => m_MoveCount;

    private float m_Time;
    private static bool m_IsTimerRunning;

    private void Update()
    {
        if (m_IsTimerRunning)
        {
            m_Time += Time.deltaTime;
            UpdateUI();
        }
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
    }

    private void UpdateUI()
    {
        MoveCountTxt.text = "Move Count: " + MoveCount;
        TimeTxt.text = $"Time: " + m_Time.ToString("0.00") + " s";
    }
}
