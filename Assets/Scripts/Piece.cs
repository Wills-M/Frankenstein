using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private Transform pieceHolder;

    [SerializeField]
    private Shader skeletonUnlitShader;

    [SerializeField]
    private Shader skeletonUnlitZAlwaysShader;

    private Transform parent;
    private GameManager gameManager;
    private Material material;

    private bool placed = false;
    
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        parent = transform.parent;
        gameManager = FindObjectOfType<GameManager>();
    }

    public bool PickUp()
    {
        material.shader = skeletonUnlitZAlwaysShader;

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
        material.shader = skeletonUnlitShader;
        placed = true;
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameManager.IncrementPoem();
    }
}
