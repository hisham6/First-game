using UnityEngine;

public class BallM : MonoBehaviour
{
    [SerializeField] PaddleB Paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    //state 
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cashed component refrences
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - Paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToBaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
           myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToBaddle()
    {
        Vector2 paddlePos = new Vector2(Paddle.transform.position.x, Paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,randomFactor),
            Random.Range(0f,randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
        
    }
}
