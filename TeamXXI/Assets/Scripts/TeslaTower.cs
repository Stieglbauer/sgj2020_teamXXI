using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaTower : MonoBehaviour
{
    [SerializeField]
    private float range;

    [SerializeField]
    private GameObject source, projectile;

    [SerializeField]
    private float fireRate;

    private Vector3 emissionSource;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        emissionSource = source.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > fireRate) { 
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) < range)
                {
                    shootAt(enemy.transform.position);
                    break;
                }
            }
            cooldown = 0;
        }
    }

    private void shootAt(Vector3 target)
    {
        GameObject shot = Instantiate(projectile, emissionSource, new Quaternion(0, 0, 0, 1));
        shot.GetComponent<Rigidbody>().velocity = -100 * (emissionSource - target).normalized;
        shot.GetComponent<Rigidbody>().WakeUp();
    }
}
