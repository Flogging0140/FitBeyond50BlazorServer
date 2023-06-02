![enter image description here](https://media.discordapp.net/attachments/1113972876425576454/1113973603663347783/image.png?width=1048&height=313)

# FitBeyond50 Blog
[project live here fitbeyond50.ca](https://fitbeyond50.ca/)

## Overview

My dad wanted a blog. As practice and just for fun I decided to look into Blazor Server. I spent a bit of time comparing the Web Assembly version and server but chose server for simple DB access. The project took about 6 days to complete. 

## Highlights

- Azure was used to host the app service
- Rebel gave it a unique domain name
- Continuous deployment from GitHub (master) to Azure
- Passwords are stored on server as env variables and not hard coded
- Swear word + emoji filtering on comments
-  Pagination, 3 posts per page
- Upload Blog Posts as HTML5 with inline CSS3
- Data is stored in cloud
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

In this video I walk through the project with brevity, not being to technical. in ~10mins I demonstrate the features of this dynamic web application. 

[![](https://markdown-videos.deta.dev/youtube/8jcfhJ3k63w)](https://youtu.be/8jcfhJ3k63w)

## Learning During Project

Some highlights of what I learned are as follows. This was a great learning experience. I plan to try the Web Assembly version of Blazor next. 

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
