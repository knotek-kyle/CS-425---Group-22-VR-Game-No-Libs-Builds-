using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

//Kyle Knotek

[ExcludeFromCoverage]
public class SwordSlicer : MonoBehaviour
{
    public InputActionProperty button;
    //public GameObject trigger;
    //Collider triggerCollider;

    public static event System.EventHandler<UnitSliceEventInfo> OnSlice;

    public class UnitSliceEventInfo : EventInfo
    {
        public GameObject UnitGO;
        public UnitSliceEventInfo(string eventDescription, GameObject go)
            {
                UnitGO = go;
                this.EventDescription = eventDescription;
            }
    }

    void Start()
    {
        InvokeRepeating("CutAction", 0.0f, 0.1f);
    }

    public void OnTriggerStay(Collider collider)
    {
        var material = collider.gameObject.GetComponent<MeshRenderer>().material;
        if (material.name.StartsWith("HighlightSlice"))
        {
            material.SetVector("CutPlaneNormal", this.transform.up);
            material.SetVector("CutPlaneOrigin", this.transform.position);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        var material = collider.gameObject.GetComponent<MeshRenderer>().material;
        if (material.name.StartsWith("HighlightSlice"))
        {
            material.SetVector("CutPlaneOrigin", Vector3.positiveInfinity);
        }
    }

    void sliceTrigger(GameObject obj)
    {   
        OnSlice?.Invoke(this, new UnitSliceEventInfo("Slicing " + obj.name, obj));
    }

    void CutAction()
    {
        
        if(button.action.IsPressed())
        {
            var mesh = this.GetComponent<MeshFilter>().sharedMesh;
            var center = mesh.bounds.center;
            var extents = mesh.bounds.extents;

            extents = new Vector3(extents.x * this.transform.localScale.x,
                                  extents.y * this.transform.localScale.y,
                                  extents.z * this.transform.localScale.z);
                                  
            // Cast a ray and find the nearest object
            RaycastHit[] hits = Physics.BoxCastAll(this.transform.position, extents, this.transform.forward, this.transform.rotation, extents.z);
            
            foreach(RaycastHit hit in hits)
            {
                var obj = hit.collider.gameObject;
                var sliceObj = obj.GetComponent<Slice>();

                if (sliceObj != null)
                {
                    sliceTrigger(obj);
                    sliceObj.GetComponent<MeshRenderer>()?.material.SetVector("CutPlaneOrigin", Vector3.positiveInfinity);
                    sliceObj.ComputeSlice(this.transform.up, this.transform.position);
                }
            }
        }
    }
}
