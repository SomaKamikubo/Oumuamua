using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHPVer : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    
    //Slider������
    [SerializeField] Slider _slider;
    [SerializeField] EnemyWindow _enemyWindow;

    int _maxHp;
    int _currentHp;

    void Start()
    {
        _maxHp = _enemyWindow.getMaxHp();
        //Slider�𖞃^���ɂ���B
        _slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        _currentHp = _maxHp;
    }

    public void HPbar() 
    {
        _currentHp = _enemyWindow.getHp();
        //Debug.Log( (float)_maxHp);
        //Debug.Log((float)_currentHp / (float)_maxHp);
        //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
        //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
        //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
        _slider.value = (float)_currentHp / (float)_maxHp;
        if(_currentHp <= 0)
        {
            _slider.gameObject.SetActive(false);
        }
    }

    public void SetActive(bool value)
    {
        _slider.gameObject.SetActive(value);
    }
    
}
