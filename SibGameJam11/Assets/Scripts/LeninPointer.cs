using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeninPointer : MonoBehaviour
{
    public RectTransform LeninHend;
    public float RotatingSpeed = 1;
    [Header("Angles")]
    public float MinAngle;
    public float MaxAngle;

    private bool isGrabbed = false;
    private Camera mainCam;
    private GameManager gameManager;
    private float lastAngle;

    public AudioSource[] Sounds;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (LeninHend.position - mainCam.transform.position).z;
        mousePos.x = mousePos.x - LeninHend.position.x;
        mousePos.y = mousePos.y - LeninHend.position.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 26;

        LeninHend.rotation = Quaternion.Lerp(
            LeninHend.rotation,
            Quaternion.Euler(0, 0, Mathf.Clamp(angle, MinAngle, MaxAngle)),
            Time.deltaTime * RotatingSpeed);

        if (gameManager.ActiveGenerator != null && lastAngle != angle)
        {
            gameManager.ActiveGenerator.Buff();
            
        }
        lastAngle = angle;
    }

    private void OnEnable()
    {
        int rnd = Random.Range(0, Sounds.Length);

        Sounds[rnd].Play();
    }

    private void OnDisable()
    {
        //foreach (var sound in Sounds)
        //{
        //    sound.Stop();
        //}
    }
}
