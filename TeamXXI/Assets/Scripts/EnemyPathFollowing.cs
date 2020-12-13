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
        Quaternion direction = Quaternion.LookRotation(stripFromY(currentTarget.transform.position - transform.position), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, 30*Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, direction) < 1) {
            transform.Translate(3 * Time.deltaTime * stripFromY(currentTarget.transform.position - transform.position).normalized, Space.World);
            if (Vector3.Distance(transform.position, currentTarget.transform.position) < 1)
            {
                currentTarget = pf.getNextCheckpoint(currentTarget);
            }
            if (currentTarget == null)
            {
                Debug.Log("Lose!");
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    private Vector3 stripFromY(Vector3 vec)
    {
        return new Vector3(vec.x, 0, vec.z);
    }

    public void setPath(GameObject newPath)
    {
        this.path = newPath;
    }
}
