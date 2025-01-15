using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace GBJ.UILogic
{
    [RequireComponent (typeof(CanvasGroup))]
    public abstract class WindowView : MonoBehaviour
    {
        public abstract WindowType Type { get; }

        private CanvasGroup _canvasGroup;

        private float _fadeTime = 0.5f;
        private bool _animIsPlaying;

        protected virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0f;
        }

        public void SetFadeTime(float time)
        {
            _fadeTime = time;
        }

        public async void Show(bool animIsPlayed = true)
        {
            gameObject.SetActive(true);

            if (animIsPlayed)
            {
                while (_animIsPlaying)
                    await UniTask.Delay(100);

                PlayShowAnim();
            }
            else
            {
                _canvasGroup.alpha = 1.0f;
            }
        }

        protected virtual void PlayShowAnim()
        {
            _animIsPlaying = true;

            _canvasGroup.DOFade(1f, _fadeTime).OnComplete(() =>
            {
                _animIsPlaying = false;
            });
        }

        public async void Hide(bool animIsPlayed = true)
        {
            if (animIsPlayed)
            {
                while (_animIsPlaying)
                    await UniTask.Delay(100);

                PlayHideAnim();
            }
            else
            {
                TurnOff();
            }
        }

        protected virtual void PlayHideAnim()
        {
            _canvasGroup.DOFade(0, _fadeTime).OnComplete(() =>
            {
                _animIsPlaying = false;
                gameObject.SetActive(false);
            });
        }

        private void TurnOff()
        {
            if (!gameObject.activeInHierarchy)
                return;

            _canvasGroup??= GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0f;
            _animIsPlaying = false;
            gameObject.SetActive(false);
        }
    }
}