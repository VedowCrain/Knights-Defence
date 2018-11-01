using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickButtonFlip : MonoBehaviour
{
	public Animator anim;
	public Button button;

	public int groupIndex = 0;

	private void Start()
	{
		anim = GetComponent<Animator>();
		button = GetComponent<Button>();
		button.onClick.AddListener(Select);
	}

	public void Select()
	{
		DeselectAll(groupIndex);
		anim.SetBool("Visible", false);
	}

	public void Deselect()
	{
		anim.SetBool("Visible", true);
	}

	public static void DeselectAll(int groupId)
	{
		foreach (var item in FindObjectsOfType<OnClickButtonFlip>())
		{
			if (item.groupIndex == groupId)
			{
				item.Deselect();
			}

		}
	}
}
