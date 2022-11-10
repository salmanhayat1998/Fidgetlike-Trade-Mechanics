using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class controller : MonoBehaviour
{
    //public GameObject[] objects;
    //  public itemHolder myItems;
    public Transform cameraPos,LookAtObj;
    public Transform itemParent;
    public static bool isdraging;
    public float selectedObjHeight = 3f;
    public Animator hand;
    public button3d acceptButton,rejectButton;
    private Camera camera;
    private GameObject currentObj;
    private Rigidbody currentObjRB;
    public static itemBtnUI currentItemBtnClicked;
    public static int currentSelectedIndex;
    private Ray ray;
    public static bool startLerping;

    public static bool isFirstTime = true;

    private void Start()
    {
        currentItemBtnClicked = null;
        camera = Camera.main;
        if (!isFirstTime)
        {
            camera.transform.position = cameraPos.position;
            camera.transform.rotation = cameraPos.rotation;
            UImanager.instance.gameplayPanel.SetActive(true);
            UImanager.instance.mainPanel.SetActive(false);
        }
    }
    private void Update()
    {
        if (startLerping)
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, cameraPos.transform.position, Time.deltaTime*3);
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation,Quaternion.Euler(69,0,0),Time.deltaTime*3);
           // camera.transform.LookAt(LookAtObj);
        }
        ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("AcceptButton"))
                {
                    acceptButton.onclick();
                    hand.SetTrigger("accept");
                    // Debug.Log("AcceptButton");
                }
                if (hit.collider.tag.Equals("RejectButton"))
                {
                    rejectButton.onclick();
                    hand.SetTrigger("reject");
                    //Debug.Log("RejectButton");
                }

            }
        }
        if (Input.GetMouseButton(0))
        {
           

            if (currentObj)
            {
                isdraging = true;
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.WorldToScreenPoint(currentObj.transform.position).z);
                Vector3 worldPos = camera.ScreenToWorldPoint(pos);
                currentObj.transform.position = new Vector3(worldPos.x, selectedObjHeight, worldPos.z);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dropItem();

        }
    }

    public void itemClick(int num)
    {
        if (num >= progressTracker.instance.currentLevelItems.items.Count) return;
        if (UImanager.instance.tutHand.activeInHierarchy)
            UImanager.instance.tutHand.SetActive(false);
        currentSelectedIndex = num;
        currentObj = Instantiate(progressTracker.instance.currentLevelItems.items[num].item.obj, progressTracker.instance.currentLevelItems.items[num].item.obj.transform.position, progressTracker.instance.currentLevelItems.items[num].item.obj.transform.rotation);
        if (!currentObj.GetComponent<itemInstance>().isMysteryItem)
        {
            currentObj.transform.SetParent(itemParent);
        }
        currentObjRB = currentObj.GetComponentInChildren<Rigidbody>();
        progressTracker.currentItemDroped = progressTracker.instance.currentLevelItems.items[num].item;
    }

    public void dropItem()
    {
       
        isdraging = false;
        if (currentObjRB)
        {
           
            currentObjRB.isKinematic = false;
            currentObj = null;
           // progressTracker.currentItemDroped = null;
        }
    }
   
}
