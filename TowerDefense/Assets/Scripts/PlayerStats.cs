using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Lifes;
    int startLifes=20;

    public static int Money;
    int startMoney=300;

    public static int Round=1;

	// Use this for initialization
	void Start () {
        Money = startMoney;
        Lifes = startLifes;
	}
}
