using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public float waitTime = -2f;

    public Image endTable;
    public Image[] stars;


    void Start()
    {
        endTable.gameObject.SetActive(false);
        for(int i=0; i<stars.Length; i++)
        {
            stars[i].gameObject.SetActive(false);  
        }
    }

    public void Update()
    {
        waitTime -= Time.deltaTime;

        if(waitTime <= 0 && waitTime >=-1)
        {
            if(PointCounter.index >0)
            {
                for(int i=0; i<PointCounter.index; i++)
                {
                    stars[i].gameObject.SetActive(true);  
                }
                
                endTable.gameObject.SetActive(true);
            }
            else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
            Destroy(this);
        }
            
        
    }
}
