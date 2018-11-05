# AsyncInn
MVC application for your Hotel management system.

Scaffold
Scaffold out a basic MVC web application using the steps provided from class 11. Include a Home Controller with a basic Index action. No need to add any content to the Index view, just have it load a greeting for now. You will work more on the Home Controller a little further down.

Look in your class repo under class 13 in the resources folder for full scaffold steps to create an MVC web app with a database.

Entities to Models
Using your database schema, convert each entity into a model within your newly created MVC web application.

Following the steps provided, in addition to what we did in class, create a new DbContext named AsyncInnDbContext. Within this DbContext, declare your Database tables and set your composite keys.

Design
Think about the design of your website. What will it look like? What pages will exist? How do the pages interact and link to each other? For our website, we will have the following pages:

Home Page to greet the Hotel Admin. This page will also serve as a dashboard for the other locations of the site.
Hotels page that will allow the admin to create and edit new or existing hotels
Rooms page where the admin will be able to create or edit new or existing rooms
Amenities page that will allow the admin to add to their list of existing amenities
A page where they can link the Amenities to the rooms that currently exist
A page where they can add existing rooms to hotels
Following the design, Create a controller for each of the pages listed above. You may “Add » Controller” on the controllers folder and scaffold out the basic CRUD operations if you wish.

Home Page
Add some html and styling to your home page. Link the index action of each of the other controllers within the Home page. Throughout the week, we will slowly evolve this page to be more of a “dashboard” feel, but start the design now to start the process.

## Explore Depoloyed Website
https://asyncinnn.azurewebsites.net/

## Load Application
in terminal: git clone open in visual studio run project without debugging

## License
This project is licensed under the MIT license.
