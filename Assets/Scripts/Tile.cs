using UnityEngine;

public class Tile : MonoBehaviour
{
    private int m_Number;
    public int Number => m_Number;

    private TextMesh m_NumTxt;

    private void Awake()
    {
        m_NumTxt = GetComponentInChildren<TextMesh>();
    }

    public void SetNumber(int num)
    {
        m_Number = num;
        m_NumTxt.text = m_Number.ToString();
    }
}
