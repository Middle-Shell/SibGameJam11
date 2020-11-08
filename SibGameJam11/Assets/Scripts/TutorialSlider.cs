using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlider : MonoBehaviour
{
    public GameObject[] Slides;
    public int CurrentSlide = 0;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            CurrentSlide++;
            NextSlider();
        }
    }

    void NextSlider()
    {
        foreach (var slider in Slides)
        {
            slider.SetActive(false);
        }
        if (CurrentSlide < Slides.Length)
        {
            Slides[CurrentSlide].SetActive(true);
        }
    }
}
