using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject TilePrefab;
    private List<Tile> m_Tiles = new List<Tile>();
    private Vector2 m_EmptyTilePos;

    private float m_TileOffset;
    private int m_Size;
    private int m_BoardSize;

    private void Start()
    {
        CreateBoard(4, 0.1f);
    }

    public void CreateBoard(int size, float tileOffset)
    {
        Vector2 newInstancePos = Vector2.zero;

        m_TileOffset = tileOffset;
        m_Size = size;
        m_BoardSize = size * size;

        for (int i = 1; i < m_BoardSize; i++)
        {
            if ((i - 1) % size == 0 && (i - 1) != 0)
            {
                newInstancePos = new Vector2(0f, newInstancePos.y - (1 + tileOffset));
            }

            Tile t = Instantiate(TilePrefab, newInstancePos, Quaternion.identity, this.transform).GetComponent<Tile>();
            m_Tiles.Add(t);
            t.SetNumber(i);
            newInstancePos.x += 1 + m_TileOffset;
        }

        m_EmptyTilePos = newInstancePos;
    }
}
