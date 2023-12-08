using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    private Vector2 m_Position = Vector2.zero;
    private static int DeathAtivator=0;
    public static bool killBoth = false;
    public bool killAll = false;
    
    void Start()
    {
        //set start position and set killBoth
        m_Position = transform.position;
        if (killAll)
        {
            killBoth = true;
        }
    }

    // Update is called once per frame
   
    void Update()
    {
        // If deatactivatore is more than 0 deatactivatore to minus 1 and call respawn 
        if (DeathAtivator>0)
        {
            DeathAtivator--;
            respawn();
        }
    }

    public void Die()
    {
        //If killBoth set DeathAtivator to 2 else set transform position to m_Position
        if (killBoth)
        {
        DeathAtivator=2;
        }
        else
        {
            transform.position = m_Position;

            if (gameObject.GetComponent<Climbing>() != null)
            {
                gameObject.GetComponent<Climbing>().stopclimp();
            }
        }

    }

    private void respawn()
    {
        //set transform position to m_Position
    transform.position = m_Position;
        if (gameObject.GetComponent<Climbing>()!=null)
        {
            gameObject.GetComponent<Climbing>().stopclimp();
        }
    }

    public void Setrespawn()
    {
        //set  m_Position to transform position
        m_Position = transform.position;
    }
}
