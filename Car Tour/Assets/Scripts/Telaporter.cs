using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telaporter : MonoBehaviour
{
    public string m_Trigger;
    private bool m_HeldTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(m_Trigger) > 0.5f && !m_HeldTrigger)
        {
            m_HeldTrigger = true;
        }
        if (Input.GetAxis(m_Trigger) < 0.5f && m_HeldTrigger)
        {
            m_HeldTrigger = false;
        }
    }
}
