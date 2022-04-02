using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorPresentor :CharactorAnimatorPresentor
{
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] AnimatorView _enemyAnimatorView;

    void Start()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        CharactorAnimeEvent();
    }
}
