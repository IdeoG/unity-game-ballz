using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    private uint _hitsRemaining = 10;

    private GameController _controller;
    private SpriteRenderer _spriteRenderer;
    private TextMeshPro _textMeshPro;

    private Color _startColor;
    private Color _endColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _controller = FindObjectOfType<GameController>();

        _startColor = Color.red;
        _endColor = Color.white;
        
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        _textMeshPro.SetText(_hitsRemaining.ToString());
        _spriteRenderer.color = Color.Lerp(_startColor, _endColor, _hitsRemaining / 10f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _controller.AddOneToScore();
        _hitsRemaining--;

        if (_hitsRemaining > 0)
        {
            UpdateVisualState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetHits(uint hits)
    {
        _hitsRemaining = hits;
        UpdateVisualState();
    }
}
