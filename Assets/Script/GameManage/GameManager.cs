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
    [SerializeField] VsBoss _vsBossTrig;
    [SerializeField] EnemyHPVer _ehb;
    [SerializeField] BossManager _bossManager;


    Subject<Unit> _gameOver = new Subject<Unit>();
    public IObservable<Unit> OnGameOver { get { return _gameOver; } }

    Subject<Unit> _gameClear = new Subject<Unit>();
    public IObservable<Unit> OnGameClear { get { return _gameClear; } }


    // Start is called before the first frame update
    void Start()
    {
        //�n�[�g����
        _playerWindow.GenerateHeart();

        //�Q�[���I�[�o�[�̔��s
        _playerWindow.OnDeath.Subscribe(_ => _gameOver.OnNext(default));

        //�Q�[���N���A�̔��s
        _boss1Window.OnDeath.Subscribe(_ => _gameClear.OnNext(default));
        _boss2Window.OnDeath.Subscribe(_ => _gameClear.OnNext(default));

        //�{�XHP�̕\��
        _vsBossTrig.VsBossTrigger.Subscribe(_ => { _ehb.SetActive(true);});

        //�{�X2�̕\��
        bool resetFlag = true;
        _boss1Window.OnHurt.Subscribe(_ =>
        {
            Debug.Log("�_���[�W�󂯂�"+ _boss1Window.getHp());
            if (_boss1Window.getHp() <= (_boss1Window.getMaxHp() / 2) && resetFlag)
            {
                _bossManager.Appear(); 
                resetFlag = false;
                Debug.Log("����" + _boss1Window.getHp());
            }
        });

    }

}
