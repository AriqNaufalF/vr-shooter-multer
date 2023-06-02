using UnityEngine;
using Zinnia.Action;

public class Gun : MonoBehaviour
{
  public GameObject barrel;
  public GameObject hitParticle;
  public GameObject shotParticle;
  public float fireRate;
  public FloatAction squeezeVal;
  public AudioSource gunSound;
  private WaitForSeconds wait = new WaitForSeconds(0.07f);
  private float nextFire;

  void Update()
  {
    if (squeezeVal.Value > 0.9 && Time.time > nextFire)
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
            hitEnemy.Kill();
          }
        }
      }
    }
  }
}
