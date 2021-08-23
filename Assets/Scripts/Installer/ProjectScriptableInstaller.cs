using UnityEngine;
using Zenject;

namespace Playground
{
    [CreateAssetMenu(fileName = nameof(ProjectScriptableInstaller), menuName = "Installers/ProjectScriptableInstaller")]
    public class ProjectScriptableInstaller : ScriptableObjectInstaller
    {
        public AudioSettings audioSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(audioSettings);
        }
    }
}
