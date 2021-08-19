using UnityEngine;

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

        private void Awake()
        {
            currentHp = hp;
        }

        public void GetDamage(int damage)
        {
            currentHp -= damage;

            PlayDamageAnimation();

            if (currentHp <= 0)
                KillSelf();
        }

        private void PlayDamageAnimation()
        {
            animator.SetTrigger("GetDamage");
        }

        private void KillSelf()
        {
            UserDataService.Instance.AddMoney(moneyForKill);
            Destroy(gameObject);
        }
    }
}
