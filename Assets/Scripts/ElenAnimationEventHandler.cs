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
            if (meleeWeapon != null)
                meleeWeapon.SetColliderActive(true);
        }

        [UsedImplicitly]
        public void MeleeAttackEnd()
        {
            
            if (meleeWeapon != null)
                meleeWeapon.SetColliderActive(false);
        }
    }
}
