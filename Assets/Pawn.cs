using System;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : MonoBehaviour
{
    public Image objectImage;
    
    public Color selectColor;

    private Color _defaultColor;
    
    public float speedRotate = 20.0f;
    
    private RectTransform _pawnTransform;
    protected Controller Controller;

    private Action<float> _inputComponent;

    private float _direction;

    private void Start()
    {
        _pawnTransform = GetComponent<RectTransform>();
        Controller = GetComponent<Controller>();
        
        SetupPlayerInput();

        _defaultColor = objectImage.color;
    }

    protected virtual void SetupPlayerInput()
    {
        Controller.BindAxis(() => Input.GetAxisRaw("Horizontal"), Rotate);
    }

    private void FixedUpdate()
    {
        Rotation(_direction);
    }

    private void Rotate(float direction)
    {
        _direction = direction;
    }

    private void Rotation(float direction)
    {
        if (direction == 0.0f) return;
        
        Vector3 pawnVectorRotation = _pawnTransform.rotation.eulerAngles;
        pawnVectorRotation.z += direction * (-1.0f) * speedRotate * Time.fixedDeltaTime;
        _pawnTransform.rotation = Quaternion.Euler(pawnVectorRotation);
    }

    public void SetSelect(bool isSelect)
    {
        objectImage.color = isSelect ? selectColor : _defaultColor;
    }
}
