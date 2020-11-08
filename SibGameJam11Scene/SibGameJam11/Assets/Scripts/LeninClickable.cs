using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeninClickable : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
{
    public bool IsPointed;

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsPointed = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPointed = false;
    }
    private void Update()
    {
        print(IsPointed);
    }
}
