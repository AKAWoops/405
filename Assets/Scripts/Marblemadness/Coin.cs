using DG.Tweening;
using UnityEngine;

namespace Mark.Ballinger.GAM405
{
    public class Coin : MonoBehaviour
    {
        public bool IsAlive = true;

        protected void Update()
        {
            if (MarbleGame.Instance.IsGameOver)
            {
                return;
            }

            transform.Rotate(MarbleConstants.CoinRotationPerFrame);
        }

        
        public void DestroyMe()
        {
            IsAlive = false;

            // Scale from full-size to nothing over several milliseconds
            
            transform.DOScale(MarbleConstants.CoinDestroyEndSize,
                    MarbleConstants.CoinDestroyEndDuration).
                SetEase(Ease.OutElastic).
                OnComplete(DoTween_OnComplete);
        }

        private void DoTween_OnComplete()
        {
            // Wait for animation to be complete then destroy
            
            Destroy(gameObject);
        }
    }
}