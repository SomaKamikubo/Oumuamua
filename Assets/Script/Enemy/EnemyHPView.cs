using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyHPView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textCurrent;
    [SerializeField] TextMeshProUGUI _textMax;
    [SerializeField] RectTransform _imageRectProgressBack;
    [SerializeField] RectTransform _imageRectProgressFront;

    // �o�[�̍Œ��̒���
    float _maxProgressWidth;
    // �o�[�̍ő�l
    int _maxValue;
    // ���݂̒l(�ڕW�l�Ƃ��Ă��g�p����)
    int _currentValue;
    // �A�j���[�V�������Ɏg�p����ꎞ�I�Ȍ��ݒl
    int _tempCurrentValue;
    // �A�j���[�V�����p
    Tween _anim;

    private void Awake()
    {
        // �ő�̉��̒������o���Ă���
        _maxProgressWidth = _imageRectProgressFront.GetWidth();
    }

    public void SetMax(int value)
    {
        _maxValue = value;
        _textMax.text = _maxValue.ToString();
    }

    public void SetCurrent(int newValue, bool useAnimation = false)
    {
        bool isPlus = newValue > _currentValue;

        _currentValue = newValue;
        _anim.Kill();

        // ���ݒl�̃o�[�̒������X�V
        _imageRectProgressFront.SetWidth(GetBarWidth(_currentValue));

        if (!useAnimation || isPlus)
        {
            _textCurrent.text = _currentValue.ToString();
            _tempCurrentValue = _currentValue;
            _imageRectProgressBack.SetWidth(GetBarWidth(newValue));
        }
        else
        {
            _anim = DOTween.To(() => _tempCurrentValue,
                value =>
                {
                    // �w�i�o�[�̓A�j���[�V�����ōX�V
                    _tempCurrentValue = value;
                    _textCurrent.text = _tempCurrentValue.ToString();
                    _imageRectProgressBack.SetWidth(GetBarWidth(value));
                },
                _currentValue, 0.35f);
        }
    }

    // �w�肵���l�ɑΉ�����o�[�̉������擾����
    private float GetBarWidth(int value)
    {
        float per = Mathf.InverseLerp(0, _maxValue, value);
        return Mathf.Lerp(0, _maxProgressWidth, per);
    }
}

public static class UIExtensions
{
    public static float GetWidth(this RectTransform self)
    {
        return self.sizeDelta.x;
    }

    public static void SetWidth(this RectTransform self, float width)
    {
        Vector2 s = self.sizeDelta;
        s.x = width;
        self.sizeDelta = s;
    }
}