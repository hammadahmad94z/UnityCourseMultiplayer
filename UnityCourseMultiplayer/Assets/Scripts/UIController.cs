using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [Tooltip("Referenz to the NetworkManager component")]
    public NetworkManager networkManager;
    [Tooltip("Refernz to the Inputfild for the IP-Address")]
    public InputField ipAddress;
    [Tooltip("Referenz to the Text for the local IP-Address")]
    public Text localIPAddress;


    public void Start()
    {
        // Get the local IP-Address and display it
        LocalIPAddress();
    }

    // Function for starting as a host
    public void StartHost()
    {
        // Set a portnumber
        networkManager.networkPort = 7777;
        networkManager.StartHost();
    }

    // Function for starting as a host
    public void StartClient()
    {
        // Set the IP-Address
        networkManager.networkAddress = ipAddress.text;
        // Set a portnumber
        networkManager.networkPort = 7777;
        networkManager.StartClient();
    }

    public void LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        localIPAddress.text = "Your local IP-Address is: " + localIP;
    }
}
