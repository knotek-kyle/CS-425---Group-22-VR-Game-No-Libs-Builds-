using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject gameObj;
    public float deathtimer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObj, deathtimer);
    }

}
