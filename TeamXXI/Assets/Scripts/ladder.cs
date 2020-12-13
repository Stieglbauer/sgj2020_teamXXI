using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("climbing");
                other.GetComponent<CharacterController>().enabled = false;
                other.transform.position = target.transform.position;
                other.GetComponent<CharacterController>().enabled = true;
            }
        }
    }
}
