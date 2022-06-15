using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorActionStatus : MonoBehaviour
{
    public bool Walking{set { this.Walking = value; } get { return this.Walking; }}
    public bool Idling { set { this.Idling = value; } get { return this.Idling; } }
    public bool Attacking { set { this.Attacking = value; } get { return this.Attacking; } }


    
}
