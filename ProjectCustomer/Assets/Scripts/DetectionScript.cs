using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    [SerializeField] ShoppingList shopList;
    [SerializeField] PickUpScript pickUpScript;
    [SerializeField] string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (pickUpScript.heldObj == false)
        {
            itemName = other.gameObject.name;
            Debug.Log(itemName + " " + "Check1");
            shopList.ItemCheck(itemName);

            Debug.Log("item deleted");
            Destroy(other.transform.gameObject, 1);
        }

        else if (pickUpScript.heldObj == true)
        {
            Debug.Log("Item still held");
        }
    }
}
