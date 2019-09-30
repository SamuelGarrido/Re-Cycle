using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    [SerializeField]
    private Transform trashPlace;

    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public static bool locked;

    void Start()
    {
        initialPosition = transform.position;
    }


    void Update()
    {
        if (Input.touchCount > 0 && !locked) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchpos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase) {

                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos)) {

                        deltaX = touchpos.x - transform.position.x;
                        deltaY = touchpos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchpos)) {

                        transform.position = new Vector2(touchpos.x - deltaX, touchpos.y - deltaY);

                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - trashPlace.position.x) <= 0.5f && Mathf.Abs(transform.position.y) <= 0.5f){
                        transform.position = new Vector2(trashPlace.position.x, trashPlace.position.y);
                        locked = true;
                    }
                    else {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);

                    }

                    break;
            }

        }        
    }
}
