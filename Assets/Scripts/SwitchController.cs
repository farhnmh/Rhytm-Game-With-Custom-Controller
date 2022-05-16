using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [Header("Attachment")]
    [SerializeField] GameManager game;
    [SerializeField] ArduinoManager arduino;
    [SerializeField] GameObject redSwitch;
    [SerializeField] GameObject blueSwitch;
    [SerializeField] GameObject greenSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino.data[0] == 1)
            game.guitarPlucked = true;
        else
            game.guitarPlucked = false;

        if (arduino.data[1] == 1)
        {
            redSwitch.transform.position = new Vector3(redSwitch.transform.position.x, -0.5f, redSwitch.transform.position.z);
            game.redPushed = true;
        }
        else if (arduino.data[1] == 0)
        {
            redSwitch.transform.position = new Vector3(redSwitch.transform.position.x, 0.5f, redSwitch.transform.position.z);
            game.redPushed = false;
        }

        if (arduino.data[2] == 1)
        {
            blueSwitch.transform.position = new Vector3(blueSwitch.transform.position.x, -0.5f, blueSwitch.transform.position.z);
            game.bluePushed = true;
        }
        else if (arduino.data[2] == 0)
        {
            blueSwitch.transform.position = new Vector3(blueSwitch.transform.position.x, 0.5f, blueSwitch.transform.position.z);
            game.bluePushed = false;
        }

        if (arduino.data[3] == 1)
        {
            greenSwitch.transform.position = new Vector3(greenSwitch.transform.position.x, -0.5f, greenSwitch.transform.position.z);
            game.greenPushed = true;
        }
        else if (arduino.data[3] == 0)
        {
            greenSwitch.transform.position = new Vector3(greenSwitch.transform.position.x, 0.5f, greenSwitch.transform.position.z);
            game.greenPushed = false;
        }
    }
}
