using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] EnemyWindow _boss1Window;
    [SerializeField] EnemyWindow _boss2Window;


    Subject<Unit> _gameOver = new Subject<Unit>();
    public IObservable<Unit> OnGameOver { get { return _gameOver; } }

    Subject<Unit> _gameClear = new Subject<Unit>();
    public IObservable<Unit> OnGameClear { get { return _gameClear; } }


    // Start is called before the first frame update
    void Start()
    {
        //ハート生成
        _playerWindow.GenerateHeart();

        //ゲームオーバーの発行
        _playerWindow.OnDeath.Subscribe(_ => _gameOver.OnNext(default));

        //ゲームクリアの発行
        _boss1Window.OnDeath.Subscribe(_ => _gameClear.OnNext(default));
        _boss2Window.OnDeath.Subscribe(_ => _gameClear.OnNext(default));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
