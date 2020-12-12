using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi!");
        Transform t = transform.GetChild(0);
        t.SetParent(null);
        t.GetComponent<ParticleSystem>().Stop();
        Destroy(transform.GetChild(0).gameObject);
        Instantiate(explosion, transform.position, new Quaternion(0,0,0,1));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position, gameObject.transform.position) < radius)
            {

            } 
        }
    }
}
