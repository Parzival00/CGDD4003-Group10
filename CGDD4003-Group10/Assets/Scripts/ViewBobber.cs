using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBobber : MonoBehaviour
{
    [Header("View Bobbing Settings")]
    [SerializeField] float walkBobSpeed = 14f;
    [SerializeField] float bobAmount = 0.05f;
    [SerializeField] PlayerController pc;

    float defaultYpos = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultYpos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if( Mathf.Abs(pc.velocity.x) > 0.1f || Mathf.Abs(pc.velocity.z) > 0.1f)
        {
            //player is walking
            timer += Time.deltaTime * walkBobSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultYpos + Mathf.Sin(timer) * bobAmount, transform.localPosition.z);
        }
        else
        {
            //player is idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultYpos, Time.deltaTime * walkBobSpeed), transform.localPosition.z);
        }
    }
}
