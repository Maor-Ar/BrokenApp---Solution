# Blog App - Fixed! 

Hey! So I fixed this blog app that was having some issues. It's pretty simple - just a basic blog where you can read posts and add new ones. I used Angular for the frontend stuff and .NET Core for the backend api.

## Quick Start 

For the backend:
- go to backend folder
- do `dotnet restore` 
- then `dotnet dev-certs https --trust` (for https stuff)
- and finally `dotnet run --launch-profile https`
- it'll be at https://localhost:7206

For the frontend:
- go to frontend/blog-app
- run `npm install` 
- then `ng serve`
- check it out at http://localhost:4200

## What I Fixed 

Backend stuff:
* Fixed that annoying CORS error (finally!)
* Got HTTPS working (more secure now)
* Made the error messages actually helpful
* Added some validation - no more empty posts!
* Added Swagger docs (check https://localhost:7206/swagger if you're curious)

Frontend stuff:
* Updated to use HTTPS 
* Better error handling
* Form validation works now
* Fixed some cleanup issues
* updated the style of the UI to not be so ugly

Also cleaned up the code a bit:
- removed duplicate stuff
- made errors more consistent
- added some docs
- made it easier to read (I hope!)

## Tech Details 

Backend is using:
- ASP.NET Core
- Swagger
- Just storing stuff in memory for now

Frontend has:
- Angular 16
- TypeScript
- Forms
- HTTP stuff for api calls

## Good to know 

- Data disappears when you restart (it's just in memory)
- HTTPS works in development
- CORS is fixed (frontend and backend talk to each other now)
- Forms check for errors
- Added some error handling so you know when something breaks

## Limitations 

Just so you know:
- Data isn't permanent (resets on restart)
- Just basic features for now
- No user accounts or anything fancy

That's pretty much it! Let me know if anything breaks again! 
