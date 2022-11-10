using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemInstance : MonoBehaviour
{
    public item item;
    public GameObject dropParticle;
    public AudioClip dropSound;
    private AudioSource audioSource;
    [HideInInspector]public int count;
    public bool isMysteryItem;
    private bool collided;
    private Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        if (animator)
            animator.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag.Equals("Desk") || collision.gameObject.tag.Equals("item")) && !collided)
        {
            collided = true;
            if (audioSource)
            {
                audioSource.PlayOneShot(dropSound);
            }

            GameObject g = Instantiate(dropParticle, transform.position, Quaternion.identity);
            Destroy(g, 0.5f);
            if (controller.currentItemBtnClicked)
            {
                controller.currentItemBtnClicked.itemCount--;
                controller.currentItemBtnClicked.count.text = controller.currentItemBtnClicked.itemCount.ToString();
            }
            if (!isMysteryItem)
            {
                if (item.possibleReactionsSounds.Length > 0)
                {
                    int ind = Random.Range(0, item.possibleReactionsSounds.Length);
                    SoundManager.Instance.opponentAudioSrc.PlayOneShot(item.possibleReactionsSounds[ind]);
                }
                progressTracker.score += item.value;
                UImanager.instance.progressBar.value = progressTracker.score;
                reactionManager.instance.showReaction(progressTracker.score);
            }
            else
            {
                StartCoroutine(showMystery());
            }
            controller.currentItemBtnClicked = null;
        }
      
    }
    private IEnumerator showMystery()
    {
        yield return new WaitForSeconds(1f);
        animator.enabled = true;
        foreach (var item1 in FindObjectsOfType<EventTrigger>())
        {
            item1.enabled = false;
        }
        animator.SetTrigger("open");
        yield return new WaitForSeconds(0.65f);
        MysteryItem item = progressTracker.currentItemDroped as MysteryItem;
        GameObject temp = item.insideObjects[Random.Range(0, item.insideObjects.Length)];
        GameObject g = Instantiate(temp, reactionManager.instance.mysteryBoxObjSpawnPos.position, Quaternion.identity);
        g.GetComponent<Rigidbody>().isKinematic = false;
        progressTracker.currentItemDroped = temp.GetComponent<itemInstance>().item;
        Instantiate(item.blastparticle, transform.position, item.blastparticle.transform.rotation);
        foreach (var item1 in FindObjectsOfType<itemBtnUI>())
        {
            if (item1.itemCount > 0)
            {
                item1.GetComponent<EventTrigger>().enabled = true;
            }
        }
        Destroy(gameObject);
      

    }
    //private int progressValue()
    //{
    //    if (progressTracker.turnCounter <= progressTracker.instance.totalTurns)
    //    {
    //        if (progressTracker.turnCounter == priority)
    //        {
    //            Debug.LogError("right");
    //            return scoreWeightOrg;
    //        }
    //        else
    //        {
    //            Debug.LogError("wrong");
    //            return scoreWeightDecreased;
    //        }
    //    }
    //    else
    //    {
    //        return scoreWeightOrg;
    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("centerLine"))
        {
            FindObjectOfType<controller>().dropItem();
         
        }
        if (other.gameObject.tag.Equals("outside") && !controller.isdraging)
        {
            Destroy(gameObject);
        }
    }
}
