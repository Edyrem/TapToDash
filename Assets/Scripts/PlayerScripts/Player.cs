using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerSettings playerSettings;
    
    [SerializeField]
    private Human ball;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Image GameOverPanel;

    [SerializeField]
    private Camera mainCamera;

    private float _speed;
    private float _jumpForce;
    private float _cameraTurnAngle;
    private float _cameraTurnSpeed;
    private bool flipCamera;
    private bool gameOver;

    private Rigidbody _ballPhysics;
    private Vector3 _movingDirection;

    private readonly float fallLine = -1;

    public static int score;

    public static Player playerInstance = null;

    private Quaternion cameraAngle1;
    private Quaternion cameraAngle2;


    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetPlayerSettings(playerSettings);

        // Settings of camera rotation
        cameraAngle1 = mainCamera.transform.rotation;
        cameraAngle2 = Quaternion.Euler(cameraAngle1.eulerAngles.x, _cameraTurnAngle, cameraAngle1.eulerAngles.z);
        flipCamera = false;
        gameOver = false;

        _ballPhysics = ball.gameObject.GetComponent<Rigidbody>();
        _movingDirection = Vector3.forward;
        score = 0;
    }

    void Update()
    {
        transform.Translate(_movingDirection * Time.deltaTime * _speed);
        
        if (Input.GetMouseButtonDown(0) && AllMoves.nextMove.Count > 0)
        {
            RotatePlayer(AllMoves.nextMove.Dequeue());
            if(!gameOver) flipCamera = !flipCamera;
        }
        RotateCamera();

        if(ball.transform.position.y <= fallLine)
        {
            GameOver();
        }
        
        scoreText.text = "Score: " + score;
    }

    public void ResetPositionOnNewLevel()
    {

    }

    private void GameOver()
    {
        _speed = 0;
        gameOver = true;
        GameOverPanel.gameObject.SetActive(true);
        ball.GetComponent<Animator>().SetBool("IsFalling", true);

    }

    private void RotatePlayer(NextMove nextMove)
    {
        var playerRotation = ball.transform.rotation;
        switch (nextMove)
        {
            case NextMove.Left:
                {
                    _movingDirection = Vector3.left;
                    ball.transform.rotation = Quaternion.Euler(playerRotation.x, -90f, playerRotation.z);
                    break;
                }
            case NextMove.Right:
                {
                    _movingDirection = Vector3.right;
                    ball.transform.rotation = Quaternion.Euler(playerRotation.x, 90f, playerRotation.z);
                    break;
                }
            case NextMove.Forward:
                {
                    _movingDirection = Vector3.forward;
                    ball.transform.rotation = Quaternion.Euler(playerRotation.x, 0, playerRotation.z);
                    break;
                }
            case NextMove.Backward:
                {
                    _movingDirection = Vector3.back;
                    ball.transform.rotation = Quaternion.Euler(playerRotation.x, 180f, playerRotation.z);
                    break;
                }
            case NextMove.Up:
                {
                    _ballPhysics?.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                    ball.GetComponent<Animator>().SetTrigger("Jump");
                    break;
                }
            case NextMove.Null: break;
        }
    }

    private void RotateCamera()
    {
        var endPosition = flipCamera ? cameraAngle2 : cameraAngle1;
        mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, endPosition, Time.deltaTime * _cameraTurnSpeed);
    }

    public void SetPlayerSettings(PlayerSettings settings)
    {
        _speed = settings.speed;
        _jumpForce = settings.jumpForce;
        _cameraTurnAngle = settings.cameraTurnAngle;
        _cameraTurnSpeed = settings.cameraTurnSpeed;
    }   
    
}
