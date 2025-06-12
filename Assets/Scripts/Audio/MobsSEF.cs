using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MobsSEF : MonoBehaviour
{
    public enum SoundType
    {
        Attack,
        Death,
        Hit,
        Fireball,
        Move,
        Recover,
        FallDown,
        Teleport
    }

    [System.Serializable]
    public class SoundEntry
    {
        public SoundType type;
        public AudioClip clip;
    }

    [Header("Sound Effect")]
    public List<SoundEntry> sounds;

    private Dictionary<SoundType, AudioClip> soundDict;
    private AudioSource audioSource;
    private AudioSource loopAudioSource;

    [Range(0f, 1f)] public float volume = 1f;

    void Awake()
    {
        // short effect such as attack
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;

        // loop sound effect such as run
        loopAudioSource = gameObject.AddComponent<AudioSource>();
        loopAudioSource.loop = true;
        loopAudioSource.playOnAwake = false;
        loopAudioSource.spatialBlend = 1f;


        soundDict = new Dictionary<SoundType, AudioClip>();
        foreach (var entry in sounds)
        {
            if (!soundDict.ContainsKey(entry.type))
            {
                soundDict.Add(entry.type, entry.clip);
            }
        }
    }

    public void PlaySound(SoundType type)
    {
        if (soundDict.TryGetValue(type, out AudioClip clip) && clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning("no sound effect found");
        }
    }   
    // for sound like run and walk
    public void PlayLoopSound(SoundType type)
    {
        if (soundDict.TryGetValue(type, out AudioClip clip) && clip != null)
        {
            if (loopAudioSource.clip != clip || !loopAudioSource.isPlaying)
            {
                loopAudioSource.clip = clip;
                loopAudioSource.volume = volume;
                loopAudioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("no loop sound found");
        }
    }

    public void StopLoopSound()
    {
        if (loopAudioSource.isPlaying)
        {
            loopAudioSource.Stop();
            loopAudioSource.clip = null;
        }
    }
}
