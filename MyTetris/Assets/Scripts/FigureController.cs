using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureController : MonoBehaviour
{
    private GameObject _controllableFigure;
    private FigureBehaviour _figureBehaviour;
    public void MakeFigureControllable()
    {
        _controllableFigure = gameObject.transform.GetChild(0).gameObject;
        _figureBehaviour = _controllableFigure.GetComponent<FigureBehaviour>();
    }
    public void RotateFigure()
    {
        if (!_figureBehaviour._canMoveRight)
            transform.Translate(Vector3.left, Space.World);
        else if(!_figureBehaviour._canMoveLeft)
            transform.Translate(Vector3.right, Space.World);
        _controllableFigure.transform.rotation *= Quaternion.Euler(0, 0, 90);
        foreach (Transform child in _controllableFigure.transform)
        {
            child.transform.rotation *= Quaternion.Euler(0, 0, -90);
        }
    }

    public void OnPullButtonDown()
    {
        _figureBehaviour.ChangeFallSpeed(0.05f);
    }

    public void OnPullButtonUp()
    {
        _figureBehaviour.ChangeFallSpeed(1f);
    }

    public void MoveFigureRight()
    {
        if (_figureBehaviour.GetFallingState() && (_figureBehaviour._canMoveRight))
            _controllableFigure.transform.Translate(Vector3.right, Space.World);
    }

    public void MoveFigureLeft()
    {
        if (_figureBehaviour.GetFallingState() && (_figureBehaviour._canMoveLeft))
            _controllableFigure.transform.Translate(Vector3.left, Space.World);
    }
}
