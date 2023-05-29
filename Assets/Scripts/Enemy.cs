using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  public NavMeshAgent agent;
  public Animator animator;
  public float attackRange = 1.8f;

  private GameObject target;

  public void Kill()
  {
    animator.SetBool("Dying", true);
    Invoke("DestroyMe", 4f);
  }

  void DestroyMe()
  {
    Object.Destroy(gameObject);
  }

  void Start()
  {
    target = GameObject.FindGameObjectWithTag("Player");
    agent.updatePosition = false;
  }

  void Update()
  {
    bool canMove = !animator.GetBool("Dying") && Vector3.Distance(transform.position, target.transform.position) > attackRange;
    animator.SetBool("Moving", canMove);
    animator.SetBool("Attacking", !canMove);
    agent.destination = canMove ? target.transform.position : transform.position;
  }

  void OnAnimatorMove()
  {
    transform.position = agent.nextPosition;
  }
}
