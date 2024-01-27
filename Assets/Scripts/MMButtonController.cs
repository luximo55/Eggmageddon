using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMButtonController : MonoBehaviour
{
   [SerializeField] private GameObject creditsPanel;
   [SerializeField] private GameObject howToPlayPanel;
   public void PlayButton()
   {
      SceneManager.LoadScene(1);
   }

   public void CreditsButton()
   {
      creditsPanel.SetActive(true);
   }
   public void ControlsButton()
   {
      howToPlayPanel.SetActive(true);
   }

   public void QuitButton()
   {
      Application.Quit();
      Debug.Log("Quit");
   }
}
