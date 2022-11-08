using UnityEngine;

public class ObjectsInput : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        FindObjectUnderRay();
    }

    private void FindObjectUnderRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _layerMask))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
