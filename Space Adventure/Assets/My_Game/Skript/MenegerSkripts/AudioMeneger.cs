using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioMeneger : MonoBehaviour
{
    #region TypeScene
    public TypeScene typescene;
    public enum TypeScene
    {
        OtherLvl,
        Menu,
        None
    }
    #endregion

    public Sound[] sounds;

    #region Name Sound Variabls
    [SerializeField] private string _nameMenuMusic;
    [SerializeField] private string _nameBackGroundMusic;
    #endregion

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        if (typescene == TypeScene.Menu)
        {
         //   PlayClip(_nameMenuMusic);
        }
        else if (typescene == TypeScene.OtherLvl)
        {
        //    PlayClip(_nameBackGroundMusic);
        }
    }

    public void PlayClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void StopClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        s.source.Stop();
    }
}
