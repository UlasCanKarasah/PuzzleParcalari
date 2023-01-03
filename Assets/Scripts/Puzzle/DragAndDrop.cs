using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject selectedPiece;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.CompareTag("Puzzle"))
            {
                selectedPiece = hit.transform.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
        }
        if (selectedPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }
}










