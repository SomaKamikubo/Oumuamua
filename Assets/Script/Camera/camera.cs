using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class camera : MonoBehaviour
{
    [SerializeField]  GameObject player;
    [SerializeField] VsBoss _vsBossTrig;
    [SerializeField] Vector3 _bossCamera;
    [SerializeField] Camera _camera;
    [SerializeField] float _cameraSize;




    bool vsBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        _vsBossTrig.VsBossTrigger.Subscribe(_ => vsBoss = true);
    }

    // Update is called once per frame
    void Update()
    {
        if (vsBoss)
        {
            transform.position = _bossCamera;
            _camera.orthographicSize = _cameraSize;

        }
        else
        {
            Vector3 playerPos = player.gameObject.transform.position;
            transform.position = new Vector3(playerPos.x, playerPos.y + 1, transform.position.z);
        }

        

    }


}
