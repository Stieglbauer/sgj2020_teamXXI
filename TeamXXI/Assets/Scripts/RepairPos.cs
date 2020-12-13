using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPos : MonoBehaviour
{
    [SerializeField]
    private int targetIndex;

    [SerializeField]
    private GameObject target;

    private TeslaTower tt;

    private void Start()
    {
        tt = target.GetComponent<TeslaTower>();
    }

    public void repair(float val)
    {
        tt.repair(targetIndex, val);
    }

    public bool isDamaged()
    {
        return tt.isDamaged(targetIndex);
    }
}
