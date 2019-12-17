using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private Transform pieceHolder;

    private Transform parent;
    private GameManager gameManager;

    private bool placed = false;
    
    private void Start()
    {
        parent = transform.parent;
        gameManager = FindObjectOfType<GameManager>();
    }

    public bool PickUp()
    {
        if (!placed)
        {
            transform.SetParent(pieceHolder);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Place()
    {
        placed = true;
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameManager.IncrementPoem();
    }
}
