using DG.Tweening;
using GBJ.UILogic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public sealed class ComingSoonView : WindowView
{
    public override WindowType Type => WindowType.ComingSoon;

    public event Action OnScreenClicked;

    [SerializeField] private Button _btnScreen;
    [SerializeField] private TMP_Text _txtComingSoon;

    private Sequence _comingSoonTxtAnim;

    protected override void Awake()
    {
        base.Awake();
        MapButtons();
    }

    private void MapButtons()
    {
        _btnScreen.onClick.AddListener(() => OnScreenClicked?.Invoke());
    }

    public void PlayComingSoonTxtAnim()
    {
        _comingSoonTxtAnim ??= InitComingSoonTxtAnim();

        if (_comingSoonTxtAnim.IsPlaying())
            return;

        _comingSoonTxtAnim.Play();
    }

    private Sequence InitComingSoonTxtAnim()
    {
        var upPos = _txtComingSoon.rectTransform.localPosition;
        var downPos = -upPos;
        var startColor = _txtComingSoon.color;
        var color = Color.yellow;
        var time = 1f;

        var anim = DOTween.Sequence();
        anim.Append(_txtComingSoon.rectTransform.DOLocalMove(downPos, time)).SetEase(Ease.Linear);
        anim.Join(_txtComingSoon.DOColor(color, time));
        anim.SetLoops(-1, LoopType.Yoyo);

        return anim;
    }
}
