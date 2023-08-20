# Blue-Gravity-Case

All the codes in the project writed by me. But I have used some of my old systems. These are Pipoza package in Assets/3rdParty/Pipoza, UI System and Money System in Assets/GameSystems/. In UI System, just UIManager and UIBase comes from my old projects.

<h3>Pipoza Package</h3>

<p>This package has some basic tools to increase efficiency like KdTree, Singleton, SingletonScriptableObject, Dictionary Serialization and Transform Extensions. We can create <strong>game system folders</strong> and <strong>config files</strong> easily. To create a system config, I am creating a config script first by using script templates. After create the config script, I create the config file from /Create/Pipoza/Config/Config Name. I don't use public or serializefield in scripts to not make inspector complicated. Instead, I store all serializable fields in config window and acces it from script. You can acces to config window from <strong>/Window/Pipoza/Config Window</strong>. Also to create a game system folder -> /Create/Pipoza/Game System Folder and rename it.</p><br>
<img src="https://file.notion.so/f/s/7604c38d-a464-4482-bae1-b2dd79955368/Ekran_Grnts_(93).png?id=2c2915ef-b122-46d2-8b6e-dda6b61d615e&table=block&spaceId=0848242d-647d-49f0-8995-ae847a0fdbca&expirationTimestamp=1692648000000&signature=aKMApl5FA445_Um2GFMvLiepzoycA93VMDNntX2l0jg&downloadName=Ekran+Görüntüsü+%2893%29.png" width=500px></img>

<img src="https://file.notion.so/f/s/d4d05fbe-57c4-4fa1-80a9-85c65c9ca56f/Ekran_Grnts_(75).png?id=8796cb48-690e-404a-895d-dd220867ba5e&table=block&spaceId=0848242d-647d-49f0-8995-ae847a0fdbca&expirationTimestamp=1692648000000&signature=KRWFd_ivlanbEp53obKCNfxLV-OD_Yk4XBcYBFzFXpo&downloadName=Ekran+Görüntüsü+%2875%29.png" width=500px></img>

<h3>Game Systems</h3>
<p>Every game system has own files like scripts, models, textures. This way is like better for me when develop advanced games.</p>

<h3>Character Changes</h3>
<p>Main character was different and more suitable for this theme. But I couldn't find a package with clothes and animations for this type of game. I tried to pay it but itch io only accepts paypal and paypal is not available in Turkey. So I changed the main character. You can see here the old movement video: https://www.youtube.com/watch?v=-nox3KmTRHQ</p><br>

<h3>References</h3>
<p>I don't use serializable fields in inspector and also do not fill fields by drag & drop. You can see in all scripts that fields are readonly and I fill them in setRefs method. When click set refs, all fields becomes assigned.</p>
<img src="https://file.notion.so/f/s/3e853932-db18-4b42-8ee3-f1110f1ba91e/Untitled.png?id=60336e90-d329-4208-ae21-fce6122d989e&table=block&spaceId=0848242d-647d-49f0-8995-ae847a0fdbca&expirationTimestamp=1692648000000&signature=FPfAnUVeVWQevV1pdH9UjZklmmb_-n5feQbVnVN5kWo&downloadName=Untitled.png" width=500px></img>

<img src="https://file.notion.so/f/s/fd1b9296-9fa3-49cc-8df7-5dca00f88abb/Untitled.png?id=a8307dac-9591-4590-9b70-976962d8f314&table=block&spaceId=0848242d-647d-49f0-8995-ae847a0fdbca&expirationTimestamp=1692648000000&signature=lSRKOSiLaIE80c2jdQvzmdgkzshlLhrmOXdBj-p-qGM&downloadName=Untitled.png" width=500px></img>

<h3>About Project</h3>
<p>Our character can move and interact with the world. To move character, just hold w, a, s, d. I writed an inventory system to manage our items. For example, we can equip our armors (outfits), eat our foods etc. Also we can inspect the character outfit in real time here.</p>
<p>To buy new items and outfits, player should go around and find some sellers. Every seller sells different items. If player has money, he can buy any item he want from this sellers. When player close enough to seller, shop panel will be enabled.</p>

<p>Player can sell his items also. Find a seller, open shop and player will see a panel at the right-bottom that includes player's inventory. By clicking this items, player will sell them to seller. When hover on item here, player can see selling prices in a small panel with red text.</p>

<p>After buy items, player will open the inventory panel, and use items. To use items, player can just click on them. For example, if player clicks on the food item, character will eat it. If player clicks on the outfit item, character will equip it.</p>
