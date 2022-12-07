using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Slot slotPrefab;

    [field: Range(0.1f, 1f)]
    [field: SerializeField] public float SlotSize { get; private set; } = 1f;

    private int columns = 10;
    private int rows = 10;

    private Slot[,] slots;

    private void Awake()
    {
        slots = new Slot[columns, rows];
        PrepareBoard();
    }

    private void PrepareBoard()
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

    public Vector3 GetStartPos()
    {
        var startX = -(columns * SlotSize / 2f) + SlotSize / 2f;
        var startY = -(columns * SlotSize / 2f) + SlotSize / 2f;

        return new Vector3(startX, startY, 0f);
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
