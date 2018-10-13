using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchPreview : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3 _dragStartPoint;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        _dragStartPoint = worldPoint;
        _lineRenderer.SetPosition(0, _dragStartPoint);
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        var pointOffset = worldPoint - _dragStartPoint;
        var endPoint = pointOffset + transform.position;
        
        _lineRenderer.SetPosition(1, endPoint);
    }

    public void Clear()
    {
        _lineRenderer.SetPosition(1, _dragStartPoint);
    }
}
