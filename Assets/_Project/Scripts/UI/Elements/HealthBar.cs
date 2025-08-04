using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.HighVoltage.Scripts.UI.Elements
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private GameObject healthOwner;
        [SerializeField] private Image fillBar;
        [SerializeField] private Color healthBarDefaultColor = Color.red;
        [SerializeField] private Color healthBarJustHitColor = Color.white;
        [SerializeField] private float animationTime = 0.2f;
        private Coroutine _currentAnimation;
        private float _targetFill;

        private IEnumerator AnimateHealthBar(float targetFill)
        {
            _targetFill = targetFill;
            float initialFill = fillBar.fillAmount;
            float elapsedTime = 0f;
        
            // Immediately set to "just hit" color at the start
            fillBar.color = healthBarJustHitColor;

            while (elapsedTime < animationTime)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / animationTime);
            
                // Lerp the fill amount
                fillBar.fillAmount = Mathf.Lerp(initialFill, targetFill, t);
            
                // Lerp the color
                fillBar.color = Color.Lerp(healthBarJustHitColor, healthBarDefaultColor, t);
            
                yield return null;
            }

            // Ensure final values are set exactly
            fillBar.fillAmount = targetFill;
            fillBar.color = healthBarDefaultColor;
        
            _currentAnimation = null;
        }
    }
}