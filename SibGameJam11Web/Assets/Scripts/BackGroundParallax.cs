using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundParallax : MonoBehaviour
{
    public float modifier;

    private Vector3 pz;
    private Vector3 StartPos;
    private RectTransform myTransform;

    void Start()
    {
        myTransform = GetComponent<RectTransform>();
        StartPos = myTransform.localPosition;
    }

    void Update()
    {
        var pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;

        myTransform.localPosition = Vector3.Lerp(myTransform.localPosition, new Vector3(StartPos.x + (pz.x * -modifier), StartPos.y + (pz.y * -modifier), myTransform.localPosition.z), Time.deltaTime);
    }
}
