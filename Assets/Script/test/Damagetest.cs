using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PlayerHP))]
public class Damagetest : Editor
{
    [ContextMenu("PrivateMethod")]


   

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var t = target as PlayerHP; //<===�{�^����\��������R���|�[�l���g(Class

        GUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.Space();
            EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
            if (GUILayout.Button("Attack",   //<===�{�^���̏�ɕ\�����镶��
                GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.Height(30)))
            {
                t.Damage(1);  // <===������������p�u���b�N���\�b�h�����s
            }
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();
        }
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(20);
    }
}
