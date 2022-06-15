using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(EnemyAttack))]
public class AttackTest1 : Editor

{
    [ContextMenu("PrivateMethod")]

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var t = target as EnemyAttack; //<===ボタンを表示させるコンポーネント(Class

        GUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.Space();
            EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
            if (GUILayout.Button("Attack",   //<===ボタンの上に表示する文字
                GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30)))
            {
                t.Attack();  // <===さっき作ったパブリックメソッドを実行
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();
        }
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(20);
    }
}
