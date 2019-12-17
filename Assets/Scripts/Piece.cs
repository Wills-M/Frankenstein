using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private Transform pieceHolder;

    private Transform parent;
    private GameManager gameManager;
    
    private void Start()
    {
        parent = transform.parent;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PickUp()
    {
        transform.SetParent(pieceHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Place()
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameManager.IncrementPoem();
    }
}
