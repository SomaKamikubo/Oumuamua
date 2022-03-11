using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの反転処理をするクラス
public class PlayerMoveReverse : MonoBehaviour
{
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;
    }
}
