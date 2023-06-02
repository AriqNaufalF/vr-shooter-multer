using TMPro;
using UnityEngine;
using Zinnia.Visual;

public class Player : MonoBehaviour
{
  public AudioSource soundPlayer;
  public AudioClip hitSound;
  public AudioClip deathSound;

  public int score;
  public TextMeshPro scoreText;

  public CameraColorOverlay hitFader;
  public CameraColorOverlay startFader;

  public float defaultHealth = 100f;
  public GameObject healthBar;
  private float currentHealth;

  public void ResetPlayer()
  {
    startFader.Blink();
    score = 0;
    UpdateScore(0);
    healthBar.transform.localScale = Vector3.one;
    currentHealth = defaultHealth;

    foreach (var enemy in FindObjectsOfType<Enemy>())
    {
      Destroy(enemy.gameObject);
    }
  }

  public void TakeDamage(float damage)
  {
    currentHealth -= damage;
    healthBar.transform.localScale = new Vector3(Mathf.InverseLerp(0, defaultHealth, currentHealth), 1, 1);
    if (currentHealth > 0)
    {
      hitFader.Blink();
      soundPlayer.PlayOneShot(hitSound);
    }
    else
    {
      ResetPlayer();
      soundPlayer.PlayOneShot(deathSound);
    }
  }

  public void UpdateScore(int point)
  {
    score += point;
    scoreText.text = score.ToString("D9");
  }

  void Start()
  {
    ResetPlayer();
  }
}
