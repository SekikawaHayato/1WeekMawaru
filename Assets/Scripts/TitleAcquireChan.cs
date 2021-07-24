using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAcquireChan : MonoBehaviour
{

    public Animator animator;
    float timer;
    float interval=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0;
            interval = Random.Range(20, 25);
            int x = Random.Range(0, 3);
            if (x == 0)
            {
                animator.SetTrigger("happy");
            }
            else if (x == 1) { 
                animator.SetTrigger("idle2");
            }
            else
            {
                animator.SetTrigger("sad");
            }
        }
    }
}
