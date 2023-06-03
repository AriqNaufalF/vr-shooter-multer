using UnityEngine;
using Zinnia.Utility;

public class SpawnManager : MonoBehaviour
{
  public SpawnArea[] spawnLocations;
  public GameObject[] enemies;
  public CountdownTimer timer;
  public GameObject player;
  private Player playerScript;

  void Start()
  {
    playerScript = player.GetComponent<Player>();
  }

  public void SpawnRandom()
  {
    int areaIndex = Random.Range(0, spawnLocations.Length);
    int enemyIndex = playerScript.score > 100 ? Random.Range(0, enemies.Length) : 0;

    Instantiate(enemies[enemyIndex], spawnLocations[areaIndex].GetRandomPosition(), player.transform.rotation);
    timer.Begin();
  }
}
