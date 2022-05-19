using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] GameObject HP;//�n�[�g�I�u�W�F�N�g
    [SerializeField] GameObject[] heart;//�n�[�g�z��
    [SerializeField] GameObject hart;//�n�[�g��u���L�����o�X
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] float _add_pos;
    

    private void Start()
    {
        Vector3 _pos;
        heart = new GameObject[_playerWindow.getMaxHp()];
        _pos = HP.transform.position;

        heart[0] = HP;
        for (int i = 1; i < _playerWindow.getMaxHp(); i++)
        {
            _pos.x += _add_pos;
            heart[i] = Instantiate(HP, _pos, Quaternion.identity, hart.transform);
        }
    }



    //HP�𔽉f����
    public void ViewHurt(int hp)
    {
        ////�q�[���̎��̏���
        //if (!heart[hp - 1].gameObject.activeSelf)
        //{
        //    heart[hp - 1].gameObject.SetActive(true);
        //}

        //�_���[�W�󂯂��Ƃ�
        if (heart[hp].gameObject.activeSelf)
        {
            heart[hp].gameObject.SetActive(false);
        }

    }
}
