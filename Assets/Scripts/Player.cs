using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 1;
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image GameOverPanel;

    private Rigidbody _ballPhysics;
    private Vector3 _movingDirection;

    public static int score;

    public static Player playerInstance = null;

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

    // Start is called before the first frame update
    void Start()
    {
        AllMoves.nextMove = new Queue<NextMove>();
        _ballPhysics = ball.gameObject.GetComponent<Rigidbody>();
        _movingDirection = Vector3.forward;
        LevelManager.position = Vector3.zero;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_movingDirection * Time.deltaTime * _speed);
        if (Input.GetMouseButtonDown(0) && AllMoves.nextMove.Count > 0)
        {
            switch (AllMoves.nextMove.Dequeue())
            {
                case NextMove.Left: _movingDirection = Vector3.left; break;
                case NextMove.Right: _movingDirection = Vector3.right; break;
                case NextMove.Forward: _movingDirection = Vector3.forward; break;
                case NextMove.Backward: _movingDirection = Vector3.back; break;
                case NextMove.Up: _ballPhysics?.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); break;
                case NextMove.Null: Debug.Log("NULL"); break;
            }
        }
        if(ball.transform.position.y <= -1f)
        {
            GameOver();
        }
        scoreText.text = "Score: " + score;
    }

    private void GameOver()
    {
        _speed = 0;
        GameOverPanel.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }

}
