canopy Starter Kits allows a quick clone/rename/code approach to getting started with canopy and UI Automation.

On Windows run `build.cmd`

On OSX run `sh build.sh` (on linux, you need to download the chromedriver linux binary and replace the current `chromedriver` file)

For linux I have created a script to take a base install of Ubuntu Server 16.04 and get everything set up.

Just clone and cd to dir then run `sudo sh setupDeb.sh`

Then run `DISPLAY=:1 xvfb-run sh buildLinux.sh` and it should work 'headless'
