using Source.Modules.Services.Scripts.Interfaces;
using UnityEngine.SceneManagement;

namespace Source.Modules.Services.Scripts
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
