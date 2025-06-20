using System.Collections;
using UnityEngine;

public class EraMagicEffectHandler : MonoBehaviour
{
    [Header("Magic Effect Settings")]
    public GameObject magicEffect;
    public float floatAmplitude = 15f;
    public float floatSpeed = 2f;
    public float rotationSpeed = 45f;

    private Vector3 originalPos;
    private bool isEffectActive = false;

    public void TriggerMagicEffect()
    {
        if (magicEffect != null)
        {
            magicEffect.SetActive(true);
            originalPos = magicEffect.transform.position;
            isEffectActive = true;
            StartCoroutine(DisableEffectAfterDelay(45f));
        }
    }

    private void Update()
    {
        if (isEffectActive && magicEffect != null)
        {
            float newY = originalPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
            magicEffect.transform.position = new Vector3(originalPos.x, newY, originalPos.z);
            magicEffect.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    private IEnumerator DisableEffectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (magicEffect != null)
        {
            magicEffect.SetActive(false);
        }

        isEffectActive = false;
    }
}
