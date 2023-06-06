using UnityEngine;
using Zinnia.Utility;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public GameObject pauseUiContainer;
  public GameObject leftRayInteractor;
  public GameObject rightRayInteractor;
  public SpawnArea[] spawnLocations;
  public GameObject[] enemies;
  public CountdownTimer timer;
  public GameObject player;
  public bool isPlaying = true;
  private Player playerScript;

  void Start()
  {
    playerScript = player.GetComponent<Player>();
  }

  public void SpawnRandom()
  {
    int areaIndex = Random.Range(0, spawnLocations.Length);
    int enemyIndex = playerScript.scoreSO.value > 100 ? Random.Range(0, enemies.Length) : 0;

    Instantiate(enemies[enemyIndex], spawnLocations[areaIndex].GetRandomPosition(), player.transform.rotation);
    timer.Begin();
  }

  public void togglePause()
  {
    if (isPlaying)
    {
      PauseGame();
      return;
    }
    PlayGame();
  }

  public void ResetGame()
  {
    PlayGame();
    playerScript.ResetPlayer();
  }

  public void PlayGame()
  {
    isPlaying = true;
    pauseUiContainer.SetActive(false);
    leftRayInteractor.SetActive(false);
    rightRayInteractor.SetActive(false);
    timer.Resume();
    Time.timeScale = 1;
    AudioListener.pause = false;
  }

  void PauseGame()
  {
    isPlaying = false;
    pauseUiContainer.SetActive(true);
    leftRayInteractor.SetActive(true);
    rightRayInteractor.SetActive(true);
    timer.Pause();
    AudioListener.pause = true;
    Time.timeScale = 0;
  }

  public void ToMainMenu()
  {
    SceneManager.LoadScene("MainMenuScene");
  }
}
