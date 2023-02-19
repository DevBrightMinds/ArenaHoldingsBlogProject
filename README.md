# Getting Started

This project is made up of two sections, the back and front end. The backend is in C# and the front end is in React TypeScript.
The backend was written in C# as per request.

The front end was written in React TypeScript for a variety of reasons - see below 

-- Provides state-of-the-art functionality.

-- An excellent choice when looking for an easy-to-use and highly productive JavaScript framework.

-- With React, you can build complex UI interactions that communicate with the server in record time with JavaScript-driven pages.

# DB and Tables setup

I chose the Model first approach, which of course will require an existing DB. 

There's a SQL file named 'SQLQuery1' on the root directory of this project.

Double click the file - it should open Microsft SQL Server Management Studio - (If not already installed, try installing it - if you prefer something else then that's okay).

The 'SQLQuery1' contains logic to build the DB and the tables required including adding mock data for the articles to get you started. It should create a DB named ArenaDB, with tables named Articles and Contacts respectively.

# Backend setup

The Backend is to run first - to get it up and running, locate the 'ArenaBlogAPI.sln' inside the ArenaBlogAPI directory and double click on it.

It should open visual studio, if not already installed, please downloadand install it. You will need it to correctly setup the backend.

Once the project is opened in VS, with all the files, locate the Web.config file and open it - you will need to change the server name on the connection string. You can use Microsft SQL Server Management Studio to locate the server name or VS itself
there's a server explorer on the left side - with available DBs you can get the entire connection string from it. You make a choice which is easier for you.

Once all what we described above is in place, you may now run the project in VS. 

Packages/Libraries used. 

-- Entity framework :- The Entity Framework enables developers to work with data in the form of domain-specific objects and properties, such as customers and customer addresses, without having to concern themselves with the underlying database tables and columns where this data is stored.

-- Cors :- It allows browsers to enforce the same-origin policy. The same-origin policy is a security measure that prevents a malicious script from accessing resources that it should not have access to.

# Front End (Views)

You will need to have NodeJS already installed in your machine, if not get the latest NodeJS online and install it.

The front end contains the views to help you interact with the API you just got running. 

The views are very simple to get running, you need to do the following. 

-- Open the views directory in VS Code or any editor of your choice. 

-- If you open it in VS Code open a new terminal - or have your command prompt open, with the views directory path already activated.

-- Run 'npm install' to install the node modules necessary

-- Run 'npm start' to load the project - it will load on [http://localhost:3000](http://localhost:3000) - it should open the browser automatically, if not go ahead and run http://localhost:3000 on the browser.

Packages/Libraries used. 

-- Redux :- For State management throughout the app 

-- React Router Dom :- For navigation.

-- Bootstrap :- For UI Design 