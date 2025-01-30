


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class NetworkListener : MonoBehaviour
{
    public int port = 5000;
    private TcpListener server;
    private bool isRunning = false;

    void Awake(){
        DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        if (FindObjectsOfType<NetworkListener>().Length > 1){
            Destroy(gameObject); // Prevent duplicate instances
            return;
            }
        }


    void Start(){
        // SceneManager.LoadScene("menu_user", LoadSceneMode.Single);
        if (!isRunning){
            StartServer();
            }
        }

    void StartServer()
    {
        server = new TcpListener(IPAddress.Any, port);
        server.Start();
        isRunning = true;

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

    void ProcessCommand(string command)
    {
        if (command.StartsWith("change_scene:")){
            string sceneName = command.Split(':')[1];
            Debug.Log($"Preparing to change to scene: {sceneName}");
            // Use Unity's main thread execution
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

    void OnApplicationQuit()
    {
    isRunning = false;
    if (server != null)
    {
        server.Stop(); // Ensure that the server is properly stopped
    }
    }


}



/* using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;  // For IOException
using System;  // For Exception

public class NetworkListener : MonoBehaviour
{
    public int port = 5000;
    private TcpListener server;
    private bool isRunning = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        if (FindObjectsOfType<NetworkListener>().Length > 1)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }
    }

    void Start()
    {
        // Start server if not already running
        if (!isRunning)
        {
            StartServer();
        }
    }

    void Update()
    {
        // Ensure server continues running across scene changes, especially after transitioning back to standby
        if (SceneManager.GetActiveScene().name == "standby_scene" && !isRunning)
        {
            StartServer();
        }
    }

    void StartServer()
    {
        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            isRunning = true;

            // Start a background thread to handle incoming commands
            Thread serverThread = new Thread(() =>
            {
                while (isRunning)
                {
                    try
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
                    catch (SocketException e)
                    {
                        Debug.LogError($"SocketException: {e.Message}");
                        // Try to restart the server if the connection is lost
                        RestartServer();
                    }
                    catch (IOException e)  // <-- Catching IOException
                    {
                        Debug.LogError($"IOException: {e.Message}");
                        // Try to restart the server if the connection is lost
                        RestartServer();
                    }
                    catch (Exception e)  // <-- Catching general Exception
                    {
                        Debug.LogError($"Exception: {e.Message}");
                    }
                }
            });

            serverThread.IsBackground = true;
            serverThread.Start();
        }
        catch (SocketException e)
        {
            Debug.LogError($"Error starting server: {e.Message}");
        }
    }

    void RestartServer()
    {
        // Gracefully stop the server and restart it to avoid connections being stuck
        if (server != null)
        {
            server.Stop();
            server = null;
        }

        // Start the server again
        StartServer();
    }

    void ProcessCommand(string command)
    {
        if (command.StartsWith("change_scene:"))
        {
            string sceneName = command.Split(':')[1];
            Debug.Log($"Preparing to change to scene: {sceneName}");

            // Enqueue scene change on main thread to avoid Unity thread errors
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                Debug.Log($"Changing to scene: {sceneName}");
                SceneManager.LoadScene(sceneName);
            });
        }
        else
        {
            Debug.LogWarning("Unknown command: " + command);
        }
    }

    void OnApplicationQuit()
    {
        isRunning = false;
        if (server != null)
        {
            server.Stop(); // Ensure the server is properly stopped
        }
    }
} */










