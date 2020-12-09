# LoLAccManager

![This is the README's header image :)](https://i.imgur.com/RXx32Yh.png)

LoLAccManager is an account storing utility program for people who play on multiple League of Legends accounts with different ranks. The main purpose of this program is to eliminate the need to login to all your accounts one by one until you find one that is in the ranked bracket you are looking to play in. With one glance of an eye you can see all your account ranks and copy the login to your clipboard to get ready to play immediately. 

# About the source
![This asset is copyrighted to Riot Games Inc. However: Riot Games allows use of their League of Legends intellectual property when meeting the conditions lined in their Legal Jibber-Jabber policy.](https://i.imgur.com/NE3FI2a.png)

Unfortunately the source code if this project may look a little "off". And this has a reason. 
I lost the source code of LoLAccManager because I changed PC and forgot to back-up all my Visual Studio Projects before doing so.

I decompiled the .exe using ILSpy which created a pretty readable project nonetheless.

## How does it work
You start off by adding an account by pressing the "Add account" button.
Which will present you the following form: 
![Add Account form](https://i.imgur.com/p82o4VP.png)
After adding your account the program stores it in a .json file and uses the Riot Games API to request the current rank and LP of the account (https://developer.riotgames.com/apis)

It will instantly show your accounts ingame name and the rank + points in that rank.
![Main form](https://i.imgur.com/HqkLN90.png)


To run this program you will need a valid Riot Developer API key which you can request at https://developer.riotgames.com/ which you need to put in apikey.txt. 

## Are the passwords encrypted?

TL;DR: Currently not.

The original plan was to add AES256 & SHA256 password encryption using the System.Security.Cryptography import. However as mentioned earlier I lost source code to this project and didn't continue it because of that. 


## Disclaimer

LoLAccManager isn’t endorsed by Riot Games and doesn’t reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc. League of Legends © Riot Games, Inc. We are in no way affiliated with, associated with or endorsed by Riot Games, Inc

##
![UI screenshot](https://i.imgur.com/I8CDcwH.png)
