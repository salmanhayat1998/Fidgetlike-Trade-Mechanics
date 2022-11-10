
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : SingeltonBase<SoundManager>
{
 
    public AudioSource opponentAudioSrc;
    public AudioSource playerAudioSrc;
    public AudioSource otherSfxAudioSrc;
    public AudioSource MusicAudioSource;
    public AudioClip buttonClick;
    public AudioClip dedhSoSound;
    public AudioClip completeSound;
    public AudioClip eheboy;
    public AudioClip[] denyButtonVoiceOvers;
    public void PlayMusic(AudioClip audioClip)
    {
        MusicAudioSource.clip = audioClip;
        MusicAudioSource.Play();
    }
    public void PlaySFX(AudioClip audioClip)
    {
        otherSfxAudioSrc.PlayOneShot(audioClip);
    } 
    public void PlaySFX(AudioSource audioSource,AudioClip audioClip)
    {
        if(!audioSource.isPlaying)
        audioSource.PlayOneShot(audioClip);
    }

      /// <summary>
      /// play delayed single shot sound
      /// </summary>
      /// <param name="audioClip"></param>
      /// <param name="time"></param>
    public void PlaySFX(AudioClip audioClip,float time)
    {
        opponentAudioSrc.clip = audioClip;
        opponentAudioSrc.PlayDelayed(time);
    }

  
}
