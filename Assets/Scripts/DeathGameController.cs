using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathGameController : MonoBehaviour
{
  [SerializeField]
  private TMP_Text scoreText;
  [SerializeField]
  private IntSO scoreSO;

  void Start()
  {
    scoreText.text = "Score: " + scoreSO.value.ToString("D9");
  }

  public void PlayAgain()
  {
    SceneManager.LoadScene("PlayScene");
  }

  public void ToMainMenu()
  {
    SceneManager.LoadScene("MainMenuScene");
  }
}
