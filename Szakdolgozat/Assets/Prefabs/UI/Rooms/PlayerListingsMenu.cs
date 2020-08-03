using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing playerListing;

    [SerializeField]
    private Transform content;

    private List<PlayerListing> listings = new List<PlayerListing>();

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerListing listing = Instantiate(playerListing, content);
        if (listing != null)
        {
            listing.SetPlayerInfo(newPlayer);
            listings.Add(listing);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }
    } 
}
