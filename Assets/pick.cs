using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class VRPickupActivator : XRBaseInteractable
{
    public GameObject picksandclock;
    public GameObject infoPanel;

    private Rigidbody rb;
    private CanvasGroup panelCanvasGroup;

    public float fadeDuration = 1f;  // Time in seconds to fade in

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();

       // if (picksandclock != null)
          //  picksandclock.SetActive(false);

        if (infoPanel != null)
        {
            panelCanvasGroup = infoPanel.GetComponent<CanvasGroup>();
            if (panelCanvasGroup != null)
            {
                panelCanvasGroup.alpha = 0f;
                panelCanvasGroup.interactable = false;
                panelCanvasGroup.blocksRaycasts = false;
            }
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        var interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null && interactor.attachTransform != null)
        {
            transform.SetParent(interactor.attachTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            transform.SetParent(args.interactorObject.transform);
        }

        if (rb != null)
            rb.isKinematic = true;

        if (panelCanvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInPanel());
        }
    }

    private IEnumerator FadeInPanel()
    {
        float elapsed = 0f;
        panelCanvasGroup.interactable = true;
        panelCanvasGroup.blocksRaycasts = true;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            panelCanvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        panelCanvasGroup.alpha = 1f;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        transform.SetParent(null);

        if (rb != null)
            rb.isKinematic = false;
    }
}
