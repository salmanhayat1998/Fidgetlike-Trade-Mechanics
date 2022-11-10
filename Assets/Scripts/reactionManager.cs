using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reactionManager : MonoBehaviour
{
    public int reqScore = 40;
    public reaction[] reactions;

    public Image reactionImage;
    public Text reactionText;
    public static reactionManager instance;
    public Animator opponentHandAnimator;
    public Transform mysteryBoxObjSpawnPos;
    public static bool reachedTarget;
    public string[] reqCompleteMsgs;
    string animToPlay;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        UImanager.instance.progressBar.maxValue = reqScore;
        UImanager.instance.progressBar.minValue = -reqScore;
    }
    public void showReaction(int ind)
    {
        
            StartCoroutine(calling(ind));
        
    
    }
    private IEnumerator calling(int score)
    {
        yield return new WaitForSeconds(.5f);
        reaction temp = getReaction(score);
        UImanager.instance.reactionPanel.SetActive(true);
        UImanager.instance.reactionMsgBox.SetActive(true);
        if (progressTracker.currentItemDroped)
        {
            if (progressTracker.currentItemDroped.possibleReactionsMsgs.Length > 0)
            {
                if (score < reqScore)
                {
                    int rand = Random.Range(0, progressTracker.currentItemDroped.possibleReactionsMsgs.Length);
                    UImanager.instance.reactionMsgText.text = progressTracker.currentItemDroped.possibleReactionsMsgs[rand];
                }
                else
                {
                    UImanager.instance.reactionMsgText.text = reqCompleteMsgs[Random.Range(0, reqCompleteMsgs.Length)];
                }
            }
           reactionImage.sprite = progressTracker.currentItemDroped.reactionImage;
        }
            // reactionImage.sprite = temp.reactionImg;
        yield return new WaitForSeconds(2.3f);
        UImanager.instance.reactionPanel.SetActive(false);
        UImanager.instance.reactionMsgBox.SetActive(false);

        if (opponentHandAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        opponentHandAnimator.Play(animToPlay);
    }


    private reaction getReaction(int id)
    {
        //Debug.LogError("score " + id);  
        // add more
        if (id<reqScore)
        {
            int rand = Random.Range(0, 2);
            animToPlay = rand==1? "middlehand":"lefthand" ;
            reactionText.text = "More !";
            return reactions[1];  

        }
        // accepted 
        else if (id>= reqScore)
        {
            animToPlay =  "middlehand2";
            reachedTarget = true;
            reactionText.text = "Done !";
            return reactions[0];
           
        }
        // default case
        else
        {
            animToPlay = "middlehand2";
            return reactions[0]; 
        }
        
    }
    //private IEnumerator hidereaction()
    //{
       
    //}
}
[System.Serializable]
public class reaction
{
    public Sprite reactionImg;
    public string comments;

}