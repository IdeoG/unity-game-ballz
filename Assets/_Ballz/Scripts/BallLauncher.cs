using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(LaunchPreview))]
public class BallLauncher : MonoBehaviour
{
    private void Awake()
    {
        _launchPreview = GetComponent<LaunchPreview>();
        _blockSpawner = FindObjectOfType<BlockSpawner>();

        CreateBall();
        CreateBall();
    }

    private void Update()
    {
        if (_ballsReady != _balls.Count) return;
        
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back * -10);

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }
    
    public void ReturnBall()
    {
        _ballsReady++;

        if (_ballsReady == _balls.Count)
        {
            _blockSpawner.SpawnRowOfBlocks();
            CreateBall();
        }
    }

    private void CreateBall()
    {
        var ball = Instantiate(_ballPrefab);
        ball.SetActive(false);
        
        _balls.Add(ball);
        _ballsReady++;
    }

    private async void LaunchBalls()
    {
        _ballsReady = 0;
        
        var direction = _endDragPosition - _startDragPosition;
        direction.Normalize();
        
        foreach (var ball in _balls)
        {
            ball.transform.position = transform.position;
            ball.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction * _ballInitialForce);

            await Task.Delay(100);
        }

    }

    private void EndDrag()
    {
        if ((_endDragPosition - _startDragPosition).magnitude < 0.2f ) return;
        
        LaunchBalls();
        _launchPreview.Clear();
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        _endDragPosition = worldPosition;

        var direction = _endDragPosition - _startDragPosition;
        _launchPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        _startDragPosition = worldPosition;
        _launchPreview.SetStartPoint(transform.position);
    }

    [Header("Ball prefab")] 
    [SerializeField] private float _ballInitialForce;
    [SerializeField] private GameObject _ballPrefab;

    private Vector3 _startDragPosition;
    private Vector3 _endDragPosition;
    private LaunchPreview _launchPreview;
    private BlockSpawner _blockSpawner;
    private List<GameObject> _balls = new List<GameObject>();
    private int _ballsReady;
    
}