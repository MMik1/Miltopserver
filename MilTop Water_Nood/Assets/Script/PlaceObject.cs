using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public int temp;
    private void OnMouseDown()
    {
        Destroy(gameObject);

        Controller.Instance.WaterSpeed(true);
    }
}
