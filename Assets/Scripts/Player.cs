using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zinnia.Visual;

public class Player : MonoBehaviour
{
  public AudioSource soundPlayer;
  public AudioClip hitSound;
  public AudioClip deathSound;

  public TextMeshPro scoreText;
  public IntSO scoreSO;

  public CameraColorOverlay hitFader;
  public CameraColorOverlay startFader;

  public float defaultHealth = 100f;
  public GameObject healthBar;
  private float currentHealth;

  public void ResetPlayer()
  {
    startFader.Blink();
    scoreSO.value = 0;
    UpdateScore(0);
    healthBar.transform.localScale = Vector3.one;
    currentHealth = defaultHealth;

    foreach (var enemy in FindObjectsOfType<Enemy>())
    {
      Destroy(enemy.gameObject);
    }
  }

  IEnumerator Death()
  {
    startFader.Blink();
    soundPlayer.PlayOneShot(deathSound);
    yield return new WaitForSeconds(deathSound.length);
    SceneManager.LoadScene("DeathScene");
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
      StartCoroutine("Death");
    }
  }

  public void UpdateScore(int point)
  {
    scoreSO.value += point;
    scoreText.text = scoreSO.value.ToString("D9");
  }

  void Start()
  {
    ResetPlayer();
  }
}
