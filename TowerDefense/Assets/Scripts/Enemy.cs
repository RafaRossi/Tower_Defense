using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed, startLifes;
    public int value;
    public Slider slider;

    float lifes;

	// Use this for initialization
	void Start () {
        lifes = startLifes;
        slider.maxValue = startLifes;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.isGameOver)
        {
            enabled = false;
            return;
        }
    }

    public void TakeDamage(int damage)
    {
        lifes -= damage;
        slider.value = lifes;
        if (lifes <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
        SpawnController.enemysAlives--;
        PlayerStats.Money += value;
    }
}
