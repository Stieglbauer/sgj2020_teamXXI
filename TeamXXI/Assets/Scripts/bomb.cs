using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
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
            Debug.Log("boom");
            done = false;
            Instantiate(explosion, gameObject.transform.position, new Quaternion(0, 0, 0, 1));
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Tower");
            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) < radius)
                {
                    RepairPos rp = enemy.GetComponent<RepairPos>();
                    if(rp != null)
                    {
                        rp.repair(-3);
                        var speaker = SpeakerScript.GetSpeaker();
                        if (speaker != null) {
                            speaker.Queue(speaker.towerCorrupted);
                        }
                    }
                    Rotateable r = enemy.GetComponent<Rotateable>();
                    if(r != null)
                    {
                        r.setAngle(Random.Range(-360 * 100, 360 * 100));
                        var speaker = SpeakerScript.GetSpeaker();
                        if (speaker != null) {
                            speaker.Queue(speaker.cannonDeflected);
                        }
                    }
                }
            }
            //Destroy(gameObject);
        }
    }
}
