using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaterCustomization : MonoBehaviour
{
	public Button maleButton, femaleButton, finalizeButton;
	public Transform customizePoint;
	public Transform spawnPoint;

	private bool gender;

	public bool Gender
	{
		get
		{
			return gender;
		}
		set
		{
			gender = value;
			GenarateCharater();
		}
	}

	private bool finalize = false;

	public GameObject[] MaleCharaterModles;
	private GameObject activeMaleCharaterModlesObject;
	public GameObject[] FemaleCharaterModles;
	private GameObject activeCharaterModelObject;
	private int selectedIndex = 0;




	private CharaterAttack currentCustomizableCharacter;

	// Use this for initialization
	void Start()
	{
		finalize = false;
		
		//activeCharaterModelObject = FemaleCharaterModles[FemaleCharaterModles.Length];
		//activeMaleCharaterModlesObject = MaleCharaterModles[FemaleCharaterModles.Length];
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void MoveAvtiveCharaterModle()
	{
		finalize = true;
		currentCustomizableCharacter.ableToAttack = true;

		if (finalize == true)
		{
			if (gender == true)
			{
				//activeMaleCharaterModlesObject = GameObject.FindGameObjectWithTag("Male");
				currentCustomizableCharacter.transform.position = spawnPoint.transform.position;
				currentCustomizableCharacter.transform.rotation = spawnPoint.transform.rotation;
			}

			if (gender == false)
			{
				//activeFemaleCharaterModlesObject = GameObject.FindGameObjectWithTag("Female");
				currentCustomizableCharacter.transform.position = spawnPoint.transform.position;
				currentCustomizableCharacter.transform.rotation = spawnPoint.transform.rotation;
			}
			//activeMaleCharaterModlesObject.transform.position = spawnPoint.transform.position;
			//activeFemaleCharaterModlesObject.transform.position = spawnPoint.transform.position;
		}
		else if (finalize == false)
		{
			//activeMaleCharaterModlesObject.transform.position = customizePoint.transform.position;
			//activeFemaleCharaterModlesObject.transform.position = customizePoint.transform.position;
		}
	}

	public void AssignWeaponToCharacter(Weapon weapon)
	{
		if (currentCustomizableCharacter != null)
		{
			currentCustomizableCharacter.weapon = weapon;
			currentCustomizableCharacter.EquippedBoolRepeat();
		}
	}

	public void AssignMagicToCharacter(Magic magic)
	{
		if (currentCustomizableCharacter != null)
		{
			currentCustomizableCharacter.magicType = magic;
		}
	}

	public void GenarateCharater()
	{
		
		foreach (Transform obj in customizePoint)
		{
			Destroy(obj.gameObject);
		}

		if (gender == true)
		{
			selectedIndex %= MaleCharaterModles.Length;
			activeCharaterModelObject = Instantiate(MaleCharaterModles[selectedIndex], customizePoint.position, customizePoint.rotation, customizePoint);


		}
		else
		{
			selectedIndex %= FemaleCharaterModles.Length;
			activeCharaterModelObject = Instantiate(FemaleCharaterModles[selectedIndex], customizePoint.position, customizePoint.rotation, customizePoint);
		}


		CharaterAttack attack = activeCharaterModelObject.GetComponent<CharaterAttack>();
		if (attack != null)
		{
			currentCustomizableCharacter = attack;
		}

	}

	public void NextModelInList()
	{
		selectedIndex++;
		GenarateCharater();
	}
	public void PreviousModelInList()
	{
		selectedIndex--;
		if (selectedIndex < 0)
		{
			selectedIndex = (gender) ? MaleCharaterModles.Length - 1 : FemaleCharaterModles.Length - 1;
		}
		GenarateCharater();
	}
}
