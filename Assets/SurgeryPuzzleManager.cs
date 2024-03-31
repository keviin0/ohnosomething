using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SurgeryPuzzleManager : MonoBehaviour
{
    public GameObject[] afterImageRefs;
    public GameObject[] beforeImageRefs;
    private Vector2[] positionArray;
    private int numPieces;
    private Vector3 mouseOffset;
    Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();
    Dictionary<string, int> imageDict = new Dictionary<string, int>();
    private Transform draggingPiece = null;
    private int piecesCorrect = 0;
    private bool complete = false;
    InventoryManager inventoryManager = null;
    private List<ItemClass> inventory;

    private void SetRefPointsPosition()
    {
        numPieces = afterImageRefs.Length;
        positionArray = new Vector2[numPieces];
        for(int i = 0; i < numPieces; i++)
        {
            positionArray[i] = afterImageRefs[i].transform.position;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SetRefPointsPosition();
        SetRefSprite();
        AddtoDict();
        inventory = GameObject.Find("PlayerInventory").GetComponent<InventoryManager>().GetInventory();
        PopulateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("3DScene");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), LayerMask.GetMask("Puzzle"));
            if (hit && hit.tag == "PuzzlePiece")
            {
                draggingPiece = hit.transform;
                mouseOffset = draggingPiece.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (draggingPiece && Input.GetMouseButtonUp(0))
        {
            var pos = Camera.main.WorldToScreenPoint(draggingPiece.position);
            pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
            pos.y = Mathf.Clamp(pos.y, 0, Screen.height);
            draggingPiece.position = Camera.main.ScreenToWorldPoint(pos);
            SnapAndDisable();
            draggingPiece.GetComponent<SpriteRenderer>().sortingOrder = 2;
            draggingPiece = null;
        }

        if (draggingPiece)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition += mouseOffset;
            draggingPiece.position = newPosition;
            draggingPiece.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }

    private void SnapAndDisable()
    {
        Sprite img = draggingPiece.gameObject.GetComponent<SpriteRenderer>().sprite;
        Debug.Log(img.name);
        Vector2 pos = positionArray[imageDict[img.name]];
        if (Vector2.Distance(draggingPiece.position, pos) < 1)
        {
            beforeImageRefs[imageDict[img.name]].active = false;
            Vector3 pos3D = new Vector3(pos.x, pos.y, 0);
            draggingPiece.position = pos3D;
            draggingPiece.GetComponent<PolygonCollider2D>().enabled = false;
            piecesCorrect++;
            if(piecesCorrect == numPieces)
            {
                complete = true;
            }
        }
    }

    private void PopulateInventory()
    {
        GameObject inventoryBar = GameObject.Find("InventoryBar");
        foreach (ItemClass item in inventory)
        {
            Transform itemGameObject = inventoryBar.transform.Find(item.itemName);
            if (itemGameObject != null)
            {
                itemGameObject.gameObject.SetActive(true);
            }
        }
    }
}
