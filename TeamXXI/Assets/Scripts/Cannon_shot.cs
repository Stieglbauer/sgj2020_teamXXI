using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_shot : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzle, expl_pos, explosion, startPos, backPos, projectile;

    public bool debug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(startPos.transform.position, muzzle.transform.position) > 0.01f)
        {
            muzzle.transform.position = Vector3.Lerp(muzzle.transform.position, startPos.transform.position, 0.01f);
        }
        if (debug) {
            Debug.Log("Boom!");
            shot();
            debug = false;
        }
    }

    void shot()
    {
        Instantiate(explosion, expl_pos.transform.position, Quaternion.Euler(-90,0,0) * muzzle.transform.rotation, muzzle.transform.parent);
        muzzle.transform.position = backPos.transform.position;
        GameObject cannonBall = Instantiate(projectile, expl_pos.transform.position, Quaternion.Euler(-90, 0, 0) * muzzle.transform.rotation);
        cannonBall.GetComponent<Rigidbody>().velocity = cannonBall.transform.rotation * new Vector3(0, 0, 15);
    }
}
