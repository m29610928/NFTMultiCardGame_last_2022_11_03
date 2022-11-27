using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC721BalanceOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "polygon";
        string network = "testnet";
        string contract = "0xD53f34B581446bC2602F121a5885CF1f4a0B2Cbc";
        string account = "0x9592C551eDCf5b83bb80C656c5c121B3A9aC5B00";

        int balance = await ERC721.BalanceOf(chain, network, contract, account);
        print(balance);
    }
}
