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
        var t = target as EnemyAttack; //<===�{�^����\��������R���|�[�l���g(Class

        GUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.Space();
            EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
            if (GUILayout.Button("Attack",   //<===�{�^���̏�ɕ\�����镶��
                GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30)))
            {
                t.Attack();  // <===������������p�u���b�N���\�b�h�����s
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();
        }
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(20);
    }
}
