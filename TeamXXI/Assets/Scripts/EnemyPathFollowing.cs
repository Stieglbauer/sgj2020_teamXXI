using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFollowing : MonoBehaviour
{
    [SerializeField]
    private GameObject path;
    private GameObject currentTarget;

    private Pathfinding pf;
    // Start is called before the first frame update
    void Start()
    {
        pf = path.GetComponent<Pathfinding>();
        currentTarget = pf.getNextCheckpoint(null);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.01f * (currentTarget.transform.position - transform.position));
        if(Vector3.Distance(transform.position, currentTarget.transform.position) < 1)
        {
            Debug.Log("next!");
            currentTarget = pf.getNextCheckpoint(currentTarget);
        }
        if(currentTarget == null)
        {
            Debug.Log("Boom!");
            GameObject.Destroy(this);
        }
    }
}
