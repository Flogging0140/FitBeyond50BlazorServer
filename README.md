
![enter image description here](https://media.discordapp.net/attachments/1113972876425576454/1113973603663347783/image.png?width=1048&height=313)

# FitBeyond50 Blog
[Project here fitbeyond50.ca](https://fitbeyond50.ca/)

## Overview

My dads hobby is fitness blogging. I decided to create a dynamic blogging application on the web, where he could use html to format his posts, then upload and manage them without me. 
Part of this project was expanding my C# skills to Blazor. I am comfortable with C#, this is my first Blazor project, and has been a positive demonstration of my ability to learn. The project took about 6 days to complete. 

_Note: Can take up to 30 seconds to load website._ 

## Highlights

- Hosted on Azure
- Domain name from Rebel
- Continuous deployment from GitHub
- Passwords stored as env variables
- Swear word + emoji filtering on comments
- Pagination
- Upload Blog Posts as HTML5 with inline CSS3
- Using SQL server, FluidAPI with navigation properties
- Users can subscribe to email list
- Share posts via email
- Optimized for mobile 
- Choose to sort posts by created date
- Role based authorization for segregated actions
- Register new accounts (role = "regular user")
- Leave comments on posts
- Author can delete posts, comments
- Optional notifications for subscribers on post release
- Loading animated SVG while awaiting async tasks

![enter image description here](https://media.discordapp.net/attachments/1113972876425576454/1113973779794776075/image.png?width=1048&height=398)

## Video Demo

In this video I walk through the project with brevity, not being to technical. in ~10mins I demonstrate the features of this dynamic web application. _I made video with Kden-Live + Obs._

[![](https://markdown-videos.deta.dev/youtube/8jcfhJ3k63w)](https://youtu.be/8jcfhJ3k63w)

## Learning During Project

Some highlights of what I learned are as follows. I plan to try the Web Assembly version of Blazor next. 

- Blazor Server
	- Authentication, Authorization
	- SPA framework from MS
	- JavaScript interop
	- Components 
	- Event callbacks, communicating from components and parents
	- Email API, did also setup MailKit with same provider, in the end preferred the API
	- Transient, singleton, scoped services

- Versioning
	- Adding migrations
	- Making pull requests
	- Continuous deployment

- Managing DB
	- Adding migrations
	- Fixing migration issues
	- Fluid API
	- Navigation properties in models

- Custom domain and SSL cirt setup from Azure
	> I would get a better representation of code % separation in GitHub
	> Less Space on server
	> Delivery time, CDNs are optimized for delivery time, they are cached closer to geo-loci of hosting server

![enter image description here](https://media.discordapp.net/attachments/1113972876425576454/1113974045466169384/image.png?width=1048&height=592)

## Self Reflection

I know I could improve in some areas, I am noting them because self reflection is critical to growth!

- Using the CDN for SASS rather than local files
	> I would get a better representation of code % separation in GitHub
	> Less Space on server
	> Delivery time, CDNs are optimized for delivery time, they are cached closer to geo-loci of hosting server

- Use Blazor's authentication state manager better, scaffolding identity
	>  HTTP context is a Razor Pages and MVC idea
	> I can use the auth state manager to collect the claims principal and roles from Identity.User 
	> make use of authorized views more
	> During setup I scaffolded the login pages, they were already there, but I didn't have access to modify the colors and remove some of the code. I experimented with selecting already existing layout pages but in the end what worked was to let it generate its own. This is the biggest thing I would like to fix for the next project. 
	
- Testing environment
	>  Regularly I do tests though didn't for this project. It would be more maintainable to have created an xUnit test proj with either a local db as staging server or sqlite in memory db.

- Abstraction
	> Something I will progressively be doing in code cleanup, more abstraction (less repeating code), deleting commented out code, and refactoring for better efficiency. 

![enter image description here](https://media.discordapp.net/attachments/1113972876425576454/1113975176477024296/image.png?width=328&height=629)

# Technologies Used

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sass/sass-original.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/bootstrap/bootstrap-original-wordmark.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain-wordmark.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/azure/azure-original-wordmark.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/github/github-original-wordmark.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/html5/html5-original-wordmark.svg)

![icon](https://cdn.jsdelivr.net/gh/devicons/devicon/icons/git/git-plain-wordmark.svg)
