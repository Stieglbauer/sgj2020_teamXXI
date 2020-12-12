using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatlin : MonoBehaviour
{
    [SerializeField]
    private GameObject mag1, mag2;
    [SerializeField]
    private GameObject arm1, arm2;
    [SerializeField]
    private GameObject mag1_ref, mag2_ref;

    [SerializeField]
    private float maxTime;

    [SerializeField]
    private GameObject muzzleFlash;


    private float timer = 0;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Reload"))
        {
            mag2.transform.SetParent(animator.GetBool("Grabbing") ? arm1.transform : gameObject.transform);
            mag1.transform.SetParent(animator.GetBool("Grabbing")?arm2.transform:gameObject.transform);
            muzzleFlash.SetActive(false);

        } else
        {

            muzzleFlash.SetActive(true);
            timer += Time.deltaTime;
        }

        if (timer > maxTime)
        {
            mag2.transform.SetParent(gameObject.transform);
            mag1.transform.SetParent(gameObject.transform);
            mag2.transform.SetPositionAndRotation(mag2_ref.transform.position, mag2_ref.transform.rotation);
            mag1.transform.SetPositionAndRotation(mag1_ref.transform.position, mag1_ref.transform.rotation);
            timer = 0;
            animator.Play("Reloading", 0);
            animator.SetBool("Reload", true);
        }

    }
}
