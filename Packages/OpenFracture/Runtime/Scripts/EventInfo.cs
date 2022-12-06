using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daniel Lontz
//Abstract class for events.  May need to add more information.
public abstract class EventInfo 
{
    public string EventDescription;
}

public class OutOfBoundsEventInfo : EventInfo
{   
    public OutOfBoundsEventInfo(string eventDescription)
        {
            this.EventDescription = eventDescription;
        }
}

public class SliceEventInfo
{
    public GameObject UnitGO;
    public SliceEventInfo(GameObject obj)
    {
        UnitGO = obj;
    }
}

public class FragmentCreationEventInfo
{
    public GameObject UnitGO;
    public FragmentCreationEventInfo(GameObject obj)
    {
            UnitGO = obj;
    }
}