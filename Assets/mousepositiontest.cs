using UnityEngine;
using System.Collections;

public class mousepositiontest : MonoBehaviour
{
    private float angle = 0;
    public Camera fpsCam;
    public clickable cobject;
    public clickable doorButtonL;
    public clickable doorButtonR;
    public clickable lightButtonL;
    public clickable lightButtonR;
    public GameObject doorL;
    public GameObject doorR;
    public GameObject doorLVisual;
    public GameObject doorRVisual;
    public GameObject doorLlight;
    public GameObject doorRlight;
    public bool doorLClosed = false;
    public bool doorRClosed = false;
    public bool doorLMoving = false;
    public bool doorRMoving = false;

    void Start()
    {
        doorLlight.gameObject.active = false;
        doorRlight.gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Is the Left Door Moving? " + doorLMoving);
        Debug.Log("Is the Left Door Closed? " + doorLClosed);
        Debug.Log("Is the Right Door Moving? " + doorRMoving);
        Debug.Log("Is the Right Door Closed? " + doorRClosed);
        SetAngle();
        CheckClickedObject();
        //Debug.Log(angle);
        //Rotation
        if (Input.mousePosition.x >= Screen.width * 0.99)
        {
            TurnRight();

        }
        if (Input.mousePosition.x <= Screen.width * 0.01)
        {
            TurnLeft();
        }

        //Clickable
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                clickable interactable = hit.collider.GetComponent<clickable>();
                if (interactable != null)
                {
                    SetClicked(interactable);
                }
            }
        }

    }
    //Setting the angle Variable
    void SetAngle()
    {
        if (transform.eulerAngles.y >= 180 && transform.eulerAngles.y <= 360)
        {
            angle = transform.eulerAngles.y - 360;
        }
        else
        {
            angle = transform.eulerAngles.y;
        }
    }
    //Turning Right
    void TurnRight()
    {
        if (60 >= angle)
        {
            Debug.Log("R");
            transform.Rotate(60 * (Vector3.up * Time.deltaTime));
        }

    }
    //Turning Left
    void TurnLeft()
    {
        if (-60 <= angle)
        {
            Debug.Log("L");
            transform.Rotate(-60 * (Vector3.up * Time.deltaTime));

        }
    }
    void SetClicked(clickable clicked)
    {
        cobject = clicked;
    }

    //cobject test

    void CheckClickedObject()
    {
        //Debug.Log(cobject);
        if (cobject == doorButtonL)
        {
            //Debug.Log("YES");
            if (doorLClosed == true)
            {
                doorLOpen();

            }
            else
            {
                doorLlight.gameObject.SetActive(true);
                doorLClose();
            }
        }
        if (cobject == doorButtonR)
        {
            //Debug.Log("YES");
            if (doorRClosed == true)
            {
                doorROpen();

            }
            else
            {
                doorRlight.gameObject.SetActive(true);
                doorRClose();
            }
        }
        if (cobject == lightButtonL)
        {
            if (doorLlight.activeSelf == true)
            {
                doorLlight.SetActive(false);
                cobject = null;
            }
            else
            {
                doorLlight.SetActive(true);
                cobject = null;
            }
        }
        if (cobject == lightButtonR)
        {
            if (doorRlight.activeSelf == true)
            {
                doorRlight.SetActive(false);
                cobject = null;
            }
            else
            {
                doorRlight.SetActive(true);
                cobject = null;
            }
        }
    }

    //Left Door Open
    void doorLOpen()
    {
        doorLMoving = true;
        if (doorL.transform.position.y < 7.5)
        {
            doorL.transform.position += 10 * Vector3.up * Time.deltaTime;
            doorLVisual.transform.position += 10 * Vector3.up * Time.deltaTime;
            if (doorL.transform.position.y >= 7.5)
            {
                doorLVisual.transform.position += -5 * Vector3.up * Time.deltaTime;
                doorL.transform.position += -5 * Vector3.up * Time.deltaTime;
                doorLlight.gameObject.SetActive(false);
                doorLMoving = false;
                doorLClosed = false;
                cobject = null;
            }
        }
        //Debug.Log(doorL.transform.position.y);
    }

    //Left Door Close
    void doorLClose()
    {
        doorLMoving = true;
        //Debug.Log(doorL.transform.position.y);
        if (doorL.transform.position.y > 2.5)
        {
            doorL.transform.position += -10 * Vector3.up * Time.deltaTime;
            doorLVisual.transform.position += -10 * Vector3.up * Time.deltaTime;
            if (doorL.transform.position.y <= 2.5)
            {
                doorLVisual.transform.position += 5 * Vector3.up * Time.deltaTime;
                doorL.transform.position += 5 * Vector3.up * Time.deltaTime;
                doorLMoving = false;
                doorLClosed = true;
                cobject = null;
            }
        }
    }
    //Right Door Open
    void doorROpen()
    {
        doorRMoving = true;
        if (doorR.transform.position.y < 7.5)
        {
            doorR.transform.position += 10 * Vector3.up * Time.deltaTime;
            doorRVisual.transform.position += 10 * Vector3.up * Time.deltaTime;
            if (doorR.transform.position.y >= 7.5)
            {
                doorRVisual.transform.position += -5 * Vector3.up * Time.deltaTime;
                doorR.transform.position += -5 * Vector3.up * Time.deltaTime;
                doorRlight.gameObject.SetActive(false);
                doorRMoving = false;
                doorRClosed = false;
                cobject = null;
            }
        }
        //Debug.Log(doorR.transform.position.y);
    }

    //Right Door Close
    void doorRClose()
    {
        doorRMoving = true;
        //Debug.Log(doorR.transform.position.y);
        if (doorR.transform.position.y > 2.5)
        {
            doorR.transform.position += -10 * Vector3.up * Time.deltaTime;
            doorRVisual.transform.position += -10 * Vector3.up * Time.deltaTime;
            if (doorR.transform.position.y <= 2.5)
            {
                doorRVisual.transform.position += 5 * Vector3.up * Time.deltaTime;
                doorR.transform.position += 5 * Vector3.up * Time.deltaTime;
                doorRMoving = false;
                doorRClosed = true;
                cobject = null;
            }
        }
    }
}