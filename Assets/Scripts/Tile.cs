using UnityEngine;

public class Tile : MonoBehaviour
{
    private int m_Number;
    public int Number => m_Number;

    private TextMesh m_NumTxt;

    private Vector3 m_CorrectPos;
    private Board m_Board;

    private void Awake()
    {
        m_NumTxt = GetComponentInChildren<TextMesh>();
        m_CorrectPos = transform.position;
        m_Board = GameObject.FindWithTag("GameManager").GetComponent<Board>();
    }

    public void SetNumber(int num)
    {
        m_Number = num;
        m_NumTxt.text = m_Number.ToString();
    }

    public void MoveToPos(Vector2 newPos)
    {
        transform.position = newPos;
    }

    public bool IsInPlace()
    {
        return transform.position == m_CorrectPos;
    }

    private void OnMouseDown()
    {
        m_Board.MoveTile(this);
        m_Board.CheckWin();
    }
}
