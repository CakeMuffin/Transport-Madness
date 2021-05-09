using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int money = 0;

    public static GameManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	void Start()
    {
		AddMoney(0);
	}

	public void AddMoney(int value)
	{
		money += value;
		UiManager.Instance.SetMoney(money);
	}
}
