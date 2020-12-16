using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D CoreRigid;
    [SerializeField] private bool isPressed = false;
    [SerializeField] public Rigidbody2D ShootRigid;
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] public GameObject CorePrefab;
    [SerializeField] public Transform CoreSpawnerPos;
    // Start is called before the first frame update
    private void Start()
    {
        CoreRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isPressed == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, ShootRigid.position) > maxDistance)
            {
                CoreRigid.position = ShootRigid.position + (mousePos - ShootRigid.position).normalized * maxDistance;

            }
            else
            {
                CoreRigid.position = mousePos;
            }
        }
    }
        private void OnMouseDown()
        {
            isPressed = true;
            CoreRigid.isKinematic = true;
        }

        private void OnMouseUp()
        {
            isPressed = false;
            CoreRigid.isKinematic = false;

            StartCoroutine(LetGo());
        }

        IEnumerator LetGo()
        {
            yield return new WaitForSeconds(0.1f);

            gameObject.GetComponent<SpringJoint2D>().enabled = false;
            this.enabled = false;

            yield return new WaitForSeconds(1);

            if (CorePrefab != null)
            {
            CorePrefab.transform.position = CoreSpawnerPos.position;
            }
        }
}
