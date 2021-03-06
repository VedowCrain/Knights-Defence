﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Combo
{
    public string[] attack;
}

public class CharaterAttack : MonoBehaviour
{
    public Weapon weapon;
    private Animator anim;
    public Transform hand;
    public Transform back;
    private bool equipped;
    public bool ableToAttack = false;

    [Space]
    public string[] singleAttack;
    public Combo[] comboAttack;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        equipped = anim.GetBool("Equipped");
		if (ableToAttack)
			origin = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponEquippedAnim();
        AttackMonitor();
        AEOMagic();

        
    }

    public void WeaponEquippedAnim()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("Equiped weapon");

            // Example of anim bool set
            //anim.SetBool("Equipped", ! anim.GetBool("Equipped"));

            equipped = !equipped;
            anim.SetBool("Equipped", equipped);
        }
    }

    [Space]
    public float attackDelay = 0.5f;
    private float timeToAttack;
    private bool clickStarted = false;
    private int clickCount = 0;

    private void AttackMonitor()
    {
        if (Input.GetButtonDown("Fire1") && equipped && ableToAttack == true)
        {
            if (!clickStarted)
            {
                clickStarted = true;
                timeToAttack = attackDelay;
                clickCount = 0;
            }
            if (clickStarted && timeToAttack > 0)
            {
                clickCount++;
            }
        }

        timeToAttack -= Time.deltaTime;

        if (timeToAttack < 0 && clickStarted)
        {
            clickStarted = false;
            print(clickCount);
            if (clickCount == 1)
            {
                if (singleAttackCoroutine == null)
                {
                    singleAttackCoroutine = StartCoroutine(SingleAttack());
                }
            }
            else
            {
                if (comboAttackCoroutine == null)
                {
                    comboAttackCoroutine = StartCoroutine(ComboAttack());
                }
            }
        }

    }

    private Coroutine comboAttackCoroutine;
    public float timeBetweenAttacks = 1.5f;

    IEnumerator ComboAttack()
    {
        Combo attack = comboAttack[Random.Range(0, comboAttack.Length)];
        foreach (string a in attack.attack)
        {
            anim.SetTrigger(a);
            yield return new WaitForSecondsRealtime(1);
        }
        comboAttackCoroutine = null;
    }

    private Coroutine singleAttackCoroutine;

    IEnumerator SingleAttack()
    {
        anim.SetTrigger(singleAttack[Random.Range(0, singleAttack.Length)]);
        yield return new WaitForSecondsRealtime(timeBetweenAttacks);
        singleAttackCoroutine = null;
    }

    [Space]
    public Transform origin;
    private Vector3 magicHitPoint;
    public Magic magicType;
    public LayerMask mask;

    void AEOMagic()
    {
		if (Camera.main == null) return;

        if (Input.GetKeyDown(KeyCode.G))
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit magicHit;
            if (Physics.Raycast(ray, out magicHit, 100, mask))
            {
                print("Magic happend at " + magicHit.point + magicHit.transform.name);
                magicHitPoint = magicHit.point;
                anim.SetTrigger("Magic");
            }

        }
    }

    void InstantiateMagic()
    {
        Instantiate<GameObject>(magicType.prefab, magicHitPoint, Quaternion.identity);
    }

    void InstantiateWeapon()
    {
        if (equipped)
        {
            foreach (Transform obj in back)
            {
                Destroy(obj.gameObject);

                print("Taking Weapon Into Hand");

                // logic of insantiate gamobject and setting parent

                /*GameObject obj = Instantiate(weapon.prefab, hand.position, Quaternion.identity);
                obj.transform.parent = hand;*/
            }

            Instantiate<GameObject>(weapon.prefab, hand.position, hand.rotation, hand);
        }
        else
        {
            foreach (Transform obj in hand)
            {
                Destroy(obj.gameObject);

                print("Putting Weapon On Back");

            }

            Instantiate<GameObject>(weapon.prefab, back.position, back.rotation, back);
        }
    }

    public void EquippedBoolRepeat()
    {
        if (equipped)
        {

            foreach (Transform obj in hand)
            {
                Destroy(obj.gameObject);

                print("Putting Weapon On Back");

            }

            Instantiate<GameObject>(weapon.prefab, hand.position, hand.rotation, hand);
        }
        else
        {
            foreach (Transform obj in back)
            {
                Destroy(obj.gameObject);

                print("Taking Weapon Into Hand");

                // logic of insantiate gamobject and setting parent

                /*GameObject obj = Instantiate(weapon.prefab, hand.position, Quaternion.identity);
                obj.transform.parent = hand;*/
            }

            Instantiate<GameObject>(weapon.prefab, back.position, back.rotation, back);
        }
    }
}
