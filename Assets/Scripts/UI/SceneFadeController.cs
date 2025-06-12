using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
// Used for fade in and out
public class SceneFadeController : MonoBehaviour
{
    public static SceneFadeController instance;
    public Image fadeImage;

    public void FadeToBlackThenScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        // 渐黑
        yield return StartCoroutine(Fade(0f, 1f, 1f));

        // 场景切换
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(from, to, elapsed / duration);
            color.a = alpha;
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 确保最终透明度准确
        color.a = to;
        fadeImage.color = color;
    }
}