using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    public AudioClip pickup; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            GameObject.Find("manager").GetComponent<GameManager>().EarnScore();
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(this.gameObject);
        }
    }
}
