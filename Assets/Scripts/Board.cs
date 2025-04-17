using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Direction;

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

        Randomize();
    }


    public bool MoveTile(Tile tile)
    {
        if(Vector2.Distance(tile.transform.position, m_EmptyTilePos) <= (1.1f + m_TileOffset))
        {
            SwapTile(tile);
            return true;
        }
        return false;
    }

    public bool MoveTile(DirectionEnum dir)
    {
        Tile adjTile = GetAdjacentTile(dir);

        if (adjTile == null)
            return false;

        SwapTile(adjTile);

        return true;
    }

    private void SwapTile(Tile tile)
    {
        Vector2 tilePos = tile.transform.position;
        tile.MoveToPos(m_EmptyTilePos);
        m_EmptyTilePos = tilePos;
    }

    private Tile GetAdjacentTile(DirectionEnum dir)
    {
        Vector3 adj = Vector3.zero;

        switch (dir)
        {
            case DirectionEnum.up:
                adj = new Vector2(m_EmptyTilePos.x, m_EmptyTilePos.y - (1 + m_TileOffset));
                break;
            case DirectionEnum.down:
                adj = new Vector2(m_EmptyTilePos.x, m_EmptyTilePos.y + (1 + m_TileOffset));
                break;
            case DirectionEnum.left:
                adj = new Vector2(m_EmptyTilePos.x + (1 + m_TileOffset), m_EmptyTilePos.y);
                break;
            case DirectionEnum.right:
                adj = new Vector2(m_EmptyTilePos.x - (1 + m_TileOffset), m_EmptyTilePos.y);
                break;
        }

        return m_Tiles.Where(t => t.transform.position == adj).FirstOrDefault();
    }

    private void Randomize()
    {
        for (int i = 0; i < 1000;)
        {
            bool success = MoveTile(GetRandomDirection());
            if (!success) ++i;
        }
    }
}
