using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 4f;
    public GameObject gameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rb.velocity = move * Time.fixedDeltaTime * speed;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "obstacle") 
        {
            FindObjectOfType<GameOver>().GameEnd();
        }
    }
}
