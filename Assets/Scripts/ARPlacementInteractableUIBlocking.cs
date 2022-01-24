using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARPlacementInteractableUIBlocking : ARPlacementInteractable
{
  protected override bool CanStartManipulationForGesture(TapGesture gesture)
  {
    if(gesture.startPosition.IsPointerOverUIObject())
    {
      return false;
    }
    else
    {
      return gesture.targetObject == null;
    }
  }
}
