using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  public AudioSource soundPlayer;
  public AudioClip deathSound;
  public AudioClip attackSound;
  public AudioClip hurtSound;
  public AudioClip[] gruntSound;
  public NavMeshAgent agent;
  public Animator animator;
  public GameObject[] dropItems;
  public float attackRange = 1.8f;
  public float attackDamage = 10f;
  public int killPoint = 10;
  public float health = 10f;

  private Player target;

  public void Kill(float damage)
  {
    health -= damage;
    soundPlayer.PlayOneShot(hurtSound);
    if (health <= 0)
    {
      GetComponent<Collider>().enabled = false;
      target.UpdateScore(killPoint);
      animator.SetBool("Dying", true);
      soundPlayer.PlayOneShot(deathSound);
      Destroy(gameObject, 4f);
    }
  }

  public void DropItem()
  {
    float chance = Random.value;
    if (chance <= 0.1)
    {
      Instantiate(dropItems[0], gameObject.transform.position + Vector3.up, gameObject.transform.rotation);
    }
    else if (chance <= 0.2)
    {
      Instantiate(dropItems[1], gameObject.transform.position + Vector3.up, gameObject.transform.rotation);
    }
  }

  public void Grunt()
  {
    int index = Random.Range(0, gruntSound.Length * 4);
    if (index < gruntSound.Length)
    {
      soundPlayer.PlayOneShot(gruntSound[index]);
    }
  }

  public void Swipe()
  {
    soundPlayer.PlayOneShot(attackSound);
  }

  public void Hit()
  {
    target.TakeDamage(attackDamage);
  }

  void Start()
  {
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    agent.updatePosition = false;
  }

  void Update()
  {
    bool canMove = !animator.GetBool("Dying") && Vector3.Distance(transform.position, target.transform.position) > attackRange;
    animator.SetBool("Moving", canMove);
    animator.SetBool("Attacking", !canMove && !animator.GetBool("Dying"));
    agent.destination = canMove ? target.transform.position : transform.position;
  }

  void OnAnimatorMove()
  {
    transform.position = agent.nextPosition;
  }
}
