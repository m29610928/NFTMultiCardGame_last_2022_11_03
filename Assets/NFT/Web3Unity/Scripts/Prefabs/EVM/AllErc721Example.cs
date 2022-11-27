using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class AllErc721Example : MonoBehaviour
{
    private class NFTs
    {
        public string contract { get; set; }

        public string tokenId { get; set; }

        public string uri { get; set; }

        public string balance { get; set; }
    }


    async void Start()
    {
        


        
        string chain = "polygon";
        string network = "testnet"; // mainnet ropsten kovan rinkeby goerli
        string account = "0x9592C551eDCf5b83bb80C656c5c121B3A9aC5B00";
        string contract = "0xD53f34B581446bC2602F121a5885CF1f4a0B2Cbc";
        int first = 500;
        int skip = 0;
        string response =
            await EVM.AllErc721(chain, network, account, contract, first, skip);
        try
        {
            NFTs[] erc721s = JsonConvert.DeserializeObject<NFTs[]>(response);
            for(int i=0;i<erc721s.Length;i++){
            print("===============");
            print(erc721s[i].contract);
            print(erc721s[i].tokenId);
            print(erc721s[i].uri);
            print(erc721s[i].balance);
            print("===============");
           
            }
        }
        catch
        {
            print("Error: " + response);
        }
    }
     
                
}

