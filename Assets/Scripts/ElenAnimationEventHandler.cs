using JetBrains.Annotations;
using UnityEngine;

namespace Playground
{
    public class ElenAnimationEventHandler : MonoBehaviour
    {
        [SerializeField] private MeleeWeapon meleeWeapon;
        
        [UsedImplicitly]
        public void MeleeAttackStart()
        {
            meleeWeapon.NotNull()?.SetColliderActive(true);
        }

        [UsedImplicitly]
        public void MeleeAttackEnd()
        {
            meleeWeapon.NotNull()?.SetColliderActive(false);
        }
    }
}
