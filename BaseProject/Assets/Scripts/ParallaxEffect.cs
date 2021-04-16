using StarterKit.Base;
using UnityEngine;

public class ParallaxEffect : BaseObject
{
    [SerializeField]
    private Vector2 _parallaxEffectIntesity;
    private Vector3 _lastCamPos;

    private Transform _mainCamera;

    private Texture2D _texture2D;

    private float _textureUnitSizeX;

    private Sprite _sprite;

    public override void BaseObjectAwake()
    {
        _mainCamera = Camera.main.transform;
        _lastCamPos = _mainCamera.position;

        SetParallaxSprites();
    }

    public override void BaseObjectFixedUpdate()
    {
        Parallax();
        EndlessBackground();
    }

    private void Parallax()
    {
        Vector3 deltaMovement = _mainCamera.position - _lastCamPos;
        transform.position += new Vector3(deltaMovement.x * _parallaxEffectIntesity.x, deltaMovement.y * _parallaxEffectIntesity.y);
        _lastCamPos = _mainCamera.position;
    }

    private void SetParallaxSprites()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite; ;
        _texture2D = _sprite.texture;
        _textureUnitSizeX = _texture2D.width / _sprite.pixelsPerUnit;
    }

    private void EndlessBackground()
    {
        if(Mathf.Abs(_mainCamera.position.x - transform.position.x) > _textureUnitSizeX)
        {
            float offsetPos = (_mainCamera.transform.position.x - transform.position.x) % _textureUnitSizeX;

            transform.position = new Vector3(_mainCamera.transform.position.x + offsetPos, transform.position.y);
        }
    }
}
