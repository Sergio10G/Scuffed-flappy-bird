using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour
{
    private GameBehaviour parent_script_;

    public float speed_;
    public float start_z_;

    // Awake is called several frames before the first update frame
    void Awake()
    {
        speed_ = 5.0f;
        GameObject game = GameObject.Find("Game");
        parent_script_ = game.GetComponent<GameBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeY();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0.0f, 0.0f, speed_ * Time.deltaTime);

        if (gameObject.transform.position.z >= 10.0f) {
            gameObject.transform.Translate(0.0f, -gameObject.transform.position.y + 1.0f, -40.0f);
            RandomizeY();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bird") {
            //parent_script_.RegisterHit();
            Debug.Log("Hit");
        }
    }

    public void RandomizeY() {
        gameObject.transform.Translate(0.0f, -6f, 0.0f);
    }
}
