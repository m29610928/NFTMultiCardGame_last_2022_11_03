using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERC721OwnerOfBatchExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "polygon";
        string network = "testnet";
        string contract = "0xD53f34B581446bC2602F121a5885CF1f4a0B2Cbc";
        string[] tokenIds = {"14", "15"};
        string multicall = ""; // optional: multicall contract https://github.com/makerdao/multicall
        string rpc = ""; // optional: custom rpc

        List<string> batchOwners = await ERC721.OwnerOfBatch(chain, network, contract, tokenIds, multicall, rpc);
        foreach (string owner in batchOwners)
        {
            print ("OwnerOfBatch: " + owner);
        } 
    }
}
