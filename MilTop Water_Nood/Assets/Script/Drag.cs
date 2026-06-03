using Unity.VisualScripting;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Collider2D col;
    public Vector3 startDragPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {        
        startDragPos = transform.position;
        transform.position = GetMousePos();
    }

    private void OnMouseUp()
    {

        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out ISlot slot) && hitCollider.gameObject.tag == "FieldSlot" && this.gameObject.tag == "Origin")
        {
            slot.OnDrop(this);
            Controller.Instance.WaterSpeed(false);
        }
        if (hitCollider != null && hitCollider.TryGetComponent(out ISlot slotP) && hitCollider.gameObject.tag == "PumpSlot" && this.gameObject.tag == "OriginPump")
        {
            slotP.OnDrop(this);
            Controller.Instance.WaterSpeed(false);
        }

        transform.position = startDragPos;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    private Vector3 GetMousePos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        return pos;
    }
}
