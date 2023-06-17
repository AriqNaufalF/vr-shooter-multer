using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
  public void ToMainMenu()
  {
    SceneManager.LoadScene("MainMenuScene");
  }
}
