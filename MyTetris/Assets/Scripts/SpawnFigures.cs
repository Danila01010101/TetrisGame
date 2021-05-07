using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{
    private int _figureIndex;
    private Vector3 _spawnPosition;
    private Color _color;
    private FigureController _figureController;
    [SerializeField]
    private GameObject[] _figures;
    void Start()
    {
        _figureController = GetComponent<FigureController>();
        SpawnFigure();
    }
    public void SpawnFigure()
    {
        _figureIndex = Random.Range(0, _figures.Length);
        _spawnPosition = new Vector3(6, 21, 10);
        GameObject _currentFigure = Instantiate(_figures[_figureIndex], _spawnPosition, _figures[_figureIndex].transform.rotation, gameObject.transform);
        _color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        foreach (Transform child in _currentFigure.transform)
        {
            child.GetComponent<Renderer>().material.SetColor("_Color", _color);
        }
        _figureController.MakeFigureControllable();
    }
}
