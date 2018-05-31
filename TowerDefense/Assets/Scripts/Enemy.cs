using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed, startLifes;
    public int value;
    public Slider slider;

    float lifes;
    bool isDead = false;

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
        if (lifes <= 0 && !isDead)
            Die();
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject);
        SpawnController.enemysAlives--;
        PlayerStats.Money += value;
    }
}
