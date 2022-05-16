using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using TMPro;

public class ArduinoManager : MonoBehaviour
{
    [Header("Arduino Attribute")]
    [SerializeField] bool isConnected;
    [SerializeField] string portName;
    [SerializeField] int baudRate;
    [SerializeField] SerialPort data_stream;
    public float[] data;
    public string datasReceived;

    void Start()
    {
        SetupSourcePort();
    }

    void Update()
    {
        if (isConnected)
        {
            datasReceived = data_stream.ReadLine();

            //menerima data yang dikirimkan oleh Arduino
            string[] datas = data_stream.ReadLine().Split(',');

            //menyiapkan seluruh data yang akan digunakan
            data[0] = float.Parse(datas[0]);
            data[1] = float.Parse(datas[1]);
            data[2] = float.Parse(datas[2]);
            data[3] = float.Parse(datas[3]);
        }
    }

    public void SetupSourcePort()
    {
        if (isConnected)
        {
            data_stream.Close();
            isConnected = false;
        }

        //portName = sourcePortText.text;

        //deklarasi sumber port dan baud rate yang digunakan oleh Arduino
        data_stream = new SerialPort(portName, baudRate);

        //membuka port yang terhubung
        data_stream.Open();

        isConnected = true;
    }
}
