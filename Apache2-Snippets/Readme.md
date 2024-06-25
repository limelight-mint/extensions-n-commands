### Navigation:
<hr></hr>

1. [C#/.NET Console/WebApp example](https://github.com/limelight-mint/extensions-n-commands/tree/main/Apache2-Snippets#how-to-create-a-web-api-console-app-or-any-other-app-that-is-self-maintanable-net-example)
- [How to run C#/.NET Console/WebApp forever](https://github.com/limelight-mint/extensions-n-commands/tree/main/Apache2-Snippets#how-to-make-web-app-self-restart-on-crash-and-self-boot-even-when-console-is-closed-1)
2. [NODE/.JS Console/WebApp example](https://github.com/limelight-mint/extensions-n-commands/tree/main/Apache2-Snippets#how-to-create-a-web-api-console-app-or-any-other-app-that-is-self-maintanable-js-example)
- [How to Run NODE/.JS Console/WebApp forever](https://github.com/limelight-mint/extensions-n-commands/tree/main/Apache2-Snippets#how-to-make-web-app-self-restart-on-crash-and-self-boot-even-when-console-is-closed)

<hr></hr>
<br></br><br></br>


### How to create a WEB-API Console App or any other app that is self maintanable (.JS EXAMPLE)
So, you just bought a Linux-based server, what to do next?:
> Log in to your Linux machine by console (at least i do it that way, if u r a rich kid u probably have an entire screen whats goin on, i dont):
```
ssh root@121.0.0.0
```
> Instead of 121.0.0.0 paste your machine IP, it will ask permission type Yes or just straight asks a root password and only u should know it tbh, once you logged in, update packages:
> if u r cool and hansome add to all commands `sudo` at the beginning 😎
```
apt-get update
```
> Once updated, download NPM and NODE or whatever u wanna host lib (it might say u dumb and it doesnt exist, just google a right version or a bundle u want, cause it might have weird name like dotnet-sdk-7.34.43.252.4.14 which is cringe, but just keep it in mind)
```
apt-get install node
apt-get install npm
```
> Navigate to your app directory (mine is root/var/tgbot)
```
cd /
cd /var/tgbot
```
> Run Node
```
node index.js
```

### How to make WEB APP self-restart on crash and self-boot even when console is closed?:

> Install forever
```
npm install forever -g
```
> Start process as forever (you should be in your app directory)
```
forever start index.js
```

> To kill the process i use this to make sure kill all the nodes (but it will, ofc, kill everything so u can get ID of forever process and kill it by id)
```
killall node
```

### How to create a WEB-API Console App or any other app that is self maintanable (.NET EXAMPLE)

So, you just bought a Linux-based server, what to do next?:
> Log in to your Linux machine by console (at least i do it that way, if u r a rich kid u probably have an entire screen whats goin on, i dont):
```
ssh root@121.0.0.0
```
> Instead of 121.0.0.0 paste your machine IP, it will ask permission type Yes or just straight asks a root password and only u should know it tbh, once you logged in, update packages:
> if u r cool and hansome add to all commands `sudo` at the beginning 😎
```
apt-get update
```
> Once updated, download dotnet or whatever u wanna host lib (it might say u dumb and it doesnt exist, just google a right version or a bundle u want, cause it might have weird name like dotnet-sdk-7.34.43.252.4.14 which is cringe, but just keep it in mind)
```
apt-get install dotnet-sdk-6.0
```
> Install Apache2 server:
```
apt-get install apache2
```
> Now, you can check if all is ok by going to your 121.0.0.0 ip, it should popup with Apache2 default page, they are stored in root/etc/apache2/sites-avaliable (or sites-enabled if this site is enabled and displayed), to remove that use:
```
a2dissite 000-default
a2dissite default
```

> NOW, THIS IS IMPORTANT, this command u will use like 99% of the time whenever u add a file, remove a file, eat, breath, etc. RELOAD APACHE2:
```
systemctl reload apache2
```
> If now your site isnt loading - thats great, now you can create your configuration, to be clear: site and service.
> Now the hardest part, in sites-avaliable create your own `.conf` file with name of your own app configuration (it is case sensitive and need to matched with our future service, remember that!). I will create a discord bot in this example so ill name it `bot.conf` and will use port `8801` so my text inside `bot.conf` will be:
```
<VirtualHost *:80>
	ServerName 121.121.121.121
	DocumentRoot /var/www/html

	ProxyPreserveHost On
	ProxyPass / http://127.0.0.1:8801/
	ProxyPassReverse / http://127.0.0.1:8801/
</VirtualHost>
```
> ServerName here is a domain (your actual public ip or domain name) and :80 is a port avaliable. Additonally u might want to set in /etc/apache2/ports.conf a line with `Listen 80` to listen that port if you dont have it already (or your port, if u didnt set 80 as i did)
> Now lets enable our new configuration and reload apache2 just to make sure (remember, i use `bot` but your app could be called `WhAtEvEr`):
```
a2ensite bot
systemctl reload apache2
```
> It will probably show errors, lets enable reverse proxy and restart:
```
a2enmod proxy
a2enmod proxy_http
a2enmod proxy_balancer
a2enmod lbmethod_byrequests
systemctl reload apache2
```
> IMPORTANT, TO ACTUALLY PROFILE UR APACHE2 AND SEE WHATS GOIN ON Lets check our status, you will def use this command also 99% of the time something is wrong:
```
systemctl status apache2
```
> If that shows some stupid error like your socket is already in use (WHY THE FCK IS MY SOCKET IN USE IF I JUST STARTED MY APP?) or some cringe stuff, to deep profiling use:
```
journalctl -xeu apache2.service
```
> If that cringe server is still bitching up, give that man a `sudo medicine`:
```
sudo service apache2 restart
```
> Run your app:
```
cd /your_folder/ where you loaded your app by FTP client
dotnet bot.dll (or YourApp.dll)
```
> If you want this app to be all time up not only when u see this console (cause the moment u close it app is closed too), scroll down to the next section

<br></br>

### How to make WEB APP self-restart on crash and self-boot even when console is closed?:

> So, youve made an app, but the moment you close the console it just stops? No worries, lets move to `root/etc/systemd/system/` now create `YourProject.service` file, im using a discord bot so ill name mine `bot.service`, REMEMBER! THIS IS REALLY IMPORTANT! it should match your name in `root/etc/apache2/sites-avaliable` directory, i already have `bot.conf` there, if u dont have `YourProject.conf` there, scroll up and start again. Anyway, the text inside my file called `bot.service` will be:
```
[Unit]
Description=Example .NET Web API App for Discord Bot Limelight Mint Eremite running on Ubuntu

[Service]
WorkingDirectory=/var/discordbot/eremite
ExecStart=/usr/bin/dotnet /var/discordbot/eremite/eremite.dll
Restart=always
# Restart service after 10 seconds if the dotnet service crashes:
RestartSec=10
SyslogIdentifier=eremite-logger
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Development

[Install]
WantedBy=multi-user.target
```
> Where `WorkingDirectory` is your app directory, `ExecStart` is direct dll to your app. Now lets enable it:
```
systemctl enable bot.service
```
> Start the service and check if its running:
```
systemctl start bot.service
systemctl status bot.service
```
> Again, i used `bot.service` cause i had my discord bot configuration as `bot.conf`, u might have different name
