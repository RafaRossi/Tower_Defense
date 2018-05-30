using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public int damage;
    public float speed = 50f;
    public GameObject bulletImpact;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effect = Instantiate(bulletImpact, transform.position, transform.rotation);
        if (target.GetComponent<Enemy>() != null)
            Damage(target.transform);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
            e.TakeDamage(damage);
    }
}
