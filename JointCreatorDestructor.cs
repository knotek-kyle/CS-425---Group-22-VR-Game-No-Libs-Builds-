//Kyle Knotek

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JointCreatorDestructor : MonoBehaviour
{
    public GameObject joint;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateJoint(ActivateEventArgs arg)
    {
        GameObject spawnedJoint = Instantiate(joint);
        spawnedJoint.transform.position = spawnPoint.position;
        //GameObject *jointp = spawnedJoint;
        Destroy(spawnedJoint, 2);
    }


    /*public void DestroyJoint(ActivateEventArgs arg, GameObject* jointp)
    {
        Destroy(*jointp, 0);
    }*/
}
