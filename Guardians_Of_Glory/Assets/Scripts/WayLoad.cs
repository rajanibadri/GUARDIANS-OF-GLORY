using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WayLoad : MonoBehaviour
{  [SerializeField] Tower tower;
    public bool isPlaceable;
    
     void OnMouseDown()
    {  if(isPlaceable&&!IsPointerOverUI())
       {
        bool isPlaced=tower.CreateTower(tower,transform.position);
        isPlaceable=!isPlaced;
       }
       
    }
     private bool IsPointerOverUI()
    { if (EventSystem.current == null)
        return false;

    PointerEventData eventData = new PointerEventData(EventSystem.current);
    eventData.position = Input.mousePosition;

    List<RaycastResult> raycastResults = new List<RaycastResult>();
    EventSystem.current.RaycastAll(eventData, raycastResults);

    for (int i = 0; i < raycastResults.Count; i++)
    {
        if (raycastResults[i].gameObject.GetComponent<RectTransform>() != null)
        {
            return true;
        }
    }

    return false;
}
}
