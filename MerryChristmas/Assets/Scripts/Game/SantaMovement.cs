using UnityEngine;

public class SantaMovement : MonoBehaviour {
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private Vector2 startposition;
    [SerializeField] public float speed;
    [SerializeField] private bool moveLeft;

	
	// Update is called once per frame
	void Update () {
        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - 
            Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;

        
        if (moveLeft) {
            
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else {
           
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Destroy(collision.gameObject);
        }
    }


}
