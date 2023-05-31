using UnityEngine;
using Zinnia.Action;

public class Gun : MonoBehaviour
{
  public GameObject barrel;
  public float fireRate;
  public FloatAction squeezeVal;
  public AudioSource gunSound;
  private WaitForSeconds wait = new WaitForSeconds(0.07f);
  private float nextFire;

  void Update()
  {
    if (squeezeVal.Value > 0.9 && Time.time > nextFire)
    {
      nextFire = Time.time + fireRate;
      gunSound.Play();
      bool isHit = Physics.Raycast(barrel.transform.position, barrel.transform.forward, out RaycastHit hitData, 100f);
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
