using UnityEngine;
using UnityEngine.EventSystems;

public class WindowInputForwarder : MonoBehaviour, IPointerClickHandler
{
   public RectTransform rawImageRect; // the game image thingy
   public Camera embeddedCamera;

   public void OnPointerClick (PointerEventData e)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImageRect, e.position, e.pressEventCamera, out Vector2 localPoint);

       
        Rect rect = rawImageRect.rect;
        float u = (localPoint.x - rect.x) / rect.width;
        float v = (localPoint.y - rect.y) / rect.height;

        //clicked outside
        if (u < 0 || u > 1 || v < 0 || v > 1) return; 

        
        Ray ray = embeddedCamera.ViewportPointToRay(new Vector3(u, v, 0));

        
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            var target = hit.collider.GetComponent<Aimlabs_Target>();
            target?.RegisterHit();
        }


    }

   
}
