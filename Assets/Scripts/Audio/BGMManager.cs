using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    private AudioSource audioSource;

    [System.Serializable]
    public class BGMEntry
    {
        public string name;
        public AudioClip clip;
    }

    [Header("BGM lists")]
    public List<BGMEntry> bgmClips;

    private Dictionary<string, AudioClip> bgmDict;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        bgmDict = new Dictionary<string, AudioClip>();

        foreach (var entry in bgmClips)
        {
            if (!bgmDict.ContainsKey(entry.name))
                bgmDict.Add(entry.name, entry.clip);
        }

        SetVolume(0.2f);
    }

    public void PlayBGM(string name)
    {
        if (bgmDict.TryGetValue(name, out AudioClip clip))
        {
            if (audioSource.clip != clip)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("bgm not found");
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }
    
    public void PlayBGMWithFadeIn(string name, float fadeDuration = 3f, float targetVolume = 1f)
    {
        if (bgmDict.TryGetValue(name, out AudioClip clip))
        {
            if (audioSource.clip != clip)
            {
                audioSource.clip = clip;
                StartCoroutine(FadeIn(fadeDuration, targetVolume));
            }
        }
        else
        {
            Debug.LogWarning($"BGM [{name}] 未找到！");
        }
    }
    private IEnumerator FadeIn(float duration, float targetVolume)
    {
        audioSource.volume = 0f;
        audioSource.Play();

        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, timer / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }


}