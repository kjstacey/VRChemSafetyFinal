using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorsAndBlockOff : MonoBehaviour
{
    //public CapsuleCollider capsuleCollider;
    public bool hasBeenClosed = false;

    [SerializeField]
    public GameObject doors;
    public GameObject invisibleWall;
    public GameObject VRRig;
    // Start is called before the first frame update
    
    void Start()
    {
        invisibleWall.SetActive(false);
        //capsuleCollider = VRRig.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    public void CloseDoorBlockOff()
    {
        if (!hasBeenClosed) {
            Debug.Log("Triggered");
            //if (coll == capsuleCollider)
            //{
            hasBeenClosed = true;
            invisibleWall.SetActive(true);
            Invoke("CloseDoors", 2.0f);
        }
    }

    void CloseDoors()
    {
        doors.GetComponent<Animation>().Play("Close");
    }
}
