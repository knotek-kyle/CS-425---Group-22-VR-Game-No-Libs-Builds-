using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daniel Lontz
/// <summary>
///Manages fragments created from slicing.  When the OnFragmentCreation event is called,
///OnSliceCreation is called adding that object to the list.  Fragments are tagged with "Slice"
///for easy management.
/// </summary>

public class FragmentManager : MonoBehaviour
{
    List<GameObject> fragmentList;

    void Start()
    {
        fragmentList = new List<GameObject>();
    }

    #region Event subscriptions

    private void OnEnable()
    {
        Slice.OnFragmentCreation += OnSliceCreation;
    }

    private void OnDisable()
    {
        Slice.OnFragmentCreation -= OnSliceCreation;
    }

    #endregion

    private void OnSliceCreation(object sender, FragmentCreationEventInfo e)
    {
        GameObject fragment = e.UnitGO;
        fragmentList.Add(fragment);
        Debug.Log("New fragment added to fragment list");
    }

}
