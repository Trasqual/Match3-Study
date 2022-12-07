using UnityEngine;

[CreateAssetMenu(menuName = "Level/Level Data")]
public class LevelData : ScriptableObject
{
    public int rows = 5;
    public int cols = 5;
    public ArrayData Data;
}
