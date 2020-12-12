using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain : MonoBehaviour
{
    private Material mat;

    [SerializeField]
    private GameObject nails, nails2, nails3, nails4;

    private Renderer nail_ren, nail2_ren, nail3_ren, nail4_ren;

    private int nail = 0;
    // Start is called before the first frame update
    void Start()
    {
        nail_ren = nails.GetComponent<Renderer>();
        nail2_ren = nails2.GetComponent<Renderer>();
        nail3_ren = nails3.GetComponent<Renderer>();
        nail4_ren = nails4.GetComponent<Renderer>();
        nail2_ren.enabled = false;
        nail3_ren.enabled = false;
        nail4_ren.enabled = false;
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        switch(nail)
        {
            case 0:
                nail_ren.enabled = true;
                nail2_ren.enabled = false;
                nail3_ren.enabled = false;
                nail4_ren.enabled = false;
                break;
            case 1:
                nail_ren.enabled = false;
                nail2_ren.enabled = true;
                nail3_ren.enabled = false;
                nail4_ren.enabled = false;
                break;
            case 2:
                nail_ren.enabled = false;
                nail2_ren.enabled = false;
                nail3_ren.enabled = true;
                nail4_ren.enabled = false;
                break;
            case 3:
                nail_ren.enabled = false;
                nail2_ren.enabled = false;
                nail3_ren.enabled = false;
                nail4_ren.enabled = true;
                break;
        }
        mat.SetTextureOffset("_MainTex", new Vector2(0, 0.1f * nail));
        nail++;
        if(nail >= 4)
        {
            nail = 0;
        }
    }
}
