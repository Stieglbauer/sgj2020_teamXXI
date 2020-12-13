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

    [SerializeField]
    private GameObject[] part1Des, part2Des;

    [SerializeField]
    private GameObject part1, part2;

    private Vector3 emissionSource;
    private float cooldown;


    public float damage1, damage2;
    // Start is called before the first frame update
    void Start()
    {
        emissionSource = source.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (damage1 < 0) damage1 = 0;
        if (damage2 < 0) damage2 = 0;
        cooldown += Time.deltaTime;
        if (damage1 + damage2 > 0)
        {
            cooldown = 0;
        }
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
        if(damage1 > 0)
        {
            foreach(GameObject p in part1Des)
            {
                p.GetComponent<Renderer>().enabled = true;
            }
            part1.GetComponent<Renderer>().enabled = false;
        } else
        {
            foreach (GameObject p in part1Des)
            {
                p.GetComponent<Renderer>().enabled = false;
            }
            part1.GetComponent<Renderer>().enabled = true;

        }
        if (damage2 > 0)
        {
            foreach (GameObject p in part2Des)
            {
                p.GetComponent<Renderer>().enabled = true;
            }
            part2.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            foreach (GameObject p in part2Des)
            {
                p.GetComponent<Renderer>().enabled = false;
            }
            part2.GetComponent<Renderer>().enabled = true;

        }
    }

    private void shootAt(Vector3 target)
    {
        GameObject shot = Instantiate(projectile, emissionSource, new Quaternion(0, 0, 0, 1));
        shot.GetComponent<Rigidbody>().velocity = -100 * (emissionSource - target).normalized;
        shot.GetComponent<Rigidbody>().WakeUp();
    }

    public void makeTowerDamaged(int whichOne)
    {
        if (whichOne == 2)
            damage2 = 2;
        else
            damage1 = 2;
    }

    public void repair(int index, float val)
    {
        if(index == 1)
        {
            damage1 -= val;
        } else
        {
            damage2 -= val;
        }
    }

    public bool isDamaged(int index)
    {
        if(index == 1)
        {
            return damage1 > 0;
        } else
        {
            return damage2 > 0;
        }
    }
}
