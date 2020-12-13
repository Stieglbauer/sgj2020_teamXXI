using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_projectile : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private GameObject explosion;

    private bool done = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
            return;
        if (done)
        {
            done = false;
            Transform t = transform.GetChild(0);
            t.gameObject.GetComponent<ParticleSystem>().Stop();
            t.SetParent(null);
            t = transform.GetChild(0);
            t.gameObject.GetComponent<ParticleSystem>().Stop();
            t.SetParent(null);
            Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 1));
            other.gameObject.GetComponent<Enemy_general>().ReduceLivesBy(1);
            Debug.Log(other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
