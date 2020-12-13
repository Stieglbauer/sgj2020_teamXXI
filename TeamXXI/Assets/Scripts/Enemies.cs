using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemies : MonoBehaviour
{
    [SerializeField]
    private GameObject path;

    private double counter = 0;
    private int schedule_progress = 0;
    [SerializeField]
    private GameObject[] enemyTypes;

    [SerializeField]
    private float[] schedule;

    [SerializeField]
    private int[] types;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (schedule_progress >= schedule.Length) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int leviathans = 0;
            foreach(GameObject enemy in enemies)
            {
                if(enemy.GetComponent<EnemyPathFollowing>() != null)
                {
                    leviathans++;
                    break;
                }
            }
            if(leviathans == 0)
            {
                Debug.Log("Win!");
                SceneManager.LoadScene("Win");
            }
        } else {
            if (counter > schedule[schedule_progress])
            {
                GameObject tank = Instantiate(enemyTypes[types[schedule_progress]], this.transform.position, enemyTypes[types[schedule_progress]].transform.rotation);
                tank.GetComponent<EnemyPathFollowing>().setPath(path);
                schedule_progress++;
                counter = 0;
            }
        }
    }
}
