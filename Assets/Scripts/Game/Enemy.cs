using System;
using UnityEngine;
using Zenject;

namespace Playground.Game
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private Animator animator;
        [SerializeField] private int moneyForKill = 3;

        [Header("FOR DEBUG")]
        [SerializeField]
        private int currentHp;

        private UserDataService userDataService;
        private SignalBus signalBus;
        
        public Action HitDelegate;
        private Action _hitDelegate;
        public event Action OnHited;
        public event Action<Enemy> OnKilled;
        public static event Action OnHitedStatic;

        [Inject]
        public void Construct(UserDataService userDataService, SignalBus signalBus)
        {
            this.userDataService = userDataService;
            this.signalBus = signalBus;
        }

        private void Awake()
        {
            currentHp = hp;
        }

        public void GetDamage(int damage)
        {
            currentHp -= damage;

            PlayDamageAnimation();
            HitActions();

            if (currentHp <= 0)
                KillSelf();
        }

        public Enemy OnHit(Action hitDelegate)
        {
            _hitDelegate = hitDelegate;

            return this;
        }

        public void Do()
        {
            Debug.Log($"ENEMY DO!");
        }

        private void PlayDamageAnimation()
        {
            animator.NotNull()?.SetTrigger("GetDamage");
        }

        private void KillSelf()
        {
            userDataService.AddMoney(moneyForKill);

            OnKilled?.Invoke(this);
            
            Destroy(gameObject);
        }

        private void HitActions()
        {
            HitDelegate?.Invoke();
            OnHited?.Invoke();
            _hitDelegate?.Invoke();
            OnHitedStatic?.Invoke();
            
            signalBus.Fire(new EnemyHitSignal
            {
                Enemy = this
            });
        }
    }
}
