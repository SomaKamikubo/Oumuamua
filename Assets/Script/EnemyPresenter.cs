using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{

    [SerializeField] EnemyView input_view;
    [SerializeField] EnemyStatus ES;
    private void Start()
    {
        input_view.OnInputX += KeyDownX => { ES.PlayAttack(KeyDownX); };
        input_view.OnInputHrizon += value => { ES.PlayMove(value);};
    }
}
