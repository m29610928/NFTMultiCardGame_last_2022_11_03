using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WalletLogin : MonoBehaviour
{
    public Toggle rememberMe;

    void Start()
    {
        
    }

    public async void OnLogin()
    {
        // get current timestamp
        int timestamp =
            (
            int
            )(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)))
                .TotalSeconds;

        // set expiration time
        int expirationTime = timestamp + 60;

        // set message
        string message = expirationTime.ToString();

        // sign message
        string signature = await Web3Wallet.Sign(message);

        // verify account
        string account = await EVM.Verify(message, signature);
        int now =
            (
            int
            )(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)))
                .TotalSeconds;

        // validate
        if (account.Length == 42 && expirationTime >= now)
        {
            // save account
            PlayerPrefs.SetString("Account", account);
            if (rememberMe.isOn)
                PlayerPrefs.SetInt("RememberMe", 1);
            else
                PlayerPrefs.SetInt("RememberMe", 0);
            print("Account: " + account);

            // serverConnect
            NetworkManager.Inst.Connect();
        } 
    }
}
