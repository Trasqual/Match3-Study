using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public int X { get; private set; }
    public int Y { get; private set; }

    private Board _board;

    private List<Slot> neighbours = new();

    public void Init(int x, int y, Board board)
    {
        X = x;
        Y = y;
        _board = board;

        transform.localPosition = new Vector3(X, Y, 0);
        UpdateName();
    }

    private void UpdateName()
    {
        gameObject.name = $"{X} : {Y}";
    }
}
