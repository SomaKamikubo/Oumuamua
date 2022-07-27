using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2HP : EnemyHP
{
    [SerializeField] EnemyWindow _boss1win;

    public override void Damage(int enemy_atk)
    {
        if (!_damaging && !isDeath())
        {
            _boss1win.Damage(enemy_atk);

            

            //“_–Å‚³‚¹‚é
            StartCoroutine("Blinking");
            StartCoroutine("CountSecoond", 2.0f);
            if (isDeath())
                Death();
        }
    }

}
