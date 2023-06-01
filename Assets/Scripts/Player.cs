using UnityEngine;
using Zinnia.Visual;

public class Player : MonoBehaviour
{
  public float defaultHealth = 100f;
  public int score;
  public CameraColorOverlay hitFader;
  public CameraColorOverlay startFader;
  private float currentHealth;

  public void ResetPlayer()
  {
    startFader.Blink();
    score = 0;
    currentHealth = defaultHealth;

    foreach (var enemy in FindObjectsOfType<Enemy>())
    {
      Destroy(enemy.gameObject);
    }
  }

  public void TakeDamage(float damage)
  {
    currentHealth -= damage;
    if (currentHealth > 0)
    {
      hitFader.Blink();
    }
    else
    {
      ResetPlayer();
    }
  }

  public void UpdateScore(int point)
  {
    score += point;
  }

  void Start()
  {
    ResetPlayer();
  }
}
