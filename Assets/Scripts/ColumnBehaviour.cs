using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour

{
    public float speed_;
    public float start_z_;

    // Awake is called several frames before the first update frame
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        speed_ = 5f;

        gameObject.transform.Translate(0.0f, Random.Range(-5.0f, 5.0f), start_z_);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0.0f, 0.0f, speed_ * Time.deltaTime);

        if (gameObject.transform.position.z >= 10.0f) {
            gameObject.transform.Translate(0.0f, -gameObject.transform.position.y - 5.0f, -gameObject.transform.position.z - 35.0f);
            gameObject.transform.Translate(0.0f, Random.Range(-5.0f, 5.0f), gameObject.transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bird") {
            speed_ = 0.0f;
            Destroy(collision.gameObject, 0);
            Debug.Log("Hit");
        }
    }
}
