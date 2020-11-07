using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocuser : MonoBehaviour
{
    public string GeneratorsTag;
    public float FocusSpeed = 1;

    [Space, Header("Camera Sizes:")]
    public float unfocusedCameraSize;
    public float focusedCameraSize;


    private Camera myCamera;
    private GameManager gameManager;

    Vector2 FucusPosition;
    private bool IsFocused;
    private Vector3 unfocusedPosition;
    private float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        lerpSpeed = Time.deltaTime * FocusSpeed;
        unfocusedPosition = transform.position;
        myCamera = GetComponent<Camera>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(myCamera.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == GeneratorsTag)
            {
                gameManager.ActiveGenerator = hitInfo.transform.gameObject.GetComponent<AutoGenerator>();
                FucusPosition = hitInfo.transform.position;
                IsFocused = true;
            }
            else
            {
                IsFocused = false;
            }
        }

        Vector2 lerpedPos = Vector2.Lerp(transform.position, unfocusedPosition, lerpSpeed);
        float lerpCameraSize = Mathf.Lerp(myCamera.orthographicSize, unfocusedCameraSize, lerpSpeed);

        if (IsFocused)
        {
            lerpedPos = Vector2.Lerp(transform.position, FucusPosition, lerpSpeed);
            lerpCameraSize = Mathf.Lerp(myCamera.orthographicSize, focusedCameraSize, lerpSpeed);
        }

        transform.position = new Vector3(lerpedPos.x, lerpedPos.y, transform.position.z);
        myCamera.orthographicSize = lerpCameraSize;
    }

    public void UnFocus()
    {
        IsFocused = false;
    }
}
