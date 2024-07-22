using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _minDistance = 0.5f;

    private List<Vector3> _points;
    private Camera _camera;
    private float _deep;

    private void Awake()
    {
        _camera = Camera.main;
        _deep = _camera!.GetComponent<Transform>().position.z;
        
        _points = new List<Vector3> { GetFirstLineRendererPoint() };
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _deep);
        var drawingPoint = _camera.ScreenToWorldPoint(mousePosition);

        if (_points.Count != 0 && !(Vector3.Distance(_points[^1], drawingPoint) >= _minDistance)) return;
        _points.Add(drawingPoint);
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, drawingPoint);
    }

    private Vector3 GetFirstLineRendererPoint()
    {
        var positions = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(positions);
        return positions[0];
    }
}