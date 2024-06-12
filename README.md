# Empower-User-Defined-APIs-Calculator-Exercise

This repository contains the CalculatorAPI automation script.
Prerequisites:

- DataMiner agent 10.4.6+
- An indexing database
- [Postman](https://postman.com/downloads)
- The prerequisites mentioned on the [Empower website](https://empower.skyline.be/sessions.html#prerequisites)
- The [User-Defined API Calculator API tutorial package](https://catalog.dataminer.services/details/25d4f7ae-34de-44f4-86b3-00927325e222) from the catalog.

## 1. Hands-on exercise

The API script is given to you from the catalog package: ‘CalculatorAPI’. Create an API Definition and an API Token and use Postman to test your API. The URL route should be …/api/custom/calculator/add.

## 2. Advanced exercises

The following exercises will not be done during the Empower session but can be done during your own time. The solutions are included in the package under the solution folder in Automation. The ‘solution’ script contains the API script, the ‘CreateDefinitionAndToken’ script can be executed through cube and will create the definition(s) and token(s) for the exercise.

Open the CalculatorAPI automation script in Visual Studio with DIS and use that to adapt/extend the script. You can use the [publish feature in DIS](https://docs.dataminer.services/develop/CICD/Skyline%20Communications/Gerrit%20and%20Jenkins/Automation_scripts_as_a_Visual_Studio_solution.html#uploading-a-script-to-a-dataminer-agent) to publish the script to your DataMiner agent.

### 2.1 Expand API with subtraction API

Our current API can add two numbers together. But we want a new API request ‘calculator/sub’ that can subtract two input numbers from each other.

The difficulty of this exercise is that both APIs, the add and sub API should use the same automation script. Using the ‘ApiTriggerInput’ class, you can differentiate from which route is being used. You should end up with 2 API definitions pointing to the same script.

### 2.2 Only allow GET request method

Our API returns a response based on our request; we therefore only want the GET HTTP method to be used. Change the API script to make sure any request method other than GET gets a 405 status code returned with an appropriate error message.

### 2.3 Use query parameters to pass the two numbers

Instead of using the raw body and splitting it to get the two numbers, change the API script so it expects these to be passed via query parameters. The URL will then have "?a=125&b=250" which would result in 375 when called for the 'add' API.
