using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
        base.OnSelectEntered(args);

        if(interactor is XRDirectInteractor)
        {
            Climbing.climbHand = interactor.GetComponent<XRController>();
            Debug.Log(interactor.name);
        }
    }
 
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        XRBaseInteractor interactor = args.interactor;
        base.OnSelectExited(args);

        if(interactor is XRDirectInteractor)
        {
            if(Climbing.climbHand && Climbing.climbHand.name == interactor.name)
            {
                Climbing.climbHand = null;
                Debug.Log("Select Exit");
            }
        }
    }
}
