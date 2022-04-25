using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AttackCollider : AttackCollider
{
    
    public void ColliderMove(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, pos.y+2f, transform.position.z);
    }
}
