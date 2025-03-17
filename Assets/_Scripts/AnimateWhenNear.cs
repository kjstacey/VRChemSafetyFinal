using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWhenNear : MonoBehaviour
{

    [SerializeField] public Animation anim;
    private float dist;
    public GameObject door;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, player.transform.position);
        if (dist < 5.0f)
        {
            anim["Open"].wrapMode = WrapMode.Once;
            anim.Play("Open");
        }
    }
}
