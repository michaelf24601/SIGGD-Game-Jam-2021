using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public float getClipLength(string name)
    {
        foreach (Sound currentSound in sounds)
        {
            if (currentSound.name == name)
            {
                return currentSound.source.clip.length;
            }
        }
        Debug.Log("Unable to find sound: \"" + name + "\"");
        return -1f;
    }

    public void Play(string name)
    {
        Sound s = null;
        foreach (Sound currentSound in sounds)
        {
            if (currentSound.name == name)
            {
                s = currentSound;
                break;
            }
        }
        if (s == null)
        {
            Debug.Log("Unable to find sound: \"" + name + "\"");
            return;
        }
        s.source.Play();

    }

    public void Stop(string name)
    {
        Sound s = null;
        foreach (Sound currentSound in sounds)
        {
            if (currentSound.name == name)
            {
                s = currentSound;
                break;
            }
        }
        if (s == null)
        {
            Debug.Log("Unable to find sound: \"" + name + "\"");
            return;
        }
        s.source.Stop();
    }

}
