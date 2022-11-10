using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class itemBtnUI : MonoBehaviour
{
    public Image icon;
    public GameObject lockIcon;
    public Text itemName,count;
    public int itemCount;
    //public bool isMysteryBox;
    private EventTrigger eventTrigger;

    private void OnEnable()
    {
        eventTrigger = GetComponent<EventTrigger>();
    }
    public void onclick()
    {
        controller.currentItemBtnClicked = this;
        FindObjectOfType<controller>().itemClick(transform.GetSiblingIndex());
    }

    private void Update()
    {
        if(count.text.Equals("0") && !lockIcon.activeInHierarchy)
        {
            lockIcon.SetActive(true);
            eventTrigger.enabled = false;
        }
    }

    public void purchaseItem()
    {
        if (Preferences.Instance.Score >= 100)
        {
            lockIcon.SetActive(false);
            eventTrigger.enabled = true;
            itemCount += 3;
            Preferences.Instance.Score -= 100;
            UImanager.instance.scoreText.text = Preferences.Instance.Score.ToString();
            count.text = itemCount.ToString();
        }
    }
}
