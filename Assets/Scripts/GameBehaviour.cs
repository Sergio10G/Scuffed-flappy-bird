using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private List<GameObject> columns_;
    private GameObject bird_;
    private void Awake()
    {
        foreach (Transform child in transform) {
            if (child.tag == "Column") {
                columns_.Add(child.gameObject);
            }
            else if (child.tag == "Bird") {
                bird_ = child.gameObject;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopColumns() {
        if (columns_.Count == 0) {
            return;
        }

    }
}
