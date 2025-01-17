using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TestNetworkVariableSynchronization : NetworkBehaviour
{
    private NetworkVariable<List<int>> m_SomeValue = new NetworkVariable<List<int>>();
    private const int k_InitialValue = 1;

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            m_SomeValue.Value[0] = k_InitialValue;
            NetworkManager.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallback;
        }
        else
        {
            if (m_SomeValue.Value[0] != k_InitialValue)
            {
                Debug.LogWarning($"NetworkVariable was {m_SomeValue.Value[0]} upon being spawned" +
                    $" when it should have been {k_InitialValue}");
            }
            else
            {
                Debug.Log($"NetworkVariable is {m_SomeValue.Value} when spawned.");
            }
            m_SomeValue.OnValueChanged += OnSomeValueChanged;
        }
    }

    private void NetworkManager_OnClientConnectedCallback(ulong obj)
    {
        StartCoroutine(StartChangingNetworkVariable());
    }

    private void OnSomeValueChanged(List<int> previous, List<int> current)
    {
        Debug.Log($"Detected NetworkVariable Change: Previous: {previous} | Current: {current}");
    }

    private IEnumerator StartChangingNetworkVariable()
    {
        var count = 0;
        var updateFrequency = new WaitForSeconds(0.5f);
        while (count < 4)
        {
            for(int i = 0; i < m_SomeValue.Value.Count; i++)
            {
                m_SomeValue.Value[i] += m_SomeValue.Value[i];
            }
            
            yield return updateFrequency;
        }
        NetworkManager.OnClientConnectedCallback -= NetworkManager_OnClientConnectedCallback;
    }
}
