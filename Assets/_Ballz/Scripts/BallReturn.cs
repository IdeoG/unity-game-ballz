using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallLauncher _ballLauncher;

    private void OnCollisionEnter2D(Collision2D other)
    {
        _ballLauncher.ReturnBall();
        other.collider.gameObject.SetActive(false);
    }

    private void Awake()
    {
        _ballLauncher = FindObjectOfType<BallLauncher>();
    }
}