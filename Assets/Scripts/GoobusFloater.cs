using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoobusFloater : MonoBehaviour
{
    public float timer = 1f;
    public bool dir = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangePosition(Vector2 position)
    {
        transform.position = position;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            if (!dir)
            {
                ChangePosition((Vector2)transform.position + new Vector2(0, 1));
                dir = true;

            } 
            else
            {
                ChangePosition((Vector2)transform.position +  new Vector2(0, -1));
                dir = false;
            }

            timer = 1f;
        }
        
    }
}
