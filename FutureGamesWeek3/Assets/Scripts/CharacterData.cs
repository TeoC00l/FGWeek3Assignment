//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character")]
public class CharacterData : ScriptableObject
{
    public float runSpeed = 10f;
    public float jumpForce = 10f;
}
