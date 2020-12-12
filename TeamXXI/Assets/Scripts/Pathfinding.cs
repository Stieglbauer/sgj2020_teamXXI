using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField]
    private GameObject[] checkpoints;

    public GameObject getNextCheckpoint(GameObject current)
    {
        if(current == null)
        {
            return checkpoints[0];
        }
        for(int i=0; i<checkpoints.Length-1; i++)
        {
            if(current.Equals(checkpoints[i]))
            {
                return checkpoints[i + 1];
            }
        }
        return null;
    }
}
