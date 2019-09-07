using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 30f;
    public float borderThickness = 10f;
    public float scrollSpeed = 5000f;
    public float minY = 15f;
    public float maxY = 70f;
    public float cameraBondary = 70f;

    //private bool isMoving = true;
    private Vector3 cameraStandardPosition;
    private void Awake()
    {
        cameraStandardPosition = this.transform.position;
    }

    void Update()
    {
        keyController();

        scrollController();
    }

    void keyController()
    {
        if(doesItReachBoundary() == true)
        {
            return;
        }

        if(PlayerStatus.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - borderThickness)
        {
            this.transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= borderThickness)
        {
            this.transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= borderThickness)
        {
            this.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - borderThickness)
        {
            this.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            this.resetToStandardPosition();
        }
    }

    void scrollController()
    {
        float scroller = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = this.transform.position;
        pos.y -= scroller * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        this.transform.position = pos;
    }

    bool doesItReachBoundary()
    {
        if (this.transform.position.x >= cameraStandardPosition.x + cameraBondary)
        {
            Vector3 temp = this.transform.position;
            temp.x--;
            this.transform.position = temp;

            return true;
        }
        if (this.transform.position.x <= cameraStandardPosition.x - cameraBondary)
        {
            Vector3 temp = this.transform.position;
            temp.x++;
            this.transform.position = temp;

            return true;
        }
        if (this.transform.position.z >= cameraStandardPosition.z + cameraBondary)
        {
            Vector3 temp = this.transform.position;
            temp.z--;
            this.transform.position = temp;

            return true;
        }
        if (this.transform.position.z <= cameraStandardPosition.z - cameraBondary)
        {
            Vector3 temp = this.transform.position;
            temp.z++;
            this.transform.position = temp;

            return true;
        }

        return false;
    }

    void resetToStandardPosition()
    {
        this.transform.position = this.cameraStandardPosition;
    }
}
