using System;
using Blading_Blitz.Scripts.Utility;
using UnityEngine;

namespace Blading_Blitz.Scripts.Environment
{
    public class WinBlock : MonoBehaviour
    {
        private GameObject thisWinCanvas;
        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            thisWinCanvas = GetComponentInChildren<WinCanvas>().gameObject;
            thisWinCanvas.SetActive(false);
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                EndTheLevel();
            }
        }
        private void EndTheLevel()
        {
            Destroy(GetComponentInChildren<BoxCollider2D>());
            if (thisWinCanvas != null)
            {
                thisWinCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("Level Complete");
            }
            Invoke(nameof(OpenMainMenu),2);
        }

        private void OpenMainMenu()
        {
            CommonlyUsedStaticMethods.OpenSceneFromBuildIndex(0);
            Destroy(gameObject);
        }
    }
}
