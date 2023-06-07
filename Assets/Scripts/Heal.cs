using UnityEngine;

public class Heal : MonoBehaviour
{
  private Player player;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    Destroy(gameObject, 30);
  }

  public void UseItem()
  {
    player.currentHealth = player.defaultHealth;
    player.healthBar.transform.localScale = new Vector3(1, 1, 1);
    Destroy(gameObject);
  }
}
