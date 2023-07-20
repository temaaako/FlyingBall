using UnityEngine;

public class Echo : MonoBehaviour
{
    [SerializeField] private float _fadeDuration = 1f;       
    [SerializeField] private float _shrinkDuration = 1f;     

    private SpriteRenderer _spriteRenderer;
    private Vector3 _originalScale;
    private float _elapsedTime;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalScale = transform.localScale;
        _elapsedTime = 0f;
    }

    private void LateUpdate()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime <= _fadeDuration)
        {
            float alpha = 1f - (_elapsedTime / _fadeDuration);
            Color newColor = _spriteRenderer.color;
            newColor.a = alpha;
            _spriteRenderer.color = newColor;
        }

        if (_elapsedTime <= _shrinkDuration)
        {
            float t = _elapsedTime / _shrinkDuration;
            Vector3 newScale = Vector3.Lerp(_originalScale, Vector3.zero, t);
            transform.localScale = newScale;
        }

        if (_elapsedTime > Mathf.Min(_fadeDuration, _shrinkDuration))
        {
            Destroy(gameObject);
        }
    }
}
