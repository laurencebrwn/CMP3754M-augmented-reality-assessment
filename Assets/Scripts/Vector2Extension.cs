using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Vector2Extension
{
    public static bool IsPointerOverUIObject(this Vector2 pos)
    {
      if (EventSystem.current.IsPointerOverGameObject())
      {
        return false;
      }
      PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
      eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);

      List<RaycastResult> results = new List<RaycastResult>();
      EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
      return results.Count > 0;
    }
}
