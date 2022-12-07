
[System.Serializable]
public class ArrayData
{
    public ColumnData[] columnDatas = new ColumnData[5];

    public ArrayData(int columnCount, int rowCount)
    {
        columnDatas = new ColumnData[columnCount];
        for (int i = 0; i < columnDatas.Length; i++)
        {
            columnDatas[i] = new ColumnData(rowCount);
        }
    }

    [System.Serializable]
    public class ColumnData
    {
        public ItemType[] rowDatas;

        public ColumnData(int rowCount)
        {
            rowDatas = new ItemType[rowCount];
        }
    }
}
