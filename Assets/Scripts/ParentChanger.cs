using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChanger : MonoBehaviour
{
    bool m_isGround;
    public bool isGround
    {
        get { return m_isGround; }
        set { m_isGround = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isGround = true;
            transform.parent = collision.gameObject.transform;
        }
        else if (collision.gameObject.tag == "StageGimmick")
        {
            m_isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isGround = false;
            transform.parent = null;
        }
        else if (collision.gameObject.tag == "StageGimmick")
        {
            m_isGround = false;
        }
    }
}
