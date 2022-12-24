using Units.Bed.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class ObjectsInput : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
    
        private Camera _camera;

        private int _fingerID = -1;

        private void Awake()
        {
#if(!UNITY_EDITOR)
        {
            _fingerID = 0;
        }
#endif
        }

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
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, _layerMask))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable) && !EventSystem.current.IsPointerOverGameObject(_fingerID))
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
