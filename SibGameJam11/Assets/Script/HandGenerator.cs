using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGenerator : MonoBehaviour
{
    public GameObject Rukoyat;
    public GameObject Clickable;
    [Header("Electricity")]
    public float Electricity = 0;
    public float GeneratingSpeed = 1;
    public float RotationOffset = 10;

    private Camera mainCam;
    private float lastAngle;
    private float angle;
    private bool isGrabbed;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.gameObject == Clickable)
            {
                isGrabbed = true;
            }
        }
        if (Input.GetMouseButtonUp(0)) isGrabbed = false;

        if (isGrabbed) RotateToCursor();

        GenerateElectricity();
    }

    private void RotateToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (transform.position - mainCam.transform.position).z;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

        Rukoyat.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void GenerateElectricity()
    {
        if (Mathf.Abs(angle - lastAngle) >= RotationOffset)
        {
            lastAngle = angle;
            Electricity += GeneratingSpeed;
            print(Electricity);
        }
    }
}
