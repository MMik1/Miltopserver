using UnityEngine;

public class DropArea : MonoBehaviour, ISlot
{
    [SerializeField] private GameObject objectSpawn;
    public void OnDrop(Drag drag)
    {
        /*if (!drag.gameObject.CompareTag("Origin"))
        {
            Destroy(drag.gameObject);
            transform.position = drag.startDragPos;
            Debug.Log("test");
        }*/

            Instantiate(objectSpawn, transform.position, transform.rotation);
        
    }
}
