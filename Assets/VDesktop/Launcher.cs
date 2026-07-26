using UnityEngine;

public class Launcher : MonoBehaviour
{
    //Get the instatiation to work
    public GameObject window;
    public Transform canvasTransform;


    //Double click stuff
    public float doubleClickDelay;
    public float timeSinceLastClicked;

    bool wasClickedRecently = false;

    void FixedUpdate()
    {
        if (wasClickedRecently)
        {
            timeSinceLastClicked += Time.deltaTime;
        }

        if (timeSinceLastClicked >= doubleClickDelay)
        {
            wasClickedRecently = false;
            timeSinceLastClicked = 0;
        }
    }

    public void onClicked()
    {
        if (wasClickedRecently)
        {
            wasClickedRecently = false;
            timeSinceLastClicked = 0;
            Instantiate(window, canvasTransform, false);

        }
        else
        {
            wasClickedRecently = true;
        }
    }




}
