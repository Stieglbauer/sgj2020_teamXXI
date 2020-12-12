using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_general : MonoBehaviour

{
    [SerializeField]
    private float lives;
    [SerializeField]
    private GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        // If lives are less or equal to zero then destroy it and instantiate the explosion
        if (lives <= 0)
        {
            // Create Explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destroy the gameObject
            Destroy(this.gameObject);
        }
    }

    public void ReduceLivesBy(float amount)
    {
        lives -= amount;
    }
}
