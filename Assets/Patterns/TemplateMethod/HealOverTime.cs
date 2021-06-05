using UnityEngine;

namespace Patterns.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealOverTime", fileName = "HealOverTime", order = 0)]
    public class HealOverTime : ActiveSkill
    {
        [SerializeField] private float _secondsActive;
        [SerializeField] private int _healthToAd;

        private float _currentTimeInSeconds;
        private bool _isActive;
        private Hero _hero;

        protected override void DoUpdate()
        {
            if (!_isActive) return;
            
            _hero.AddHealth(_healthToAd * Time.deltaTime);
            
            _currentTimeInSeconds += Time.deltaTime;
            if (_currentTimeInSeconds > _secondsActive)
                _isActive = false;
        }

        protected override void DoActivate(Hero hero)
        {
            _isActive = true;
            _currentTimeInSeconds = 0;
            _hero = hero;
        }
    }
}
