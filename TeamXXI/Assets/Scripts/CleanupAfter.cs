using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupAfter : MonoBehaviour
{
    public float seconds = 5.0f;

    void Start()
    {
        StartCoroutine(CleanupCoroutine());
    }

    IEnumerator CleanupCoroutine()
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Destroy(gameObject);
    }
}
