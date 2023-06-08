using System.Collections;
using UnityEngine;
using Zinnia.Action;

public class Gun : MonoBehaviour
{
  [SerializeField]
  private GameObject barrel;
  [SerializeField]
  private GameObject hitParticle;
  [SerializeField]
  private GameObject shotParticle;
  public float fireRate = 0.25f;
  private float defaultFireRate;
  private float defaultDamage = 5;
  public float damage = 5;
  public FloatAction squeezeVal;
  [SerializeField]
  private AudioSource gunSound;
  private float nextFire;
  private GameController gameController;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    defaultFireRate = fireRate;
    defaultDamage = damage;
  }

  void Update()
  {
    if (squeezeVal.Value > 0.9 && Time.time > nextFire && gameController.isPlaying)
    {
      // Add fire rate delay to gun
      nextFire = Time.time + fireRate;

      // Add particle and sound when shot
      GameObject muzzleFlash = Instantiate(shotParticle, barrel.transform);
      muzzleFlash.transform.SetParent(null);
      gunSound.Play();
      Destroy(muzzleFlash, 0.5f);


      bool isHit = Physics.Raycast(barrel.transform.position, barrel.transform.forward, out RaycastHit hitData, 100f);

      // Set particle effect at the raycast hit
      GameObject hitEffect = Instantiate(hitParticle);
      hitEffect.transform.position = hitData.point;
      Destroy(hitEffect, 1f);

      if (isHit)
      {
        if (hitData.transform.tag == "Enemy")
        {
          Enemy hitEnemy = hitData.transform.GetComponent<Enemy>();
          if (hitEnemy != null)
          {
            hitEnemy.Kill(damage);
          }
        }
        else if (hitData.transform.tag == "PowerUp")
        {
          PowerUp hitPowerUp = hitData.transform.GetComponent<PowerUp>();
          if (hitPowerUp != null)
          {
            hitPowerUp.UseItem();
            StartCoroutine(ResetGun(hitPowerUp.appliedDuration));
          }
        }
        else if (hitData.transform.tag == "HealPotion")
        {
          Heal hitHeal = hitData.transform.GetComponent<Heal>();
          if (hitHeal != null)
          {
            hitHeal.UseItem();
          }
        }
      }
    }
  }

  IEnumerator ResetGun(float duration)
  {
    yield return new WaitForSeconds(duration);
    damage = defaultDamage;
    fireRate = defaultFireRate;
  }
}
