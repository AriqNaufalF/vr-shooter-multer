using UnityEngine;
using Zinnia.Utility;

public class SpawnManager : MonoBehaviour
{
  public SpawnArea[] spawnLocations;
  public GameObject[] enemies;
  public CountdownTimer timer;
  public Transform player;

  public void SpawnRandom()
  {
    int areaIndex = Random.Range(0, spawnLocations.Length);
    int enemyIndex = Random.Range(0, enemies.Length);

    Instantiate(enemies[enemyIndex], spawnLocations[areaIndex].GetRandomPosition(), player.rotation);
    timer.Begin();
  }
}
