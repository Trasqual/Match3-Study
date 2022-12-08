using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    Vector2 scrollPos;

    public override void OnInspectorGUI()
    {
        SerializedObject SO = new(target);

        SerializedProperty cols = SO.FindProperty("cols");
        SerializedProperty rows = SO.FindProperty("rows");
        EditorGUILayout.PropertyField(cols);
        EditorGUILayout.PropertyField(rows);

        SerializedProperty data = SO.FindProperty("Data");

        SerializedProperty columnDatas = data.FindPropertyRelative("columnDatas");

        columnDatas.arraySize = rows.intValue;
        EditorGUILayout.HelpBox("Data", MessageType.None);
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < columnDatas.arraySize; i++)
        {
            SerializedProperty rowDatas = columnDatas.GetArrayElementAtIndex(i).FindPropertyRelative("rowDatas");

            rowDatas.arraySize = cols.intValue;
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < rowDatas.arraySize; j++)
            {
                EditorGUILayout.PropertyField(rowDatas.GetArrayElementAtIndex(j), GUIContent.none);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
        SO.ApplyModifiedProperties();
    }
}
