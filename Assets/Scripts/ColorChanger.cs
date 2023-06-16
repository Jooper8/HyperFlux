using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private float hueShiftSpeed = 60f;
    [SerializeField] private float delayDuration = 2f;

    private bool changingColor = false;
    private ColorGrading colorGrading;
    private float initialHue = -30f;
    private float targetHue = 30f;

    private void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
        colorGrading.hueShift.value = initialHue;
        StartChangingColor();
    }
    public void StartChangingColor()
    {
        if (!changingColor)
        {
            StartCoroutine(ChangeColor());
        }
    }
    public void StopChangingColor()
    {
        if (changingColor)
        {
            StopCoroutine(ChangeColor());
            changingColor = false;
        }
    }
    private IEnumerator ChangeColor()
    {
        changingColor = true;
        float elapsedTime = 0f;
        float currentHue = initialHue;
        bool transitioningToTarget = true;

        while (true)
        {
            float hueStep = hueShiftSpeed * Time.deltaTime;
            if (transitioningToTarget)
            {
                currentHue += hueStep;
                if (currentHue >= targetHue)
                {
                    currentHue = targetHue;
                    transitioningToTarget = false;
                    yield return new WaitForSeconds(delayDuration);
                }
            }
            else
            {
                currentHue -= hueStep;
                if (currentHue <= initialHue)
                {
                    currentHue = initialHue;
                    transitioningToTarget = true;
                    yield return new WaitForSeconds(delayDuration);
                }
            }
            colorGrading.hueShift.value = currentHue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
