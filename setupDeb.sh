#https://github.com/lefthandedgoat/canopy/issues/320

wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | sudo apt-key add -
sudo sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list'

sudo apt-get -y --force-yes update

sudo apt-get -y install mono-complete fsharp

sudo apt-get -y install google-chrome-stable

sudo apt-get -y install xvfb