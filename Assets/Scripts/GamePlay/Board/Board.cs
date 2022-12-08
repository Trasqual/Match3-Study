using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Slot slotPrefab;

    private readonly int columns = 10;
    private readonly int rows = 10;

    private Slot[,] slots;

    private void Awake()
    {
        slots = new Slot[columns, rows];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                var slot = Instantiate(slotPrefab, transform);
                slot.Init(i, j, this);

                slots[i, j] = slot;
            }
        }
    }

    public Slot GetSlot(Slot slot, Direction dir)
    {
        var x = slot.X;
        var y = slot.Y;

        switch (dir)
        {
            case Direction.Up:
                y += 1;
                break;
            case Direction.Down:
                y -= 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
            case Direction.Right:
                x += 1;
                break;
            default:
                break;
        }

        if (x >= columns || x < 0 || y >= rows || y < 0)
        {
            return null;
        }

        return slots[x, y];
    }
}
