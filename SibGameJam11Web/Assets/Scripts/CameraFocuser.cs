using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraFocuser : MonoBehaviour
{
    public GameObject Lenin;
    [Space]
    public string GeneratorsTag;
    public float FocusSpeed = 1;
    public Vector2 Offset;
    public GameObject LeninCollider;

    [Space, Header("Camera Sizes:")]
    public float unfocusedCameraSize;
    public float focusedCameraSize;

    [Header("Lenin CoolDown")]
    public float CoolDownTime = 1;
    public float WorkableTime = 1;

    private Camera myCamera;
    private GameManager gameManager;

    private bool IsFocused;
    private Vector2 FucusPosition;
    private Vector3 unfocusedPosition;
    private float lerpSpeed;
    private bool canFocus = true;
    private bool timerStarted;

    void Start()
    {
        lerpSpeed = Time.deltaTime * FocusSpeed;
        unfocusedPosition = transform.position;
        myCamera = GetComponent<Camera>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (canFocus)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(myCamera.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == GeneratorsTag)
                {
                    gameManager.ActiveGenerator = hitInfo.transform.parent.gameObject.GetComponent<AutoGenerator>();
                    print(hitInfo.transform.name);
                    FucusPosition = hitInfo.transform.position;
                    IsFocused = true;
                    Lenin?.SetActive(true);
                    LeninCollider.SetActive(true);
                    StartCoolDownTimer();
                }
                else
                {
                    UnFocus();
                }
            }
        }
        else
        {
            UnFocus();
        }

        Vector2 lerpedPos = Vector2.Lerp(transform.position, unfocusedPosition, lerpSpeed);
        float lerpCameraSize = Mathf.Lerp(myCamera.orthographicSize, unfocusedCameraSize, lerpSpeed);

        if (IsFocused)
        {
            lerpedPos = Vector2.Lerp(transform.position, FucusPosition - Offset, lerpSpeed);
            lerpCameraSize = Mathf.Lerp(myCamera.orthographicSize, focusedCameraSize, lerpSpeed);
        }

        transform.position = new Vector3(lerpedPos.x, lerpedPos.y, transform.position.z);
        myCamera.orthographicSize = lerpCameraSize;
    }

    public void UnFocus()
    {
        IsFocused = false;
        gameManager.ActiveGenerator = null;
        Lenin?.SetActive(false);
        LeninCollider.SetActive(false);
    }

    private void StartCoolDownTimer()
    {
        if (!timerStarted)
        {
            Invoke("StartCoolDown", WorkableTime);
            timerStarted = true;
        }
    }

    private void StartCoolDown()
    {
        canFocus = false;
        Invoke("RemoveCoolDown", CoolDownTime);
    }

    private void RemoveCoolDown()
    {
        canFocus = true;
        timerStarted = false;
    }
}
