using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUnityChan : MonoBehaviour
{

    public Animator animator;
    float timer;
    float interval=10;
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
            interval = Random.Range(18, 23);
            int x = Random.Range(0, 3);
            if (x == 0)
            {
                animator.SetTrigger("wait01");
            }
            else if (x == 1) { 
                animator.SetTrigger("wait02");
            }
            else
            {
                animator.SetTrigger("relesh");
            }
        }
    }
}
