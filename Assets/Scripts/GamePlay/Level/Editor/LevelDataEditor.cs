using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SerializedObject SO = new SerializedObject(target);

        SerializedProperty cols = SO.FindProperty("cols");
        SerializedProperty rows = SO.FindProperty("rows");
        EditorGUILayout.PropertyField(cols);
        EditorGUILayout.PropertyField(rows);

        SerializedProperty data = SO.FindProperty("Data");

        SerializedProperty columnDatas = data.FindPropertyRelative("columnDatas");

        columnDatas.arraySize = cols.intValue;
        EditorGUILayout.HelpBox("Data", MessageType.None);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < columnDatas.arraySize; i++)
        {
            SerializedProperty rowDatas = columnDatas.GetArrayElementAtIndex(i).FindPropertyRelative("rowDatas");

            rowDatas.arraySize = rows.intValue;
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < rowDatas.arraySize; j++)
            {
                EditorGUILayout.PropertyField(rowDatas.GetArrayElementAtIndex(j), GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
        SO.ApplyModifiedProperties();
    }
}
