using System.Collections;
using UnityEngine;

public class CanvasFadeIn : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] _canvasGroups;
    [SerializeField] private float _fadeDuration = 1.5f;
    [SerializeField] private float _delay = 2f;
    
    private void Start()
    {
        foreach (var canvasGroup in _canvasGroups)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void FadeInCanvas(string canvasName)
    {
        if (canvasName == UIScreensNamesConst.GameOverCanvas)
        {
            StartCoroutine(FadeIn(_canvasGroups[0]));
        }

        if (canvasName == UIScreensNamesConst.SuccessCanvas)
        {
            StartCoroutine(FadeIn(_canvasGroups[1]));
        }
        
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        var elapsedTime = 0f;
        
        yield return new WaitForSeconds(_delay);

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / _fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}