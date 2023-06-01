using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  public NavMeshAgent agent;
  public Animator animator;
  public float attackRange = 1.8f;
  public float attackDamage = 10f;
  public int killPoint = 10;

  private Player target;

  public void Kill()
  {
    GetComponent<Collider>().enabled = false;
    target.UpdateScore(killPoint);
    animator.SetBool("Dying", true);
    Destroy(gameObject, 4f);
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
