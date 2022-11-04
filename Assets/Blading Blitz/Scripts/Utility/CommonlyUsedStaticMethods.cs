using UnityEngine;
using UnityEngine.SceneManagement;
namespace Blading_Blitz.Scripts.Utility
{
    public static class CommonlyUsedStaticMethods
    {
        /// <summary>
        /// In build - Quits the game
        /// In playmode - Ends the playmode 
        /// </summary>
        public static void QuitGame()
        {
            Debug.Log($"Quitting Game");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
        
        /// <summary>
        /// This will reset the current scene.
        /// </summary>
        public static void ResetCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        /// <summary>
        /// This will load a scene based on a build index.
        /// </summary>
        /// <param name="buildIndex">Build index of the scene to load.</param>
        /// <returns></returns>
        public static void OpenSceneFromBuildIndex(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}
