





using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class NetworkListener_menu_PC_older : MonoBehaviour
{
    public int port = 5000;
    private TcpListener server;
    private Thread serverThread;
    private bool isRunning = false;

    void Awake()
    {
        // DontDestroyOnLoad(gameObject); // Keep this object alive across scenes

        // Prevent duplicate instances
        if (FindObjectsOfType<NetworkListener>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (!isRunning)
        {
            StartServer();
            string localIP = GetLocalIPAddress();
            Debug.Log($"🚀 Server is running on {localIP}:5000");


        }
    }

    void Update()
    {
        // Restart server if returning to standby_scene
        if (SceneManager.GetActiveScene().name == "standby_scene" && !isRunning)
        {
            Debug.Log("Restarting Server in Standby Scene...");
            StartServer();
        }
    }


void StartServer()
{
    if (server != null) {
        Debug.LogWarning("Server is already running!");
        return;
    }

    try
    {
        server = new TcpListener(IPAddress.Any, port);
        server.Start();
        isRunning = true;

        Debug.Log("Server started on port " + port);

        Thread serverThread = new Thread(() =>
        {
            while (isRunning)
            {
                if (server.Pending())
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string command = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Debug.Log("Received command: " + command);
                    ProcessCommand(command);

                    stream.Close();
                    client.Close();
                }
            }
        });
        serverThread.IsBackground = true;
        serverThread.Start();
    }
    catch (SocketException e)
    {
        Debug.LogError("Failed to start server: " + e.Message);
    }
}

// -------------------------------------------------------------------------------

void ProcessCommand(string command)
{
    if (command.StartsWith("change_scene:")){
        string sceneName = command.Split(':')[1];
        Debug.Log($"Preparing to change to scene: {sceneName}");

        // Stop the server before switching scenes
        // StopServer();

        UnityMainThreadDispatcher.Instance().Enqueue(() =>{
            Debug.Log($"Changing to scene: {sceneName}");
            SceneManager.LoadScene(sceneName);
        });
    }
    else
    {
        Debug.LogWarning("Unknown command: " + command);
    }
}
// -------------------------------------------------------------------------------


private string GetLocalIPAddress()
{
    string localIP = "Unknown";
    var host = Dns.GetHostEntry(Dns.GetHostName());

    foreach (var ip in host.AddressList)
    {
        if (ip.AddressFamily == AddressFamily.InterNetwork) // IPv4 only
        {
            localIP = ip.ToString();
            break;
        }
    }
    return localIP;
}
}
