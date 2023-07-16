using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> _pooledGameObjects = new List<GameObject>();
    [SerializeField] private int _amountToPool = 0;
    [SerializeField] private GameObject _gameObjectPrefab;

    void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject gObject = Instantiate(_gameObjectPrefab);
            gObject.gameObject.SetActive(false);
            _pooledGameObjects.Add(gObject);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledGameObjects.Count; i++)
        {
            if (!_pooledGameObjects[i].gameObject.activeInHierarchy)
            {
                return _pooledGameObjects[i].gameObject;
            }
        }

        return null;
    }
}
