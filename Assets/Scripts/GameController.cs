using UnityEngine;
using Zinnia.Utility;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  [SerializeField]
  private GameObject pauseUiContainer;
  [SerializeField]
  private GameObject leftRayInteractor;
  [SerializeField]
  private GameObject rightRayInteractor;
  [SerializeField]
  private SpawnArea[] spawnLocations;
  [SerializeField]
  private GameObject[] enemies;
  [SerializeField]
  private CountdownTimer timer;
  [SerializeField]
  private CountdownTimer stageTimer;
  [SerializeField]
  private GameObject player;
  public bool isPlaying = true;
  private Player playerScript;
  private int enemyCount = 1;

  void Start()
  {
    playerScript = player.GetComponent<Player>();
    PlayGame();
  }

  public void SpawnRandom()
  {
    for (int i = 0; i < enemyCount; i++)
    {
      int areaIndex = Random.Range(0, spawnLocations.Length);
      int enemyIndex = playerScript.scoreSO.value > 100 ? Random.Range(0, enemies.Length) : 0;
      Instantiate(enemies[enemyIndex], spawnLocations[areaIndex].GetRandomPosition(), player.transform.rotation);
    }
    timer.Begin();
  }

  public void NextStage()
  {
    if (timer.StartTime > 0.5f)
    {
      timer.StartTime -= 0.5f;
      enemyCount++;
      foreach (var enemy in enemies)
      {
        Enemy enemySc = enemy.GetComponent<Enemy>();
        enemySc.health += 5;
        enemySc.attackDamage += 5;
      }
      stageTimer.Begin();
    }
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
    stageTimer.Resume();
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
    stageTimer.Pause();
    AudioListener.pause = true;
    Time.timeScale = 0;
  }

  public void ToMainMenu()
  {
    SceneManager.LoadScene("MainMenuScene");
  }
}
