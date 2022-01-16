using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float speed_;
    public float start_x_;

    // Start is called before the first frame update
    void Start()
    {
        speed_ = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(speed_ * Time.deltaTime, 0.0f, 0.0f);

        if (gameObject.transform.position.z >= 46.0f) {
            gameObject.transform.Translate(-105.0f, 0.0f, 0.0f);
        }
    }
}
