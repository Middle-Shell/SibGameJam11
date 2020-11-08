using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class HandGenerator : MonoBehaviour
{
    public GameObject Rukoyat;
    public GameObject Clickable;
    public UnityEngine.Transform RotationPivot;
    [Header("Electricity")]
    public float GeneratingSpeed = 1;
    public float RotationOffset = 10;
    [Header("Animations")]
    public UnityArmatureComponent MyAnimator;
    public AudioSource PlaySound;

    private GameManager gameManager;
    private Camera mainCam;
    private float lastAngle;
    private float angle;
    private bool isGrabbed;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
        Animate();
        SFX();
    }

    private void RotateToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (RotationPivot.position - mainCam.transform.position).z;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(RotationPivot.position);
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
            gameManager.Electricity += GeneratingSpeed * Time.deltaTime;
        }
    }

    private void Animate()
    {
        if (MyAnimator != null)
        {
            if (isGrabbed)
            {
                if (MyAnimator.animation.lastAnimationName != "1")
                {
                    MyAnimator.animation.Play("1");
                }
            }
            else
            {
                MyAnimator.animation.Play("0");
            }
        }
    }

    private void SFX()
    {
        if (isGrabbed)
        {
            if (!PlaySound.isPlaying)
            {
                PlaySound.Play();
            }
        }
        else
        {
            PlaySound.Stop();
        }
    }
}
