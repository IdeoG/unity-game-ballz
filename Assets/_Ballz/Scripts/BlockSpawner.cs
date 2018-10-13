using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private float _distanceBetweenBlock = 0.7f;
    [SerializeField] private int _playWidth = 8;

    private List<Block> _blocksSpawned = new List<Block>();
    private int _rowsSpawned;

    private void OnEnable()
    {
        for (var i = 0; i < 1; i++)
        {
            SpawnRowOfBlocks();
        }
    }

    public void SpawnRowOfBlocks()
    {
        foreach (var block in _blocksSpawned)
        {
            if (block != null) block.transform.position += Vector3.down * _distanceBetweenBlock;
        }
        
        for (var i = 0; i < _playWidth; i++)
        {
            if (Random.Range(0, 100) <= 30)
            {
                var block = Instantiate(_blockPrefab, GetPosition(i), Quaternion.identity);
                var hits = Random.Range(1, 5) + _rowsSpawned;

                block.SetHits((uint) hits);
                
                _blocksSpawned.Add(block);
            }
        }

        _rowsSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        var position = transform.position;
        position += Vector3.right * i * _distanceBetweenBlock;
        return position;
    }
}
