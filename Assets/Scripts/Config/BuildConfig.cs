using UnityEngine;

namespace Playground.Config
{
    [CreateAssetMenu(fileName = Tag, menuName = "Configs/BuildConfig")]
    public class BuildConfig : ScriptableObject
    {
        private const string Tag = nameof(BuildConfig);

        [SerializeField] private bool isRelease;

        public bool IsRelease => isRelease;
    }
}
