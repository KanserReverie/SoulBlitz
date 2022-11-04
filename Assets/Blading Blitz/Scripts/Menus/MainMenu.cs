using Blading_Blitz.Scripts.Utility;
using UnityEngine;
namespace Blading_Blitz.Scripts.Menus
{
    public class MainMenu : MonoBehaviour
    {
        public void StartPrototypeLevel()
        {
            CommonlyUsedStaticMethods.OpenSceneFromBuildIndex(1);
        }
    }
}
