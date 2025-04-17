using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private Board m_Board;

    private void Awake()
    {
        m_Board = GameObject.FindWithTag("GameManager").GetComponent<Board>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_Board.MoveTile(Direction.DirectionEnum.left);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_Board.MoveTile(Direction.DirectionEnum.right);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Board.MoveTile(Direction.DirectionEnum.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_Board.MoveTile(Direction.DirectionEnum.down);
        }
    }
}
