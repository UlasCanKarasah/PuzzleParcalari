using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private Item _item;

    public Item Item
    {
        get => _item;

        set
        {
            if (_item == value) return;

            _item = value;

            icon.sprite = _item.sprite;
        }
    }

    public Button button;

    public Image icon;

    public Tile Left => x > 0 ? Board.Instance.Tiles[x - 1, y] : null;
    public Tile Top => y > 0 ? Board.Instance.Tiles[x, y - 1] : null;
    public Tile Right => x < Board.Instance.Width - 1 ? Board.Instance.Tiles[x + 1, y] : null;
    public Tile Bottom => y < Board.Instance.Width - 1 ? Board.Instance.Tiles[x, y + 1] : null;
    //capraz kontrol
    public Tile TopLeft => x > 0 && y > 0 ? Board.Instance.Tiles[x - 1, y - 1] : null;
    public Tile TopRight => x < Board.Instance.Width - 1 && y > 0 ? Board.Instance.Tiles[x + 1, y - 1] : null;
    public Tile BottomLeft => x > 0 && y < Board.Instance.Width - 1 ? Board.Instance.Tiles[x - 1, y + 1] : null;
    public Tile BottomRight => x < Board.Instance.Width - 1 && y < Board.Instance.Width - 1 ? Board.Instance.Tiles[x + 1, y + 1] : null;


    public Tile[] Neighbours => new[]
    {
        Left,
        Top,
        Right,
        Bottom,

    };

    public Tile[] NeigboursCross => new[]
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    };



    private void Start ()
    {
        button.onClick.AddListener(call:() => Board.Instance.Select(tile:this));
    }

    // komsulari kontrol etme

    public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
    {
        var result = new List<Tile> { this, };

        // inf loop olusmasin diye kontrol

        if(exclude == null)
        {
            exclude = new List<Tile> { this, };

        }
        else
        {
            exclude.Add(this);
        }

        //komsularin iceriklerini kontrol et

        if (SceneManager.GetActiveScene().name == "Match3")
        {
            foreach (var neighbour in Neighbours)
            {
                if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;

                result.AddRange(neighbour.GetConnectedTiles(exclude));
            }
        }

        if (SceneManager.GetActiveScene().name == "Match3 level2")
        {
            foreach (var neighbour in NeigboursCross)
            {
                if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;

                result.AddRange(neighbour.GetConnectedTiles(exclude));
            }
        }


        return result;


    }

}
