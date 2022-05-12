using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] GameObject HP;

    [SerializeField] int _max_hp;
    [SerializeField] int _now_hp;
    Vector3 _pos;
    [SerializeField] float _add_pos;

    [SerializeField] GameObject[] heart;
    [SerializeField] GameObject hart;

    private void Awake()
    {
        heart = new GameObject[_max_hp];
        _pos = HP.transform.position;

        heart[0] = HP;
        for (int i=1; i < _max_hp; i++)
        {
            _pos.x += _add_pos;
            heart[i] = Instantiate(HP, _pos, Quaternion.identity, hart.transform);

        }
    }


    //‚ ‚ÙƒR[ƒh
    public void ViewHurt(int hp)
    {
        
    }
}
