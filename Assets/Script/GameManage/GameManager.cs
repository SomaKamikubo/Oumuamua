using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerWindow _playerWindow;

    Subject<Unit> _gameOver = new Subject<Unit>();
    public IObservable<Unit> OnGameOver { get { return _gameOver; } }


    // Start is called before the first frame update
    void Start()
    {
        //�n�[�g����
        _playerWindow.GenerateHeart();

        //�Q�[���I�[�o�[�̔��s
        _playerWindow.OnDeath.Subscribe(_ => _gameOver.OnNext(default));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
