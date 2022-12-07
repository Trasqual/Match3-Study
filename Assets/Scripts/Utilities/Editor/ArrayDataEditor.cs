using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ArrayData))]
public class ArrayDataEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);

        Rect newPosition = position;
        newPosition.y += 18f;

        SerializedProperty columnDatas = property.FindPropertyRelative("columnDatas");
        if (columnDatas.arraySize <= 0)
        {
            columnDatas.arraySize = 5;
        }
        for (int i = 0; i < columnDatas.arraySize; i++)
        {
            SerializedProperty rowDatas = columnDatas.GetArrayElementAtIndex(i).FindPropertyRelative("rowDatas");
            newPosition.height = 18f;
            if (rowDatas.arraySize <= 0)
            {
                rowDatas.arraySize = 5;
            }
            newPosition.width = position.width / rowDatas.arraySize;
            for (int j = 0; j < rowDatas.arraySize; j++)
            {
                EditorGUI.PropertyField(newPosition, rowDatas.GetArrayElementAtIndex(j), GUIContent.none);
                newPosition.x += newPosition.width;
            }
            newPosition.x = position.x;

            newPosition.y += 18f;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 100;
    }
}
