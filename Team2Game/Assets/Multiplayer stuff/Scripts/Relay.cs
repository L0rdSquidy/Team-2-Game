using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using TMPro;

public class Relay : MonoBehaviour
{
    //public TextMeshProUGUI joinCodeTxt;
    private TMP_InputField joinCodeInput;
    string joincode;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private async void Start()
    {
        await UnityServices.InitializeAsync();

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        //joinCodeTxt = GameObject.Find("JoinCode").GetComponent<TextMeshProUGUI>();
        joinCodeInput = GameObject.Find("JoinInput").GetComponent<TMP_InputField>();
    }

    public async void StartRelay() 
    {
        joincode = await StartHost();
        //joinCodeTxt.text = joincode;
        NetworkManager.Singleton.GetComponent<MultiplayerManage>().SessionStart(joincode);
    }

    public async void JoinRelay() 
    {
        if(joinCodeInput.text == null) //joinCodeTxt?
        {
            return;
        }

        await StartClient(joinCodeInput.text);
    }

    private async Task<string> StartHost(int maxConnections = 2)//or 1? 
    {
        //try 
        //{
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);
        //}
        //catch    
        //{
          //  throw;
        //}

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        WhoHost.Instance.isHost = true;

        return NetworkManager.Singleton.StartHost() ? joinCode : null;
    }

    private async Task<bool> StartClient(string joinCode) 
    {
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));

        return !string.IsNullOrEmpty(joinCode) && NetworkManager.Singleton.StartClient();
    }



}
