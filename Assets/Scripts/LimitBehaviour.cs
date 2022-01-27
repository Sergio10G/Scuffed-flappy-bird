using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bird") {
            GameManager.Instance.RegisterHit();
        }
    }
}
