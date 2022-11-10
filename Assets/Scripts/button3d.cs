using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button3d : MonoBehaviour
{
    public string animName;
    public float hitdelaytime = 0.2f;
    public bool isPlayerButton;
    public bool isAcceptButton;
    private ParticleSystem hitParticles;
    private Animator animator;

    void Start()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    public void onclick()
    {
        StartCoroutine(btnHit());
    }
    private IEnumerator btnHit()
    {
        yield return new WaitForSeconds(hitdelaytime);
        Handheld.Vibrate();
        animator.SetTrigger(animName);
        if(!hitParticles.isPlaying)
        hitParticles.Play();
        if (isPlayerButton)
        {
            if (reactionManager.reachedTarget && isAcceptButton)
            {

                progressTracker.instance.gameWin();
            }
            else
            {
                int rand = Random.Range(0, SoundManager.Instance.denyButtonVoiceOvers.Length);
                
                SoundManager.Instance.PlaySFX(SoundManager.Instance.opponentAudioSrc,SoundManager.Instance.denyButtonVoiceOvers[rand]);
                reactionManager.instance.showReaction(progressTracker.score);
            }
        }
    }
}
