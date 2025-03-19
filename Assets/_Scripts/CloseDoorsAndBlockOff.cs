using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorsAndBlockOff : MonoBehaviour
{
    [SerializeField]
    public GameObject doors;
    public GameObject invisibleWall;
    // Start is called before the first frame update
    
    void Start()
    {
        invisibleWall.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerExit(Collider coll)
    {
        Debug.Log("Triggered");
        //if (coll.gameObject.tag == "Player")
        //{
            invisibleWall.SetActive(true);
            Invoke("CloseDoors", 3.0f);
        //}
    }

    void CloseDoors()
    {
        doors.GetComponent<Animation>().Play("Close");
    }
}
