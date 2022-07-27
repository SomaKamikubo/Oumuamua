using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHPVer : MonoBehaviour
{
    //最大HPと現在のHP。
    
    //Sliderを入れる
    [SerializeField] Slider _slider;
    [SerializeField] EnemyWindow _enemyWindow;

    int _maxHp;
    int _currentHp;

    void Start()
    {
        _maxHp = _enemyWindow.getMaxHp();
        //Sliderを満タンにする。
        _slider.value = 1;
        //現在のHPを最大HPと同じに。
        _currentHp = _maxHp;
    }

    public void HPbar() 
    {
        _currentHp = _enemyWindow.getHp();
        //Debug.Log( (float)_maxHp);
        //Debug.Log((float)_currentHp / (float)_maxHp);
        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
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
