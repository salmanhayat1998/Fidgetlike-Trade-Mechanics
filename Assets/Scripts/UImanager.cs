using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    public GameObject mainPanel,gameplayPanel;
    public GameObject reactionPanel;
    public GameObject reactionMsgBox;
    public Text reactionMsgText;
    public GameObject controles;
    public GameObject winPanel;
    public Slider progressBar;
    public Transform itemParent;
    public Text scoreText;
    
    public GameObject itemPrefabUI;
    public GameObject tutHand;
    public GameObject[] buttons3D;
    public GameObject[] thingsToEnableOnstart;
    private void Awake()
    {
        if (instance == null)
            instance = this;

    }
    private void Start()
    {
        scoreText.text = Preferences.Instance.Score+"";
    }

    public void spawnItemBtns()
    {
        for (int i = 0; i < progressTracker.instance.currentLevelItems.items.Count; i++)
        {
            GameObject g = Instantiate(itemPrefabUI,itemParent);
            itemBtnUI temp = g.GetComponent<itemBtnUI>();
            item tempItem = progressTracker.instance.currentLevelItems.items[i].item;
            var active = progressTracker.instance.currentLevelItems.items[i].itemCount == 0 ? true : false;
            temp.lockIcon.SetActive(active);
           // temp.lockIcon.SetActive(tempItem.isPaid);
            g.GetComponent<EventTrigger>().enabled = !active;
            temp.itemName.text = progressTracker.instance.currentLevelItems.items[i].itemname;
            temp.itemCount = progressTracker.instance.currentLevelItems.items[i].itemCount;
            temp.count.text = temp.itemCount.ToString();
            if (tempItem.itemImg)
            {
                temp.icon.sprite = tempItem.itemImg;
            }
            
        }
    }
    public void OnPlay()
    {

        controller.startLerping = true;
        mainPanel.SetActive(false);
        //spawnItemBtns();
        Invoke("enablegameplay",2f);
    }
    void enablegameplay()
    {

        if (Preferences.Instance.isfirstTime == 0)
        {
            tutHand.SetActive(true);
            Preferences.Instance.isfirstTime = 1;
        }
        foreach (var item in thingsToEnableOnstart)
        {
            item.SetActive(true);
        }
        SoundManager.Instance.PlaySFX(SoundManager.Instance.playerAudioSrc, SoundManager.Instance.dedhSoSound);
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
    }
    public void nextLevel()
    {
        Preferences.Instance.Levels++;
        if(Preferences.Instance.Levels>= progressTracker.instance.items.Length)
        {
            Preferences.Instance.Levels = 0;
        }
        controller.isFirstTime = false;
        SceneManager.LoadScene(1);
       
    }
    public void buttonClickSOund()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.buttonClick);
    }
    public void home()
    {
        mainPanel.SetActive(true);
        gameplayPanel.SetActive(false);
    }

}
