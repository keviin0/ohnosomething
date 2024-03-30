using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryPuzzleManager : MonoBehaviour
{
    public GameObject[] afterImageRefs;
    private Vector2[] positionArray;
    private int numPieces;
    private Vector3 mouseOffset;
    Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();
    Dictionary<string, int> imageDict = new Dictionary<string, int>();
    private Transform draggingPiece = null;

    private void SetRefPointsPosition()
    {
        numPieces = afterImageRefs.Length;
        positionArray = new Vector2[numPieces];
        for(int i = 0; i < numPieces; i++)
        {
            positionArray[i] = afterImageRefs[i].transform.position;
            Debug.Log(afterImageRefs[i].transform.position);
        }
    }
    private void SetRefSprite()
    {
        numPieces = afterImageRefs.Length;
        for (int i = 0; i < numPieces; i++)
        {
            Sprite temp = afterImageRefs[i].GetComponent<SpriteRenderer>().sprite;
            string spriteName = temp.name;
            if (!spriteDict.ContainsKey(spriteName))
            {
                spriteDict[spriteName] = temp;
            }
        }
    }

    private void AddtoDict()
    {
        for (int i = 0; i < numPieces; i++)
        {
            imageDict.Add(afterImageRefs[i].GetComponent<SpriteRenderer>().sprite.name, i);
        }
    }

    public Sprite GetSprite(string name)
    {
        return spriteDict[name];
    }

    void Start()
    {
        SetRefPointsPosition();
        SetRefSprite();
        AddtoDict();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), LayerMask.GetMask("Puzzle"));
            Debug.Log(hit.tag);
            if (hit && hit.tag == "PuzzlePiece")
            {
                draggingPiece = hit.transform;
                mouseOffset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += mouseOffset;
            draggingPiece.position = newPosition;
            draggingPiece.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
}
