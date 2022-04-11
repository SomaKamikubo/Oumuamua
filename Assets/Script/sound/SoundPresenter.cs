using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SoundPresenter : MonoBehaviour
{
    [SerializeField] SwitchBGM _sBGM;
    [SerializeField] VsBoss _vsBosstrig;
    [SerializeField]  PlayerWindow _playerWindow;
    [SerializeField] EnemyWindow _eneWin;
    // Start is called before the first frame update
    void Start()
    {
        //_sBGM‚ÌƒŠƒXƒg 0:title 1:stage 2:boss 3:clear 4:death

        _sBGM.PlayBGM(1);

        _playerWindow.OnDeath.Subscribe(_ =>_sBGM.PlayBGM(4));

        _vsBosstrig.VsBossTrigger.Subscribe(_ => _sBGM.PlayBGM(2));
        _eneWin.OnDeath.Subscribe(_ => _sBGM.PlayBGM(5));

    }


}
