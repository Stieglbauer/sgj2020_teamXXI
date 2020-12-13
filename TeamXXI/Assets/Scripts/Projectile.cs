using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private GameObject explosion;

    private bool done = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
            return;
        if (done)
        {
            done = false;
            Transform t = transform.GetChild(0);
            t.gameObject.GetComponent<ParticleSystem>().Stop();
            t.SetParent(null);
            Destroy(transform.GetChild(0).gameObject);
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 1));
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) < radius)
                {
                    enemy.GetComponent<Enemy_general>().ReduceLivesBy(10 / (1 + Vector3.Distance(enemy.transform.position, gameObject.transform.position)));
                }
            }
            Destroy(gameObject);
        }
    }
}
