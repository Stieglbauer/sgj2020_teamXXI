using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private float speed;
    private float currentXPosition;
    private float currentZPosition;

    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        resetCooldown();
    }

    void OnDrawGizmosSelected()
    {
        Vector3 overPosition = new Vector3(9, transform.position.y, 10);
        Gizmos.DrawLine(transform.position, overPosition);
        Gizmos.DrawWireSphere(overPosition, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            Debug.Log("bomb away");
            resetCooldown();
            throwBomb();
        }

        transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.Self);

        if (transform.position.x > 300 || transform.position.x < -300 ||
            transform.position.y > 300 || transform.position.y < -300 ||
            transform.position.z > 300 || transform.position.z < -300)
        {
            Destroy(this);
        }
    }

    private void resetCooldown()
    {
        cooldown = Random.Range(7, 10);
    }
    private void throwBomb()
    {
        Instantiate(bomb, gameObject.transform.position, new Quaternion(0, 0, 0, 1));
    }

}
