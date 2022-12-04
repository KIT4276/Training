using UnityEngine;
using UnityEngine.UI;

public class AnimatGifs : MonoBehaviour
{
    private RawImage _im = null;
    private Renderer _rend = null;

    [SerializeField]
    private Texture2D[] _frames;
    [SerializeField]
    private float _framesPerSec = 10f;

    private void Awake()
    {
        _im = GetComponent<RawImage>();
        _rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        float index = Time.time * _framesPerSec;
        index %= _frames.Length;

        if (_rend != null)
        {
            _rend.material.mainTexture = _frames[(int)index];
        }
        else
            _im.texture = _frames[(int)index];
    }
}
