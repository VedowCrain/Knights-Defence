using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
	private float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	private Transform enemyTarget;
	private Rigidbody rbBody;
	Rigidbody theRigidedbody;
	private float deathdelay;
	private NavMeshAgent agent;
	public float damping;
	private Animator anim;
	public float doAttackDistance = 1;
	public string[] singleAttack;
	public float timeBetweenAttacks;
	private bool Dead = false;

	// Use this for initialization
	void Start()
	{
		enemyTarget = FindObjectOfType<player>().transform;
		rbBody = GetComponent<Rigidbody>();
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		fpsTargetDistance = Vector3.Distance(enemyTarget.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance && Dead == false)
		{
			lookAtPlayer();
			GetComponent<WanderingAI>().StopAgent();
			rbBody.isKinematic = true;
		}
		else
		{
			GetComponent<WanderingAI>().ResumeAgent();
			rbBody.isKinematic = false;
		}
		if (fpsTargetDistance < attackDistance && Dead == false)
		{
			attackPlease();
		}

		deathdelay -= Time.deltaTime;
		if (deathdelay <= 0 && Dead == true)
		{
			Destroy(this.gameObject);
		}
	}

	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation(enemyTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		Debug.Log("I see you");
	}

	void attackPlease()
	{
		agent.destination = enemyTarget.position;
		GetComponent<WanderingAI>().ResumeAgent();
		if (fpsTargetDistance <= doAttackDistance && singleAttackCoroutine == null)
		{
			singleAttackCoroutine = StartCoroutine(SingleAttack());
			Debug.Log("Attack");
		}
	}

	[Space]
	[SerializeField] private float health = 1000;

	[Space]
	[SerializeField] private float timer = 4;

	private void OnTriggerEnter(Collider other)
	{
		print("Collision");

		if (other.gameObject.CompareTag("Weapon"))
		{
			Weapon weapon = FindObjectOfType<CharaterAttack>().weapon;
			if (fpsTargetDistance >= weapon.minRange && fpsTargetDistance <= weapon.maxRange)
			{
				health -= weapon.damage;
				Debug.Log("Delt " + weapon.damage + "Damage");
				Debug.Log("Boss Health " + health);
			}
			else
			{
				Debug.Log("Missed");
			}
		}

		if (health <= 0)
		{
			Dead = true;

			if (Dead == true)
			{
				deathdelay = timer;
				GetComponent<WanderingAI>().StopAgent();
				CapsuleCollider c = GetComponent<CapsuleCollider>();
				c.enabled = false;
				Destroy(c);
				anim.SetTrigger("Death");
			}
		}
	}

	private Coroutine singleAttackCoroutine;

	IEnumerator SingleAttack()
	{
		anim.SetTrigger(singleAttack[Random.Range(0, singleAttack.Length)]);
		yield return new WaitForSecondsRealtime(timeBetweenAttacks);
		singleAttackCoroutine = null;
	}
}
