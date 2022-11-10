using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressTracker : MonoBehaviour
{
    public float winDelay;
    public GameObject confeti;
    public Animator endAnimator;
    public itemHolder[] items;
    public static int score;
    [HideInInspector]
    public itemHolder currentLevelItems;
    public static progressTracker instance;
    public static item currentItemDroped;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        currentLevelItems = items[Preferences.Instance.Levels];
        if (!controller.isFirstTime)
        {
            foreach (var item in UImanager.instance.thingsToEnableOnstart)
            {
                item.SetActive(true);
            }
        }
        UImanager.instance.spawnItemBtns();
        //foreach (var item in currentLevelItems.items)
        //{
        //    if (!item.item.isPaid)
        //    {
        //        totalTurns += item.itemCount;
        //    }
        //}
    }
    public void gameWin()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.completeSound);
        UImanager.instance.gameplayPanel.SetActive(false);
        Preferences.Instance.Score += 500;
        StartCoroutine(winCall());
    }
   
    private IEnumerator winCall()
    {
        
        yield return new WaitForSeconds(1.3f);
        confeti.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.Instance.playerAudioSrc,SoundManager.Instance.eheboy);
        endAnimator.Play("LevelEndAnimation");
        yield return new WaitForSeconds(winDelay);
        UImanager.instance.winPanel.SetActive(true);
        UImanager.instance.controles.SetActive(false);
        foreach (var item in UImanager.instance.buttons3D)
        {
            item.SetActive(false);
        }
        score = 0;
        reactionManager.reachedTarget = false;
    }

}
