using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float MovementSpeed = 10f;

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

    public void MoveToPos(Vector2 newPos, bool playAnim)
    {
        if (playAnim)
            StartCoroutine(MoveAnim(newPos));
        else
            transform.position = newPos;
    }

    private IEnumerator MoveAnim(Vector2 targetPos)
    {
        while (Vector2.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, MovementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        m_Board.CheckWin();
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
