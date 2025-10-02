using UnityEngine;

public class SelectingObject : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject objectToSelect; 
    [SerializeField] private Sprite objectImage;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
    }

    private void Select()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            objectToSelect = hit.collider.gameObject;
            Debug.Log("Selected: " + objectToSelect.name);
            
            //if (TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
            //{
            //    objectImage = sr.sprite;
            //    Debug.Log("Got sprite from: " + objectToSelect.name);
            //}
            
            SpriteRenderer sr = objectToSelect.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                objectImage = sr.sprite;
                
                Debug.Log("Got sprite from: " + objectToSelect.name);
            }
            
            Destroy(objectToSelect);
        }
    }
}

            // // چک کن ببین آیتم اسکریپت GameObjectLabelCategory داره
            // GameObjectLabelCategory item = picked.GetComponent<GameObjectLabelCategory>();
            // if (item != null)
            // {
            //     // category و label آیتم رو به Resolver کاراکتر بده
            //     characterHatResolver.SetCategoryAndLabel(item.category, item.label);
            //
            //     Debug.Log($"Applied {item.category}/{item.label} to character hat!");
            // }

