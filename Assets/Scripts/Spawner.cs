using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _initialIntervall;
    private float _intervall;

    private void Start()
    {
        _intervall = _initialIntervall;
    }

    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_intervall > 0)
        {
            _intervall -= Time.deltaTime;
        }
        else
        {
            GameObject gameObject = this._objectPool.GetPooledObject();

            if (gameObject != null)
            {
                gameObject.transform.position = this.transform.position;
                gameObject.SetActive(true);

                _intervall = _initialIntervall;
            }
        }
    }
}
