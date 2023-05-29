using UnityEngine;

public class Gun : MonoBehaviour
{
  public GameObject barrel;
  public void Shoot()
  {
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
