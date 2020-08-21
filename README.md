**<h1 align = "center"> Animal Shelter**


**<h2 align="center">"Please Adopt Today!"**


**<h4 align = "center">
  <a href="#requirements">Requirements</a> •
  <a href="#setup">Setup</a> •
  <a href="#protecting-your-data">Protecting Data<a> •
  <a href="#questions-and-concerns">Q's & C's</a> •
  <a href="#technologies-used">Technologies</a> •
  <a href="#bugs">Bugs</a> •  
  <a href="#contributors">Contributors</a> •
  <a href="#license">License</a>**

<br>
<h2 align = "center">
</h1>

**ABOUT**

The back end of an application that builds out an API for different animals in and animal shelter. The functionality implimented uses Tokenization. 

**ANIMALS**

Access information on Animals up for adoption.

**HTTP Request**

  ```js 
  GET /api/animal
  POST /api/animal
  GET /api/animal/{id}
  PUT /api/animal/{id}
  DELETE /api/animal/{id}
  
  ```

  **PATH PARAMETERS**

  | Parameters        | Type           | Default  | Description |
  | ------------- |:-------------:| -----:| -------------:|
  | Species      | string| null | Return matches by species. |
  | Breed      | string      |   null | Return matches by breed. |
  | Name | string     |   null | Return matches by name. |
  | Age | int      |    0 | Return matches by age. |

  <br>


## **REQUIREMENTS**

* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

<br>

## **SETUP**

* _Install and configure MySQL_
  1. _This program utilizes MySQL Community Server version 8.0.15 and requires [this to be pre-installed](https://dev.mysql.com/downloads/file/?id=484914). Click the link at the bottom that reads "No thanks, just start my download"_
  2. _Use Legacy Password Encryption and set password to "epicodus"_
  3. _Click "Finish_

copy this url to clone this project to your local system:
```html
https://github.com/aesadin/AnimalShelter.Solution.git
```

<br>

Once copied, select "Clone Repository" from within VSCode & paste the copied link as shown in the image below.

![cloning](https://coding-assets.s3-us-west-2.amazonaws.com/img/clone-github2.gif "Cloning from Github within VSCode")

<br>

* _Install the MySQL database_
  1. _Open a new terminal in your text editor (Ctrl+\` in V.S. Code) and run command `> echo 'export PATH="$PATH:/usr/local/mysql/bin"' >> ~/.zprofile`_
  2. _Enter the command `> source ~/.zprofile` to confirm MsSQL has been installed_
  3. _Connect to MySQL by running the command `> mysql -uroot -pepicodus`_
  4. _Install the necessary MySQL database by copying the code block from the .sql file and entering it into your terminal OR import the 'allison_sadin.sql' file included in the repo to MySQL workbench_
    * To import the allison_sadin.sql file to your workbench, save this file to your computer
    * Open MySQL Workbench and click the second icon from the left at the top of the window. It is labeled, "open a SQL script file in a new query tab".
    * Then select from your file directory the allison_sadin.sql file.
  5. _Once the following code block has been entered you will close MySQL by running the command `> exit`_

  <br>

  * _Running Migration_
    1. _To create the initial migration folder run the following command in the terminal after navigating into `> cd Factory` _

    ```js 
    dotnet ef migrations add Initial 
    ```
    2. _Then run the following command next_

    ```js
    dotnet ef database update
    ```

    3. _To make sure this migration successfully created a database, open MySQL workbench and refresh to see if the database allison_sadin is listed in the schemas_
    4. _Anytime a change is intended to be made to the database, both migration commands must be run, however a different title must be given other than "Initial" that includes a short description. An example is given below._

     ```js 
    dotnet ef migrations add LocationTable 
    ```
    


<br>

* _Run the application_
  1. _In the terminal, navigate to the project directory by running the command `> cd Factory`_
  2. _Now that we are in the Sneuss directory you will run the command `> dotnet restore`_
  3. _Once the "obj" folder has initialized you will run the command `> dotnet run`_
  

![cloning](https://coding-assets.s3-us-west-2.amazonaws.com/img/dotnet-readme.gif "How to clone repo")

<br>

* _Using the JSON Web Token_
<br>
To gain authorization to use the POST, PUT and DELETE functionality of the API, you must first aunthenticate yourself through Postman.
<br>
  1. _Open Postman and creat a POST request by using the dropdown menu to the left of the 'Send' button. Then in the type box enter the following URL _
   ```js 
    http://localhost:5001/users/authenticate
    ```
  2. _Then select 'Body' and below that click the button for 'raw' and using the dropdown menu to the right, select 'JSON'. Then enter the following query into the Body tab and hit send_
  ```js 
    {
    "username": "test",
    "password": "test"
    }
    ```
  3. _The token will be generated in the response box below. Copy and paste the given token and enter it as the token parameter in the Authorization tab_
  4. __


## **PROTECTING YOUR DATA**

#### **Step 1: From within VSCode in the root project directory, we will create a .gitignore file**

# For Mac Users
```js 
touch .gitignore 
```

# For Windows Users:

```js 
ni .gitignore 
```

#### Step 2: commit that .gitignore file (this prevents your sensitive information from being shown to others). **⚠️DO NOT PROCEED UNTIL YOU DO!⚠️**

![setup](https://coding-assets.s3-us-west-2.amazonaws.com/img/entity-readme-image.png "Set up instructions")

#### Step 3: **To commit your .gitignore file enter the following commands**

```js
git add .gitignore
```
```js
git commit -m "protect data"
```

#### Step 4: **Then, you need to update your username and password in the appsettings.json file.**

_by default these are set to user:root and an empty password. if you are unsure, refer to the settings for your MySqlWorkbench._

![appsettings](https://coding-assets.s3-us-west-2.amazonaws.com/img/app-settings.png)

<br>

## **QUESTIONS AND CONCERNS**

_Questions, comments and concerns can be directed to the author Allison Sadin aesadin@gmail.com_

<br>

## **Technologies Used**

_**Written in:** [Visual Studio Code](https://code.visualstudio.com/)_

_**Image work:** [Adobe Photoshop](https://www.adobe.com/products/photoshop.html/)_

_**Database Mgmt:** [MySql Workbench](https://www.mysql.com/products/workbench/)_

_**Language:** [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)_

<br>


## **Known Bugs**

_**No known bugs**_

<br>


## **Contributors**


[<img src="https://coding-assets.s3-us-west-2.amazonaws.com/linked-in-images/allison-sadin.jpg" width="160px;"/><br /><sub><b>Allison Sadin</b></sub>](https://www.linkedin.com/in/allison-sadin-pdx/)<br /> 


<br>

## **License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2020 **_Allison Sadin_**