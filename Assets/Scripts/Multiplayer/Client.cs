using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;

public class Client : MonoBehaviour
{
    public static Client instance;
    public static int dataBufferSize = 4096;

    public string ip = "127.0.0.1";
    public int port = 26950;
    public int myId = 0;
    public TCP tcp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        tcp = new TCP();
    }

    public void ConnectedToServer()
    {
        tcp.Connect();
    }

    public class TCP
    {
        public TcpClient socket;
        private NetworkStream _stream;
        private byte[] _receiveBuffer;

        public void Connect()
        {
            socket = new TcpClient
            {
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize
            };

            _receiveBuffer = new byte[dataBufferSize];
            socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);
        }

        private void ConnectCallback(IAsyncResult __result)
        {
            socket.EndConnect(__result);

            if (!socket.Connected)
            {
                return;
            }

            _stream = socket.GetStream();
            _stream.BeginRead(_receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult __result)
        {
            try
            {
                int __byteLenght = _stream.EndRead(__result);
                if (__byteLenght <= 0)
                {
                    return;
                }

                byte[] __data = new byte[__byteLenght];
                Array.Copy(_receiveBuffer, __data, __byteLenght);
                _stream.BeginRead(_receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }
            catch (Exception __ex)
            {

                Console.WriteLine($"Error receiving TCP data {__ex}");
            }
        }
    }


}
