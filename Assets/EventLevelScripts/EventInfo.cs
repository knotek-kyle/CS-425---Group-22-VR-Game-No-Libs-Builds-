using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EventInfo 
{
    public string EventDescription;
}


public class FragmentCreationEventInfo : EventInfo
{
    public GameObject UnitGO;
}

public class UnitSpawnEventInfo : EventInfo 
{
    public GameObject UnitGO;
}

public class AudioEventInfo : EventInfo
{
    public AudioSource audio;
}
