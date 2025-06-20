using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EraSceneTransitionManager : MonoBehaviour
{
    [Header("Panels & Audio")]
    public GameObject eraSelectionPanel;
    public GameObject confirmationPanel;
    public AudioSource transitionAudio;

    [Header("Transition")]
    public Animator transitionAnimator; // Assign your Animator with crossfade
    public float waitBeforeFade = 5f;
    public float fadeDuration = 1f;

    private CanvasGroup confirmationCanvasGroup;
    private string sceneToLoad;

    private void Start()
    {
        if (confirmationPanel != null)
        {
            confirmationCanvasGroup = confirmationPanel.GetComponent<CanvasGroup>();
            confirmationPanel.SetActive(false);
        }
    }

    // Called from VR button OnClick
    public void OnEraSelected(string sceneName)
    {
        sceneToLoad = sceneName;
        StartCoroutine(HandleTransitionSequence());
    }

    private IEnumerator HandleTransitionSequence()
    {
        // Step 1: Hide Era Selection UI
        if (eraSelectionPanel != null)
            eraSelectionPanel.SetActive(false);

        // Step 2: Show Confirmation Panel
        if (confirmationPanel != null)
        {
            confirmationPanel.SetActive(true);
            if (confirmationCanvasGroup != null)
                confirmationCanvasGroup.alpha = 1f;
        }

        // Step 3: Play transition audio
        if (transitionAudio != null)
            transitionAudio.Play();

        // Step 4: Wait (let audio play, magic circle show, etc.)
        yield return new WaitForSeconds(waitBeforeFade);

        // Step 5: Trigger fade animation
        if (transitionAnimator != null)
            transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(fadeDuration);

        // Step 6: Load Scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
