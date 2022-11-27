using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERC721OwnerOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "polygon";
        string network = "testnet";
        string contract = "0xfF9FEFF81605711D21f9C02cB1C7cE6735a3d395";
        string tokenId = "13";

        string ownerOf = await ERC721.OwnerOf(chain, network, contract, tokenId);
        print(ownerOf);
    }
}
