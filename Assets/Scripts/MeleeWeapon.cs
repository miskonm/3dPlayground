using System;
using Playground.Game;
using UnityEngine;

namespace Playground
{
    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField] private Collider col;
        [SerializeField] private int damage;

        private void Awake()
        {
            SetColliderActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
           if(other.TryGetComponent<Enemy>(out var enemy))
               enemy.GetDamage(damage);
        }

        public void SetColliderActive(bool isActive)
        {
            col.enabled = isActive;
        }
    }
}
