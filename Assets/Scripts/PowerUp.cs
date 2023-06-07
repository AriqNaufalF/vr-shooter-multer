using UnityEngine;

public class PowerUp : MonoBehaviour
{
  public float boostDamage = 20;
  public float fireRateBoost = 0.15f;
  public float appliedDuration = 5;
  private Gun gun;

  void Start()
  {
    gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    Destroy(gameObject, 30);
  }

  public void UseItem()
  {
    gun.damage *= boostDamage;
    gun.fireRate = fireRateBoost;
    Destroy(gameObject);
  }
}
