using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  void Start()
  {
    Time.timeScale = 1;
  }
  public void StartGame()
  {
    SceneManager.LoadScene("PlayScene");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
