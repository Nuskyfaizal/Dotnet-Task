DotNet Task Documentation

Introduction: 

WebAPI application for an Employer Retrieving, Creating and Updating a form data.

Table of Contents:

1. Technologies used
2. Setting up the application
3. Summary
4. Endpoints


1. Technologies used - 

Following technologies have been used to develop the application;
	API -				.Net 8.0
	Database - 		    Azure CosmosDB for NoSQL

2. Setting up the application - 

   Backend;
	- The database connection string should be configured in the appsettings.Development.json file
	- The application runs on port http://localhost:5000


3. Summary - 

The application uses Azure CosmosDB for NoSQL database. For development purposes, I have used CosmosDB emulator. 

ApplicationProgram - This container saves the data from screen 1 and used to retrieve the data to screen 2
CandidateApplication - This container saves the candidate form from screen 2
InformationDetails - This container has Personal Information fields objects. These items will be loaded in the screen 1.
Questions - This container is used to save, edit and retrieve the questions created by the employer
QuestionType - This container has questionType objects (ex: Yes/No, Date, Paragraph)

API uses FluentValidation library for Personal Information form and middleware to handle errors from the validations, when a candidate submits the form.


4. Endpoints

Following sample endpoints are provided for testing puposes

--POST http://localhost:5000/api/Question/AddQuestion

{
  "questionType": "Multiple Choice",
  "question": "Education Levels",
  "maxChoicesAllowed": 5,
  "isOtherEnabled": false,
  "choices": [
    {
      "choice": "Bachelor's"
    },
    {
      "choice": "Diploma"
    },
    {
      "choice": "Secondary School"
    },
    {
      "choice": "Primary School"
    }
  ]
}


--POST http://localhost:5000/api/Application/CreateProgram
{
  "programTitle": "Summer Internship Program",
  "programDescription": "Paid internships for skilled IT professionals",
  "informationDetails": [   
    {
      "informationDetailsId": "1",
      "isInternal": false,
      "isHidden": false
    },
    {
      "informationDetailsId": "2",
      "isInternal": false,
      "isHidden": false
    },
    {
      "informationDetailsId": "3",
      "isInternal": false,
      "isHidden": false
    },
    {
      "informationDetailsId": "4",
      "isInternal": false,
      "isHidden": false
    },
    {
      "informationDetailsId": "5",
      "isInternal": false,
      "isHidden": false
    },
    {
      "informationDetailsId": "6",
      "isInternal": false,
      "isHidden": false
    },
    {
      "informationDetailsId": "7",
      "isInternal": false,
      "isHidden": true
    },
    {
      "informationDetailsId": "8",
      "isInternal": false,
      "isHidden": false
    },
    { 
      "informationDetailsId": "9",
      "isInternal": false,
      "isHidden": false
    }
  ],
  "programQuestions": [
    {
      "questionId": "9e764051-b731-484c-956e-f5a6014f29da"
    }
  ]
}


--POST http://localhost:5000/api/CandidateApplication/SaveCandidateApplication
{
  "programId": "479ce60a-d022-47e3-bc8a-a13681eed255",
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@gmail.com",
  "phone": "5789292021",
  "nationality": "England",
  "currentResidence": "London",
  "idNumber": 098725257,
  "dateOfBirth": "2020-05-16T08:48:11.748Z",
  "gender": "Male",
  "answers": [
    {
      "questionId": "9e764051-b731-484c-956e-f5a6014f29da",
      "answer": [
        "Secondary School", "Diploma"
      ]
    }
  ]
}