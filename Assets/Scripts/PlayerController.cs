using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int pieceMask = 1 << 8;
    private int altarMask = 1 << 9;

    private bool carryingPiece = false;
    private Piece carriedPiece;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3, pieceMask | altarMask))
            {
                if (!carryingPiece && hit.collider.tag == "Piece")
                {
                    carryingPiece = true;
                    carriedPiece = hit.collider.gameObject.GetComponent<Piece>();
                    carriedPiece.PickUp();
                }
                else if (carryingPiece && hit.collider.tag == "Altar")
                {
                    carryingPiece = false;
                    carriedPiece.Place();
                }
            }
        }
    }
}
