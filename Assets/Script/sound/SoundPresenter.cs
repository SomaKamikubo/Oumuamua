using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SoundPresenter : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SwitchBGM _sBGM;
    [SerializeField] VsBoss _vsBosstrig;

    InputView _inputView;
   // Player _player;
    // Start is called before the first frame update
    void Start()
    {
        //_sBGM‚ÌƒŠƒXƒg 0:title 1:stage 2:boss 3:clear 4:death
        //_player = player.GetComponent<Player>();

        //_sBGM.A(1);

        //_player.OnDeath.Subscribe(value => {
        //    if (value == "DeathTrigger")
        //        _sBGM.A(4);
        //});

        _vsBosstrig.VsBossTrigger.Subscribe(_ => _sBGM.A(2));

    }

    // Update is called once per frame
    void Update()
    {
        //if (player.transform.position.x == 40)
        //    _sBGM.A(2);
    }
}
