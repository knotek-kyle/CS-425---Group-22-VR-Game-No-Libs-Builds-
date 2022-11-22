using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks {
public class FragmentManager : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> fragmentList;
    void Start()
    {
        fragmentList = new List<GameObject>();
    }

    private void OnEnable()
    {
        Slice.OnFragmentCreation += OnSliceCreation;
        
    }

    private void OnDisable()
    {
        Slice.OnFragmentCreation -= OnSliceCreation;
    }

    private void OnSliceCreation(object sender, Slice.FragmentCreationEventInfo e)
    {
        GameObject fragment = e.UnitGO;
        fragmentList.Add(fragment);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (fragmentList.Count > 0){
            foreach (GameObject go in fragmentList)
            {
                Debug.Log(go.name);
            }
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            foreach (GameObject go in fragmentList)
            {
                Destroy(go);
            }
            fragmentList.Clear();
        }
    }
}
}